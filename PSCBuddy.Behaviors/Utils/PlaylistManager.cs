using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using PSCBuddy.Behaviors.JsonModels;

namespace PSCBuddy.Behaviors.Utils
{
  public class PlaylistManager
  {
    public bool TryUpdatePlaylist(string driveRoot, string playlistName, IEnumerable<string> gamePaths,
      string corePath = "DETECT", string coreName = "DETECT", bool overwrite = false, string readableNameXml = null)
    {
      var nameLookup = readableNameXml != null
        ? GetReadableNameDictionary(readableNameXml)
        : new Dictionary<string, string>();
      if (!driveRoot.EndsWith("\\"))
      {
        driveRoot += "\\";
      }
      var playlistDirectory = Path.Combine(driveRoot, @"bleemsync\opt\retroarch\.config\retroarch\playlists");
      if (!Directory.Exists(playlistDirectory))
      {
        return false;
      }

      var playlistPath = Path.Combine(playlistDirectory, playlistName + ".lpl");
      PlaylistJson json;

      if (File.Exists(playlistPath) && !overwrite)
      {
        json = JsonConvert.DeserializeObject<PlaylistJson>(File.ReadAllText(playlistPath));
      }
      else
      {
        json = new PlaylistJson
        {
          version = "1.0",
          items = new List<PlaylistItemJson>(),
        };
      }

      foreach (var gamePath in gamePaths)
      {
        var cleanFileName = Path.GetFileNameWithoutExtension(gamePath);
        if (cleanFileName == null)
        {
          throw new InvalidOperationException("Passed file with no name (?)");
        }
        var item = new PlaylistItemJson
        {
          core_name = coreName,
          core_path = corePath,
          db_name = $"{playlistName}.lpl",
          label = nameLookup.TryGetValue(cleanFileName, out var title) ? title : cleanFileName,
          path = this.ConvertPath(gamePath),
          crc32 = "DETECT",
        };

        json.items.Add(item);
      }

      json.items = json.items.OrderBy(i => i.label).ToList();

      // Important:  can't handle CRLF
      var jsonText = JsonConvert.SerializeObject(json, Formatting.Indented).Replace(Environment.NewLine, "\n");

      File.WriteAllText(playlistPath, jsonText);

      return true;
    }

    private static Dictionary<string, string> GetReadableNameDictionary(string xml)
    {
      var xdoc = XDocument.Parse(xml);
      if (xdoc.Root == null)
      {
        throw new Exception("Bad XML");
      }
      var ns = xdoc.Root.GetDefaultNamespace();
      var nameDesc = xdoc.Root.Descendants(ns + "game");
      var results = nameDesc.Select(nd => new
        {name = nd.Attribute(ns + "name").Value, description = nd.Descendants(ns + "description").Single().Value});
      return results.ToDictionary(x => x.name, x => x.description);
    }

    private string ConvertPath(string originalPath)
    {
      var sb = new StringBuilder("/media");
      var i = 0;
      foreach (var character in originalPath)
      {
        if (i++ < 2)
        {
          continue;
        }

        sb.Append(character == '\\' ? '/' : character);
      }

      return sb.ToString();
    }
  }
}
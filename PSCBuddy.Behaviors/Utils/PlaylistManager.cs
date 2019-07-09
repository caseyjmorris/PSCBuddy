using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PSCBuddy.Behaviors.JsonModels;

namespace PSCBuddy.Behaviors.Utils
{
  public class PlaylistManager
  {
    public bool TryUpdatePlaylist(string driveRoot, string playlistName, IEnumerable<string> gamePaths,
      string corePath = "DETECT", string coreName = "DETECT", bool overwrite = false)
    {
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
        var item = new PlaylistItemJson
        {
          core_name = coreName,
          core_path = corePath,
          db_name = $"{playlistName}.lpl",
          label = Path.GetFileNameWithoutExtension(gamePath),
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
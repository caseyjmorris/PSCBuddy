﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PSCBuddy.Behaviors.Utils
{
  public class PSXUtil
  {
    public string ArchiveToCHD(string chdmanPath, string sevenZPath, string archivePath, bool forceCueCreate,
      string targetDirectory, bool cleanup)
    {
      if (!Directory.Exists(targetDirectory))
      {
        throw new ArgumentException("Directory does not exist", nameof(targetDirectory));
      }
      var unzipped = this.Extract7zArchive(sevenZPath, archivePath);

      var cueCandidates = this.FindCueFiles(unzipped).ToArray();
      var cueFile = string.Empty;
      var binFiles =
        Directory.GetFiles(unzipped).Where(f => Path.GetExtension(f).ToLowerInvariant() == ".bin").ToArray();
      if (!binFiles.Any())
      {
        throw new Exception("no bin files found");
      }

      if (cueCandidates.Any() && !forceCueCreate)
      {
        cueFile = cueCandidates.First();
      }
      else if (cueCandidates.Any())
      {
        foreach (var cueCandidate in cueCandidates)
        {
          File.Delete(cueCandidate);
        }
        cueCandidates = Array.Empty<string>();
      }

      if (!cueCandidates.Any())
      {
        var cueFileText = this.GetPSXCueSheet(binFiles);
        cueFile = Path.Combine(unzipped, GetScrubbedFileName(binFiles[0]) + ".cue");
        File.WriteAllText(cueFile, cueFileText);
      }

      var chdLoc = this.MakeCHD(chdmanPath, cueFile);
      var targetLoc = Path.Combine(targetDirectory, Path.GetFileName(chdLoc));

      File.Move(chdLoc, targetLoc);

      if (cleanup)
      {
        Directory.Delete(unzipped, true);
      }

      return targetLoc;
    }

    private IEnumerable<string> FindCueFiles(string path)
      =>
        Directory.GetFiles(path).Where(f => Path.GetExtension(f).ToLowerInvariant() == ".cue");


    private string GetPSXCueSheet(IList<string> tracks)
    {
      if (tracks.Count == 0)
      {
        throw new ArgumentException("No tracks", nameof(tracks));
      }
      /* 
      Sample
        FILE "Primal Rage (USA) (Track 04).bin" BINARY
          TRACK 01 MODE2/2352
            INDEX 01 00:00:00
        FILE "Primal Rage (USA) (Track 05).bin" BINARY
          TRACK 02 AUDIO
            INDEX 00 00:00:00
            INDEX 01 00:02:00
        FILE "Primal Rage (USA) (Track 06).bin" BINARY
          TRACK 03 AUDIO
            INDEX 00 00:00:00
            INDEX 01 00:02:00
      */

      var sb = new StringBuilder();
      for (var i = 0; i < tracks.Count; i++)
      {
        if (tracks[i].Contains('"'))
        {
          throw new ArgumentException("Track name cannot contain quotation mark", nameof(tracks));
        }
        if (i == 0)
        {
          sb.AppendLine($"FILE \"{tracks[0]}\" BINARY")
            .AppendLine("  TRACK 01 MODE2/2352")
            .AppendLine("    INDEX 01 00:00:00");
        }

        else
        {
          sb.AppendLine($"FILE \"{tracks[i]}\" BINARY")
            .AppendLine($"  TRACK {i:D2} AUDIO")
            .AppendLine("    INDEX 00 00:00:00")
            .AppendLine("    INDEX 01 00:02:00");
        }
      }

      return sb.ToString();
    }

    private string Extract7zArchive(string executablePath, string archivePath)
    {
      if (!File.Exists(executablePath))
      {
        throw new ArgumentException("Exec not found", nameof(executablePath));
      }
      if (!File.Exists(archivePath))
      {
        throw new ArgumentException("Archive not found", nameof(archivePath));
      }
      if (Path.GetExtension(archivePath)?.ToLowerInvariant() != ".7z")
      {
        throw new ArgumentException("Not a 7z archive", nameof(archivePath));
      }

      var wd = Path.GetDirectoryName(archivePath);
      var fileName = Path.GetFileName(archivePath) ?? "";
      var escapedFileName = fileName.Replace("\"", "\\\"");
      var clean =
        GetScrubbedFileName(archivePath);

      if (clean.Length == 0)
      {
        clean = "TARGET";
      }

      Debug.Assert(wd != null, "wd != null");

      var psi = new ProcessStartInfo
      {
        WorkingDirectory = wd,
        FileName = executablePath,
        WindowStyle = ProcessWindowStyle.Hidden,
        Arguments = $"e {escapedFileName} -o{clean}"
      };

      var process = Process.Start(psi);
      process?.WaitForExit();

      if (!Directory.Exists(Path.Combine(wd, clean)))
      {
        throw new Exception("Extract failed");
      }

      return clean;
    }

    private string MakeCHD(string chdmanPath, string cuePath)
    {
      if (!File.Exists(chdmanPath))
      {
        throw new ArgumentException("Can't find chdman", nameof(chdmanPath));
      }
      if (!File.Exists(cuePath))
      {
        throw new ArgumentException("Can't find cue", nameof(cuePath));
      }

      var wd = Path.GetDirectoryName(cuePath);
      var chdFile = GetScrubbedFileName(cuePath) + ".chd";

      Debug.Assert(wd != null, "wd != null");

      var psi = new ProcessStartInfo
      {
        WorkingDirectory = wd,
        FileName = chdmanPath,
        WindowStyle = ProcessWindowStyle.Hidden,
        Arguments = $"createcd -i \"{cuePath}\" -o \"{chdFile}\"",
      };

      var process = Process.Start(psi);
      process?.WaitForExit();
      var fullpath = Path.Combine(wd, chdFile);

      if (!File.Exists(fullpath))
      {
        throw new Exception("CHD creation failed");
      }

      return fullpath;
    }

    private static string GetScrubbedFileName(string filePath) => new string(
      Path.GetFileNameWithoutExtension(filePath)?.Select(c => char.IsLetterOrDigit(c) ? c : '_').ToArray());
  }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PSCBuddy.Behaviors.Utils.Systems;

namespace PSCBuddy.Behaviors.Utils
{
  public class GameInstallCoordinator
  {
    private readonly IPlaylistManager playlistManager;
    private readonly ISystem system;

    public GameInstallCoordinator(IPlaylistManager playlistManager, ISystem system)
    {
      this.system = system;
      this.playlistManager = playlistManager;
    }

    public string ArchiveToCHD(string chdmanPath, string sevenZPath, string archivePath, bool forceCueCreate,
      string targetDirectory, bool cleanup, Action<string> logConsoleOutput)
    {
      if (!Directory.Exists(targetDirectory))
      {
        throw new ArgumentException("Directory does not exist", nameof(targetDirectory));
      }
      var discs = archivePath.Split(';').Where(n => !string.IsNullOrWhiteSpace(n)).ToList();

      if (discs.Count == 0 || discs.Any(d => !File.Exists(d)))
      {
        throw new FileNotFoundException("Couldn't find file");
      }

      var discLocations =
        discs.Select(
          d =>
            this.ArchiveIndividualDiscToCHD(chdmanPath, sevenZPath, d, forceCueCreate, targetDirectory, cleanup,
              logConsoleOutput));

      var playlistName = targetDirectory.Split('\\').Last();
      var driveLetter = targetDirectory.Split(':').First() + ":\\";

      if (discs.Count > 1)
      {
        string m3uName;
        var m3uText = M3UBuilder.GetM3UText(discLocations, out m3uName);
        var m3uTarget = Path.Combine(targetDirectory, m3uName);
        File.WriteAllText(m3uTarget, m3uText);
        this.playlistManager.TryUpdatePlaylist(driveLetter, playlistName, new[] {m3uTarget},
          this.system.CoreLocation, this.system.CoreName);
        return m3uTarget;
      }
      else
      {
        var disc = discLocations.Single();
        this.playlistManager.TryUpdatePlaylist(driveLetter, playlistName, new[] {disc},
          this.system.CoreLocation, this.system.CoreName);
        return disc;
      }
    }

    private string ArchiveIndividualDiscToCHD(string chdmanPath, string sevenZPath, string archivePath,
      bool forceCueCreate,
      string targetDirectory, bool cleanup, Action<string> logConsoleOutput)
    {
      var unzipped = this.Extract7zArchive(sevenZPath, archivePath, logConsoleOutput);

      var cueCandidates = this.FindCueFiles(unzipped).ToArray();
      var cueFile = string.Empty;
      var binFiles =
        Directory.GetFiles(unzipped).Where(f =>
            Path.GetExtension(f).ToLowerInvariant() == ".bin" || Path.GetExtension(f).ToLowerInvariant() == ".iso")
          .ToArray();
      if (!binFiles.Any())
      {
        throw new Exception("No bin or iso files found");
      }

      var canonicalName = Regex.Replace(Path.GetFileNameWithoutExtension(binFiles.First()), @"\s*\(Track \d+\)\s*$",
        string.Empty).Replace("_", " ") + ".chd";

      var forceCueRewritableSystem = this.system as IForceCueRewritableSystem;

      if (cueCandidates.Any() && (!forceCueCreate || forceCueRewritableSystem == null))
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

      if (!cueCandidates.Any() && forceCueRewritableSystem != null)
      {
        var cueFileText = forceCueRewritableSystem.GetPlaylistText(binFiles);
        cueFile = Path.Combine(unzipped, GetScrubbedFileName(binFiles[0]) + ".cue");
        File.WriteAllText(cueFile, cueFileText);
      }
      else if (!cueCandidates.Any() && forceCueRewritableSystem == null)
      {
        throw new Exception("No CUE file found!");
      }

      var chdLoc = this.MakeCHD(chdmanPath, cueFile, logConsoleOutput);
      var targetLoc = Path.Combine(targetDirectory, canonicalName);

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

    private string Extract7zArchive(string executablePath, string archivePath, Action<string> logConsoleOutput)
    {
      if (!File.Exists(executablePath))
      {
        throw new ArgumentException("Exec not found", nameof(executablePath));
      }
      if (!File.Exists(archivePath))
      {
        throw new ArgumentException("Archive not found", nameof(archivePath));
      }

      var ext = Path.GetExtension(archivePath)?.ToLowerInvariant();
      if (ext != ".7z" && ext != ".zip" && ext !=".rar")
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
        Arguments = $"e \"{escapedFileName}\" -o{clean}",
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        UseShellExecute = false,
      };

      var process = Process.Start(psi);
      process.OutputDataReceived += (sender, args) => logConsoleOutput(args.Data);
      process.ErrorDataReceived += (sender, args) => logConsoleOutput(args.Data);
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();
      process.WaitForExit();

      if (!Directory.Exists(Path.Combine(wd, clean)))
      {
        throw new Exception("Extract failed");
      }

      return Path.Combine(wd, clean);
    }

    private string MakeCHD(string chdmanPath, string cuePath, Action<string> logConsoleOutput)
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
      var fullpath = Path.Combine(wd, chdFile);
      var cueFile = Path.GetFileName(cuePath);

      Debug.Assert(wd != null, "wd != null");

      var psi = new ProcessStartInfo
      {
        WorkingDirectory = wd,
        FileName = chdmanPath,
        WindowStyle = ProcessWindowStyle.Hidden,
        Arguments = $"createcd -i \"{cueFile}\" -o \"{chdFile}\"",
        UseShellExecute = false,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
      };

      var process = Process.Start(psi);
      process.OutputDataReceived += (sender, args) => logConsoleOutput(args.Data);
      process.ErrorDataReceived += (sender, args) => logConsoleOutput(args.Data);
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();
      process.WaitForExit();


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
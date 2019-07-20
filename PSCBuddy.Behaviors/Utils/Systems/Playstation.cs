using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSCBuddy.Behaviors.Utils.Systems
{
  public class Playstation : IForceCueRewritableSystem
  {
    private static readonly Lazy<Playstation> InternalInstance = new Lazy<Playstation>(() => new Playstation());
    public static Playstation Instance => InternalInstance.Value;

    private Playstation()
    {
    }

    public string CoreName => "PCSX ReARMed";

    public string CoreLocation => "/media/bleemsync/opt/retroarch/.config/retroarch/cores/pcsx_rearmed_libretro.so";

    public string GetPlaylistText(IList<string> tracks)
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
            .AppendLine($"  TRACK {i + 1:D2} AUDIO")
            .AppendLine("    INDEX 00 00:00:00")
            .AppendLine("    INDEX 01 00:02:00");
        }
      }

      return sb.ToString();
    }
  }
}
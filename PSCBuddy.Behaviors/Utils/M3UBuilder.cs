using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PSCBuddy.Behaviors.Utils
{
  public static class M3UBuilder
  {
    public static string GetM3UText(IEnumerable<string> discs, out string suggestedFilename)
    {
      var filenames = discs.Select(Path.GetFileName).ToList();
      suggestedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(filenames.First()), @"\s*\(Disc \d+\)\s*$",
        string.Empty) + ".m3u";
      return string.Join("\n", filenames);
    }
  }
}
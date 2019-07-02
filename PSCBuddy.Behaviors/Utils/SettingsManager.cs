using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.Behaviors.Utils
{
  public class SettingsManager
  {
    private static string ProgramDirectory =
      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PSCBuddy");

    private static string PSXCHDSettings = Path.Combine(ProgramDirectory, "psxchdarchive.json");

    public void SavePSXArchiveCHDSettings(IArchiveCHDConversionView view)
    {
      var settings = new ArchiveCHDConversionSettingsStore();
      view.CopyTo(settings);
      var json = JsonConvert.SerializeObject(settings);
      Directory.CreateDirectory(ProgramDirectory);
      File.WriteAllText(PSXCHDSettings, json);
    }

    public void LoadPSXArchiveCHDSettings(IArchiveCHDConversionView view)
    {
      if (File.Exists(PSXCHDSettings))
      {
        var json = File.ReadAllText(PSXCHDSettings);
        var settings = JsonConvert.DeserializeObject<ArchiveCHDConversionSettingsStore>(json);
        settings.CopyTo(view);
      }
    }
  }
}
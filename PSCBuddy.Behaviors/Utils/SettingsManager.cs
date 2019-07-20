using System;
using System.IO;
using Newtonsoft.Json;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.Behaviors.Utils
{
  public static class SettingsManager
  {
    private static string ProgramDirectory =
      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PSCBuddy");

    public static void SaveArchiveChdSettings(IArchiveCHDConversionView view)
    {
      var settings = new ArchiveCHDConversionSettingsStore();
      view.CopyTo(settings);
      var json = JsonConvert.SerializeObject(settings);
      Directory.CreateDirectory(ProgramDirectory);
      var path = Path.Combine(ProgramDirectory, view.SelectedSystem.SettingsFileName);
      File.WriteAllText(path, json);
    }

    public static void LoadArchiveChdSettings(IArchiveCHDConversionView view)
    {
      var path = Path.Combine(ProgramDirectory, view.SelectedSystem.SettingsFileName);
      if (File.Exists(path))
      {
        var json = File.ReadAllText(path);
        var settings = JsonConvert.DeserializeObject<ArchiveCHDConversionSettingsStore>(json);
        settings.CopyTo(view);
      }
    }
  }
}
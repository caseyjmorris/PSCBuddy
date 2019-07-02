namespace PSCBuddy.Behaviors.Views
{
  public interface IArchiveCHDConversionSettings
  {
    string CHDManPath { get; set; }
    string SevenZPath { get; set; }
    string ArchivePath { get; set; }
    bool ForceCueCreate { get; set; }
    string TargetDirectory { get; set; }
    bool Cleanup { get; set; }
  }

  public class ArchiveCHDConversionSettingsStore : IArchiveCHDConversionSettings
  {
    public string CHDManPath { get; set; }
    public string SevenZPath { get; set; }
    public string ArchivePath { get; set; }
    public bool ForceCueCreate { get; set; }
    public string TargetDirectory { get; set; }
    public bool Cleanup { get; set; }
  }

  public static class ArchiveCHDConversionSettingsExtension
  {
    public static void CopyTo(this IArchiveCHDConversionSettings from, IArchiveCHDConversionSettings to)
    {
      to.CHDManPath = from.CHDManPath;
      to.ArchivePath = from.ArchivePath;
      to.Cleanup = from.Cleanup;
      to.ForceCueCreate = from.ForceCueCreate;
      to.SevenZPath = from.SevenZPath;
      to.TargetDirectory = from.TargetDirectory;
    }
  }


  public interface IArchiveCHDConversionView : IArchiveCHDConversionSettings
  {
    void ToggleControls(bool enabled);
    void ToggleProgress(bool inProgress);
    void ShowMessage(string message);
    void ShowError(string error);
    bool IsValid { get; }
    void LogConsole(string message);
  }
}
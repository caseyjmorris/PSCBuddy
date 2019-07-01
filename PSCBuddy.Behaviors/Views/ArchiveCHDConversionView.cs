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

  public interface IArchiveCHDConversionView : IArchiveCHDConversionSettings
  {
    void SaveScreen();
    void LoadScreen();
    void ToggleControls(bool enabled);
    void ToggleProgress(bool inProgress);
    void ShowMessage(string message);
    void ShowError(string error);
    bool IsValid { get; }
  }
}
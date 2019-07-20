using System;
using System.Diagnostics;
using System.IO;
using PSCBuddy.Behaviors.Utils;
using PSCBuddy.Behaviors.Utils.Systems;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.Behaviors.Presenters
{
  public class ArchiveCHDConversionPresenter
  {
    private readonly IArchiveCHDConversionView view;

    public ArchiveCHDConversionPresenter(IArchiveCHDConversionView view)
    {
      this.view = view;
      SettingsManager.LoadArchiveChdSettings(this.view);
    }

    public void ArchiveToCHD()
    {
      SettingsManager.SaveArchiveChdSettings(this.view);
      if (!this.view.IsValid)
      {
        this.view.ShowError("Please fill in all fields");
        return;
      }

      try
      {
        this.view.ToggleControls(false);
        this.view.ToggleProgress(true);
        SettingsManager.SaveArchiveChdSettings(this.view);
        var util = new GameInstallCoordinator(new PlaylistManager(), Playstation.Instance);
        var chd = util.ArchiveToCHD(this.view.CHDManPath, this.view.SevenZPath, this.view.ArchivePath,
          this.view.ForceCueCreate, this.view.TargetDirectory, this.view.Cleanup, this.view.LogConsole);
        this.view.ShowMessage("CHD created!");
        var chdPath = Path.GetDirectoryName(chd);
        Process.Start("explorer.exe", chdPath);
      }
      catch (Exception e)
      {
        this.view.ShowError(e.Message);
      }
      finally
      {
        this.view.ToggleControls(true);
        this.view.ToggleProgress(false);
      }
    }
  }
}
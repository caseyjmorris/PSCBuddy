﻿using System;
using System.Diagnostics;
using System.IO;
using PSCBuddy.Behaviors.Utils;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.Behaviors.Presenters
{
  public class ArchiveCHDConversionPresenter
  {
    private readonly IArchiveCHDConversionView view;
    private readonly SettingsManager settingsManager = new SettingsManager();

    public ArchiveCHDConversionPresenter(IArchiveCHDConversionView view)
    {
      this.view = view;
      this.settingsManager.LoadPSXArchiveCHDSettings(this.view);
    }

    public void ArchiveToCHD()
    {
      this.settingsManager.SavePSXArchiveCHDSettings(this.view);
      if (!this.view.IsValid)
      {
        this.view.ShowError("Please fill in all fields");
        return;
      }

      try
      {
        this.view.ToggleControls(false);
        this.view.ToggleProgress(true);
        this.settingsManager.SavePSXArchiveCHDSettings(this.view);
        var util = new PSXUtil();
        var chd = util.ArchiveToCHD(this.view.CHDManPath, this.view.SevenZPath, this.view.ArchivePath,
          this.view.ForceCueCreate, this.view.TargetDirectory, this.view.Cleanup);
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
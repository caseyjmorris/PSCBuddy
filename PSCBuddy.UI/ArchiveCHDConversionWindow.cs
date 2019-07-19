﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSCBuddy.Behaviors.Presenters;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.UI
{
  public partial class ArchiveCHDConversionWindow : Form, IArchiveCHDConversionView
  {
    private readonly ArchiveCHDConversionPresenter presenter;

    public ArchiveCHDConversionWindow()
    {
      this.InitializeComponent();
      this.presenter = new ArchiveCHDConversionPresenter(this);
      CheckForIllegalCrossThreadCalls = false;
    }

    public string CHDManPath
    {
      get => this.txtCHDManLoc.Text;
      set => this.txtCHDManLoc.Text = value;
    }

    public string SevenZPath
    {
      get => this.txt7zLoc.Text;
      set => this.txt7zLoc.Text = value;
    }

    public string ArchivePath
    {
      get => this.txtArchiveLoc.Text;
      set => this.txtArchiveLoc.Text = value;
    }

    public bool ForceCueCreate
    {
      get => this.checkForceCue.Checked;
      set => this.checkForceCue.Checked = value;
    }

    public string TargetDirectory
    {
      get => this.txtTargetLoc.Text;
      set => this.txtTargetLoc.Text = value;
    }

    public bool Cleanup
    {
      get => this.checkCleanup.Checked;
      set => this.checkCleanup.Checked = value;
    }

    public void ToggleControls(bool enabled)
    {
      this.btnGo.Enabled = enabled;
    }

    public void ToggleProgress(bool inProgress)
    {
      this.prgWork.Style = inProgress ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
    }

    public void ShowMessage(string message)
    {
      MessageBox.Show(message);
    }

    public void ShowError(string error)
    {
      MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public bool IsValid
      => !string.IsNullOrWhiteSpace(this.SevenZPath) && !string.IsNullOrWhiteSpace(this.ArchivePath) &&
         !string.IsNullOrWhiteSpace(this.CHDManPath) && !string.IsNullOrWhiteSpace(this.TargetDirectory);

    public void LogConsole(string message)
    {
      this.txtOutput.Text += Environment.NewLine + message;
    }

    private void btnChdMan_Click(object sender, EventArgs e)
    {
      using (var fd = new OpenFileDialog())
      {
        fd.FileName = this.CHDManPath;
        fd.Filter = "Application|*.exe";
        fd.CheckFileExists = true;
        var result = fd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
        {
          this.CHDManPath = fd.FileName;
        }
      }
    }

    private void btn7z_Click(object sender, EventArgs e)
    {
      using (var fd = new OpenFileDialog())
      {
        fd.FileName = this.SevenZPath;
        fd.Filter = "Application|*.exe";
        fd.CheckFileExists = true;
        var result = fd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
        {
          this.SevenZPath = fd.FileName;
        }
      }
    }

    private void btnArchive_Click(object sender, EventArgs e)
    {
      using (var fd = new OpenFileDialog())
      {
        fd.FileName = this.ArchivePath;
        fd.Filter = "PSX game|*.7z";
        fd.CheckFileExists = true;
        fd.Multiselect = true;
        var result = fd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
        {
          this.ArchivePath = string.Join(";", fd.FileNames.OrderBy(f => f));
        }
      }
    }

    private void btnSaveTo_Click(object sender, EventArgs e)
    {
      using (var fbd = new FolderBrowserDialog())
      {
        fbd.SelectedPath = this.TargetDirectory;
        var result = fbd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
        {
          this.TargetDirectory = fbd.SelectedPath;
        }
      }
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      this.presenter.ArchiveToCHD();
    }
  }
}
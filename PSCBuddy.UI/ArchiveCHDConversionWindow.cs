using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSCBuddy.Behaviors.Views;

namespace PSCBuddy.UI
{
  public partial class ArchiveCHDConversionWindow : Form, IArchiveCHDConversionView
  {
    public ArchiveCHDConversionWindow()
    {
      this.InitializeComponent();
    }

    public string CHDManPath
    {
      get { return this.txtCHDManLoc.Text; }
      set { this.txtCHDManLoc.Text = value; }
    }

    public string SevenZPath
    {
      get { return this.txt7zLoc.Text; }
      set { this.txt7zLoc.Text = value; }
    }

    public string ArchivePath
    {
      get { return this.txtArchiveLoc.Text; }
      set { this.txtArchiveLoc.Text = value; }
    }

    public bool ForceCueCreate
    {
      get { return this.checkForceCue.Checked; }
      set { this.checkForceCue.Checked = value; }
    }

    public string TargetDirectory
    {
      get { return this.txtTargetLoc.Text; }
      set { this.txtTargetLoc.Text = value; }
    }

    public bool Cleanup
    {
      get { return this.checkCleanup.Checked; }
      set { this.checkCleanup.Checked = value; }
    }

    public void ToggleControls(bool enabled)
    {
      this.btnGo.Enabled = enabled;
    }

    public void ToggleProgress(bool inProgress)
    {
      if (inProgress)
      {
        this.prgWork.Style = ProgressBarStyle.Marquee;
      }
      else
      {
        this.prgWork.Style = ProgressBarStyle.Continuous;
      }
    }

    public void ShowMessage(string message)
    {
      MessageBox.Show(message);
    }

    public void ShowError(string error)
    {
      MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public bool IsValid { get; }

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
        var result = fd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
        {
          this.ArchivePath = fd.FileName;
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
          this.ArchivePath = fbd.SelectedPath;
        }
      }
    }
  }
}
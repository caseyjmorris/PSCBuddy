namespace PSCBuddy.UI
{
  partial class ArchiveCHDConversionWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtCHDManLoc = new System.Windows.Forms.TextBox();
      this.lblCHDManLoc = new System.Windows.Forms.Label();
      this.txt7zLoc = new System.Windows.Forms.TextBox();
      this.lbl7zLoc = new System.Windows.Forms.Label();
      this.txtArchiveLoc = new System.Windows.Forms.TextBox();
      this.lblArchiveLoc = new System.Windows.Forms.Label();
      this.txtTargetLoc = new System.Windows.Forms.TextBox();
      this.lblTargetLoc = new System.Windows.Forms.Label();
      this.checkForceCue = new System.Windows.Forms.CheckBox();
      this.checkCleanup = new System.Windows.Forms.CheckBox();
      this.btnGo = new System.Windows.Forms.Button();
      this.prgWork = new System.Windows.Forms.ProgressBar();
      this.btnChdMan = new System.Windows.Forms.Button();
      this.btn7z = new System.Windows.Forms.Button();
      this.btnArchive = new System.Windows.Forms.Button();
      this.btnSaveTo = new System.Windows.Forms.Button();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.lblSystem = new System.Windows.Forms.Label();
      this.cmbSystemSelect = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      this.txtCHDManLoc.Location = new System.Drawing.Point(114, 38);
      this.txtCHDManLoc.Name = "txtCHDManLoc";
      this.txtCHDManLoc.Size = new System.Drawing.Size(940, 23);
      this.txtCHDManLoc.TabIndex = 0;
      this.lblCHDManLoc.AutoSize = true;
      this.lblCHDManLoc.Location = new System.Drawing.Point(8, 42);
      this.lblCHDManLoc.Name = "lblCHDManLoc";
      this.lblCHDManLoc.Size = new System.Drawing.Size(102, 15);
      this.lblCHDManLoc.TabIndex = 1;
      this.lblCHDManLoc.Text = "CHDMan location";
      this.txt7zLoc.Location = new System.Drawing.Point(114, 70);
      this.txt7zLoc.Name = "txt7zLoc";
      this.txt7zLoc.Size = new System.Drawing.Size(940, 23);
      this.txt7zLoc.TabIndex = 2;
      this.lbl7zLoc.AutoSize = true;
      this.lbl7zLoc.Location = new System.Drawing.Point(8, 73);
      this.lbl7zLoc.Name = "lbl7zLoc";
      this.lbl7zLoc.Size = new System.Drawing.Size(64, 15);
      this.lbl7zLoc.TabIndex = 3;
      this.lbl7zLoc.Text = "7z location";
      this.lbl7zLoc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.txtArchiveLoc.Location = new System.Drawing.Point(114, 101);
      this.txtArchiveLoc.Name = "txtArchiveLoc";
      this.txtArchiveLoc.Size = new System.Drawing.Size(940, 23);
      this.txtArchiveLoc.TabIndex = 4;
      this.lblArchiveLoc.AutoSize = true;
      this.lblArchiveLoc.Location = new System.Drawing.Point(8, 104);
      this.lblArchiveLoc.Name = "lblArchiveLoc";
      this.lblArchiveLoc.Size = new System.Drawing.Size(93, 15);
      this.lblArchiveLoc.TabIndex = 5;
      this.lblArchiveLoc.Text = "Archive location";
      this.txtTargetLoc.Location = new System.Drawing.Point(114, 132);
      this.txtTargetLoc.Name = "txtTargetLoc";
      this.txtTargetLoc.Size = new System.Drawing.Size(940, 23);
      this.txtTargetLoc.TabIndex = 6;
      this.lblTargetLoc.AutoSize = true;
      this.lblTargetLoc.Location = new System.Drawing.Point(7, 135);
      this.lblTargetLoc.Name = "lblTargetLoc";
      this.lblTargetLoc.Size = new System.Drawing.Size(45, 15);
      this.lblTargetLoc.TabIndex = 7;
      this.lblTargetLoc.Text = "Save to";
      this.checkForceCue.AutoSize = true;
      this.checkForceCue.Location = new System.Drawing.Point(12, 158);
      this.checkForceCue.Name = "checkForceCue";
      this.checkForceCue.Size = new System.Drawing.Size(123, 19);
      this.checkForceCue.TabIndex = 8;
      this.checkForceCue.Text = "Force cue creation";
      this.checkForceCue.UseVisualStyleBackColor = true;
      this.checkCleanup.AutoSize = true;
      this.checkCleanup.Location = new System.Drawing.Point(153, 162);
      this.checkCleanup.Name = "checkCleanup";
      this.checkCleanup.Size = new System.Drawing.Size(148, 19);
      this.checkCleanup.TabIndex = 9;
      this.checkCleanup.Text = "Clean up extracted files";
      this.checkCleanup.UseVisualStyleBackColor = true;
      this.btnGo.Location = new System.Drawing.Point(12, 185);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(1088, 27);
      this.btnGo.TabIndex = 10;
      this.btnGo.Text = "Go";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      this.prgWork.Location = new System.Drawing.Point(12, 229);
      this.prgWork.Name = "prgWork";
      this.prgWork.Size = new System.Drawing.Size(1088, 27);
      this.prgWork.TabIndex = 11;
      this.btnChdMan.Location = new System.Drawing.Point(1063, 38);
      this.btnChdMan.Name = "btnChdMan";
      this.btnChdMan.Size = new System.Drawing.Size(37, 27);
      this.btnChdMan.TabIndex = 12;
      this.btnChdMan.Text = "...";
      this.btnChdMan.UseVisualStyleBackColor = true;
      this.btnChdMan.Click += new System.EventHandler(this.btnChdMan_Click);
      this.btn7z.Location = new System.Drawing.Point(1062, 70);
      this.btn7z.Name = "btn7z";
      this.btn7z.Size = new System.Drawing.Size(37, 27);
      this.btn7z.TabIndex = 13;
      this.btn7z.Text = "...";
      this.btn7z.UseVisualStyleBackColor = true;
      this.btn7z.Click += new System.EventHandler(this.btn7z_Click);
      this.btnArchive.Location = new System.Drawing.Point(1063, 101);
      this.btnArchive.Name = "btnArchive";
      this.btnArchive.Size = new System.Drawing.Size(37, 27);
      this.btnArchive.TabIndex = 14;
      this.btnArchive.Text = "...";
      this.btnArchive.UseVisualStyleBackColor = true;
      this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
      this.btnSaveTo.Location = new System.Drawing.Point(1062, 134);
      this.btnSaveTo.Name = "btnSaveTo";
      this.btnSaveTo.Size = new System.Drawing.Size(37, 27);
      this.btnSaveTo.TabIndex = 15;
      this.btnSaveTo.Text = "...";
      this.btnSaveTo.UseVisualStyleBackColor = true;
      this.btnSaveTo.Click += new System.EventHandler(this.btnSaveTo_Click);
      this.txtOutput.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.txtOutput.Location = new System.Drawing.Point(10, 263);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtOutput.Size = new System.Drawing.Size(1089, 416);
      this.txtOutput.TabIndex = 16;
      this.lblSystem.Location = new System.Drawing.Point(6, 9);
      this.lblSystem.Name = "lblSystem";
      this.lblSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblSystem.Size = new System.Drawing.Size(100, 23);
      this.lblSystem.TabIndex = 17;
      this.lblSystem.Text = "System";
      this.cmbSystemSelect.FormattingEnabled = true;
      this.cmbSystemSelect.Location = new System.Drawing.Point(113, 6);
      this.cmbSystemSelect.Name = "cmbSystemSelect";
      this.cmbSystemSelect.Size = new System.Drawing.Size(986, 23);
      this.cmbSystemSelect.TabIndex = 18;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1121, 690);
      this.Controls.Add(this.cmbSystemSelect);
      this.Controls.Add(this.lblSystem);
      this.Controls.Add(this.txtOutput);
      this.Controls.Add(this.btnSaveTo);
      this.Controls.Add(this.btnArchive);
      this.Controls.Add(this.btn7z);
      this.Controls.Add(this.btnChdMan);
      this.Controls.Add(this.prgWork);
      this.Controls.Add(this.btnGo);
      this.Controls.Add(this.checkCleanup);
      this.Controls.Add(this.checkForceCue);
      this.Controls.Add(this.lblTargetLoc);
      this.Controls.Add(this.txtTargetLoc);
      this.Controls.Add(this.lblArchiveLoc);
      this.Controls.Add(this.txtArchiveLoc);
      this.Controls.Add(this.lbl7zLoc);
      this.Controls.Add(this.txt7zLoc);
      this.Controls.Add(this.lblCHDManLoc);
      this.Controls.Add(this.txtCHDManLoc);
      this.Name = "ArchiveCHDConversionWindow";
      this.Text = "Archive CHD conersion";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtCHDManLoc;
    private System.Windows.Forms.Label lblCHDManLoc;
    private System.Windows.Forms.TextBox txt7zLoc;
    private System.Windows.Forms.Label lbl7zLoc;
    private System.Windows.Forms.TextBox txtArchiveLoc;
    private System.Windows.Forms.Label lblArchiveLoc;
    private System.Windows.Forms.TextBox txtTargetLoc;
    private System.Windows.Forms.Label lblTargetLoc;
    private System.Windows.Forms.CheckBox checkForceCue;
    private System.Windows.Forms.CheckBox checkCleanup;
    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.ProgressBar prgWork;
    private System.Windows.Forms.Button btnChdMan;
    private System.Windows.Forms.Button btn7z;
    private System.Windows.Forms.Button btnArchive;
    private System.Windows.Forms.Button btnSaveTo;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.ComboBox cmbSystemSelect;
    private System.Windows.Forms.Label lblSystem;
  }
}


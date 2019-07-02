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
    private void InitializeComponent ()
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
      this.SuspendLayout();
      // 
      // txtCHDManLoc
      // 
      this.txtCHDManLoc.Location = new System.Drawing.Point(104, 29);
      this.txtCHDManLoc.Name = "txtCHDManLoc";
      this.txtCHDManLoc.Size = new System.Drawing.Size(806, 20);
      this.txtCHDManLoc.TabIndex = 0;
      // 
      // lblCHDManLoc
      // 
      this.lblCHDManLoc.AutoSize = true;
      this.lblCHDManLoc.Location = new System.Drawing.Point(13, 32);
      this.lblCHDManLoc.Name = "lblCHDManLoc";
      this.lblCHDManLoc.Size = new System.Drawing.Size(91, 13);
      this.lblCHDManLoc.TabIndex = 1;
      this.lblCHDManLoc.Text = "CHDMan location";
      // 
      // txt7zLoc
      // 
      this.txt7zLoc.Location = new System.Drawing.Point(104, 56);
      this.txt7zLoc.Name = "txt7zLoc";
      this.txt7zLoc.Size = new System.Drawing.Size(806, 20);
      this.txt7zLoc.TabIndex = 2;
      // 
      // lbl7zLoc
      // 
      this.lbl7zLoc.AutoSize = true;
      this.lbl7zLoc.Location = new System.Drawing.Point(13, 59);
      this.lbl7zLoc.Name = "lbl7zLoc";
      this.lbl7zLoc.Size = new System.Drawing.Size(58, 13);
      this.lbl7zLoc.TabIndex = 3;
      this.lbl7zLoc.Text = "7z location";
      this.lbl7zLoc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // txtArchiveLoc
      // 
      this.txtArchiveLoc.Location = new System.Drawing.Point(104, 83);
      this.txtArchiveLoc.Name = "txtArchiveLoc";
      this.txtArchiveLoc.Size = new System.Drawing.Size(806, 20);
      this.txtArchiveLoc.TabIndex = 4;
      // 
      // lblArchiveLoc
      // 
      this.lblArchiveLoc.AutoSize = true;
      this.lblArchiveLoc.Location = new System.Drawing.Point(13, 86);
      this.lblArchiveLoc.Name = "lblArchiveLoc";
      this.lblArchiveLoc.Size = new System.Drawing.Size(83, 13);
      this.lblArchiveLoc.TabIndex = 5;
      this.lblArchiveLoc.Text = "Archive location";
      // 
      // txtTargetLoc
      // 
      this.txtTargetLoc.Location = new System.Drawing.Point(104, 110);
      this.txtTargetLoc.Name = "txtTargetLoc";
      this.txtTargetLoc.Size = new System.Drawing.Size(806, 20);
      this.txtTargetLoc.TabIndex = 6;
      // 
      // lblTargetLoc
      // 
      this.lblTargetLoc.AutoSize = true;
      this.lblTargetLoc.Location = new System.Drawing.Point(12, 113);
      this.lblTargetLoc.Name = "lblTargetLoc";
      this.lblTargetLoc.Size = new System.Drawing.Size(44, 13);
      this.lblTargetLoc.TabIndex = 7;
      this.lblTargetLoc.Text = "Save to";
      // 
      // checkForceCue
      // 
      this.checkForceCue.AutoSize = true;
      this.checkForceCue.Location = new System.Drawing.Point(16, 133);
      this.checkForceCue.Name = "checkForceCue";
      this.checkForceCue.Size = new System.Drawing.Size(115, 17);
      this.checkForceCue.TabIndex = 8;
      this.checkForceCue.Text = "Force cue creation";
      this.checkForceCue.UseVisualStyleBackColor = true;
      // 
      // checkCleanup
      // 
      this.checkCleanup.AutoSize = true;
      this.checkCleanup.Location = new System.Drawing.Point(137, 136);
      this.checkCleanup.Name = "checkCleanup";
      this.checkCleanup.Size = new System.Drawing.Size(136, 17);
      this.checkCleanup.TabIndex = 9;
      this.checkCleanup.Text = "Clean up extracted files";
      this.checkCleanup.UseVisualStyleBackColor = true;
      // 
      // btnGo
      // 
      this.btnGo.Location = new System.Drawing.Point(16, 156);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(933, 23);
      this.btnGo.TabIndex = 10;
      this.btnGo.Text = "Go";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // prgWork
      // 
      this.prgWork.Location = new System.Drawing.Point(16, 194);
      this.prgWork.Name = "prgWork";
      this.prgWork.Size = new System.Drawing.Size(933, 23);
      this.prgWork.TabIndex = 11;
      // 
      // btnChdMan
      // 
      this.btnChdMan.Location = new System.Drawing.Point(917, 29);
      this.btnChdMan.Name = "btnChdMan";
      this.btnChdMan.Size = new System.Drawing.Size(32, 23);
      this.btnChdMan.TabIndex = 12;
      this.btnChdMan.Text = "...";
      this.btnChdMan.UseVisualStyleBackColor = true;
      this.btnChdMan.Click += new System.EventHandler(this.btnChdMan_Click);
      // 
      // btn7z
      // 
      this.btn7z.Location = new System.Drawing.Point(916, 56);
      this.btn7z.Name = "btn7z";
      this.btn7z.Size = new System.Drawing.Size(32, 23);
      this.btn7z.TabIndex = 13;
      this.btn7z.Text = "...";
      this.btn7z.UseVisualStyleBackColor = true;
      this.btn7z.Click += new System.EventHandler(this.btn7z_Click);
      // 
      // btnArchive
      // 
      this.btnArchive.Location = new System.Drawing.Point(917, 83);
      this.btnArchive.Name = "btnArchive";
      this.btnArchive.Size = new System.Drawing.Size(32, 23);
      this.btnArchive.TabIndex = 14;
      this.btnArchive.Text = "...";
      this.btnArchive.UseVisualStyleBackColor = true;
      this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
      // 
      // btnSaveTo
      // 
      this.btnSaveTo.Location = new System.Drawing.Point(916, 112);
      this.btnSaveTo.Name = "btnSaveTo";
      this.btnSaveTo.Size = new System.Drawing.Size(32, 23);
      this.btnSaveTo.TabIndex = 15;
      this.btnSaveTo.Text = "...";
      this.btnSaveTo.UseVisualStyleBackColor = true;
      this.btnSaveTo.Click += new System.EventHandler(this.btnSaveTo_Click);
      // 
      // ArchiveCHDConversionWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(961, 232);
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
  }
}


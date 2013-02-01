namespace PathViewer
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tpMachine = new System.Windows.Forms.TabPage();
      this.lbMachine = new System.Windows.Forms.ListBox();
      this.tpUser = new System.Windows.Forms.TabPage();
      this.lbUser = new System.Windows.Forms.ListBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnRestore = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnBackup = new System.Windows.Forms.Button();
      this.ofdBackup = new System.Windows.Forms.OpenFileDialog();
      this.sfdRestore = new System.Windows.Forms.SaveFileDialog();
      this.fbdFolderSelector = new System.Windows.Forms.FolderBrowserDialog();
      this.tabControl1.SuspendLayout();
      this.tpMachine.SuspendLayout();
      this.tpUser.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tpMachine);
      this.tabControl1.Controls.Add(this.tpUser);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(379, 355);
      this.tabControl1.TabIndex = 0;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tpMachine
      // 
      this.tpMachine.Controls.Add(this.lbMachine);
      this.tpMachine.Location = new System.Drawing.Point(4, 22);
      this.tpMachine.Name = "tpMachine";
      this.tpMachine.Padding = new System.Windows.Forms.Padding(3);
      this.tpMachine.Size = new System.Drawing.Size(371, 329);
      this.tpMachine.TabIndex = 1;
      this.tpMachine.Text = "Machine";
      this.tpMachine.UseVisualStyleBackColor = true;
      // 
      // lbMachine
      // 
      this.lbMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbMachine.FormattingEnabled = true;
      this.lbMachine.HorizontalScrollbar = true;
      this.lbMachine.Location = new System.Drawing.Point(6, 6);
      this.lbMachine.Name = "lbMachine";
      this.lbMachine.Size = new System.Drawing.Size(359, 316);
      this.lbMachine.TabIndex = 1;
      // 
      // tpUser
      // 
      this.tpUser.Controls.Add(this.lbUser);
      this.tpUser.Location = new System.Drawing.Point(4, 22);
      this.tpUser.Name = "tpUser";
      this.tpUser.Padding = new System.Windows.Forms.Padding(3);
      this.tpUser.Size = new System.Drawing.Size(371, 329);
      this.tpUser.TabIndex = 0;
      this.tpUser.Text = "User";
      this.tpUser.UseVisualStyleBackColor = true;
      // 
      // lbUser
      // 
      this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbUser.FormattingEnabled = true;
      this.lbUser.HorizontalScrollbar = true;
      this.lbUser.Location = new System.Drawing.Point(6, 6);
      this.lbUser.Name = "lbUser";
      this.lbUser.Size = new System.Drawing.Size(359, 316);
      this.lbUser.TabIndex = 0;
      // 
      // btnAdd
      // 
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(397, 34);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Enabled = false;
      this.btnEdit.Location = new System.Drawing.Point(397, 63);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(75, 23);
      this.btnEdit.TabIndex = 1;
      this.btnEdit.Text = "Edit";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnRestore
      // 
      this.btnRestore.Enabled = false;
      this.btnRestore.Location = new System.Drawing.Point(397, 266);
      this.btnRestore.Name = "btnRestore";
      this.btnRestore.Size = new System.Drawing.Size(75, 23);
      this.btnRestore.TabIndex = 1;
      this.btnRestore.Text = "Restore";
      this.btnRestore.UseVisualStyleBackColor = true;
      this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
      // 
      // btnSave
      // 
      this.btnSave.Enabled = false;
      this.btnSave.Location = new System.Drawing.Point(397, 344);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 1;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Enabled = false;
      this.btnDelete.Location = new System.Drawing.Point(397, 92);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(75, 23);
      this.btnDelete.TabIndex = 1;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnBackup
      // 
      this.btnBackup.Enabled = false;
      this.btnBackup.Location = new System.Drawing.Point(397, 237);
      this.btnBackup.Name = "btnBackup";
      this.btnBackup.Size = new System.Drawing.Size(75, 23);
      this.btnBackup.TabIndex = 1;
      this.btnBackup.Text = "Backup";
      this.btnBackup.UseVisualStyleBackColor = true;
      this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
      // 
      // ofdBackup
      // 
      this.ofdBackup.Filter = "All Files|*.*";
      this.ofdBackup.Title = "Please select the backup to open.";
      // 
      // sfdRestore
      // 
      this.sfdRestore.DefaultExt = "txt";
      this.sfdRestore.FileName = "backup.txt";
      this.sfdRestore.Filter = "All Files|*.*";
      this.sfdRestore.Title = "Please select the file to save to";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 379);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnBackup);
      this.Controls.Add(this.btnRestore);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.Text = "Path Viewer";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.tpMachine.ResumeLayout(false);
      this.tpUser.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tpUser;
    private System.Windows.Forms.TabPage tpMachine;
    private System.Windows.Forms.ListBox lbUser;
    private System.Windows.Forms.ListBox lbMachine;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnRestore;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnBackup;
    private System.Windows.Forms.OpenFileDialog ofdBackup;
    private System.Windows.Forms.SaveFileDialog sfdRestore;
    private System.Windows.Forms.FolderBrowserDialog fbdFolderSelector;
  }
}


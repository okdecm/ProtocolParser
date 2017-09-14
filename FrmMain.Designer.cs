namespace ProtocolParser
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.miMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.FileStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExportCSharpClasses = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditOrderByValue = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbProtocolDetails = new System.Windows.Forms.RichTextBox();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.protocolsTree = new System.Windows.Forms.TreeView();
            this.scProtocolInfo = new System.Windows.Forms.SplitContainer();
            this.tlpResults = new System.Windows.Forms.TableLayoutPanel();
            this.tbResultsSearch = new System.Windows.Forms.TextBox();
            this.msMenu.SuspendLayout();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scProtocolInfo)).BeginInit();
            this.scProtocolInfo.Panel1.SuspendLayout();
            this.scProtocolInfo.Panel2.SuspendLayout();
            this.scProtocolInfo.SuspendLayout();
            this.tlpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMenuFile,
            this.miEdit,
            this.aboutToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(684, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // miMenuFile
            // 
            this.miMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripOpen,
            this.fileStripSave,
            this.fileStripSaveAs,
            this.miFileExport,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.miMenuFile.Name = "miMenuFile";
            this.miMenuFile.Size = new System.Drawing.Size(37, 20);
            this.miMenuFile.Text = "File";
            // 
            // FileStripOpen
            // 
            this.FileStripOpen.Name = "FileStripOpen";
            this.FileStripOpen.Size = new System.Drawing.Size(152, 22);
            this.FileStripOpen.Text = "Open";
            this.FileStripOpen.Click += new System.EventHandler(this.fileStripOpen_Click);
            // 
            // fileStripSave
            // 
            this.fileStripSave.Enabled = false;
            this.fileStripSave.Name = "fileStripSave";
            this.fileStripSave.Size = new System.Drawing.Size(152, 22);
            this.fileStripSave.Text = "Save";
            this.fileStripSave.Click += new System.EventHandler(this.fileStripSave_Click);
            // 
            // fileStripSaveAs
            // 
            this.fileStripSaveAs.Enabled = false;
            this.fileStripSaveAs.Name = "fileStripSaveAs";
            this.fileStripSaveAs.Size = new System.Drawing.Size(152, 22);
            this.fileStripSaveAs.Text = "Save As";
            this.fileStripSaveAs.Click += new System.EventHandler(this.fileStripSaveAs_Click);
            // 
            // miFileExport
            // 
            this.miFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileExportCSharpClasses});
            this.miFileExport.Name = "miFileExport";
            this.miFileExport.Size = new System.Drawing.Size(152, 22);
            this.miFileExport.Text = "Export";
            // 
            // miFileExportCSharpClasses
            // 
            this.miFileExportCSharpClasses.Name = "miFileExportCSharpClasses";
            this.miFileExportCSharpClasses.Size = new System.Drawing.Size(153, 22);
            this.miFileExportCSharpClasses.Text = "CSharp Classes";
            this.miFileExportCSharpClasses.Click += new System.EventHandler(this.miFileExportCSharpClasses_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditOrderByValue});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 20);
            this.miEdit.Text = "Edit";
            // 
            // miEditOrderByValue
            // 
            this.miEditOrderByValue.Name = "miEditOrderByValue";
            this.miEditOrderByValue.Size = new System.Drawing.Size(151, 22);
            this.miEditOrderByValue.Text = "Order By Value";
            this.miEditOrderByValue.Click += new System.EventHandler(this.miEditOrderByValue_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rtbProtocolDetails
            // 
            this.rtbProtocolDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProtocolDetails.Location = new System.Drawing.Point(0, 0);
            this.rtbProtocolDetails.Name = "rtbProtocolDetails";
            this.rtbProtocolDetails.ReadOnly = true;
            this.rtbProtocolDetails.Size = new System.Drawing.Size(452, 415);
            this.rtbProtocolDetails.TabIndex = 3;
            this.rtbProtocolDetails.Text = "";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 439);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(684, 22);
            this.ssStatus.TabIndex = 4;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(152, 17);
            this.tsslStatus.Text = "Please load a protocol store";
            // 
            // protocolsTree
            // 
            this.protocolsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolsTree.Location = new System.Drawing.Point(3, 29);
            this.protocolsTree.Name = "protocolsTree";
            this.protocolsTree.Size = new System.Drawing.Size(222, 383);
            this.protocolsTree.TabIndex = 5;
            this.protocolsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProtocols_AfterSelect);
            // 
            // scProtocolInfo
            // 
            this.scProtocolInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scProtocolInfo.Location = new System.Drawing.Point(0, 24);
            this.scProtocolInfo.Name = "scProtocolInfo";
            // 
            // scProtocolInfo.Panel1
            // 
            this.scProtocolInfo.Panel1.Controls.Add(this.tlpResults);
            // 
            // scProtocolInfo.Panel2
            // 
            this.scProtocolInfo.Panel2.Controls.Add(this.rtbProtocolDetails);
            this.scProtocolInfo.Size = new System.Drawing.Size(684, 415);
            this.scProtocolInfo.SplitterDistance = 228;
            this.scProtocolInfo.TabIndex = 6;
            // 
            // tlpResults
            // 
            this.tlpResults.ColumnCount = 1;
            this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResults.Controls.Add(this.protocolsTree, 0, 1);
            this.tlpResults.Controls.Add(this.tbResultsSearch, 0, 0);
            this.tlpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResults.Location = new System.Drawing.Point(0, 0);
            this.tlpResults.Name = "tlpResults";
            this.tlpResults.RowCount = 2;
            this.tlpResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResults.Size = new System.Drawing.Size(228, 415);
            this.tlpResults.TabIndex = 6;
            // 
            // tbResultsSearch
            // 
            this.tbResultsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbResultsSearch.Location = new System.Drawing.Point(3, 3);
            this.tbResultsSearch.Name = "tbResultsSearch";
            this.tbResultsSearch.Size = new System.Drawing.Size(222, 20);
            this.tbResultsSearch.TabIndex = 6;
            this.tbResultsSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbResultsSearch_KeyUp);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.scProtocolInfo);
            this.Controls.Add(this.msMenu);
            this.Controls.Add(this.ssStatus);
            this.MainMenuStrip = this.msMenu;
            this.Name = "FrmMain";
            this.Text = "Protocol Parser";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.scProtocolInfo.Panel1.ResumeLayout(false);
            this.scProtocolInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scProtocolInfo)).EndInit();
            this.scProtocolInfo.ResumeLayout(false);
            this.tlpResults.ResumeLayout(false);
            this.tlpResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip msMenu;
		private System.Windows.Forms.ToolStripMenuItem miMenuFile;
		private System.Windows.Forms.ToolStripMenuItem FileStripOpen;
		private System.Windows.Forms.RichTextBox rtbProtocolDetails;
		private System.Windows.Forms.StatusStrip ssStatus;
		private System.Windows.Forms.TreeView protocolsTree;
		private System.Windows.Forms.SplitContainer scProtocolInfo;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.ToolStripMenuItem miFileExport;
		private System.Windows.Forms.ToolStripMenuItem miEdit;
		private System.Windows.Forms.ToolStripMenuItem miEditOrderByValue;
		private System.Windows.Forms.TableLayoutPanel tlpResults;
		private System.Windows.Forms.TextBox tbResultsSearch;
		private System.Windows.Forms.ToolStripMenuItem miFileExportCSharpClasses;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileStripSave;
        private System.Windows.Forms.ToolStripMenuItem fileStripSaveAs;
    }
}


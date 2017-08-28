namespace HeaderProtocolParser
{
	partial class fProtocolParser
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
			this.miMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileExport = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileExportERB = new System.Windows.Forms.ToolStripMenuItem();
			this.tstbByDec = new System.Windows.Forms.ToolStripTextBox();
			this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditOrderByValue = new System.Windows.Forms.ToolStripMenuItem();
			this.rtbProtocolDetails = new System.Windows.Forms.RichTextBox();
			this.ssStatus = new System.Windows.Forms.StatusStrip();
			this.tspbStatus = new System.Windows.Forms.ToolStripProgressBar();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tvProtocols = new System.Windows.Forms.TreeView();
			this.scProtocolInfo = new System.Windows.Forms.SplitContainer();
			this.tlpResults = new System.Windows.Forms.TableLayoutPanel();
			this.tbResultsSearch = new System.Windows.Forms.TextBox();
			this.miFileExportCSharpClasses = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tstbByDec,
            this.miEdit});
			this.msMenu.Location = new System.Drawing.Point(0, 0);
			this.msMenu.Name = "msMenu";
			this.msMenu.Size = new System.Drawing.Size(684, 27);
			this.msMenu.TabIndex = 0;
			this.msMenu.Text = "menuStrip1";
			// 
			// miMenuFile
			// 
			this.miMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMenuFileOpen,
            this.miFileExport});
			this.miMenuFile.Name = "miMenuFile";
			this.miMenuFile.Size = new System.Drawing.Size(37, 23);
			this.miMenuFile.Text = "File";
			// 
			// miMenuFileOpen
			// 
			this.miMenuFileOpen.Name = "miMenuFileOpen";
			this.miMenuFileOpen.Size = new System.Drawing.Size(152, 22);
			this.miMenuFileOpen.Text = "Open";
			this.miMenuFileOpen.Click += new System.EventHandler(this.miMenuFileOpen_Click);
			// 
			// miFileExport
			// 
			this.miFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileExportERB,
            this.miFileExportCSharpClasses});
			this.miFileExport.Name = "miFileExport";
			this.miFileExport.Size = new System.Drawing.Size(152, 22);
			this.miFileExport.Text = "Export";
			// 
			// miFileExportERB
			// 
			this.miFileExportERB.Name = "miFileExportERB";
			this.miFileExportERB.Size = new System.Drawing.Size(153, 22);
			this.miFileExportERB.Text = "ERB";
			this.miFileExportERB.Click += new System.EventHandler(this.miFileExportERB_Click);
			// 
			// tstbByDec
			// 
			this.tstbByDec.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tstbByDec.BackColor = System.Drawing.Color.Violet;
			this.tstbByDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstbByDec.Name = "tstbByDec";
			this.tstbByDec.ReadOnly = true;
			this.tstbByDec.Size = new System.Drawing.Size(100, 23);
			this.tstbByDec.Text = "By Dec";
			this.tstbByDec.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tstbByDec.Enter += new System.EventHandler(this.tstbByDec_Enter);
			this.tstbByDec.Leave += new System.EventHandler(this.tstbByDec_Leave);
			// 
			// miEdit
			// 
			this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditOrderByValue});
			this.miEdit.Name = "miEdit";
			this.miEdit.Size = new System.Drawing.Size(39, 23);
			this.miEdit.Text = "Edit";
			// 
			// miEditOrderByValue
			// 
			this.miEditOrderByValue.Name = "miEditOrderByValue";
			this.miEditOrderByValue.Size = new System.Drawing.Size(151, 22);
			this.miEditOrderByValue.Text = "Order By Value";
			this.miEditOrderByValue.Click += new System.EventHandler(this.miEditOrderByValue_Click);
			// 
			// rtbProtocolDetails
			// 
			this.rtbProtocolDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbProtocolDetails.Location = new System.Drawing.Point(0, 0);
			this.rtbProtocolDetails.Name = "rtbProtocolDetails";
			this.rtbProtocolDetails.ReadOnly = true;
			this.rtbProtocolDetails.Size = new System.Drawing.Size(452, 412);
			this.rtbProtocolDetails.TabIndex = 3;
			this.rtbProtocolDetails.Text = "";
			// 
			// ssStatus
			// 
			this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbStatus,
            this.tsslStatus});
			this.ssStatus.Location = new System.Drawing.Point(0, 439);
			this.ssStatus.Name = "ssStatus";
			this.ssStatus.Size = new System.Drawing.Size(684, 22);
			this.ssStatus.TabIndex = 4;
			this.ssStatus.Text = "statusStrip1";
			// 
			// tspbStatus
			// 
			this.tspbStatus.Name = "tspbStatus";
			this.tspbStatus.Size = new System.Drawing.Size(100, 16);
			// 
			// tsslStatus
			// 
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(152, 17);
			this.tsslStatus.Text = "Please load a protocol store";
			// 
			// tvProtocols
			// 
			this.tvProtocols.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvProtocols.Location = new System.Drawing.Point(3, 29);
			this.tvProtocols.Name = "tvProtocols";
			this.tvProtocols.Size = new System.Drawing.Size(222, 380);
			this.tvProtocols.TabIndex = 5;
			this.tvProtocols.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProtocols_AfterSelect);
			// 
			// scProtocolInfo
			// 
			this.scProtocolInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scProtocolInfo.Location = new System.Drawing.Point(0, 27);
			this.scProtocolInfo.Name = "scProtocolInfo";
			// 
			// scProtocolInfo.Panel1
			// 
			this.scProtocolInfo.Panel1.Controls.Add(this.tlpResults);
			// 
			// scProtocolInfo.Panel2
			// 
			this.scProtocolInfo.Panel2.Controls.Add(this.rtbProtocolDetails);
			this.scProtocolInfo.Size = new System.Drawing.Size(684, 412);
			this.scProtocolInfo.SplitterDistance = 228;
			this.scProtocolInfo.TabIndex = 6;
			// 
			// tlpResults
			// 
			this.tlpResults.ColumnCount = 1;
			this.tlpResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpResults.Controls.Add(this.tvProtocols, 0, 1);
			this.tlpResults.Controls.Add(this.tbResultsSearch, 0, 0);
			this.tlpResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpResults.Location = new System.Drawing.Point(0, 0);
			this.tlpResults.Name = "tlpResults";
			this.tlpResults.RowCount = 2;
			this.tlpResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpResults.Size = new System.Drawing.Size(228, 412);
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
			// miFileExportCSharpClasses
			// 
			this.miFileExportCSharpClasses.Name = "miFileExportCSharpClasses";
			this.miFileExportCSharpClasses.Size = new System.Drawing.Size(153, 22);
			this.miFileExportCSharpClasses.Text = "CSharp Classes";
			this.miFileExportCSharpClasses.Click += new System.EventHandler(this.miFileExportCSharpClasses_Click);
			// 
			// fProtocolParser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.scProtocolInfo);
			this.Controls.Add(this.msMenu);
			this.Controls.Add(this.ssStatus);
			this.MainMenuStrip = this.msMenu;
			this.Name = "fProtocolParser";
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
		private System.Windows.Forms.ToolStripMenuItem miMenuFileOpen;
		private System.Windows.Forms.RichTextBox rtbProtocolDetails;
		private System.Windows.Forms.StatusStrip ssStatus;
		private System.Windows.Forms.TreeView tvProtocols;
		private System.Windows.Forms.SplitContainer scProtocolInfo;
		private System.Windows.Forms.ToolStripProgressBar tspbStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.ToolStripMenuItem miFileExport;
		private System.Windows.Forms.ToolStripMenuItem miFileExportERB;
		private System.Windows.Forms.ToolStripTextBox tstbByDec;
		private System.Windows.Forms.ToolStripMenuItem miEdit;
		private System.Windows.Forms.ToolStripMenuItem miEditOrderByValue;
		private System.Windows.Forms.TableLayoutPanel tlpResults;
		private System.Windows.Forms.TextBox tbResultsSearch;
		private System.Windows.Forms.ToolStripMenuItem miFileExportCSharpClasses;
	}
}


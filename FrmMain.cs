using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocolParser.Data;
using ProtocolParser.Factory;
using ProtocolParser.Extensions;

namespace ProtocolParser
{
    public partial class FrmMain : Form
    {
        private static readonly Color NotFoundColor = Color.DarkGray;

        private readonly Stopwatch _loadWatch;
        private ProtocolInfo _protocolInfo;
        private bool _saved;
        private string _saveLocation;

        public FrmMain()
        {
            InitializeComponent();
            _loadWatch = new Stopwatch();
        }

        private void fileStripOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Open Protocol Info File",
                Filter = "Protocol Parser Binary|*.ppb|C Header File|*.h",
                CheckFileExists = true
                // InitialDirectory = @"D:\Projects\Fiesta\Resources"
            };

            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;

            var s = Path.GetExtension(openFileDialog.FileName);
            if (s == null)
                return;

            var extension = s.Replace(".", "");
            switch (extension.ToLower())
            {
                case "h":
                    LoadHeaderFile(openFileDialog.FileName);
                    break;
                case "ppb":
                    _saved = true;
                    _saveLocation = openFileDialog.FileName;
                    using (var fileStream = File.OpenRead(_saveLocation))
                    using (var reader = new BinaryReader(fileStream, Encoding.UTF8))
                    {
                        _protocolInfo = reader.Read<ProtocolInfo>();
                    }

                    DisplayProtocolInfo();
                    break;
            }
        }

        private void tvProtocols_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var protocol = protocolsTree.SelectedNode.Tag as Protocol;

            rtbProtocolDetails.Text = protocol != null
                ? protocol.Structure
                : string.Empty;
        }

        private void miFileExportCSharpClasses_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            /*var folderBrowserDialog = new FolderBrowserDialog();
            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
                return;

            foreach (var protocolGroup in _protocolInfo.Groups)
            {
                var protocols = new List<string>();

                foreach (var protocol in protocolGroup.Protocols)
                {
                    var name = protocol.Name.Replace($"{protocolGroup.Name}_", "");

                    if (name.StartsWith("2"))
                    {
                        name = name.Substring(1);
                        name = $"TO_{name}";
                    }

                    var groupName = protocolGroup.Id
                        .Replace("0x", "")
                        .PadLeft(2, '0');

                    var protocolValue = protocol.Value
                        .Replace("0x", "")
                        .PadLeft(2, '0');

                    protocols.Add(
                        $"\t\t{name} = 0x{groupName}{protocolValue},");
                }

                var content =
                    "using System;\r\n\r\nnamespace {0}\r\n{{\r\n\tpublic enum {1} : UInt16\r\n\t{{\r\n{2}\r\n\t}}\r\n}}";

                content = string.Format(content, "Fiesta.Game.Networking.PacketTypes",
                    protocolGroup.Name.Replace("NC_", ""), string.Join(Environment.NewLine, protocols));

                File.WriteAllText(
                    $"{folderBrowserDialog.SelectedPath}\\{protocolGroup.Name.Replace("NC_", "")}.cs", content);
            }*/
        }

        private void miEditOrderByValue_Click(object sender, EventArgs e)
        {
            if (_protocolInfo == null)
                return;

            /*_protocolInfo.Groups = _protocolInfo.Groups
                .OrderBy(x => int.Parse(x.Value.Replace("0x", ""), NumberStyles.HexNumber))
                .ToList();

            foreach (var protocolGroup in _protocolInfo.ProtocolGroups)
                protocolGroup.Protocols = protocolGroup.Protocols
                    .OrderBy(x => int.Parse(x.Value.Replace("0x", ""), NumberStyles.HexNumber))
                    .ToList();

            DisplayProtocolInfo();*/
        }

        private void tbResultsSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            var content = tbResultsSearch.Text.Trim();
            if (content.Length <= 0)
                return; // Prevent searching if there is no input.

            // Detect if we are searching for a string.
            var isNumeric = int.TryParse(content, out var searchFor);
            if (isNumeric)
            {
                // Search for a number.

                var group = (byte) (searchFor >> 10);
                var type = (ushort) (searchFor & 0x400);

                var protocolGroup = _protocolInfo.Groups
                    .First(x => x.Id == group);

                if (protocolGroup == null)
                    return;

                var parentTreeNode = protocolsTree.Nodes.Cast<TreeNode>()
                    .First(x => x.Tag == protocolGroup);

                if (parentTreeNode == null)
                    return;

                var protocol = protocolGroup.Protocols
                    .First(x => x.Id == type);

                if (protocol != null)
                {
                    var childTreeNode = parentTreeNode.Nodes
                        .Cast<TreeNode>().First(x => x.Tag == protocol);

                    if (childTreeNode != null)
                        protocolsTree.SelectedNode = childTreeNode;
                }
                else
                {
                    protocolsTree.SelectedNode = parentTreeNode;
                }
            }
            else
            {
                // TODO Search trough the groupnames.
                var result = _protocolInfo.Groups
                    .FirstOrDefault(group => group.Name.StartsWith(content) || group.Name.Contains(content) ||
                                             group.Name.ToLower().Equals(content.ToLower()));

                if (result != null)
                {
                    protocolsTree.Focus();
                    return;
                }
            }

            protocolsTree.Focus();
        }

        private void DisplayProtocolInfo()
        {
            if (_protocolInfo == null)
                return;

            // Enable save buttons if needed.
            var protocolDataExists = _protocolInfo != null;

            fileStripSaveAs.Enabled = protocolDataExists;
            fileStripSave.Enabled = protocolDataExists;

            protocolsTree.Nodes.Clear();

            foreach (var protocolGroup in _protocolInfo.Groups)
            {
                var protocolGroupTreeNode = new TreeNode($"{protocolGroup.Name} ({protocolGroup.Id})")
                {
                    Tag = protocolGroup
                };

                if (protocolGroup.Protocols.Count <= 0)
                {
                    protocolGroupTreeNode.BackColor = NotFoundColor;
                }

                foreach (var protocol in protocolGroup.Protocols)
                {
                    var protocolTreeNode = new TreeNode($"{protocol.Name} ({protocol.Id:X2})")
                    {
                        Tag = protocol,
                        BackColor = protocol.HasNoStructure ? NotFoundColor : Color.Empty,
                    };
                    
                    protocolGroupTreeNode.Nodes.Add(protocolTreeNode);
                }

                protocolsTree.Nodes.Add(protocolGroupTreeNode);
            }
        }

        private void LoadHeaderFile(string path)
        {
            _saved = false;
            protocolsTree.Nodes.Clear();

            var backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            backgroundWorker.DoWork += (doWorkSender, doWorkEventArgs) =>
            {
                _protocolInfo = ProtocolInfoFactory.ParseFromHeader(path, (BackgroundWorker) doWorkSender);
            };

            backgroundWorker.ProgressChanged += (doWorkSender, doWorkEventArgs) =>
            {
                if (doWorkEventArgs.UserState == null)
                    return;

                var info = doWorkEventArgs.UserState as ProtocolInfo;
                if (info != null)
                {
                    tsslStatus.Text = $"Loading Protocol Info Version: {info.InfoVersion}";
                }
                else if (doWorkEventArgs.UserState is ProtocolGroup)
                {
                    var group = (ProtocolGroup) doWorkEventArgs.UserState;
                    tsslStatus.Text = $"Loading Protocol Group {group.Name}";
                }
                else if (doWorkEventArgs.UserState is Protocol)
                {
                    var protocol = (Protocol) doWorkEventArgs.UserState;
                    tsslStatus.Text = $"Loading Protocol {protocol.Name}";
                }
            };

            backgroundWorker.RunWorkerCompleted += (sender, args) =>
            {
                _loadWatch.Stop();
                DisplayProtocolInfo();
                tsslStatus.Text = $"Completed in {_loadWatch.ElapsedMilliseconds}ms";
            };

            _loadWatch.Restart();
            backgroundWorker.RunWorkerAsync();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void fileStripSave_Click(object sender, EventArgs e)
        {
            SaveContent(false);
        }

        private void fileStripSaveAs_Click(object sender, EventArgs e)
        {
            SaveContent(true);
        }

        private void SaveContent(bool forceSave)
        {
            if (_protocolInfo == null)
                return;

            // Show dialog if it is a force save or no save has been made.
            if (forceSave || !_saved)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Title = "Save Protocol Parser Binary",
                    Filter = "Protocol Parser Binary|*.ppb",
                    // InitialDirectory = @"D:\Projects\Fiesta\Resources"
                };

                var dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                    return;

                _saveLocation = saveFileDialog.FileName;
            }
            
            try
            {
                using (var fileStream = File.Create(_saveLocation))
                using (var writer = new BinaryWriter(fileStream, Encoding.UTF8))
                {
                    writer.Write(_protocolInfo);
                }

                _saved = true;

                MessageBox.Show(
                    "Parser Binary succesfully exported!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to export Parser Binary file:\n {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
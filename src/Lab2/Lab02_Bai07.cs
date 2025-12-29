using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab02_Bai07 : Form
    {
        public Lab02_Bai07()
        {
            InitializeComponent();
        }

        private void Lab02_Bai07_Load(object sender, EventArgs e)
        {
            treeViewFiles.BeforeExpand += treeViewFiles_BeforeExpand;
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            treeViewFiles.NodeMouseDoubleClick += treeViewFiles_NodeMouseDoubleClick;

            LoadDrives();
        }

        private void LoadDrives()
        {
            treeViewFiles.Nodes.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (!drive.IsReady) continue;

                    TreeNode driveNode = new TreeNode(drive.Name);
                    driveNode.Tag = drive;
                    driveNode.Nodes.Add("...");
                    treeViewFiles.Nodes.Add(driveNode);
                }
                catch { }
            }
        }

        private void treeViewFiles_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            DirectoryInfo directory = null;
            if (e.Node.Tag is DriveInfo drive)
                directory = drive.RootDirectory;
            else if (e.Node.Tag is DirectoryInfo dir)
                directory = dir;
            else
                return;

            try
            {
                foreach (DirectoryInfo subDir in directory.GetDirectories())
                {
                    TreeNode dirNode = new TreeNode(subDir.Name);
                    dirNode.Tag = subDir;
                    dirNode.Nodes.Add("...");
                    e.Node.Nodes.Add(dirNode);
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    fileNode.Tag = file;
                    e.Node.Nodes.Add(fileNode);
                }
            }
            catch { }
        }

        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFileContentFromNode(e.Node);
        }

        private void treeViewFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowFileContentFromNode(e.Node);
        }

        private void ShowFileContentFromNode(TreeNode node)
        {
            if (node == null) return;

            fileContentBox.Clear();

            if (node.Tag is DirectoryInfo dir)
            {
                fileContentBox.Text = "[Thư mục] " + dir.FullName;
                return;
            }

            if (node.Tag is DriveInfo drive)
            {
                fileContentBox.Text = "[Ổ đĩa] " + drive.Name;
                return;
            }

            if (node.Tag is FileInfo file)
            {
                try
                {
                    string ext = Path.GetExtension(file.FullName).ToLowerInvariant();

                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                    {
                        InsertImageToRichTextBox(file.FullName);
                        return;
                    }

                    string text;
                    using (var reader = new StreamReader(file.FullName, Encoding.UTF8, true))
                    {
                        text = reader.ReadToEnd();
                    }

                    int nonPrintableCount = text.Count(ch => char.IsControl(ch) && ch != '\r' && ch != '\n' && ch != '\t');

                    if (nonPrintableCount > 50)
                    {
                        fileContentBox.Text = "Không hỗ trợ xem trực tiếp file nhị phân: " + file.Name;
                    }
                    else
                    {
                        fileContentBox.Text = text;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    fileContentBox.Text = "Không có quyền đọc file này.";
                }
                catch (Exception ex)
                {
                    fileContentBox.Text = "Lỗi khi đọc file: " + ex.Message;
                }
            }
        }

        private void InsertImageToRichTextBox(string imagePath)
        {
            try
            {
                using (Image img = Image.FromFile(imagePath))
                {
                    Clipboard.SetImage(img);
                    fileContentBox.Clear();
                    fileContentBox.Paste();
                }
            }
            catch
            {
                fileContentBox.Text = "Không thể hiển thị ảnh này.";
            }
        }
    }
}

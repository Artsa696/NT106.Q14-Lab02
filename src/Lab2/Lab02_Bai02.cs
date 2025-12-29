using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2
{
    public partial class Lab02_Bai02 : Form
    {
        public Lab02_Bai02()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fullPath = ofd.FileName;
                    txtFileName.Text = ofd.SafeFileName;
                    txtUrl.Text = fullPath;

                    FileInfo fileInfo = new FileInfo(fullPath);
                    txtSize.Text = fileInfo.Length.ToString() + " bytes";

                    string fullContent;
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        fullContent = sr.ReadToEnd();
                    }

                    rtbContent.Text = fullContent;

                    txtCharCount.Text = fullContent.Length.ToString();

                    int lineCount = File.ReadAllLines(fullPath).Length;
                    txtLineCount.Text = lineCount.ToString();

                    char[] delimiters = new char[] { ' ', '\r', '\n', '\t' };
                    string[] words = fullContent.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    txtWordCount.Text = words.Length.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                }
            }
        }
    }
}

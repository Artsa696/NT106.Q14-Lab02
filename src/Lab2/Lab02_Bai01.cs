using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab02_Bai01 : Form
    {
        private string rawContent = "";
        private const string inputFile = "input1.txt";
        private const string outputFile = "output1.txt";

        public Lab02_Bai01()
        {
            InitializeComponent();
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fullPath = ofd.FileName;
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        string fileContent = sr.ReadToEnd();
                        rtbDisplay.Text = fileContent;
                        rawContent = fileContent;
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy file. Hãy kiểm tra đường dẫn.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi đọc file: " + ex.Message);
                }
            }
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            string outputFilePath = "output1.txt";

            try
            {
                string content = rtbDisplay.Text;
                string upperCaseContent = content.ToUpper();

                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    sw.Write(upperCaseContent);
                }

                MessageBox.Show("Đã ghi file 'output1.txt' thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi ghi file: " + ex.Message);
            }
        }

        private void richTextBoxHienThi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

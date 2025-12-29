using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab02_Bai04 : Form
    {
        private List<Student> students = new List<Student>();
        private string inputFile = "input4.txt";

        public Lab02_Bai04()
        {
            InitializeComponent();
        }

        private void labelCharCount_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void Lab02_Bai04cs_Load(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(inputFile, rtbInputDisplay.Text);
                MessageBox.Show($"Đã ghi nội dung vào file '{inputFile}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string error))
            {
                MessageBox.Show(error, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse values
            int mssv = int.Parse(txtID.Text.Trim());
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            TryParseFlexibleFloat(txtCourse1.Text, out float c1);
            TryParseFlexibleFloat(txtCourse2.Text, out float c2);
            TryParseFlexibleFloat(txtCourse3.Text, out float c3);

            Student st = new Student
            {
                Name = name,
                MSSV = mssv,
                Phone = phone,
                Course1 = c1,
                Course2 = c2,
                Course3 = c3
            };
            st.Average = (st.Course1 + st.Course2 + st.Course3) / 3f;
            st.Average = (float)Math.Round(st.Average, 2);

            // Append to richtextbox (format same as spec)
            rtbInputDisplay.AppendText(st.Name + Environment.NewLine);
            rtbInputDisplay.AppendText(st.MSSV + Environment.NewLine);
            rtbInputDisplay.AppendText(st.Phone + Environment.NewLine);
            rtbInputDisplay.AppendText(st.Course1 + Environment.NewLine);
            rtbInputDisplay.AppendText(st.Course2 + Environment.NewLine);
            rtbInputDisplay.AppendText(st.Course3 + Environment.NewLine);
            rtbInputDisplay.AppendText(st.Average + Environment.NewLine + Environment.NewLine);

            // Save to file
            try
            {
                File.WriteAllText(inputFile, rtbInputDisplay.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clear inputs
            txtName.Clear(); txtID.Clear(); txtPhone.Clear(); txtCourse1.Clear(); txtCourse2.Clear(); txtCourse3.Clear();

            // Also add to in-memory list for immediate navigation
            students.Add(st);
            lblPageNumber.Text = $"{students.Count} / {students.Count}";
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    MessageBox.Show($"Không tìm thấy file '{inputFile}'. Vui lòng tạo và ghi dữ liệu trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] lines = File.ReadAllLines(inputFile);
                List<string> nonEmpty = new List<string>();
                foreach (var ln in lines)
                {
                    if (!string.IsNullOrWhiteSpace(ln)) nonEmpty.Add(ln.Trim());
                }

                students.Clear();

                for (int i = 0; i + 6 < nonEmpty.Count; i += 7)
                {
                    try
                    {
                        var st = new Student();
                        st.Name = nonEmpty[i];
                        st.MSSV = int.TryParse(nonEmpty[i + 1], out int idv) ? idv : 0;
                        st.Phone = nonEmpty[i + 2];
                        TryParseFlexibleFloat(nonEmpty[i + 3], out float f1);
                        TryParseFlexibleFloat(nonEmpty[i + 4], out float f2);
                        TryParseFlexibleFloat(nonEmpty[i + 5], out float f3);
                        st.Course1 = f1; st.Course2 = f2; st.Course3 = f3;
                        TryParseFlexibleFloat(nonEmpty[i + 6], out float favg);
                        st.Average = favg;
                        students.Add(st);
                    }
                    catch
                    {
                        // ignore malformed block
                    }
                }

                rtbInputDisplay.Text = string.Join(Environment.NewLine, lines);

                if (students.Count > 0)
                {
                    ShowObject(0);
                    MessageBox.Show($"Đã đọc {students.Count} sinh viên từ file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File không chứa sinh viên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (students.Count == 0) return;
            int current = 1;
            if (!string.IsNullOrWhiteSpace(lblPageNumber.Text))
            {
                var parts = lblPageNumber.Text.Split('/');
                if (parts.Length >= 1 && int.TryParse(parts[0].Trim(), out int p)) current = p;
            }
            int next = current == students.Count ? 1 : current + 1;
            ShowObject(next - 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (students.Count == 0) return;
            int current = 1;
            if (!string.IsNullOrWhiteSpace(lblPageNumber.Text))
            {
                var parts = lblPageNumber.Text.Split('/');
                if (parts.Length >= 1 && int.TryParse(parts[0].Trim(), out int p)) current = p;
            }
            int prev = current == 1 ? students.Count : current - 1;
            ShowObject(prev - 1);
        }

        private void ShowObject(int index)
        {
            if (index < 0 || index >= students.Count) return;
            var s = students[index];
            txtDisplayName.Text = s.Name;
            txtDisplayID.Text = s.MSSV.ToString();
            txtDisplayPhone.Text = s.Phone;
            txtDisplayCourse1.Text = s.Course1.ToString();
            txtDisplayCourse2.Text = s.Course2.ToString();
            txtDisplayCourse3.Text = s.Course3.ToString();
            txtDisplayAverage.Text = s.Average.ToString("F2");
            lblPageNumber.Text = $"{index + 1} / {students.Count}";
        }

        private bool TryParseFlexibleFloat(string s, out float value)
        {
            s = (s ?? string.Empty).Trim();
            if (float.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out value)) return true;
            s = s.Replace(',', '.');
            return float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private bool ValidateInputs(out string error)
        {
            error = string.Empty;
            string name = (txtName.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(name))
            {
                error = "Vui lòng nhập Họ và tên."; return false;
            }

            string idText = (txtID.Text ?? string.Empty).Trim();
            if (idText.Length != 8 || !idText.All(char.IsDigit))
            {
                error = "Mã số sinh viên phải gồm đúng 8 chữ số."; return false;
            }

            string phone = (txtPhone.Text ?? string.Empty).Trim();
            if (phone.Length != 10 || phone[0] != '0' || !phone.All(char.IsDigit))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng '0'."; return false;
            }

            if (!TryParseFlexibleFloat(txtCourse1.Text, out float c1) || c1 < 0f || c1 > 10f)
            { error = "Điểm môn 1 phải là số trong khoảng 0 đến 10."; return false; }
            if (!TryParseFlexibleFloat(txtCourse2.Text, out float c2) || c2 < 0f || c2 > 10f)
            { error = "Điểm môn 2 phải là số trong khoảng 0 đến 10."; return false; }
            if (!TryParseFlexibleFloat(txtCourse3.Text, out float c3) || c3 < 0f || c3 > 10f)
            { error = "Điểm môn 3 phải là số trong khoảng 0 đến 10."; return false; }

            return true;
        }

        [Serializable]
        private class Student
        {
            public string Name { get; set; } = string.Empty;
            public int MSSV { get; set; }
            public string Phone { get; set; } = string.Empty;
            public float Course1 { get; set; }
            public float Course2 { get; set; }
            public float Course3 { get; set; }
            public float Average { get; set; }
        }
    }
}

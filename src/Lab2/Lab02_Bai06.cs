using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Lab02_Bai06 : Form
    {
         public Lab02_Bai06()
         {
             InitializeComponent();
         }

        private void btnInitDb_Click(object sender, EventArgs e)
        {
            try
            {
                DbHelper.InitDatabase();
                MessageBox.Show("Đã tạo/kiểm tra database thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo DB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtUserID.Text.Trim(), out id) || string.IsNullOrEmpty(txtUserID.Text.Trim()))
                {
                    id = DbHelper.GetNextUserId();
                }
                var name = txtUserName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên user rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var role = cbUserRole.SelectedItem?.ToString() ?? "User";
                DbHelper.InsertNguoiDung(id, name, role);
                MessageBox.Show($"Đã thêm/cập nhật user (ID={id}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Text = id.ToString();
                RefreshContributors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm user: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIDMA.Text.Trim(), out int id))
                {
                    MessageBox.Show("ID món không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var ten = txtTenMon.Text.Trim();
                var hinh = txtHinh.Text.Trim();
                int idncc = 0;
                if (cmbIDNCC.SelectedItem is int sel) idncc = sel;

                DbHelper.InsertMonAn(id, ten, hinh, idncc);
                MessageBox.Show("Đã thêm/cập nhật món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                lvMonAn.Items.Clear();
                var items = DbHelper.LoadMonAnWithNguoiDung();
                // sort by ID ascending
                items = items.OrderBy(x => x.IDMA).ToList();
                foreach (var it in items)
                {
                    var lvi = new ListViewItem(it.IDMA.ToString());
                    lvi.SubItems.Add(it.TenMonAn);
                    var role = GetUserRole(it.IDNCC);
                    lvi.SubItems.Add(string.IsNullOrEmpty(it.HoVaTen) ? "" : it.HoVaTen + " (" + role + ")");
                    lvi.Tag = it;
                    lvMonAn.Items.Add(lvi);
                }
                RefreshContributors();
                MessageBox.Show($"Đã tải {items.Count} món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMonAn.SelectedItems.Count == 0) return;
            var tag = ((int IDMA, string TenMonAn, string HinhAnh, int IDNCC, string HoVaTen))lvMonAn.SelectedItems[0].Tag;
            lblContributor.Text = "Người đóng góp: " + tag.HoVaTen;
            try
            {
                if (!string.IsNullOrEmpty(tag.HinhAnh) && File.Exists(tag.HinhAnh))
                {
                    using var fs = new FileStream(tag.HinhAnh, FileMode.Open, FileAccess.Read);
                    pbImage.Image = Image.FromStream(fs);
                }
                else pbImage.Image = null;
            }
            catch { pbImage.Image = null; }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var pick = DbHelper.GetRandomMonAn();
                if (pick == null)
                {
                    MessageBox.Show("Không có món trong DB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var p = pick.Value;
                lblContributor.Text = "Người đóng góp: " + p.HoVaTen;
                var role = GetUserRole(p.IDNCC);
                if (!string.IsNullOrEmpty(role)) lblContributor.Text += " (" + role + ")";

                try
                {
                    if (!string.IsNullOrEmpty(p.HinhAnh) && File.Exists(p.HinhAnh))
                    {
                        using var fs = new FileStream(p.HinhAnh, FileMode.Open, FileAccess.Read);
                        pbImage.Image = Image.FromStream(fs);
                    }
                    else pbImage.Image = null;
                }
                catch { pbImage.Image = null; }

                MessageBox.Show($"Món được chọn: {p.TenMonAn}\nNgười đóng góp: {p.HoVaTen}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn ngẫu nhiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserRole(int idncc)
        {
            try
            {
                var users = DbHelper.LoadNguoiDung();
                var u = users.FirstOrDefault(x => x.IDNCC == idncc);
                return u == default ? "" : u.QuyenHan;
            }
            catch { return ""; }
        }

        private void RefreshContributors()
        {
            try
            {
                cmbIDNCC.Items.Clear();
                var users = DbHelper.LoadNguoiDung();
                foreach (var u in users)
                {
                    cmbIDNCC.Items.Add(u.IDNCC);
                }
                if (cmbIDNCC.Items.Count > 0) cmbIDNCC.SelectedIndex = 0;
            }
            catch { }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                txtHinh.Text = dlg.FileName;
            }
        }

        private void btnInputUserID_Click(object sender, EventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Nhập ID user (số):", "Nhập ID", "");
            if (int.TryParse(input, out int id))
            {
                txtUserID.Text = id.ToString();
            }
            else if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChooseRole_Click(object sender, EventArgs e)
        {
            using var dlg = new Form();
            dlg.Text = "Chọn vai trò";
            dlg.ClientSize = new Size(260, 120);

            var rbUser = new RadioButton() { Text = "User", Location = new Point(20, 20), Checked = true };
            var rbAdmin = new RadioButton() { Text = "Admin", Location = new Point(20, 50) };
            var btnOk = new Button() { Text = "OK", Location = new Point(150, 70), DialogResult = DialogResult.OK };
            dlg.Controls.Add(rbUser);
            dlg.Controls.Add(rbAdmin);
            dlg.Controls.Add(btnOk);
            dlg.AcceptButton = btnOk;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                cbUserRole.SelectedItem = rbAdmin.Checked ? "Admin" : "User";
            }
        }
    }
}

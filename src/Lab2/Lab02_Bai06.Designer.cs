namespace Lab2
{
    partial class Lab02_Bai06
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
            txtIDMA = new TextBox();
            txtTenMon = new TextBox();
            txtHinh = new TextBox();
            btnAddMon = new Button();
            btnLoad = new Button();
            lvMonAn = new ListView();
            chID = new ColumnHeader();
            chName = new ColumnHeader();
            chContributor = new ColumnHeader();
            pbImage = new PictureBox();
            lblContributor = new Label();
            btnRandom = new Button();
            btnInitDb = new Button();
            txtUserID = new TextBox();
            txtUserName = new TextBox();
            btnAddUser = new Button();
            cbUserRole = new ComboBox();
            btnChooseRole = new Button();
            btnBrowseImage = new Button();
            btnInputUserID = new Button();
            cmbIDNCC = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // txtIDMA
            // 
            txtIDMA.Location = new Point(12, 12);
            txtIDMA.Name = "txtIDMA";
            txtIDMA.PlaceholderText = "IDMA";
            txtIDMA.Size = new Size(100, 27);
            txtIDMA.TabIndex = 0;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(120, 12);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.PlaceholderText = "TenMonAn";
            txtTenMon.Size = new Size(200, 27);
            txtTenMon.TabIndex = 1;
            // 
            // txtHinh
            // 
            txtHinh.Location = new Point(330, 12);
            txtHinh.Name = "txtHinh";
            txtHinh.PlaceholderText = "HinhAnh (path)";
            txtHinh.Size = new Size(200, 27);
            txtHinh.TabIndex = 2;
            // 
            // btnAddMon
            // 
            btnAddMon.Location = new Point(794, 13);
            btnAddMon.Name = "btnAddMon";
            btnAddMon.Size = new Size(120, 27);
            btnAddMon.TabIndex = 4;
            btnAddMon.Text = "Thêm món";
            btnAddMon.Click += btnAddMon_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 45);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 30);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Tải danh sách";
            btnLoad.Click += btnLoad_Click;
            // 
            // lvMonAn
            // 
            lvMonAn.Columns.AddRange(new ColumnHeader[] { chID, chName, chContributor });
            lvMonAn.FullRowSelect = true;
            lvMonAn.Location = new Point(12, 90);
            lvMonAn.Name = "lvMonAn";
            lvMonAn.Size = new Size(400, 300);
            lvMonAn.TabIndex = 6;
            lvMonAn.UseCompatibleStateImageBehavior = false;
            lvMonAn.View = View.Details;
            lvMonAn.SelectedIndexChanged += lvMonAn_SelectedIndexChanged;
            // 
            // chID
            // 
            chID.Text = "ID";
            chID.Width = 90;
            // 
            // chName
            // 
            chName.Text = "Tên";
            chName.Width = 110;
            // 
            // chContributor
            // 
            chContributor.Text = "Người đóng góp";
            chContributor.Width = 180;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(420, 90);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(330, 220);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 7;
            pbImage.TabStop = false;
            // 
            // lblContributor
            // 
            lblContributor.Location = new Point(420, 320);
            lblContributor.Name = "lblContributor";
            lblContributor.Size = new Size(330, 30);
            lblContributor.TabIndex = 8;
            lblContributor.Text = "Người đóng góp: ";
            // 
            // btnRandom
            // 
            btnRandom.Location = new Point(420, 360);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(120, 30);
            btnRandom.TabIndex = 9;
            btnRandom.Text = "Chọn ngẫu nhiên";
            btnRandom.Click += btnRandom_Click;
            // 
            // btnInitDb
            // 
            btnInitDb.Location = new Point(657, 48);
            btnInitDb.Name = "btnInitDb";
            btnInitDb.Size = new Size(120, 30);
            btnInitDb.TabIndex = 10;
            btnInitDb.Text = "Tạo DB";
            btnInitDb.Click += btnInitDb_Click;
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(12, 48);
            txtUserID.Name = "txtUserID";
            txtUserID.PlaceholderText = "IDNCC (user)";
            txtUserID.Size = new Size(100, 27);
            txtUserID.TabIndex = 11;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(138, 48);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "HoVaTen";
            txtUserName.Size = new Size(200, 27);
            txtUserName.TabIndex = 12;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(434, 48);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(100, 27);
            btnAddUser.TabIndex = 14;
            btnAddUser.Text = "Thêm user";
            btnAddUser.Click += btnAddUser_Click;
            // 
            // cbUserRole
            // 
            cbUserRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserRole.Items.AddRange(new object[] { "User", "Admin" });
            cbUserRole.Location = new Point(330, 12);
            cbUserRole.Name = "cbUserRole";
            cbUserRole.Size = new Size(100, 28);
            cbUserRole.TabIndex = 13;
            // 
            // btnChooseRole
            // 
            btnChooseRole.Location = new Point(540, 47);
            btnChooseRole.Name = "btnChooseRole";
            btnChooseRole.Size = new Size(100, 28);
            btnChooseRole.TabIndex = 14;
            btnChooseRole.Text = "Chọn vai trò";
            btnChooseRole.Click += btnChooseRole_Click;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(540, 12);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(100, 27);
            btnBrowseImage.TabIndex = 3;
            btnBrowseImage.Text = "Chọn ảnh";
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // btnInputUserID
            // 
            btnInputUserID.Location = new Point(344, 48);
            btnInputUserID.Name = "btnInputUserID";
            btnInputUserID.Size = new Size(86, 27);
            btnInputUserID.TabIndex = 12;
            btnInputUserID.Text = "Nhập ID";
            btnInputUserID.Click += btnInputUserID_Click;
            // 
            // cmbIDNCC
            // 
            cmbIDNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIDNCC.Location = new Point(657, 11);
            cmbIDNCC.Name = "cmbIDNCC";
            cmbIDNCC.Size = new Size(120, 28);
            cmbIDNCC.TabIndex = 3;
            // 
            // Lab02_Bai06
            // 
            ClientSize = new Size(970, 581);
            Controls.Add(txtIDMA);
            Controls.Add(txtTenMon);
            Controls.Add(txtHinh);
            Controls.Add(cmbIDNCC);
            Controls.Add(btnBrowseImage);
            Controls.Add(btnAddMon);
            Controls.Add(btnLoad);
            Controls.Add(lvMonAn);
            Controls.Add(pbImage);
            Controls.Add(lblContributor);
            Controls.Add(btnRandom);
            Controls.Add(btnInitDb);
            Controls.Add(txtUserID);
            Controls.Add(btnInputUserID);
            Controls.Add(txtUserName);
            Controls.Add(cbUserRole);
            Controls.Add(btnAddUser);
            Controls.Add(btnChooseRole);
            Name = "Lab02_Bai06";
            Text = "Lab02_Bai06";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtIDMA;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtHinh;
        private System.Windows.Forms.Button btnAddMon;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListView lvMonAn;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chContributor;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblContributor;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnInitDb;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ComboBox cbUserRole;
        private System.Windows.Forms.Button btnChooseRole;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnInputUserID;
        private System.Windows.Forms.ComboBox cmbIDNCC;
    }
 }
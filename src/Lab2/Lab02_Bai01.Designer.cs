namespace Lab2
{
    partial class Lab02_Bai01
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDoc = new Button();
            btnGhi = new Button();
            rtbDisplay = new RichTextBox();
            SuspendLayout();
            // 
            // btnDoc
            // 
            btnDoc.Location = new Point(42, 75);
            btnDoc.Name = "btnDoc";
            btnDoc.Size = new Size(94, 29);
            btnDoc.TabIndex = 0;
            btnDoc.Text = "Đọc file";
            btnDoc.UseVisualStyleBackColor = true;
            btnDoc.Click += btnDocFile_Click;
            // 
            // btnGhi
            // 
            btnGhi.Location = new Point(42, 134);
            btnGhi.Name = "btnGhi";
            btnGhi.Size = new Size(94, 29);
            btnGhi.TabIndex = 1;
            btnGhi.Text = "Ghi file";
            btnGhi.UseVisualStyleBackColor = true;
            btnGhi.Click += btnGhiFile_Click;
            // 
            // rtbDisplay
            // 
            rtbDisplay.Location = new Point(313, 75);
            rtbDisplay.Name = "rtbDisplay";
            rtbDisplay.Size = new Size(441, 192);
            rtbDisplay.TabIndex = 2;
            rtbDisplay.Text = "";
            rtbDisplay.TextChanged += richTextBoxHienThi_TextChanged;
            // 
            // Lab02_Bai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbDisplay);
            Controls.Add(btnGhi);
            Controls.Add(btnDoc);
            Name = "Lab02_Bai01";
            Text = "Lab02_Bai01";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDoc;
        private Button btnGhi;
        private RichTextBox rtbDisplay;
    }
}

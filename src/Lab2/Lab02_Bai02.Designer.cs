namespace Lab2
{
    partial class Lab02_Bai02
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
            this.components = new System.ComponentModel.Container();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labelLineCount = new System.Windows.Forms.Label();
            this.labelWordCount = new System.Windows.Forms.Label();
            this.labelCharCount = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtLineCount = new System.Windows.Forms.TextBox();
            this.txtWordCount = new System.Windows.Forms.TextBox();
            this.txtCharCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(260, 28);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read from File";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 360);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(260, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(290, 12);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(490, 383);
            this.rtbContent.TabIndex = 2;
            this.rtbContent.Text = string.Empty;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 60);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(57, 13);
            this.labelFileName.TabIndex = 3;
            this.labelFileName.Text = "File name";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(100, 57);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(172, 20);
            this.txtFileName.TabIndex = 4;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(12, 95);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 13);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(100, 92);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(172, 20);
            this.txtSize.TabIndex = 6;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(12, 132);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(29, 13);
            this.labelUrl.TabIndex = 7;
            this.labelUrl.Text = "URL";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(100, 129);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(172, 20);
            this.txtUrl.TabIndex = 8;
            // 
            // labelLineCount
            // 
            this.labelLineCount.AutoSize = true;
            this.labelLineCount.Location = new System.Drawing.Point(12, 168);
            this.labelLineCount.Name = "labelLineCount";
            this.labelLineCount.Size = new System.Drawing.Size(62, 13);
            this.labelLineCount.TabIndex = 9;
            this.labelLineCount.Text = "Line count";
            // 
            // txtLineCount
            // 
            this.txtLineCount.Location = new System.Drawing.Point(100, 165);
            this.txtLineCount.Name = "txtLineCount";
            this.txtLineCount.ReadOnly = true;
            this.txtLineCount.Size = new System.Drawing.Size(172, 20);
            this.txtLineCount.TabIndex = 10;
            // 
            // labelWordCount
            // 
            this.labelWordCount.AutoSize = true;
            this.labelWordCount.Location = new System.Drawing.Point(12, 205);
            this.labelWordCount.Name = "labelWordCount";
            this.labelWordCount.Size = new System.Drawing.Size(71, 13);
            this.labelWordCount.TabIndex = 11;
            this.labelWordCount.Text = "Words count";
            // 
            // txtWordCount
            // 
            this.txtWordCount.Location = new System.Drawing.Point(100, 202);
            this.txtWordCount.Name = "txtWordCount";
            this.txtWordCount.ReadOnly = true;
            this.txtWordCount.Size = new System.Drawing.Size(172, 20);
            this.txtWordCount.TabIndex = 12;
            // 
            // labelCharCount
            // 
            this.labelCharCount.AutoSize = true;
            this.labelCharCount.Location = new System.Drawing.Point(12, 242);
            this.labelCharCount.Name = "labelCharCount";
            this.labelCharCount.Size = new System.Drawing.Size(87, 13);
            this.labelCharCount.TabIndex = 13;
            this.labelCharCount.Text = "Character count";
            // 
            // txtCharCount
            // 
            this.txtCharCount.Location = new System.Drawing.Point(100, 239);
            this.txtCharCount.Name = "txtCharCount";
            this.txtCharCount.ReadOnly = true;
            this.txtCharCount.Size = new System.Drawing.Size(172, 20);
            this.txtCharCount.TabIndex = 14;
            // 
            // Lab02_Bai02
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 407);
            this.Controls.Add(this.txtCharCount);
            this.Controls.Add(this.labelCharCount);
            this.Controls.Add(this.txtWordCount);
            this.Controls.Add(this.labelWordCount);
            this.Controls.Add(this.txtLineCount);
            this.Controls.Add(this.labelLineCount);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab02_Bai02";
            this.Text = "Bai2";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.Label labelLineCount;
        private System.Windows.Forms.Label labelWordCount;
        private System.Windows.Forms.Label labelCharCount;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtLineCount;
        private System.Windows.Forms.TextBox txtWordCount;
        private System.Windows.Forms.TextBox txtCharCount;
    }
}
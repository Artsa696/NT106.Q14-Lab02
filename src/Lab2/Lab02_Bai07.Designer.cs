namespace Lab2
{
    partial class Lab02_Bai07
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
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.fileContentBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewFiles.Location = new System.Drawing.Point(0, 0);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(329, 602);
            this.treeViewFiles.TabIndex = 0;
            // 
            // fileContentBox
            // 
            this.fileContentBox.Location = new System.Drawing.Point(335, 0);
            this.fileContentBox.Name = "fileContentBox";
            this.fileContentBox.Size = new System.Drawing.Size(679, 602);
            this.fileContentBox.TabIndex = 1;
            this.fileContentBox.Text = "";
            // 
            // Lab02_Bai07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 602);
            this.Controls.Add(this.treeViewFiles);
            this.Controls.Add(this.fileContentBox);
            this.Name = "Lab02_Bai07";
            this.Text = "Lab02_Bai07";
            this.Load += new System.EventHandler(this.Lab02_Bai07_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.RichTextBox fileContentBox;
    }
}
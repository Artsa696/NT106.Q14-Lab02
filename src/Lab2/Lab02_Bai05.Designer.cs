namespace Lab2
{
    partial class Lab02_Bai05
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Text = "Lab02_Bai05";

            // RichTextBox for input5.txt
            this.rtbInputDisplay = new System.Windows.Forms.RichTextBox();
            this.rtbInputDisplay.Location = new System.Drawing.Point(12, 12);
            this.rtbInputDisplay.Size = new System.Drawing.Size(676, 380);
            this.rtbInputDisplay.Name = "rtbInputDisplay";
            this.Controls.Add(this.rtbInputDisplay);

            // Read button
            this.btnReadInput = new System.Windows.Forms.Button();
            this.btnReadInput.Location = new System.Drawing.Point(12, 405);
            this.btnReadInput.Size = new System.Drawing.Size(140, 30);
            this.btnReadInput.Text = "Đọc input5.txt";
            this.btnReadInput.Name = "btnReadInput";
            this.btnReadInput.Click += new System.EventHandler(this.btnReadInput_Click);
            this.Controls.Add(this.btnReadInput);

            // Export button
            this.btnShowOutput = new System.Windows.Forms.Button();
            this.btnShowOutput.Location = new System.Drawing.Point(170, 405);
            this.btnShowOutput.Size = new System.Drawing.Size(180, 30);
            this.btnShowOutput.Text = "Xuất output5.txt";
            this.btnShowOutput.Name = "btnShowOutput";
            this.btnShowOutput.Click += new System.EventHandler(this.btnShowOutput_Click);
            this.Controls.Add(this.btnShowOutput);

            // ProgressBar and status label
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBar.Location = new System.Drawing.Point(12, 445);
            this.progressBar.Size = new System.Drawing.Size(520, 23);
            this.progressBar.Name = "progressBar";
            this.Controls.Add(this.progressBar);

            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.Location = new System.Drawing.Point(550, 445);
            this.lblStatus.Size = new System.Drawing.Size(138, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Trạng thái";
            this.Controls.Add(this.lblStatus);
        }

        #endregion

        // Controls
        private System.Windows.Forms.RichTextBox rtbInputDisplay;
        private System.Windows.Forms.Button btnReadInput;
        private System.Windows.Forms.Button btnShowOutput;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}
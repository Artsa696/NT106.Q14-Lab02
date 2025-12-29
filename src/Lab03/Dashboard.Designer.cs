namespace TCP_server
{
    partial class Dashboard
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
            this.btnOpenTCPServer = new System.Windows.Forms.Button();
            this.btnOpenTCPClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenTCPServer
            // 
            this.btnOpenTCPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOpenTCPServer.Location = new System.Drawing.Point(50, 30);
            this.btnOpenTCPServer.Name = "btnOpenTCPServer";
            this.btnOpenTCPServer.Size = new System.Drawing.Size(250, 80);
            this.btnOpenTCPServer.TabIndex = 0;
            this.btnOpenTCPServer.Text = "Open TCP Server";
            this.btnOpenTCPServer.UseVisualStyleBackColor = true;
            this.btnOpenTCPServer.Click += new System.EventHandler(this.btnOpenTCPServer_Click);
            // 
            // btnOpenTCPClient
            // 
            this.btnOpenTCPClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOpenTCPClient.Location = new System.Drawing.Point(330, 30);
            this.btnOpenTCPClient.Name = "btnOpenTCPClient";
            this.btnOpenTCPClient.Size = new System.Drawing.Size(250, 80);
            this.btnOpenTCPClient.TabIndex = 1;
            this.btnOpenTCPClient.Text = "Open new TCP client";
            this.btnOpenTCPClient.UseVisualStyleBackColor = true;
            this.btnOpenTCPClient.Click += new System.EventHandler(this.btnOpenTCPClient_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 141);
            this.Controls.Add(this.btnOpenTCPClient);
            this.Controls.Add(this.btnOpenTCPServer);
            this.Name = "Dashboard";
            this.Text = "Lab03_Bai03";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenTCPServer;
        private System.Windows.Forms.Button btnOpenTCPClient;
    }
}

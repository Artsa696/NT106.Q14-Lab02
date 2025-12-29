using System;
using System.Windows.Forms;

namespace TCP_server
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnOpenTCPServer_Click(object sender, EventArgs e)
        {
            Server serverForm = new Server();
            serverForm.Show();
        }

        private void btnOpenTCPClient_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();
        }
    }
}

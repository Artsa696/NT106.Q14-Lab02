using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab02_Bai01 bai01 = new Lab02_Bai01();
            bai01.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab02_Bai02 bai02 = new Lab02_Bai02();
            bai02.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab02_Bai03 bai03 = new Lab02_Bai03();
            bai03.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab02_Bai04 bai04 = new Lab02_Bai04();
            bai04.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lab02_Bai05 bai05 = new Lab02_Bai05();
            bai05.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lab02_Bai06 bai06 = new Lab02_Bai06();
            bai06.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Lab02_Bai07 bai07 = new Lab02_Bai07();
            bai07.ShowDialog();
        }
    }
}

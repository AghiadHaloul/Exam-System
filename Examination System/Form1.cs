using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System
{
    public partial class Form1 : Form
    {
        public static Form form2;
        public static Form form1 = new Form1();
        static public bool signer;//true for teacher
        public Form1()
        {
            form2 = new Form2();
            InitializeComponent();
        }
        private void Studentbtn_Click(object sender, EventArgs e)
        {
            signer = false;
            this.Hide();
            form2.ShowDialog();

        }

        private void Teacherbtn_Click(object sender, EventArgs e)
        {
            signer = true;
            this.Hide();
            form2.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

    }
}

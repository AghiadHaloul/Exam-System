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
    public partial class Form2 : Form
    {
        public static Form signed_In;
        Form signingUp;
        public static student s;
        public static teacher t;
        public static Examination_SystemEntities2 EF = new Examination_SystemEntities2();

        public Form2()
        {
            t = new teacher();
            s = new student();
            signed_In = new Signed_In();
            signingUp = new Signing_Up();
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.signer == true)
            {
                if (t.checkTeacherSignIn(textBox1.Text, textBox2.Text))
                {
                    this.Hide();
                    signed_In.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password Incorrect!\nPlease Check Username and Password");
                }
            }
            else
            {
                if (s.checkStudentSignIn(textBox1.Text, textBox2.Text))
                {
                    this.Hide();
                    signed_In.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password Incorrect!\nPlease Check Username and Password");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signingUp.ShowDialog();
        }


    }
}

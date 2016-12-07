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
    public partial class Signed_In : Form
    {
        public static Form addExam, solve, delete, Report,Ch;
        public static Form singIn = new Form1();
        public static bool deleteORedit;//true for deleting
        bool signout = false;
        public Signed_In()
        {
            addExam = new add_Exam();
            solve = new solveExam();
            delete = new delete_Exam();
            Report = new generateReport();
            Ch = new viewChart();
            InitializeComponent();
        }
        void visible(bool x)
        {
            if (x == true)
            {
                //Teacher
                button1.Visible = x;
                button2.Visible = x;
                button3.Visible = x;
                button4.Visible = x;
                button5.Visible = x;
                button1.Text = "Add Exam";
                label1.Text = "Choose Your Path Wisely!";
            }
            else
            {
                //Student
                button1.Visible = !x;
                button2.Visible = x;
                button3.Visible = x;
                button4.Visible = x;
                button5.Visible = x;
                button1.Text = "Solve an Exam";
                label1.Text = "Dude! Run! Save yourself!!!";
                button1.Location = new Point(507, 278);
            }
        }

        private void Signed_In_Load(object sender, EventArgs e)
        {
            if (Form1.signer == true)
            {
                visible(true);
                label2.Text = "Welcome back " + Form2.t.getFirstName() + " :)";
            }
            else
            {
                visible(false);
                label2.Text = "Welcome back " + Form2.s.getFirstName() + " :)";
            }
        }

        private void Signed_In_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (signout == true)
                Form1.form1.ShowDialog();
            else
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.signer == true)
            {
                this.Hide();
                addExam.ShowDialog();
            }
            else
            {
                this.Hide();
                solve.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //deleting exam
            this.Hide();
            deleteORedit = true;
            delete.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //editing exam
            this.Hide();
            deleteORedit = false;
            delete.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //issuing Reports
            this.Hide();
            Report.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // showing charts
            this.Hide();
            Ch.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           /* this.Hide();
            Signed_In.singIn.ShowDialog();*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            signout = true;
            this.Hide();
        }

    }
}

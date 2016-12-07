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
    public partial class add_Exam : Form
    {
        bool hasBeenClicked1;
        bool hasBeenClicked2;
        bool hasBeenClicked3;
        bool hasBeenClicked4;
        Form addQuest;
        public static examClass ex;

        public add_Exam()
        {

            addQuest = new Add_Question();
            InitializeComponent();
            hasBeenClicked1 = hasBeenClicked2 = hasBeenClicked3
                            = hasBeenClicked4 = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Exam_Load(object sender, EventArgs e)
        {
            label1.Visible = label2.Visible = label3.Visible
                           = label4.Visible = false;

        }

        private void add_Exam_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
            textBox1.ForeColor = Color.Black;

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked2)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked2 = true;
            }
            textBox2.ForeColor = Color.Black;

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked3)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked3 = true;
            }
            textBox3.ForeColor = Color.Black;

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked4)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked4 = true;
            }
            textBox4.ForeColor = Color.Black;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                hasBeenClicked1 = false;
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Exam Name";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                hasBeenClicked2 = false;
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Number of Questions";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                hasBeenClicked3 = false;
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Duration";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                hasBeenClicked4 = false;
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Mark";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Exam Name")
                label1.Visible = true;
            else
                label1.Visible = false;
            if (textBox2.Text == "Number of Questions")
                label2.Visible = true;
            else
                label2.Visible = false;
            if (textBox3.Text == "Duration")
                label3.Visible = true;
            else
                label3.Visible = false;
            if (textBox4.Text == "Mark")
                label4.Visible = true;
            else
                label4.Visible = false;
            if ((label1.Visible == false) && (label2.Visible == false) && 
                (label3.Visible == false) && (label4.Visible == false)&&
                (int.Parse(textBox2.Text)>0))
            {
                //add exam then start adding Questions
                ex= new examClass(textBox1.Text, int.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text));
                this.Hide();
                addQuest.ShowDialog();
                ex.save();
            }
            else if (int.Parse(textBox2.Text)<=0)
            {
                MessageBox.Show("Number of Questions must be at least 1");
            }
        }
    }
}

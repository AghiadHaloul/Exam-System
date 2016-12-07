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
    public partial class Add_Question : Form
    {
        int NumberOfQestions, counter;
        bool hasBeenClicked1;
        bool hasBeenClicked2;
        bool hasBeenClicked3;
        bool hasBeenClicked4;
        bool hasBeenClicked5;
        bool hasBeenClicked6;
        bool hasBeenClicked7;
        public Add_Question()
        {
            hasBeenClicked1 = hasBeenClicked2 = hasBeenClicked3
                            = hasBeenClicked4 = hasBeenClicked5 = hasBeenClicked6
                            = hasBeenClicked7 = false;
            InitializeComponent();
        }

        private void Add_Question_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            NumberOfQestions = add_Exam.ex.getNumberOfQuestions();
            visible(true);
            counter = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            visible(radioButton1.Checked);
        }
        void visible(bool x)
        {
            if (x)//true = MCQ
            {
                textBox2.Text = "Choice 1";
                textBox3.Text = "Choice 2";
                textBox4.Text = "Choice 3";
                textBox5.Text = "Choice 4";
                textBox4.Enabled = textBox3.Enabled = true;
                textBox5.Visible = textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = textBox5.Visible = false;
                textBox3.Enabled = textBox4.Enabled = false;
                textBox3.Text = "true";
                textBox4.Text = "false";
            }
            textBox1.Text = "Question Text";
            textBox6.Text = "Answer";
            textBox7.Text = "Score";
            textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = textBox4.ForeColor
                               = textBox5.ForeColor = textBox6.ForeColor = textBox7.ForeColor = Color.Gray;
            hasBeenClicked1 = hasBeenClicked2 = hasBeenClicked3 = hasBeenClicked4
                            = hasBeenClicked5 = hasBeenClicked6 = hasBeenClicked7
                            = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            visible(radioButton1.Checked);
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                hasBeenClicked1 = false;
                textBox1.Text = "Question Text";
                textBox1.ForeColor = Color.Gray;
            }
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                hasBeenClicked2 = false;
                textBox2.Text = "Choice 1";
                textBox2.ForeColor = Color.Gray;
            }
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                hasBeenClicked3 = false;
                textBox3.Text = "Choice 2";
                textBox3.ForeColor = Color.Gray;
            }
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

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                hasBeenClicked4 = false;
                textBox4.Text = "Choice 3";
                textBox4.ForeColor = Color.Gray;

            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked5)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked5 = true;
            }
            textBox5.ForeColor = Color.Black;

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                hasBeenClicked5 = false;
                textBox5.Text = "Choice 4";

                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked6)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked6 = true;
            }
            textBox6.ForeColor = Color.Black;

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                hasBeenClicked6 = false;
                textBox6.Text = "Answer";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check and record Question
            if (everythingOk())
            {
                int type;
                string[] choices = new string[4];
                if (radioButton1.Checked)
                {
                    type = 1;
                    choices[0] = textBox2.Text;
                    choices[1] = textBox3.Text;
                    choices[2] = textBox4.Text;
                    choices[3] = textBox5.Text;
                }
                else
                {
                    type = 2;
                    choices[1] = textBox3.Text;
                    choices[2] = textBox4.Text;
                    choices[0] = choices[3] = "";
                }
                QuestionClass q = new QuestionClass(add_Exam.ex.getName(), textBox1.Text, double.Parse(textBox7.Text), type, choices, textBox6.Text);
                counter++;
                if (counter != NumberOfQestions)
                {
                    //take another question
                    visible(true);

                }
                else
                {
                    //finished adding all questions
                    //not yet implemented
                    MessageBox.Show("Exam Added :)");
                    this.Hide();
                }
            }
        }
        bool everythingOk()
        {
            if (radioButton1.Checked)
            {
                if (textBox1.Text == "Question Text")
                {
                    MessageBox.Show("Please Enter Question Text!");
                    return false;
                }
                if (textBox2.Text == "Choice 1")
                {
                    MessageBox.Show("Please Enter Choice 1!");
                    return false;
                }
                if (textBox3.Text == "Choice 2")
                {
                    MessageBox.Show("Please Enter Choice 2!");
                    return false;
                }
                if (textBox4.Text == "Choice 3")
                {
                    MessageBox.Show("Please Enter Choice 3!");
                    return false;
                }
                if (textBox5.Text == "Choice 4")
                {
                    MessageBox.Show("Please Enter Choice 4!");
                    return false;
                }
                if (textBox6.Text == "Answer")
                {
                    MessageBox.Show("Please Enter The Answer");
                    return false;
                }
            }
            else
            {
                if (textBox1.Text == "Question Text")
                {
                    MessageBox.Show("Please Enter Question Text!");
                    return false;
                }
                if (textBox6.Text == "Answer")
                {
                    MessageBox.Show("Please Enter The Answer");
                    return false;
                }
            }
            return true;
        }

        private void Add_Question_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (counter != NumberOfQestions)
                add_Exam.ex.setNumberOfQuestions(counter);
            Form2.signed_In.Show();
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked7)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked7 = true;
            }
            textBox7.ForeColor = Color.Black;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                hasBeenClicked7 = false;
                textBox7.Text = "Score";
                textBox7.ForeColor = Color.Gray;
            }
        }
    }
}

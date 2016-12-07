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
    public partial class Edit_Questions : Form
    {
        int count;
        Exam exam;
        public Edit_Questions()
        {
            count = 0;
            exam = new Exam();
            InitializeComponent();
        }

        private void Edit_Questions_Load(object sender, EventArgs e)
        {
            exam = Form2.EF.Exams.Find(delete_Exam.examSelected);
            Display_Question(delete_Exam.q[count]);
        }
        private void Display_Question(Question question)
        {
            //stoped here
            textBox1.Text = question.Question_Text;
            if (question.Type == 1)
            {
                radioButton1.Checked = true;
                textBox2.Visible = textBox5.Visible = true;
                textBox2.Text = question.mcq_Choice_1;
                textBox5.Text = question.mcq_Choice_4;
            }
            else
            {
                radioButton2.Checked = true;
                textBox2.Visible = textBox5.Visible = false;
                textBox3.Enabled = textBox4.Enabled = false;
            }

            textBox3.Text = question.mcq_Choice_2;
            textBox4.Text = question.mcq_Choice_3;
            textBox6.Text = question.Correct_Answer;
            textBox7.Text = question.Question_Score.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (everythingOk())
            {
                int type = 0;
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
                delete_Exam.q[count].Exam_Name = delete_Exam.examSelected;
                delete_Exam.q[count].Question_Text = textBox1.Text;
                delete_Exam.q[count].Question_Score = double.Parse(textBox7.Text);
                delete_Exam.q[count].mcq_Choice_1 = textBox2.Text;
                delete_Exam.q[count].mcq_Choice_2 = textBox3.Text;
                delete_Exam.q[count].mcq_Choice_3 = textBox4.Text;
                delete_Exam.q[count].mcq_Choice_4 = textBox5.Text;
                delete_Exam.q[count].Type = type;
                delete_Exam.q[count].Correct_Answer = textBox6.Text;
                count++;
                if (count != exam.Number_Of_Questions)
                {
                    //edit another question
                    Display_Question(delete_Exam.q[count]);

                }
                else
                {
                    //finished editing all questions
                    QuestionClass questionclass = new QuestionClass();
                    questionclass.Up_Date_Questions(delete_Exam.q);
                    MessageBox.Show("Exam Edited :)");
                    this.Hide();
                }
            }
        }
        bool everythingOk()
        {
            if (radioButton1.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Question Text!");
                    return false;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please Enter Choice 1!");
                    return false;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter Choice 2!");
                    return false;
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Please Enter Choice 3!");
                    return false;
                }
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Please Enter Choice 4!");
                    return false;
                }
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter The Answer");
                    return false;
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Question Text!");
                    return false;
                }
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter The Answer");
                    return false;
                }
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please Enter Question Score");
                return false;
            }
            return true;
        }

        private void Edit_Questions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox2.Visible = textBox5.Visible = true;
                textBox3.Enabled = textBox4.Enabled = true;
            }
            else
            {
                textBox3.Enabled = textBox4.Enabled = false;
                textBox2.Visible = textBox5.Visible = false;
            }
        }

    }
}

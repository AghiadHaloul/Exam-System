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
    public partial class delete_Exam : Form
    {
        static public string examSelected;
        Form edit;
        int count;
        public static Question[] q;
        public delete_Exam()
        {
            count = 0;
            edit = new Edit_Questions();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Back Button
            this.Close();
        }

        private void delete_Exam_Load(object sender, EventArgs e)
        {
            if (Signed_In.deleteORedit == true)
            {
                button1.Text = "Delete";
                listBox1.Items.AddRange(solveExam.ee.getExamsNames());
            }
            else
            {
                button1.Text = "Edit";
                listBox1.Items.AddRange(solveExam.ee.getExamsNames());
            }
        }

        private void delete_Exam_FormClosing(object sender, FormClosingEventArgs e)
        {
            listBox1.Items.Clear();
            Form2.signed_In.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete or edit exam from file
            if (button1.Text == "Delete")
            {
                //delete selected Exam
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry No Exams Exist To Be Deleted!");
                }
                else
                {
                    if (listBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select an Exam First!");
                    }
                    else
                    {
                        string selected = listBox1.GetItemText(listBox1.SelectedItem);
                        const string message = "Are you Sure You want to Delete this Exam?";
                        const string caption = "Confirm Deletion";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                        //---
                        if (result == DialogResult.Yes)
                        {
                            examClass examToBeDeleted = new examClass();
                            examToBeDeleted.delete(selected);
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //edit selected exam
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry No Exams Exist To Be Edited!");
                }
                else
                {
                    if (listBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select an Exam First!");
                    }
                    else
                    {
                        string selected = examSelected = listBox1.GetItemText(listBox1.SelectedItem);
                        Exam exam = new Exam();
                        exam = Form2.EF.Exams.Find(selected);
                        q = new Question[exam.Number_Of_Questions];
                        q = readQuestion(exam.Exam_Name);
                        this.Hide();
                        edit.ShowDialog();
                    }
                }

            }
        }
        public Question[] readQuestion(string ExamName)
        {
            foreach (var Question in Form2.EF.Questions)
            {
                if (Question.Exam_Name == ExamName)
                {
                    q[count] = Question;
                    count++;
                }
            }
            return q;
        }
    }
}

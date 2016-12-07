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
    public partial class solveExam : Form
    {
        public static Form answerQuestion;
        public static examClass ee;
        
        public static int timeLeft;

        public solveExam()
        {
            ee = new examClass();
            answerQuestion = new AnswerQuestion();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Sorry No Exams Exist!");
            }
            else
            {
                //start selected exam
                string selected = listBox1.GetItemText(listBox1.SelectedItem);
                ee = new examClass(selected);
                this.Hide();
                timeLeft = Convert.ToInt32(ee.getDuration());
                timer2.Start();
                answerQuestion.ShowDialog();
            }
        }

        private void solveExam_Load(object sender, EventArgs e)
        {
            //load exams to listview
            listBox1.Items.Clear();
            listBox1.Items.AddRange(ee.getExamsNames());
        }

        private void solveExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show(timeLeft.ToString());
            if (timeLeft >= 1)
            {
                // Display the new time left 
                // by updating the Time Left label.
                timeLeft -= 1;
                /*if (timeLeft > 1) 
                    timeLeft.Text = timeLeft + " minutes";
                else 
                    timeLeft.Text = timeLeft + " minute";*/

            }
            else if (timeLeft < 1)
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer2.Stop();
                MessageBox.Show("Time is up.", timeLeft.ToString());

                solveExam.answerQuestion.Hide();
            }
        }
    }
}

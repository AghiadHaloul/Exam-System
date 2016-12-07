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

    public partial class AnswerQuestion : Form
    {
        Question[] q;
        int counter;
        int count;
        double score;
        bool finishedOnTime = false;
        // how to access these 2 from solveExam
        public AnswerQuestion()
        {
            score = counter = count = 0;
            InitializeComponent();
        }
        public void store(){
        reportsTable r = new reportsTable();
                r.Student_Username = Form2.s.getUserName();
                r.examName = solveExam.ee.getName();
                r.score = score;
                r.totalscore = solveExam.ee.getTotalScore();
                r.date = DateTime.Now;
                if (score / r.totalscore >= 0.5)
                    r.status = "Passed";
                else
                    r.status = "Failed";
                r.percentage = (r.score / r.totalscore) * 100;
                Form2.EF.reportsTables.Add(r);
                Form2.EF.SaveChanges();
                MessageBox.Show("You got: " + score + " From " + solveExam.ee.getTotalScore());
    }
        public void updateTimeLabel(){
            int x=1;
            x++;

        }
        private void AnswerQuestion_Load(object sender, EventArgs e)
        {
            //load first question
            //timeLeft = Convert.ToInt32(solveExam.ee.getDuration());
            score = counter = count = 0;
            q = readQuestion(solveExam.ee.getName());
            loadQuestion();
        }

        public Question[] readQuestion(string ExamName)
        {
            q = new Question[solveExam.ee.getNumberOfQuestions()];
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
        private void loadQuestion()
        {
           // timeLeftLabel.Text = timeLeft + " minutes";
            label1.Text = q[counter].Question_Text;
            if (q[counter].Type == 2)
            {
                radioButton1.Visible = radioButton4.Visible = false;
                radioButton2.Text = "true";
                radioButton3.Text = "false";
            }
            else
            {
                radioButton1.Visible = radioButton2.Visible = radioButton3.Visible
                                     = radioButton4.Visible = true;
                radioButton1.Text = q[counter].mcq_Choice_1;
                radioButton2.Text = q[counter].mcq_Choice_2;
                radioButton3.Text = q[counter].mcq_Choice_3;
                radioButton4.Text = q[counter].mcq_Choice_4;
            }
            label2.Text = "Question Score: " + q[counter].Question_Score;
            label3.Text = "Question Number " + (counter + 1).ToString() + ":";
            counter++;
        }

        
        private bool IsCorrect()
        {
            if (q[counter - 1].Type == 2)
            {
                if (radioButton2.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton2.Text;
                else if (radioButton3.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton3.Text;
            }
            else
            {
                if (radioButton1.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton1.Text;
                else if (radioButton2.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton2.Text;
                else if (radioButton3.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton3.Text;
                else if (radioButton4.Checked == true)
                    return q[counter - 1].Correct_Answer == radioButton4.Text;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool isCorrect;
            isCorrect = IsCorrect();
            if (isCorrect == true)
            {
                MessageBox.Show("Correct Answer :)");
                score += q[counter - 1].Question_Score;
            }
            else
                MessageBox.Show("Wrong Answer\nCorrect Answer is: " + q[counter - 1].Correct_Answer);
            //load all next questions
            if (count != counter)
                loadQuestion();
            else
            {
                
                finishedOnTime = true;
                reportsTable r = new reportsTable();
                r.Student_Username = Form2.s.getUserName();
                r.examName = solveExam.ee.getName();
                r.score = score;
                r.totalscore = solveExam.ee.getTotalScore();
                r.date = DateTime.Now;
                if (score / r.totalscore >= 0.5)
                    r.status = "Passed";
                else
                    r.status = "Failed";
                r.percentage = (r.score / r.totalscore) * 100;
                Form2.EF.reportsTables.Add(r);
                Form2.EF.SaveChanges();
                MessageBox.Show("You got: " + score + " From " + solveExam.ee.getTotalScore());
                this.Close();

            }

        }

        private void AnswerQuestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


    }
}

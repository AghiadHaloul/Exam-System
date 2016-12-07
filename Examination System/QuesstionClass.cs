using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Examination_System
{
    class QuestionClass
    {
        private string examName;
        private string questionText;
        private double questionScore;
        private int type;//1 For MCQ / 2 For True or False
        private string[] mcqChoices = new string[4];
        private string correctAnswer;
        public QuestionClass()
        {
            questionText = correctAnswer = examName = "";
            questionScore = type = 0;
        }
        public QuestionClass(string Exam, string quesText, double quesScore, int quesType,
            string[] mcqChoices, string correctAnswer)
        {
            this.examName = Exam;
            this.questionText = quesText;
            this.questionScore = quesScore;
            this.type = quesType;
            this.mcqChoices = mcqChoices;
            this.correctAnswer = correctAnswer;
            Question q = new Question();
            q.Exam_Name = this.examName;
            q.Question_Text = this.questionText;
            q.Question_Score = this.questionScore;
            q.Type = this.type;
            q.mcq_Choice_1 = this.mcqChoices[0];
            q.mcq_Choice_2 = this.mcqChoices[1];
            q.mcq_Choice_3 = this.mcqChoices[2];
            q.mcq_Choice_4 = this.mcqChoices[3];
            q.Correct_Answer = this.correctAnswer;
            Form2.EF.Questions.Add(q);
            Form2.EF.SaveChanges();

        }
        public void Up_Date_Questions(Question[] q)
        {
            foreach (var Question in Form2.EF.Questions)
            {
                if(Question.Exam_Name==delete_Exam.examSelected)
                {
                    Form2.EF.Questions.Attach(Question);
                    Form2.EF.Questions.Remove(Question);
                }
            }
            Form2.EF.SaveChanges();
            for(int i=0;i<q.Length;i++)
            {
                Form2.EF.Questions.Add(q[i]);
            }
            Form2.EF.SaveChanges();
        }

        public string getQuestionText() { return questionText; }
        public double getQuestionScore() { return questionScore; }
        public int getQuestionType() { return type; }
        public string[] getmcqChoices() { return mcqChoices; }
        public string getCorrectAnswer() { return correctAnswer; }

        public bool checkAnswer(string sAnswer)
        {
            if (sAnswer == correctAnswer)
                return true;
            return false;
        }

    }
}

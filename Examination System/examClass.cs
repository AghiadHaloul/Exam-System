using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
namespace Examination_System
{
    public class examClass
    {
        private string name;
        private int numOfQuestions;
        private double duration;
        private double totalScore;

        public examClass()
        {
            name = "";
            numOfQuestions = 0; duration = totalScore = 0;
        }

        public examClass(string Name)
        {
            Exam e = Form2.EF.Exams.Find(Name);
            if (e == null)
            {

            }
            else
            {
                name = e.Exam_Name;
                numOfQuestions = e.Number_Of_Questions;
                duration = e.Duration;
                totalScore = e.Total_Score;
            }
        }
        public examClass(string name, int numOfQuestions, double duration, double totalScore)
        {
            this.name = name;
            this.numOfQuestions = numOfQuestions;
            this.duration = duration;
            this.totalScore = totalScore;
        }

        public string getName() { return name; }
        public int getNumberOfQuestions() { return numOfQuestions; }
        public double getDuration() { return duration; }
        public double getTotalScore() { return totalScore; }
        public string[] getExamsNames()
        {
            //To fill List of Exams
            int count = Form2.EF.Exams.Count();
            string[] exams = new string[count];
            int i = 0;
            foreach (var Exam in Form2.EF.Exams)
            {
                exams[i] = Exam.Exam_Name;
                i++;
            }
            return exams;
        }
        public void setNumberOfQuestions(int x)
        { numOfQuestions = x; }
        public void delete(string Name)
        {
            Exam e = Form2.EF.Exams.Find(Name);
            Form2.EF.Exams.Attach(e);
            Form2.EF.Exams.Remove(e);
            Form2.EF.SaveChanges();
            foreach (var Question in Form2.EF.Questions)
            {
                if (Question.Exam_Name == Name)
                {
                    Form2.EF.Questions.Attach(Question);
                    Form2.EF.Questions.Remove(Question);
                }
            }
            Form2.EF.SaveChanges();

            MessageBox.Show("Exam Deleted!");

        }
        public void save()
        {
            Exam e = new Exam();
            e.Exam_Name = this.name;
            e.Number_Of_Questions = this.numOfQuestions;
            e.Duration = this.duration;
            e.Total_Score = this.totalScore;
            Form2.EF.Exams.Add(e);
            Form2.EF.SaveChanges();
        }
    }
}

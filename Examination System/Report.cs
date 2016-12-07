using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    class Report // for the student profile
    {
        private string studentID;
        private string examName;
        private DateTime Date;
        private double score;
        private double totalScore;
        private string status;
        private double percentage;
        public Report(string studentID,string examName,DateTime Date,double Score,
            double totalScore)
        {
            this.studentID = studentID;
            this.examName = examName;
            this.Date = Date;
            this.score = Score;
            this.totalScore = totalScore;
            if (score / totalScore >= 0.5)
                status = "Passed";
            else
                status = "Failed";
            this.percentage = (Score / totalScore)*100;
        }

        public string getStudentID() { return studentID; }
        public string getExamName() { return examName; }
        public DateTime getDate() { return Date; }
        public double getScore() { return score; }
        public double getTotalScore() { return totalScore; }
        public string getStatus() { return status; }
        public double getPercentage() { return percentage; }
    }
}

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
    public partial class generateReport : Form
    {
        public static Form chartsForm = new viewChart();
        public generateReport()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                dataGridView2.Rows.Clear();
                foreach (var reportsTables in Form2.EF.reportsTables)
                {
                    if (textBox2.Text != "")
                    {
                        if (reportsTables.Student_Username.Replace(" ", "") == textBox2.Text)
                        {
                            dataGridView2.Rows.Add(reportsTables.Student_Username.Replace(" ", ""), reportsTables.examName.Replace(" ", ""), reportsTables.score + " / " + reportsTables.totalscore, String.Format("{0:0.00}",(reportsTables.percentage)), reportsTables.status.Replace(" ", ""), reportsTables.date);
                            count++;
                        }
                    }
                    else
                    {
                        dataGridView2.Rows.Add(reportsTables.Student_Username.Replace(" ", ""), reportsTables.examName.Replace(" ", ""), reportsTables.score + " / " + reportsTables.totalscore,String.Format("{0:0.00}",(reportsTables.percentage)), reportsTables.status.Replace(" ", ""), reportsTables.date);
                        count++;
                    }
                }
                if (count == 0)
                    MessageBox.Show("No records found for '" + textBox2.Text + "'.");
            }
            catch
            {
                MessageBox.Show("An error occured.");
            }
        }

        private void generateReport_Load_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void generateReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}



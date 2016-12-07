using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Examination_System
{
    public partial class viewChart : Form
    {
        public viewChart()
        {
            InitializeComponent();
        }
        bool showAll = false;
        int count = 0;
        private void clearSeries()
        {
            chart1.Series["Grades"].Points.Clear();
        }
        private void loadStat()
        {
            clearSeries();
            double distinct = 0;
            double vgood = 0;
            double good = 0;
            double fair = 0;
            double failed = 0;
            count = 0;
            foreach (var reportsTables in Form2.EF.reportsTables)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (reportsTables.Student_Username == textBox1.Text||showAll==true)
                    {
                        count++;
                        if (reportsTables.percentage >= 85)
                            distinct++;
                        else if (reportsTables.percentage >= 75)
                            vgood++;
                        else if (reportsTables.percentage >= 65)
                            good++;
                        else if (reportsTables.percentage >= 50)
                            fair++;
                        else
                            failed++;
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (reportsTables.examName == textBox1.Text||showAll == true)
                    {
                        count++;
                        if (reportsTables.percentage >= 85)
                            distinct++;
                        else if (reportsTables.percentage >= 75)
                            vgood++;
                        else if (reportsTables.percentage >= 65)
                            good++;
                        else if (reportsTables.percentage >= 50)
                            fair++;
                        else
                            failed++;
                    }
                }
                else
                {

                    if (reportsTables.percentage >= 85)
                        distinct++;
                    else if (reportsTables.percentage >= 75)
                        vgood++;
                    else if (reportsTables.percentage >= 65)
                        good++;
                    else if (reportsTables.percentage >= 50)
                        fair++;
                    else
                        failed++;
                }

               
            }

            double sum = distinct + vgood + good + fair + failed;
            if(failed!=0)
            chart1.Series["Grades"].Points.AddXY("Failed " +
                String.Format("{0:0.00%}", failed / sum), failed);
            if(fair!=0)
            chart1.Series["Grades"].Points.AddXY("Fair " +
                String.Format("{0:0.00%}", fair / sum), fair);
            if(good!=0)
            chart1.Series["Grades"].Points.AddXY("Good " +
                String.Format("{0:0.00%}", good / sum), good);
            if(vgood!=0)
            chart1.Series["Grades"].Points.AddXY("Very Good " +
                String.Format("{0:0.00%}", vgood / sum), vgood);
            if(distinct!=0)
            chart1.Series["Grades"].Points.AddXY("Distinct " +
                String.Format("{0:0.00%}", distinct / sum), distinct);
            

        }
        private void fillWithNull()
        {
            clearSeries();
            chart1.Series["Grades"].Points.AddXY("Invalid Data",1);
            count = 0;
        }
        private void viewChart_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            loadStat();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                checkBox1.Checked= false;
            if ((textBox1.Text == "" && showAll==false) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please provide all the necessary information.");
                textBox1.Text = "";
                label6.Hide();
                dataLabel.Hide();
            }
            else if ((textBox1.Text != ""||showAll==true) && comboBox1.SelectedIndex != -1)
            {
                loadStat();
                if (count == 0 && showAll == false)
                {
                    fillWithNull();
                    MessageBox.Show("No data found for '" + textBox1.Text + "'.");
                    count++;
                    label6.Hide();
                    dataLabel.Hide();
                }
                else
                {
                    if (showAll == false)
                        dataLabel.Text = textBox1.Text;
                    label6.Show();
                    dataLabel.Show();
                }
            }
        }

        private void viewChart_Leave(object sender, EventArgs e)
        {

            this.Hide();
            Form2.signed_In.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Grades"].ChartType = SeriesChartType.Pie;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Grades"].ChartType = SeriesChartType.Column;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Grades"].ChartType = SeriesChartType.SplineArea;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Grades"].ChartType = SeriesChartType.Radar;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Hide();
            dataLabel.Hide();
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    checkBox1.Text = "Show all students.";
                    break;
                case 1:
                    checkBox1.Text = "Show all exams.";
                    break;
            }
            checkBox1.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label6.Hide();
            dataLabel.Hide();
            if (checkBox1.Checked)
            {
                showAll = true;
                if(comboBox1.SelectedIndex==0)
                dataLabel.Text = "all students.";
                else if (comboBox1.SelectedIndex == 1)
                    dataLabel.Text = "all exams.";
            }
            else
                showAll = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void viewChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.signed_In.Show();
        }
    }
}

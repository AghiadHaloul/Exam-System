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
    public partial class Signing_Up : Form
    {
        bool hasBeenClicked1;
        bool hasBeenClicked2;
        bool hasBeenClicked3;
        bool hasBeenClicked4;
        bool hasBeenClicked5;
        bool hasBeenClicked6;
        bool hasBeenClicked7;
        bool hasBeenClicked8;


        public Signing_Up()
        {
            hasBeenClicked1 = hasBeenClicked2 = hasBeenClicked3
                            = hasBeenClicked4 = hasBeenClicked5 = hasBeenClicked6
                            = hasBeenClicked7 = hasBeenClicked8 = false;
            InitializeComponent();
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

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked4)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked4 = true;
                textBox4.UseSystemPasswordChar = true;
            }
            textBox4.ForeColor = Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked5)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked5 = true;
                textBox5.UseSystemPasswordChar = true;
            }
            textBox5.ForeColor = Color.Black;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
            {
                hasBeenClicked5 = false;
                textBox5.ForeColor = Color.Gray;
                textBox5.Text = "Confirm Password";
                textBox5.UseSystemPasswordChar = false;
                label5.Visible = false;
            }
            else if (textBox5.Text == textBox4.Text)
            {
                label5.Visible = false;
            }
            else
            {
                label5.Text = "*Password doesn't match!";
                label5.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "First Name")
                label1.Visible = true;
            else
                label1.Visible = false;
            if (textBox2.Text == "Last Name")

                label2.Visible = true;
            else
                label2.Visible = false;
            if (textBox3.Text == "Username")
                label3.Visible = true;
            else
                label3.Visible = false;
            if (textBox4.Text == "Password")
                label4.Visible = true;
            else
                label4.Visible = false;
            if (textBox5.Text == "Confirm Password")
            {
                label5.Text = "*This Field is needed";
                label5.Visible = true;
            }
            else
            {
                label5.Text = "*Password doesn't match!";
                label5.Visible = false;
            } if (textBox6.Text == "Email")

                label6.Visible = true;
            else
                label6.Visible = false;
            if ((textBox7.Text == "Department") || (textBox7.Text == "Year"))

                label7.Visible = true;
            else
                label7.Visible = false;
            if (textBox8.Text == "ID")
                label8.Visible = true;
            else
                label8.Visible = false;
            if (everythingOk())
            {
                //check username then write to file 
                if (Form1.signer == true)
                {
                    if (Form2.t.checkTeacherSignUp(textBox3.Text))
                    {
                        MessageBox.Show("Username Already Exist!\nPlease Choose another Username");
                    }
                    else
                    {
                        teacher tmp = new teacher(textBox8.Text, textBox1.Text, textBox2.Text, textBox3.Text,
                            textBox4.Text, textBox6.Text, textBox7.Text);
                        MessageBox.Show("You Were Successfully Signed Up :)");
                        this.Close();
                    }
                }
                else
                {
                    if (Form2.s.checkStudentSignUp(textBox3.Text))
                    {
                        MessageBox.Show("Username Already Exist!\nPlease Choose another Username");
                    }
                    else
                    {
                        student tmp = new student(textBox8.Text, textBox1.Text, textBox2.Text, textBox3.Text,
                            textBox4.Text, textBox6.Text, textBox7.Text);
                        MessageBox.Show("You Were Successfully Signed Up :)");
                        this.Close();
                    }
                }
            }

        }
        public bool everythingOk()
        {
            if ((label1.Visible == false) && (label2.Visible == false) &&
                (label3.Visible == false) && (label4.Visible == false) && 
                (label5.Visible == false) && (label6.Visible == false) && 
                (label7.Visible == false) && (label8.Visible == false))
                return true;
            return false;
        }

        private void Signing_Up_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.form2.Show();
        }

        private void Signing_Up_Load(object sender, EventArgs e)
        {
            label1.Visible = label2.Visible = label3.Visible
               = label4.Visible = label5.Visible = label6.Visible
               = label7.Visible = label8.Visible = false;
            if (Form1.signer == true)
                textBox7.Text = "Department";
            else
                textBox7.Text = "Year";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                hasBeenClicked1 = false;
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "First Name";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                hasBeenClicked2 = false;
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Last Name";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                hasBeenClicked3 = false;
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Username";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                hasBeenClicked4 = false;
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Password";
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                hasBeenClicked6 = false;
                textBox6.ForeColor = Color.Gray;
                textBox6.Text = "Email";
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                hasBeenClicked7 = false;
                textBox7.ForeColor = Color.Gray;
                if (Form1.signer == true)
                    textBox7.Text = "Department";
                else
                    textBox7.Text = "Year";
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (!hasBeenClicked8)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked8 = true;
            }
            textBox8.ForeColor = Color.Black;

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                hasBeenClicked8 = false;
                textBox8.ForeColor = Color.Gray;
                textBox8.Text = "ID";
            }
        }

    }
}

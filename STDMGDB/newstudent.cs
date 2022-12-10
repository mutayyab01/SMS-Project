using System;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class newstudent : Form
    {
        public newstudent()
        {
            InitializeComponent();
            radmale.Checked = true;

            //DateTime dta = DateTime.Now;
            //  var a = Convert.ToString(dta.ToString("yyyy/MM/dd"));
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            addstudent add = new addstudent();
            String name = textBox1.Text;
            String fname = textBox2.Text;
            String gender = "";
            String phone = textBox5.Text;
            String address = textBox6.Text;
            if (radmale.Checked)
            {
                gender = "MALE";
            }
            else if (radfemale.Checked)
            {
                gender = "FEMALE";

            }
            else if (radmale.Checked == false || radfemale.Checked)
            {
                MessageBox.Show("Please Select Gender||", "ERROR");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("PLease Enter First Name !");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("PLease Enter Last Name !");

            }
            //else if (date1>=a)
            //{
            //    MessageBox.Show("Incorrect Date ");
            //}
            else if (textBox5.Text == "")
            {
                MessageBox.Show("PLease Enter Phone NUmber !");

            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("PLease Enter Address !");

            }
            else
            {

                add.add_student(name, fname, gender, date.Text, phone, address);
                MessageBox.Show("NEW STUEDENT ADDED", "CONGRATULATION");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch))
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else
            {

                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = false;
            }
            else if (ch == 8 || ch == 32)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = false;
            }
            else if (ch == 8 || ch == 32)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

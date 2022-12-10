using System;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class addcourse : Form
    {
        public addcourse()
        {
            InitializeComponent();
        }

        int i;
        private void btnadd_Click(object sender, EventArgs e)
        {
            course course = new course();
            string label = textBox1.Text;

            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Course Label", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (course.checklabel(label)==false)
                {

                    if (textBox3.Text == string.Empty)
                    {
                        errorProvider1.SetError(textBox3, "PLease Enter Course Code");
                    }
                    else if (noofhour.Value == 0)
                    {
                        errorProvider1.Clear();
                        hour.SetError(noofhour, "PLease Enter Credit Hour");
                    }
                    else
                    {
                        int num = (int)noofhour.Value;
                        string add = textBox2.Text;
                        string cc = textBox3.Text;
                        course.addcourse(cc, label, num, add);
                        MessageBox.Show("Course Added", "ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Course Label Already Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
                throw;
            }


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            course course = new course();
            string label = textBox1.Text;

            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Course Label", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (course.checklabel(label) == false)
                {

                    if (textBox3.Text == string.Empty)
                    {
                        errorProvider1.SetError(textBox3, "PLease Enter Course Code");
                    }
                    else if (noofhour.Value == 0)
                    {
                        errorProvider1.Clear();
                        hour.SetError(noofhour, "PLease Enter Credit Hour");
                    }
                    else
                    {
                        int num = (int)noofhour.Value;
                        string add = textBox2.Text;
                        string cc = textBox3.Text;
                        course.addcourse(cc, label, num, add);
                        MessageBox.Show("Course Added", "ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Course Label Already Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
                throw;
            }

        }
    }
}

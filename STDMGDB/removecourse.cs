using System;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class removecourse : Form
    {
        public removecourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                course c = new course();
                string s = textBox1.Text;
                if (c.checklabel(s) == false)
                {
                    c.deletecourse(s);
                    MessageBox.Show("Course Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Course Label NOT Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                course c = new course();
                string s = textBox1.Text;
                if (c.checklabel(s) == false)
                {
                    c.deletecourse(s);
                    MessageBox.Show("Course Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Course Label NOT Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetterOrDigit(ch))
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

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class changepassward : Form
    {
        public changepassward()
        {
            InitializeComponent();
            label6.Text = Form1.SetValueForText2;

            label7.Text = Form1.SetValueForText1;
        }
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void changepassward_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Please Enter Current Password");
            }
            else if (textBox2.Text.Length == 0)
            {
                errorProvider1.Dispose();
                errorProvider2.SetError(textBox2, "Please Enter New Password");
            }
            else if (textBox3.Text.Length == 0)
            {
                errorProvider2.Dispose();
                errorProvider3.SetError(textBox3, "Please Enter Confirm Password");

            }
            else
            {

                String name = textBox1.Text;
                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "SELECT * FROM [user] WHERE passward='" + textBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        MessageBox.Show("passward match");
                        updatepassward();
                        MessageBox.Show("Passward Successfuly Changed ","Passward Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        
                    }
                    else
                    {
                        MessageBox.Show("New Password And Confirm Password Does Not Match\nPlease Check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Current Passward Does Not Match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();

                }
            }
        }

        void updatepassward()
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "update [user] set passward='"+textBox3.Text+"' where username='"+ label7.Text + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    textBox1.UseSystemPasswordChar = false;
                    textBox2.UseSystemPasswordChar = false;
                    textBox3.UseSystemPasswordChar = false;

                    break;
                default:
                    textBox1.UseSystemPasswordChar = true;
                    textBox2.UseSystemPasswordChar = true;
                    textBox3.UseSystemPasswordChar = true;

                    break;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void pictureBox1_Click(object sender, EventArgs e)
        {


            try
            {

                if (comboBox1.Text == "TEACHER")
                {
                    if (txtuser.Text.Length == 0)
                    {
                        P1.Visible = true;

                    }
                    if (txtuser.Text.Length >= 1)
                    {
                        P1.Visible = false;

                    }
                    if (txtpass.Text.Length == 0)
                    {
                        P2.Visible = true;

                    }
                    if (txtpass.Text.Length >= 1)
                    {
                        P2.Visible = false;

                    }
                    if (txtuser.Text.Length >= 1 && txtpass.Text.Length >= 1)
                    {

                        String name = txtuser.Text;
                        //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                        SqlConnection con = new SqlConnection(cs);
                        con.Open();
                        String query = "SELECT * FROM [user] WHERE username='" + txtuser.Text + "' and passward ='" + txtpass.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows == true)
                        {
                            SetValueForText1 = txtuser.Text;
                           
                            SetValueForText2 = fullname();
                           
                            MessageBox.Show("LOGIN SUCCESSFUL", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            this.Hide();
                            Main_Foam f2 = new Main_Foam();
                            f2.Show();
                            Main_Foam.instance.lbl.Text = " >>  " + txtuser.Text + "  <<";

                        }
                        else
                        {
                            MessageBox.Show("LOGIN FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                    }
                }
                else if (comboBox1.Text == "ADMIN")
                {
                    if (txtuser.Text == "ADMIN" && txtpass.Text == "ADMIN")
                    {
                        Adminfoam admin = new Adminfoam();
                        admin.Show();

                    }
                    else
                    {
                        MessageBox.Show("INCORRECT USERNAME OR PASSWARD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
                else
                {
                    MessageBox.Show("PLEASE SELECT LOGIN TYPE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        //---------------------------------------------------------------------------------------------------//---------------------------------------------------------------

        string fullname()
        {
            String name = txtuser.Text;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "select full_name from teacher where username='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string count1 = cmd.ExecuteScalar().ToString();
            return count1;
            //sda.Fill(dt);
            //return dt.ToString();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            P1.Visible = false;
            P2.Visible = false;
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            bool check = showpass.Checked;
            switch (check)
            {
                case true:
                    txtpass.UseSystemPasswordChar = false;

                    break;
                default:
                    txtpass.UseSystemPasswordChar = true;

                    break;
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (comboBox1.Text == "TEACHER")
                {
                    if (txtuser.Text.Length >= 1 && txtpass.Text.Length >= 1)
                    {

                        String name = txtuser.Text;
                        //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                        SqlConnection con = new SqlConnection(cs);
                        con.Open();
                        String query = "SELECT * FROM [user] WHERE username='" + txtuser.Text + "' and passward ='" + txtpass.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows == true)
                        {
                            SetValueForText1 = txtuser.Text;

                            SetValueForText2 = fullname();
                            MessageBox.Show("LOGIN SUCCESSFUL", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            this.Hide();
                            Main_Foam f2 = new Main_Foam();
                            f2.Show();
                            Main_Foam.instance.lbl.Text = " >>  " + txtuser.Text + "  <<";

                        }
                        else
                        {
                            MessageBox.Show("LOGIN FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                else if (comboBox1.Text == "ADMIN")
                {
                    if (txtuser.Text == "ADMIN" && txtpass.Text == "ADMIN")
                    {
                        Adminfoam admin = new Adminfoam();
                        admin.Show();

                    }
                    else
                    {
                        MessageBox.Show("INCORRECT USERNAME OR PASSWARD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("PLEASE SELECT LOGIN TYPE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Aqua;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }
    }
}

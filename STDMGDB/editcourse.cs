using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class editcourse : Form
    {
        public editcourse()
        {
            InitializeComponent();
        }
        course c = new course();
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void editcourse_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  course";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["label"].ToString());
            }
            con.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from course where label='" + comboBox1.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["label"].ToString();
                    noofhour.Value = int.Parse(dr["hour_number"].ToString());
                    textBox3.Text = dr["C_code"].ToString();
                    textBox2.Text = dr["description"].ToString();
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (textBox1.Text.Length > 0)
                    {

                        SqlConnection con = new SqlConnection(cs);

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = " UPDATE course set hour_number='" + noofhour.Value + "',description='" + textBox2.Text + "',C_code='" + textBox3.Text + "' where label='" + textBox1.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Course", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        noofhour.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Please Select Course label ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Please Select Course Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (comboBox1.SelectedItem != null)
                {
                    if (textBox1.Text.Length > 0)
                    {

                        SqlConnection con = new SqlConnection(cs);
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = " UPDATE course set hour_number='" + noofhour.Value + "',description='" + textBox2.Text + "',C_code='" + textBox3.Text + "' where label='" + textBox1.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Course", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        noofhour.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Please Select Course label ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Please Select Course Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

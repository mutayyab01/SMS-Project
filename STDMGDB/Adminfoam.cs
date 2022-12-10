using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class Adminfoam : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Adminfoam()
        {
            InitializeComponent();
            binddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            teacher admin = new teacher();
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Please Enter Full Name");
            }
            else if (textBox2.Text.Length == 0)
            {
                errorProvider1.Dispose();
                errorProvider2.SetError(textBox2, "Please Enter User Name");
            }
            else if (comboBox1.Text == string.Empty)
            {
                errorProvider2.Dispose();
                errorProvider3.SetError(comboBox1, "Please Enter Gender");
            }
            else if (maskedTextBox1.Text.Length == 5)
            {
                errorProvider3.Dispose();
                errorProvider4.SetError(maskedTextBox1, "Please Enter Phone Number");

            }
            else if (textBox6.Text.Length == 0)
            {
                errorProvider4.Dispose();
                errorProvider5.SetError(textBox6, "Please Enter Address ");
            }
            else
            {
                errorProvider5.Dispose();
                string name = textBox1.Text;
                string username = textBox2.Text;
                if (admin.checkusername(username) == false)
                {
                    MessageBox.Show("Username Already Exist \nUsername Must Be Unique For All Teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string gender = comboBox1.Text;
                    string date = dateTimePicker1.Text;
                    string phone = maskedTextBox1.Text;
                    string address = textBox6.Text;

                    admin.Addteacher(name, username, gender, date, phone, address);
                    MessageBox.Show("Teacher ADD Successfully", "ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    admin.addusernameto_usertbl(username);
                    binddata();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox6.Text = "";
                    comboBox1.Text = null;
                    maskedTextBox1.Text = "";
                    dateTimePicker1.Text = "2003-12-3";



                }
            }
        }



        public void binddata()
        {
            try
            {

                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "select * from [teacher]";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            binddata();
        }
        int i;
        private void button2_Click(object sender, EventArgs e)
        {
            teacher admin = new teacher();
            string name = textBox1.Text;
            string username = textBox2.Text;
            if (admin.checkusername(username) == false)
            {
                MessageBox.Show("Username Already Exist \nUsername Must Be Unique For All Teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string gender = comboBox1.Text;
                string date = dateTimePicker1.Text;
                string phone = maskedTextBox1.Text;
                string address = textBox6.Text;
                admin.updateteacher(i, name, username, gender, date, phone, address);
                MessageBox.Show("Teacher Successfully Updated ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                binddata();

                admin.updateusernameto_usertbl(getid(datagrid_username), username);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox6.Text = "";
                comboBox1.Text = null;
                maskedTextBox1.Text = "";
                dateTimePicker1.Text = "2003-12-3";
            }


        }
        int getid(string username)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = " select id from [user] where username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //string id = cmd.Parameters["@id"].Value.ToString();
            int modified = (int)cmd.ExecuteScalar();
            //int  modified = int.Parse(id); 

            return modified;

        }
        string datagrid_username;
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string id = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
            i = int.Parse(id);
            textBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
            datagrid_username = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
            string gender = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
            comboBox1.SelectedItem = gender.Trim();
            dateTimePicker1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
            maskedTextBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[5].Value);
            textBox6.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[6].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text.Length == 0)
                {
                    MessageBox.Show(" Please Select Teacher Username", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
                else
                {

                    teacher delete = new teacher();
                    delete.delete_teacher(i);
                    if (MessageBox.Show("Are You Sure You Want To Delete This Teacher ", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(" TEACHER DELETED SUCCESSFULLY", "CONGRATULATION");
                        delete.DELETEusernameto_usertbl(textBox2.Text);
                        binddata();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = null;
                        maskedTextBox1.Text = "";
                        dateTimePicker1.Text = "2003-12-3";




                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class managestdfoam : Form
    {
        stdindatabase st = new stdindatabase();
        public managestdfoam()
        {
            InitializeComponent();
            binddata();
            double total = int.Parse(totstd());
            totallbl.Text = "TOTAL STUDENT  :" + total;
            dataGridView1.ClearSelection();
        }
        public String execcount(String count)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = count;
            SqlCommand cmd = new SqlCommand(query, con);
            string count1 = cmd.ExecuteScalar().ToString();
            //cmd.ExecuteNonQuery();
            con.Close();
            return count1;
        }
        public string totstd()
        {
            return execcount("select count(*) from student");
        }
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        int i;
        private void btnadd_Click(object sender, EventArgs e)
        {
            addstudent add = new addstudent();
            String name = textBox1.Text;
            String fname = textBox3.Text;
            String gender = "";
            String phone = textBox5.Text;
            String address = textBox6.Text;
            if (radmale.Checked)
            {
                gender = "MALE";
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("PLease Enter First Name !");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("PLease Enter Last Name !");
            }
            else if (radfemale.Checked)
            {
                gender = "FEMALE";

            }
            else if (radmale.Checked == false || radfemale.Checked)
            {
                MessageBox.Show("Please Select Gender||", "ERROR");
            }
            //else if (date1>=a)
            //{
            //    MessageBox.Show("Incorrect Date ");
            //}
            if ((radmale.Checked || radfemale.Checked) && textBox1.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("PLease Enter Phone Number !");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("PLease Enter Address !");
                }
                else
                {
                    add.add_student(name, fname, gender, date.Text, phone, address);
                    MessageBox.Show("NEW STUEDENT ADDED", "CONGRATULATION");
                    binddata();
                    double total = int.Parse(totstd());
                    totallbl.Text = "TOTAL STUDENT  :" + total;
                    textBox1.Text = "";
                    textBox3.Text = "";
                    radmale.Checked = false;
                    radfemale.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    date.Text = "2003-12-01";
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            binddata();
            dataGridView1.ClearSelection();
        }
        public void binddata()
        {
            try
            {
                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "select * from student";
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Please Select Student Name ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    addstudent add = new addstudent();
                    String name = textBox1.Text;
                    String fname = textBox3.Text;
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
                    add.update_student(i, name, fname, gender, date.Text, phone, address);
                    MessageBox.Show("UPDATED STUEDENT ", "CONGRATULATION");
                    binddata();
                    textBox1.Text = "";
                    textBox3.Text = "";
                    radmale.Checked = false;
                    radfemale.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    date.Text = "2003-12-01";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show(" Please Select Student Name First!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    addstudent add = new addstudent();
                    add.delete_student(i);
                    if (MessageBox.Show("Are You Sure You Want To Delete This Student ", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(" STUEDENT DELETED ", "CONGRATULATION");
                        binddata();
                        double total = int.Parse(totstd());
                        totallbl.Text = "TOTAL STUDENT  :" + total;
                        textBox1.Text = "";
                        textBox3.Text = "";
                        radmale.Checked = false;
                        radfemale.Checked = false;
                        textBox5.Text = "";
                        textBox6.Text = "";
                        date.Text = "2003-12-01";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            try
            {

                String s = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                //string z = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                i = int.Parse(s);
                textBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                textBox3.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                String gender = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                if (gender == "MALE      ")
                {
                    radmale.Checked = true;
                }
                else
                {
                    radfemale.Checked = true;
                }
                date.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
                textBox5.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[5].Value);
                textBox6.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[6].Value);
            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message, "ERROR");

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtfind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n;
                bool isNumeric = int.TryParse(txtfind.Text, out n);
                if (isNumeric == false)
                {
                    //String connectionstring ="Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select * from student where first_name like @first_name +'%'";
                    //string query = "select * from student  WHERE CONCAT('first_name','last_name','address')LIKE' % "+txtfind.Text+"%'";
                    SqlDataAdapter sdq = new SqlDataAdapter(query, con);
                    sdq.SelectCommand.Parameters.AddWithValue("@first_name", txtfind.Text.Trim());
                    DataTable data = new DataTable();
                    sdq.Fill(data);
                    if (data.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = data;
                    }
                    else
                    {
                        MessageBox.Show("NO Result Found");
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message, "ERROR");
            }
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int find = int.Parse(txtfind.Text);
                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string query = "select id,first_name,last_name,gender,dob,phone,address from student where id='" + find + "'";
                SqlDataAdapter sdq = new SqlDataAdapter(query, con);
                sdq.SelectCommand.Parameters.AddWithValue("@first_name", txtfind.Text.Trim());
                DataTable data = new DataTable();
                sdq.Fill(data);
                if (data.Rows.Count > 0)
                {
                    textBox1.Text = data.Rows[0]["first_name"].ToString();
                    textBox3.Text = data.Rows[0]["last_name"].ToString();

                    string sex = data.Rows[0]["gender"].ToString();
                    if (sex == "MALE      ")
                    {
                        radmale.Checked = true;
                    }
                    else
                    {
                        radfemale.Checked = true;
                    }
                    date.Text = data.Rows[0]["dob"].ToString();
                    textBox5.Text = data.Rows[0]["phone"].ToString();
                    textBox6.Text = data.Rows[0]["address"].ToString();
                }
                else
                {
                    MessageBox.Show("NO Result Found");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message, "ERROR");

            }
        }
        private void txtfind_KeyPress(object sender, KeyPressEventArgs e)
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
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class managescore : Form
    {
        public managescore()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        score scorestd = new score();
        public void binddata()
        {
            try
            {

                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "  SELECT student.first_name,student.last_name,score.course_name,score.student_score,score.description FROM student INNER JOIN score ON student.first_name = score.student_name";
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
        bool Check = true;
        private void managescore_Load(object sender, EventArgs e)
        {

            binddata();
            //     STUDENT IN COMBO BOX 1 Load FROM Sql Server --------------------------------
            SqlConnection con = new SqlConnection(cs);
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["first_name"].ToString());
            }
            con.Close();
            //     COURSES IN COMBO BOX 1 Load FROM Sql Server --------------------------------

            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from  course";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                comboBox2.Items.Add(dr1["label"].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please Select Student Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please Select Course Name ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Score", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string student = comboBox1.Text;
                string course = comboBox2.Text;
                if (scorestd.scoreexist(student, course) == false)
                {
                    MessageBox.Show("Score Already Exist For Same Student ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int score = int.Parse(textBox1.Text);
                    string desc = textBox2.Text;
                    scorestd.addscore(student, course, score, desc);
                    MessageBox.Show("Score Added Successfully", "Addes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    binddata();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string name = comboBox2.Text;
                string s = comboBox1.Text;
                //string s = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (scorestd.scoreexist(s, name) == true)
                {
                    MessageBox.Show("Course Does Not Exist !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    binddata();

                }
                else
                {
                    scorestd.deletecourse(name);
                    MessageBox.Show("Deleted Successfully", "Addes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    binddata();
                }


            }
            catch (Exception ezx)
            {
                MessageBox.Show(ezx.Message, "Addes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                //textBox2.Visible = false;
                //comboBox2.Visible = false;
                //comboBox1.Visible = false;
                //textBox1.Visible = false;
                //label1.Visible = false;
                //label2.Visible = false;
                //label3.Visible = false;
                //label4.Visible = false;
                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                Check = false;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "select * from student";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox2.Visible = false;
                //comboBox2.Visible = false;
                //comboBox1.Visible = false;
                //textBox1.Visible = false;
                //label1.Visible = false;
                //label2.Visible = false;
                //label3.Visible = false;
                //label4.Visible = false;
                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                Check = false;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String query = "select * from course";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Check = true;
            binddata();
            //textBox2.Visible = true;
            //comboBox2.Visible = true;
            //comboBox1.Visible = true;
            //textBox1.Visible = true;
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (dataGridView1.SelectedRows<0)
            //{
            //    MessageBox.Show("ERROR");
            //}
            //else
            //{
            //MessageBox.Show(sender.ToString());
            if (Check == true)
            {

                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            //}
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}



using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class addscore : Form
    {
        score scorestd = new score();
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public addscore()
        {
            InitializeComponent();
        }

        private void addscore_Load(object sender, EventArgs e)
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

            //SqlConnection con = new SqlConnection(cs);
            //comboBox1.Items.Clear();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student where first_name='" + comboBox1.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Text = dr["first_name"].ToString();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from course where label='" + comboBox2.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Text = dr["label"].ToString();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        public void binddata()
        {
            try
            {

                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                //String query = "select * from score";
                String query = "    SELECT student.first_name,student.last_name,score.course_name,score.student_score,score.description FROM student INNER JOIN score ON student.first_name = score.student_name ";
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message, "ERROR");

            }
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

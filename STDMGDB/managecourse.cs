using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class managecourse : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public managecourse()
        {
            InitializeComponent();
        }
        course c = new course();
        public void filllist()
        {
            SqlConnection con = new SqlConnection(cs);
            listView1.Items.Clear();
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
                listView1.Items.Add(dr["label"].ToString());
            }
            con.Close();
        }
        private void managecourse_Load(object sender, EventArgs e)
        {
            filllist();

            totcourse.Text = "TOTAL COURSE : " + c.totcourse();
        }


        void showdata()
        {
            try
            {
                string ss = "";
                int i = listView1.FocusedItem.Index;
                string sss = listView1.Items[i].Text;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from course where label='" + sss + "'";


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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showdata();




        }
        int i;
        private void button1_Click(object sender, EventArgs e)
        {

            course course = new course();
            string label = textBox1.Text;
            int num = (int)noofhour.Value;
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Course Label", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (course.checklabel(label) == true)
                {

                    if (textBox3.Text == string.Empty)
                    {
                        errorProvider1.SetError(textBox3, "PLease Enter Course Code");
                    }
                    else if (noofhour.Value == 0)
                    {
                        errorProvider1.Clear();
                        errorProvider2.SetError(noofhour, "PLease Enter Credit Hour");

                    }
                    //else if (noofhour.Value < 0 && noofhour.Value > 50)
                    //{
                    //    MessageBox.Show("Credit Hour Can't Exceeded 50", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                    else
                    {
                        num = (int)noofhour.Value;
                        string add = textBox2.Text;
                        string cc = textBox3.Text;
                        course.addcourse(cc, label, num, add);
                        MessageBox.Show("Course Added", "ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        filllist();
                        totcourse.Text = "TOTAL COURSE : " + c.totcourse();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        noofhour.Value = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (listView1.SelectedItems != null)
                {
                    if (textBox1.Text.Length > 0)
                    {
                        textBox1.ReadOnly = true;
                        SqlConnection con = new SqlConnection(cs);

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        showdata1();
                        cmd.CommandText = " UPDATE course set hour_number='" + noofhour.Value + "',description='" + textBox2.Text + "',C_code='" + textBox3.Text + "' where label='" + textBox1.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Course", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        totcourse.Text = "TOTAL COURSE : " + c.totcourse();
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        noofhour.Value = 0;
                        textBox1.ReadOnly = false;
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
        void showdata1()
        {
            try
            {
                string ss = "";
                int i = listView1.FocusedItem.Index;
                string sss = listView1.Items[i].Text;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from course where label='" + sss + "'";


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["label"].ToString();
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                course c = new course();
                string s = textBox1.Text;
                if (c.checklabel(s) == false)
                {
                    c.deletecourse(s);
                    MessageBox.Show("Course Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    filllist();
                    totcourse.Text = "TOTAL COURSE : " + c.totcourse();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    noofhour.Value = 0;
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

        private void noofhour_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
                if (noofhour.Text.Length >= 2 || e.KeyValue == 109)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(c.totcourse()) - int.Parse(c.totcourse());

            showindex(index);
            indexs = 0;
        }

        void showindex(int index)
        {
            try
            {
                string ss = "";

                string sss = listView1.Items[index].Text;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from course where label='" + sss + "'";


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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int index = int.Parse(c.totcourse()) - 1;

            showindex(index);

            string sss = listView1.Items[index].Text;
            
            indexs = int.Parse(c.totcourse()) - 1;
        }

       

        int indexs = 0;
        private void next_Click(object sender, EventArgs e)
        {
            int count = int.Parse(c.totcourse()) - 1;
            if ( indexs< count)
            {
                indexs = indexs + 1;
                showindex(indexs);
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            int count = int.Parse(c.totcourse()) ;
            if (indexs < count&&indexs>0)
            {
                indexs = indexs - 1;
               
                showindex(indexs);
            }
        }
    }
}

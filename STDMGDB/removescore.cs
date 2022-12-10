using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class removescore : Form
    {
        public removescore()
        {
            InitializeComponent();
            binddata();
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
                String query = " SELECT student.first_name,student.last_name,score.course_name,score.student_score,score.description FROM student INNER JOIN score ON student.first_name = score.student_name";
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
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            string name = textBox1.Text;
                string s = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (scorestd.scoreexist(s,name) == true)
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
              
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
        }
    }
}

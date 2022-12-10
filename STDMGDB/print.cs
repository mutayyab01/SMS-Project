using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class print : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //managestdfoam man = new managestdfoam();
        public print()
        {
            InitializeComponent();


            binddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //man.binddata();

            binddata();
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

        private void print_Load(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            //else
            //{
            //    dateTimePicker1.Enabled = true;
            //    dateTimePicker2.Enabled = true;

            //}
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";
            if (radioButton4.Checked)
            {
                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                if (radioButton2.Checked)//MALE RADIO BUTTON
                {
                    query = "SELECT * FROM student where dob between '" + date1 + "' AND '" + date2 + "' AND gender ='MALE'";

                }
                else if (radioButton3.Checked)//FEMALE RADIO BUTTON
                {
                    query = "SELECT * FROM student where dob between '" + date1 + "' AND '" + date2 + "' AND gender ='FEMALE'";


                }
                else
                {
                    query = "SELECT * FROM student where dob between '" + date1 + "' AND '" + date2 + "'";

                }
                binddata(query);

            }
            else
            {
                if (radioButton2.Checked)//MALE RADIO BUTTON
                {
                    query = "SELECT * FROM student where gender ='MALE'";

                }
                else if (radioButton3.Checked)//FEMALE RADIO BUTTON
                {
                    query = "SELECT * FROM student where  gender ='FEMALE'";


                }
                else
                {
                    query = "SELECT * FROM student  ";

                }
                binddata(query);













            }

        }
        void binddata(string query1)
        {
            try
            {

                //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                String queryy = query1;
                SqlDataAdapter sda = new SqlDataAdapter(queryy, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "SAVE FILE";
                save.Filter = "Text File (*.txt)|*.txt | All File(*.*)|*.*";
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var writer = new StreamWriter(File.Create(save.FileName)/*, Encoding.UTF8*/))
                    {
                        if (!File.Exists(save.FileName))
                        {
                            //MessageBox.Show("FILE ALREADY EXIST ", "EXIST", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            File.Create(save.FileName);
                        }
                        else
                        {
                            //File.Create(path);
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    if (j == 4)
                                    {
                                        DateTime bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value);
                                        writer.Write("\t   " + bdate.ToString("yyyy-MM-dd") + "\t   " + "|");
                                    }
                                    else if (j == dataGridView1.ColumnCount - 1)
                                    {
                                        writer.Write("\t   " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t   ");

                                    }
                                    else
                                    {
                                        writer.Write("\t   " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t   " + "|");

                                    }

                                }
                                writer.WriteLine("");
                                writer.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                            }
                            writer.Close();
                            MessageBox.Show("DATA EXPORTED SUCCESSFULLY", "DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }


                #region save coding
                //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\stutent_list.txt";
                ////using (var writer = new StreamWriter(path/*, Encoding.UTF8*/))
                ////{
                ////    if (!File.Exists(path))
                ////    {
                ////        //MessageBox.Show("FILE ALREADY EXIST ", "EXIST", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ////        File.Create(path);
                ////    }
                ////    else
                ////    {
                ////        //File.Create(path);
                ////        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                ////        {
                ////            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                ////            {
                ////                if (j == 4)
                ////                {
                ////                    DateTime bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value);
                ////                    writer.Write("\t   " + bdate.ToString("yyyy-MM-dd") + "\t   " + "|");
                ////                }
                ////                else if (j== dataGridView1.ColumnCount-1)
                ////                {
                ////                    writer.Write("\t   " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t   ");

                ////                }
                ////                else
                ////                {
                ////                    writer.Write("\t   " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t   " + "|");

                ////                }

                ////            }
                ////            writer.WriteLine("");
                ////            writer.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                ////        }
                ////        writer.Close();
                ////        MessageBox.Show("DATA EXPORTED SUCCESSFULLY", "DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////    }
                ////} 
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

















    }
}


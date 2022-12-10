using System;
using System.Configuration;
using System.Data.SqlClient;

namespace STDMGDB
{
    class addstudent
    {
        private object dataGridView1;
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public void add_student(String fname, String lname, String gender, String dob, String phone, String address)
        {


            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "insert into student(first_name,last_name,gender,dob,phone,address) values('" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + phone + "','" + address + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void update_student(int i, String fname, String lname, String gender, String dob, String phone, String address)
        {


            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "update student set first_name='" + fname + "',last_name='" + lname + "',gender='" + gender + "',dob='" + dob + "',phone='" + phone + "',address='" + address + "' where id='" + i + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void delete_student(int i)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "delete from student where id='"+i+"' ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }














    }
}

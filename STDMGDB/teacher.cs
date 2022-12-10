using System;
using System.Configuration;
using System.Data.SqlClient;

namespace STDMGDB
{
    class teacher
    {
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public void Addteacher(string fullname, string username, string gender, string birthdate, string phone, string address)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "insert into teacher(full_name,username,gender,birth_date,phone,address) values('" + fullname + "','" + username + "','" + gender + "','" + birthdate + "','" + phone + "','" + address + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool checkusername(string check)
        {
            //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "  SELECT * FROM teacher WHERE username='" + check + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }
        public void addusernameto_usertbl(string username)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "insert into [user](username,passward) values('" + username + "','1234')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void updateteacher(int i, string name, string username, string gender, string birthdate, string phone, string address)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "update teacher set full_name='" + name + "',username='" + username + "',gender='" + gender + "',birth_date='" + birthdate + "',phone='" + phone + "',address='" + address + "' where id='" + i + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateusernameto_usertbl(int id,string username/*,string passward*/)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "update [user] set username ='" + username + "' where id='"+id+"'"; 
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void delete_teacher(int id)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "delete from teacher where id='" + id + "' ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DELETEusernameto_usertbl(string username/*,string passward*/)
        {
            //String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "delete from [user] where username='"+username+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


















    }
}

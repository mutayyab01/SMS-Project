using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace STDMGDB
{
    class course
    {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public void addcourse(string coursecode, string label, int hournumber, string description)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "insert into course (C_code,label,hour_number,description) values(@C_code,@label,@hour_number,@description)";

            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@label", label);
            cmd.Parameters.AddWithValue("@C_code", coursecode);
            cmd.Parameters.AddWithValue("@hour_number", hournumber);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public bool checklabel(string s)
        {
            //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "  SELECT * FROM course WHERE label='"+s+"'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
          
            if(dr.HasRows==true)
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
        public bool deletecourse(string name)
        {

            //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "DELETE FROM course WHERE label='" + name + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@label", name);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public DataTable getallcourse()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "select * from course";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;
        }

        //public DataTable getallcoursebyyname(string name)
        //{
        //    SqlConnection con = new SqlConnection(cs);
        //    con.Open();
        //    String query = "  Select * from course WHERE label='" + name + "'";

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataAdapter dr = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    dr.Fill(dt);
        //    return dt;
            
        //}
        //----------------------------------------------------------------------------------------------------------------------

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
        public string totcourse()
        {

            return execcount("select count(*) from course");
        }


    }
}

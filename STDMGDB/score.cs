using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDMGDB
{
    class score
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        public void addscore(string student_name, string course_name, int student_score, string description)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = "insert into score (student_name,course_name,student_score,description) values(@student_name,@course_name,@student_score,@description)";

            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@student_name", student_name);
            cmd.Parameters.AddWithValue("@course_name", course_name);
            cmd.Parameters.AddWithValue("@student_score", student_score);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        // Checking score if exist or not----------------------------
        public bool scoreexist(string student,string course)
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            String query = " select * from score where [student_name]='"+student+"' AND course_name='"+course+"'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
         
            if (dr.HasRows==true)
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
            String query = "DELETE FROM score WHERE course_name='" + name + "'";

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

        //--------Populate data to gridview in remove course foam



    }
}

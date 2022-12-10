using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace STDMGDB
{
    class Studenrcount
    {

        public static int Count(String tabelname)
        {
            int total=0;
            String connectionstring = "Data Source=DESKTOP-PD9ESJ4\\SQLEXPRESS;Initial Catalog=StMGDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            String query = "SELECT COUNT(*)AS\"total\"FROM\"\"user\"";
                      

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return total;
        }




















    }
}

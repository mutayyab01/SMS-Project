using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace STDMGDB
{
    public partial class stdindatabase : Form
    {
        Color totalpanel1;
        Color panelfemale;
        Color panelmale;
            //stdindatabase st = new stdindatabase();
        public stdindatabase()
        {
            InitializeComponent();

            totalpanel1 = totalpanel.BackColor;
            panelmale = malepanel.BackColor;
            panelfemale = femalepanel.BackColor;

           double totalstudent = Convert.ToDouble(totstd());
            double female = Convert.ToDouble(totfemale());
            double male = Convert.ToDouble(totmale());

            double malepercentage=Math.Round(((male/totalstudent)*100),2);

            double femalepercentage= Math.Round(((female/totalstudent)*100),2);


            totalstd.Text = "TOTAL STUDENT = " + totalstudent;
            malestd.Text = "MALE  % :" + malepercentage;
            femalestd.Text = "FEMALE  % :" + femalepercentage;


        }
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void totalstd_MouseEnter(object sender, EventArgs e)
        {
            totalpanel.BackColor = Color.White;
            totalstd.ForeColor = totalpanel1;
        }

        private void totalstd_MouseLeave(object sender, EventArgs e)
        {
            totalpanel.BackColor = totalpanel1;
            totalstd.ForeColor = Color.White;
        }

        private void malestd_MouseEnter(object sender, EventArgs e)
        {
            malepanel.BackColor = Color.White;
            malestd.ForeColor = panelmale;
        }

        private void malestd_MouseLeave(object sender, EventArgs e)
        {
            malepanel.BackColor = panelmale;
            malestd.ForeColor = Color.White;
        }

        private void femalestd_MouseEnter(object sender, EventArgs e)
        {
            femalepanel.BackColor = Color.White;
            femalestd.ForeColor = panelfemale;
        }

        private void femalestd_MouseLeave(object sender, EventArgs e)
        {
            femalepanel.BackColor = panelfemale;
            femalestd.ForeColor = Color.White;
        }
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
        public string totstd() {

            return execcount("select count(*) from student");
        }
        public string totmale()
        {

            return execcount("select count(*) from student where gender='MALE'");
        }
        public string totfemale()
        {

            return execcount("select count(*) from student where gender='FEMALE'");
        }








































    }
}

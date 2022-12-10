using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STDMGDB
{
    public partial class Main_Foam : Form
    {
        public static Main_Foam instance;
        public Label lbl;
        public Main_Foam()
        {
            InitializeComponent();
            instance = this;
            lbl = lblname;
        }
        private void Main_Foam_Load(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            lblname.Text = f1.Name.ToUpper();
        }
        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newstudent newstudent =  new newstudent();
            newstudent.Show();
        }
        private void mANAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managestdfoam manage = new managestdfoam();
            manage.Show();
        }

        private void sTATICSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stdindatabase st = new stdindatabase();
            st.Show();
        }

        private void pRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print p = new print();
            p.Show();
        }

        private void aDDCOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addcourse add = new addcourse();
            add.Show();
        }

        private void eDITCOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editcourse edit = new editcourse();
            edit.Show();
        }

        private void mANAGECOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managecourse man = new managecourse();
            man.Show();
        }

        private void rEMOVECOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removecourse remove = new removecourse();
            remove.Show();
        }

        private void aDDSCOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addscore addscore = new addscore();
            addscore.Show();
        }

        private void rEMOVESCOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removescore remove = new removescore();
            remove.Show();
        }

        private void mANAGESCOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managescore sc = new managescore();
            sc.Show();
        }

        private void cHANGEPASSWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepassward change = new changepassward();
            change.Show();
           
        }
    }
}

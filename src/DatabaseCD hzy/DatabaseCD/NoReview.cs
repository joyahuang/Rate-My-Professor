using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DatabaseCD
{
    public partial class NoReview : Form
    {
        int cid;
        SqlConnection myconn;
        public NoReview(int cid_,SqlConnection conn)
        {
            InitializeComponent();
            cid = cid_;
            myconn = conn;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            coursesComment cc = new coursesComment(cid,myconn);
            cc.ShowDialog();
            if (cc.DialogResult == DialogResult.OK) {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

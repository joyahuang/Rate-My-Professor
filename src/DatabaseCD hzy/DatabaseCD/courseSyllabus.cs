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
using System.IO;

namespace DatabaseCD
{
    public partial class courseSyllabus : Form
    {
        int cID;
        SqlConnection myconn;
        public courseSyllabus(int cID_, SqlConnection conn)
        {
            InitializeComponent();
            this.cID = cID_;
            this.myconn = conn;
        }
        private void courseSyllabus_Load(object sender, EventArgs e)
        {
            SqlDataAdapter imgadapter = new SqlDataAdapter("select coutline from Course where cID=" + cID.ToString(), myconn);
            DataTable mytable = new DataTable();
            imgadapter.Fill(mytable);
            if (!Convert.IsDBNull(mytable.Rows[0].ItemArray[0])) {
                byte[] mydata = (byte[])mytable.Rows[0].ItemArray[0];
                MemoryStream myPic = new MemoryStream(mydata);
                pictureBox1.Image = Image.FromStream(myPic);          
            }
            myconn.Close();
        }
    }
}

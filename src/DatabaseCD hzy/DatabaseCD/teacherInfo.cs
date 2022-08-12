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
using DevExpress.XtraGrid.Views.Tile;

namespace DatabaseCD
{
    public partial class teacherInfo : Form
    {
        int tID;
        public teacherInfo(int tid_,SqlConnection myconn)
        {
            InitializeComponent();
            //基本信息修改
            tID = tid_;
            string t = "select tclg,tname,tmail,toffice,tpic from Teacher where tID=" + tID.ToString();
            SqlCommand tcmd = new SqlCommand(t, myconn);
            myconn.Open();
            {
                SqlDataReader myreader = tcmd.ExecuteReader();
                while (myreader.Read())
                {
                    //基本信息
                    label11.Text = myreader["tname"].ToString().Trim();
                    label6.Text = myreader["tclg"].ToString().Trim();
                    label7.Text = myreader["toffice"].ToString().Trim();
                    label12.Text = myreader["tmail"].ToString().Trim();
                    if (!Convert.IsDBNull(myreader["tpic"])) {
                        byte[] mydata = (byte[])myreader["tpic"];
                        MemoryStream myPic = new MemoryStream(mydata);
                        pictureBox1.Image = Image.FromStream(myPic);
                    }
                    
                }
                myreader.Close();
            }
            myconn.Close();
            //教的课程列表
            SqlCommand mycmd = new SqlCommand("select cid,cname,cclg,csms,ctype,callScore,cassnum,cscoring,ctcptc,chelp,chwl,tname from StaticCourse where tid= " + tID.ToString(), myconn);
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                if (mydatareader.HasRows)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = mydatareader;
                    this.gridControl1.DataSource = bs;
                    mydatareader.Close();
                }
            }
            myconn.Close();

        }
        private void teacherInfo_Load(object sender, EventArgs e)
        {

        }

        private void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            TileViewItem t = (TileViewItem)e.DataItem;
            int cid = int.Parse(tileView1.GetRowCellValue(t.RowHandle, colcid).ToString());
            //VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.vconn);
            thiscourse.Show();
        }

        private void tileView1_ItemDoubleClick(object sender, TileViewItemClickEventArgs e)
        {
            int[] r = tileView1.GetSelectedRows();
            //int cid = int.Parse(tileView1.GetDataRow(r[0])["课程号"]);
            int cid = int.Parse(tileView1.GetRowCellValue(r[0], colcid).ToString());
            //VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.vconn);
            thiscourse.Show();
        }
    }
}

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
using DatabaseCD;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Tile;

namespace RateMyCourse
{
    public partial class Hot : Form
    {
        //static string conn = @"Data Source=.;Initial Catalog=databasecd;Integrated Security=True";
        SqlConnection myconn = VitalMessage.myconn;
        //static string mystr = "select * from staticcourse";
        //SqlDataAdapter myadapter = new SqlDataAdapter(mystr, conn);
       

        public Hot()
        {
            InitializeComponent();

            gridControl1.Width = 1067;
            gridControl1.Height = 542;
            SqlCommand mycmd = new SqlCommand("select * from hotCourse", myconn);
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                if (mydatareader.HasRows)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = mydatareader;
                    gridControl1.DataSource = bs;
                }
            }
            myconn.Close();
        
        }

        private void Hot_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“databaseCDDataSet.hotCourse”中。您可以根据需要移动或删除它。
            //this.hotCourseTableAdapter.Fill(this.databaseCDDataSet.hotCourse);

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
         
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            int[] r = tileView1.GetSelectedRows();
            //int cid = int.Parse(tileView1.GetDataRow(r[0])["课程号"]);
            int cid=int.Parse(tileView1.GetRowCellValue(r[0],colcid).ToString());
            VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.myconn);         
            thiscourse.Show();

        }

        private void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            TileViewItem t = (TileViewItem)e.DataItem;
            int cid = int.Parse(tileView1.GetRowCellValue(t.RowHandle, colcid).ToString());
            VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.myconn);
            thiscourse.Show();
        }
    }
}

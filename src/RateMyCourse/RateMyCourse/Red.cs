using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Tile;
using System.Data.SqlClient;
namespace RateMyCourse
{
    public partial class Red : Form
    {
        SqlConnection myconn = VitalMessage.myconn;
        public Red()
        {
            InitializeComponent();
        }

        private void Red_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“databaseCDDataSet.redCourse”中。您可以根据需要移动或删除它。
            //this.redCourseTableAdapter.Fill(this.databaseCDDataSet.redCourse);
            //// TODO: 这行代码将数据加载到表“databaseCDDataSet2.redCourse”中。您可以根据需要移动或删除它。
            //this.redCourseTableAdapter.Fill(this.databaseCDDataSet2.redCourse);
            //// TODO: 这行代码将数据加载到表“databaseCDDataSet2.hotCourse”中。您可以根据需要移动或删除它。
            //this.hotCourseTableAdapter.Fill(this.databaseCDDataSet2.hotCourse);
            SqlCommand mycmd = new SqlCommand("select * from redCourse", myconn);
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

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            int[] r = tileView1.GetSelectedRows();
            //int cid = int.Parse(tileView1.GetDataRow(r[0])["课程号"]);
            int cid = int.Parse(tileView1.GetRowCellValue(r[0], colcid).ToString());
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

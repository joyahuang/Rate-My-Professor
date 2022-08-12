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

namespace RateMyCourse
{
    public partial class StaticCourse : Form
    {
        SqlConnection myconn = VitalMessage.myconn;
        public StaticCourse()
        {
            InitializeComponent();
        }

        private void StaticCourse_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“databaseCDDataSet.StaticCourse”中。您可以根据需要移动或删除它。
            //this.staticCourseTableAdapter.Fill(this.databaseCDDataSet.StaticCourse);
            SqlCommand mycmd = new SqlCommand("select * from staticCourse", myconn);
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            int[] r = gridView1.GetSelectedRows();
            //int cid = int.Parse(tileView1.GetDataRow(r[0])["课程号"]);
            //int cid = int.Parse(gridView1.GetDataRow(r[0])["cid"].ToString());
            int cid = int.Parse(gridView1.GetRowCellValue(r[0], colcid).ToString());
            VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.myconn);

            thiscourse.Show();
        }
    }
}

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
    public partial class Collect : Form
    {
        //static string conn = @"Data Source=.;Initial Catalog=DatabaseCD;Integrated Security=True";
        SqlConnection myconn = VitalMessage.myconn;
        
        
        public Collect()
        {
            InitializeComponent();
        }

        private void Collect_Load(object sender, EventArgs e)
        {
            //// TODO: 这行代码将数据加载到表“databaseCDDataSet1.Course”中。您可以根据需要移动或删除它。
            //this.courseTableAdapter.Fill(this.databaseCDDataSet1.Course);
            //// TODO: 这行代码将数据加载到表“databaseCDDataSet.myCollection”中。您可以根据需要移动或删除它。
            //this.myCollectionTableAdapter.Fill(this.databaseCDDataSet.myCollection);
            string mystr = "SELECT "
            + "dbo.StaticCourse.cname,dbo.StaticCourse.cclg,dbo.StaticCourse.csms, dbo.StaticCourse.cid, "
            + "dbo.StaticCourse.ctype,dbo.StaticCourse.callScore,dbo.StaticCourse.ctcptc, "
            + "dbo.StaticCourse.cscoring, "
            + "dbo.StaticCourse.chelp,dbo.StaticCourse.chwl, "
            + "dbo.StaticCourse.tname "
            + "FROM dbo.StaticCourse,dbo.myCollection "
            + "WHERE dbo.myCollection.myuID = "+ VitalMessage.uid.ToString()
            + "AND dbo.StaticCourse.cid = dbo.myCollection.cID ";
            SqlDataAdapter myadapter = new SqlDataAdapter(mystr, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "collection");
            gridControl1.DataSource = mydataset.Tables["collection"];
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void cardView1_Click(object sender, EventArgs e)
        {
            int[] r = cardView1.GetSelectedRows();
            //int cid = int.Parse(tileView1.GetDataRow(r[0])["课程号"]);
            int cid = int.Parse(cardView1.GetDataRow(r[0])["cid"].ToString());
            VitalMessage.cid = cid;
            DatabaseCD.courseInfo thiscourse = new DatabaseCD.courseInfo(cid,VitalMessage.uid,VitalMessage.myconn);

            thiscourse.Show();
        }
    }
}

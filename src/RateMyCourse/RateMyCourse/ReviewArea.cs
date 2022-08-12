using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Tile;
using System.Data.SqlClient;

namespace DatabaseCD
{
    public partial class ReviewArea : Form
    {
        int cid;
        SqlConnection myconn;
        courseInfo ci;
        public ReviewArea(BindingSource bs, int cid_, SqlConnection conn,courseInfo ci_)
        {
            InitializeComponent();
            gridControl1.DataSource = bs;
            cid = cid_;
            myconn = conn;
            ci = ci_;
        }

        private void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            TileViewItem t = (TileViewItem)e.DataItem;
            string a = tileView1.GetRowCellValue(t.RowHandle, colmyuID).ToString();
            string sql = "update Review set rlike=rlike+1 where cID="+cid.ToString()+" and myuID="+a;
            SqlCommand asscmd = new SqlCommand(sql, myconn);
            myconn.Open();
            {
                try { asscmd.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            myconn.Close();
            ci.simpleButton5.PerformClick();
        }

        private void ReviewArea_Load(object sender, EventArgs e)
        {

        }
    }
}

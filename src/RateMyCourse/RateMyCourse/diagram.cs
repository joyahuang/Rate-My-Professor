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
using DevExpress.XtraCharts;

namespace DatabaseCD
{
    public partial class diagram : Form
    {
        //请修改数据库connection
        static string mystr = @"Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myconn = new SqlConnection(mystr);
        DataSet mydataset = new DataSet();
        DataTable table = new DataTable();
        public diagram(int cid,string colname,string title)
        {
            InitializeComponent();
            //找数据
            ChartControl barChart = new ChartControl();
            string mysql="";
            if (colname != "hwl") { mysql = "select " + colname + ",count(" + colname + ") from Assessment where cID=" + cid.ToString() + " group by " + colname; }
            else { mysql = "select hwl=case hwl	when '1' then  '1小时以下'when '2' then  '1-2小时'when '3' then  '2-3小时'when '5' then  '3-4小时'else '4小时以上' end	,count(hwl) from Assessment where cID=" + cid.ToString() + "group by hwl"; }
            SqlDataAdapter myadapter = new SqlDataAdapter(mysql,myconn);
            myadapter.Fill(mydataset, "a");
            table=mydataset.Tables["a"];
            //放到pie里
            Series s1 = new Series(title, ViewType.Bar);
            foreach (DataRow dr in table.Rows) { 
                s1.Points.Add(new SeriesPoint(dr[0].ToString(),dr[1]));
            }
            barChart.Series.Add(s1);
            //格式
            BarSeriesView myview = (BarSeriesView)s1.View;
            //barChart.Titles.Add(new ChartTitle());
            //barChart.Titles[0].Text = s1.Name;
            barChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            barChart.Dock = DockStyle.Fill;
            this.Controls.Add(barChart);
        }
    }
}

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
    public partial class courseInfo : Form
    {
        int cID;
        int tID;
        //请修改数据库connection
        static string mystr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myconn = new SqlConnection(mystr);
        public courseInfo(int cID_)
        {
            InitializeComponent();
            this.cID = cID_;
            //初始化
            evaluation_init();
            review_init();
            //判断该用户是否收藏过该课程
            string collection = "select * from myCollection where cID=" + cID.ToString() + "and myuID=" + VitalMessage.uid.ToString(); ;
            SqlCommand collectioncmd = new SqlCommand(collection, myconn);
            myconn.Open();
            SqlDataReader myreader = collectioncmd.ExecuteReader();
            if (myreader.HasRows)
            {
                simpleButton1.ForeColor = SystemColors.Control;
                simpleButton1.Enabled = false;
            }
            myreader.Close();
            myconn.Close();
            //判断该用户是否评价过该课程
            string assessment = "select * from Assessment where cID=" + cID.ToString() + "and myuID=" + VitalMessage.uid.ToString(); ;
            SqlCommand asscmd = new SqlCommand(assessment, myconn);
            myconn.Open();
            myreader = asscmd.ExecuteReader();
            if (myreader.HasRows)
            {
                simpleButton3.ForeColor = SystemColors.Control;
                simpleButton3.Enabled = false;
            }
            myreader.Close();
            myconn.Close();
            //判断该用户是否今天评论过该课程
            string rev = "select * from Review where cID=" + cID.ToString() + "and myuID=" + VitalMessage.uid.ToString() + "and rdate='" + DateTime.Now.ToString("d")+"'";
            SqlCommand revcmd = new SqlCommand(rev, myconn);
            myconn.Open();
            myreader = revcmd.ExecuteReader();
            if (myreader.HasRows)
            {
                simpleButton4.ForeColor = SystemColors.Control;
                simpleButton4.Enabled = false;
            }
            myreader.Close();
            myconn.Close();
            //加载静态的基本信息
            string course = "select cname,tid,cclg,tname,csms,ctype,cppt from StaticCourse where cID=" + cID.ToString();
            SqlCommand coursecmd = new SqlCommand(course, myconn);
            myconn.Open();
            {
                myreader = coursecmd.ExecuteReader();
                while (myreader.Read())
                {
                    //基本信息
                    tID = Convert.ToInt32(myreader["tid"]);
                    cidLabel.Text = myreader["cname"].ToString().Trim();
                    cclgLabel.Text = myreader["cclg"].ToString().Trim();
                    tnameLabel.Text = myreader["tname"].ToString().Trim();
                    csmsLabel.Text = myreader["csms"].ToString().Trim();
                    ctypeLabel.Text = myreader["ctype"].ToString().Trim();
                    //考勤
                    string[] cppt = myreader["cppt"].ToString().Split(new char[4] { 'A', 'P', 'H', 'T' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < 4; i++) if (cppt[i][0].Equals('0')) cppt[i] = cppt[i].Remove(0, 1);
                    label23.Text = cppt[0] + "%";
                    label24.Text = cppt[1] + "%";
                    label25.Text = cppt[2] + "%";
                    label26.Text = cppt[3] + "%";
                }
                myreader.Close();
            }
            myconn.Close();
        }
        private void evaluation_init() {  
            string course = "select callScore,cassnum,cscoring,ctcptc,chelp,chwl from StaticCourse where cID=" + cID.ToString();
            SqlCommand coursecmd = new SqlCommand(course, myconn);
            SqlDataReader myreader;
            myconn.Open();
            {
                myreader = coursecmd.ExecuteReader();
                while (myreader.Read())
                {
                    //评价
                    callscoreLabel.Text = myreader["callScore"].ToString();
                    cassnumLabel.Text = "此条目共有" + myreader["cassnum"].ToString() + "人评价";
                    label11.Text = myreader["cscoring"].ToString();
                    label16.Text = myreader["ctcptc"].ToString();
                    label17.Text = myreader["chelp"].ToString();
                    label18.Text = myreader["chwl"].ToString();
                }
                myreader.Close();
            }
            myconn.Close();          
            //加载总体印象分的图表
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "allscore", "总体印象分");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
            
        }
        public void review_init() {
            //加载评论区
            SqlCommand mycmd = new SqlCommand("getReview", myconn);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter cid = new SqlParameter("@_cID", SqlDbType.Int);
            mycmd.Parameters.Add(cid);
            cid.Value = cID;
            SqlDataReader mydatareader;
            myconn.Open();
            {
                mydatareader = mycmd.ExecuteReader();
                if (mydatareader.HasRows)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = mydatareader;
                    ReviewArea ra = new ReviewArea(bs, cID, myconn,this);
                    panel2.Controls.Clear();
                    ra.TopLevel = false;
                    panel2.Controls.Add(ra);
                    ra.Show();
                    mydatareader.Close();
                }
                else
                {
                    NoReview nr = new NoReview(cID, myconn);
                    panel2.Controls.Clear();
                    nr.TopLevel = false;
                    panel2.Controls.Add(nr);
                    nr.Show();
                    if (nr.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("refresh");
                        review_init();
                    }
                }
            }
            myconn.Close();
        }
        private void courseInfo_Load(object sender, EventArgs e)
        {
          
           
        }

        private void label9_Click(object sender, EventArgs e)
        {
            teacherInfo t = new teacherInfo(tID,myconn);
            t.ShowDialog();
        }



        private void callscoreLabel_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "allscore", "总体印象分");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "scoring", "给分");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "tcptc", "上课质量");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "help", "教师热心程度");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            diagram cs = new diagram(cID, "hwl", "作业量");
            cs.TopLevel = false;
            panel1.Controls.Add(cs);
            cs.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            courseSyllabus cs = new courseSyllabus(cID,myconn);
            cs.ShowDialog();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string favorite = "insert into myCollection values('"+VitalMessage.uid+"','" + cID.ToString()+"')";
            SqlCommand favoritecmd = new SqlCommand(favorite, myconn);
            myconn.Open();
            {
                try { favoritecmd.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            myconn.Close();
            simpleButton1.Enabled = false;
        }


        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            coursesEvaluation ce = new coursesEvaluation(cID,myconn);
            ce.ShowDialog();
            simpleButton3.Enabled = false;
            evaluation_init();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            coursesComment cc = new coursesComment(cID, myconn);
            cc.ShowDialog();
            if (cc.DialogResult == DialogResult.OK) {
                review_init();
            }
            simpleButton4.Enabled = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            review_init();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            evaluation_init();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

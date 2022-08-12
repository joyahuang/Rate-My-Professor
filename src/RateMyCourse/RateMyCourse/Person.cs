using DatabaseCD;
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
    public partial class Person : Form
    {
        //static string connStr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myconn = VitalMessage.myconn;
        Collect collect = new Collect();
        public Person()
        {
            InitializeComponent();
        }
        
        private void Person_Load(object sender, EventArgs e)
        {
            collect.TopLevel = false;
            panel1.Controls.Add(collect);
            collect.Show();

            byte[] MyData = new byte[0];
            {
                myconn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myconn;
                cmd.CommandText = "SELECT dbo.myUser.upic,unkname,umail,uclg,umj,uermy,upro FROM dbo.myUser WHERE myuID=" + VitalMessage.uid.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                label11.Text = sdr["unkname"].ToString();
                label12.Text = sdr["umail"].ToString();
                label14.Text = sdr["uclg"].ToString();
                label9.Text = sdr["umj"].ToString();
                if (Convert.IsDBNull(sdr["uermy"])) { label8.Text = "-"; }
                else { label8.Text = sdr["uermy"].ToString(); }
                label13.Text= convertToName(sdr["upro"].ToString());

                if (Convert.IsDBNull(sdr["upic"]))
                {
                    myconn.Close();
                    return;
                }
                

                MyData = (byte[])sdr["upic"];//读取第一个图片的位流
                myconn.Close();
            }
            var ms = new System.IO.MemoryStream(MyData);
            var bmp = new Bitmap(ms);
            ms.Dispose();
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alterInfo info = new alterInfo(this);
            info.Show();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            alterPhoto alterMyPhoto = new alterPhoto(this);
            alterMyPhoto.Show();
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alterPassword thisAlter = new alterPassword();
            thisAlter.Show();
        }
        public string convertToName(string level)
        {
            if (level == "1") return "本科生";
            if (level == "2") return "研究生";
            if (level == "3") return "博士生";
            if (level == "4") return "其他";
            else return "-";
        }
    }
}

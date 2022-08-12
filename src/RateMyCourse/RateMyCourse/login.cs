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
    public partial class login : Form
    {
        public static int myuID;
        //static string connStr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myConn = RateMyCourse.VitalMessage.myconn;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registration r = new registration();
            r.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //如果登录失败，则重新输入
            if (!checkLogin()) return;
            //不然登录成功
            this.Hide();
            
            RateMyCourse.MainForm m = new RateMyCourse.MainForm();
            m.ShowDialog();
            this.Close();
        }
        private bool checkLogin()
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            DataSet ds = new DataSet();
            string find = "SELECT * FROM myUser WHERE umail = '" + email + "'";
            SqlDataAdapter myAdapter = new SqlDataAdapter(find, myConn);
            int n = myAdapter.Fill(ds, "person");
            //邮箱不存在
            if (n == 0)
            {
                MessageBox.Show("该邮箱不存在，请重新输入！");
                textBox1.Text = "";
                textBox2.Text = "";
                return false;
            }

            //密码不正确
            if (password != ds.Tables["person"].Rows[0][2].ToString())
            {
                MessageBox.Show("密码不正确，请重新输入！");
                //textBox1.Text = "";
                textBox2.Text = "";
                return false;
            }

            //else成功登录
            myuID = int.Parse(ds.Tables["person"].Rows[0][0].ToString());
            //更新vitalMessa
            RateMyCourse.VitalMessage.uid = myuID;
            return true;
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
    }
   
}

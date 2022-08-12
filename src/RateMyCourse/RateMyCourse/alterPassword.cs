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
using RateMyCourse;

namespace DatabaseCD
{
    public partial class alterPassword : Form
    {
        //static string connStr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myConn = VitalMessage.myconn;
        public alterPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //输入密码符合规范

            //TODO：判断两次输入是否一致


            //TODO:Update myUser
            string old = textBox1.Text;
            string new1 = textBox2.Text;
            string new2 = textBox3.Text;
            //原密码是否正确
            if (!isOldCorrect(old)) return;
            //新密码是否符合规范
            if (!checkFormat(new1)) return;
            //新密码两次是否相同
            if (new1 != new2)
            {
                MessageBox.Show("两次新密码不同，请重新输入！");
                textBox2.Text = "";
                textBox3.Text = "";
                return;
            }

            //没问题，修改密码
            updatePassword(VitalMessage.uid, new1);
            this.Close();
            this.Close();

        }
        private bool isOldCorrect(string old)
        {
            DataSet ds = new DataSet();
            string find = "SELECT upswd FROM myUser WHERE myuID = " + VitalMessage.uid.ToString();
            SqlDataAdapter myAdapter = new SqlDataAdapter(find, myConn);
            myAdapter.Fill(ds, "password");
            if (old == ds.Tables["password"].Rows[0][0].ToString()) return true;
            else
            {
                MessageBox.Show("原密码不正确，请重新输入！");
                textBox1.Text = "";
                return false;
            }
        }
        //新密码是否符合规范
        private bool checkFormat(string password)
        {
            if (password.Length < 8 || password.Length > 12)
            {
                MessageBox.Show("密码长度应为8-12位，请重新输入！");
                textBox2.Text = "";
                textBox3.Text = "";
                return false;
            }
            else return true;
        }
        //修改密码至数据库
        private void updatePassword(int myuID, string password)
        {
            string update = "UPDATE myUser SET upswd = '" + password + "' WHERE myuID = " + myuID.ToString();
            SqlCommand cmd = new SqlCommand(update, myConn);
            myConn.Open();
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            myConn.Close();
            MessageBox.Show("密码修改成功！");
        }
    }
}
    
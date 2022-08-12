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
    public partial class registration : Form
    {
        //static string connStr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myConn = RateMyCourse.VitalMessage.myconn;

        string email;
        string password;
        string nickName;
        string major;
        string college;
        string startYear;
        string trainLevel;
        public registration()
        {
            InitializeComponent();
            for(int i=2010;i<=2030;i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert myUser
            //读取所填信息
            getPersonInfo();
            //必填项
            if (!checkFormat()) return;
            //检查邮箱是否被注册
            if (isEmailExisted()) return;
            //没问题，把当前用户添加进数据库
            insertUser();
            this.Close();
           
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //不支持空格
            if (e.KeyChar == 32)
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.SelectionStart - 1, 1);
                MessageBox.Show("密码不应含有空格！");
            }
        }
        private void getPersonInfo()
        {
            email = textBox3.Text;
            password = textBox2.Text;
            nickName = textBox1.Text;
            major = textBox4.Text;
            college = textBox5.Text;
            if(comboBox1.SelectedItem!=null)startYear = comboBox1.SelectedItem.ToString();
            if (comboBox3.SelectedItem != null) trainLevel = convertToNum(comboBox3.SelectedItem.ToString());
        }
        //必填项
        private bool checkFormat()
        {
            //密码长度
            if (password.Length < 8 || password.Length > 12)
            {
                MessageBox.Show("密码长度应为8-12位，请重新输入！");
                textBox2.Text = "";
                return false;
            }
            //邮箱 昵称不为空
            if (email.Length == 0 || nickName.Length == 0)
            {
                if (email.Length == 0)
                {
                    MessageBox.Show("邮箱不为空，请重新输入！");
                    textBox3.Text = "";
                }
                if (nickName.Length == 0)
                {
                    MessageBox.Show("昵称不为空，请重新输入！");
                    textBox1.Text = "";
                }
                return false;
            }
            return true;
        }
        //检查邮箱是否被注册
        private bool isEmailExisted()
        {
            string find = "SELECT * FROM myUser WHERE umail = '" + email + "'";
            SqlDataAdapter myAdapter = new SqlDataAdapter(find, myConn);
            DataSet ds = new DataSet();
            //如果查到n！=0， 没查到n为0
            int n = myAdapter.Fill(ds, "register");
            if (n != 0)
            {
                MessageBox.Show("该邮箱已被注册，请重新输入！");
                textBox3.Text = "";
                return true;
            }
            else
                return false;
        }
        //把当前用户添加进数据库
        private void insertUser()
        {
            string insert = "INSERT INTO myUser VALUES( "+ "'"+email + "','" + password + "','" + nickName + "','" + college + "','" + major + "','" + startYear + "','" + trainLevel + "',"+" null)";
            SqlCommand cmd = new SqlCommand(insert, myConn);
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
            MessageBox.Show("注册成功！");
        }
        //培养层次 文字到数字的映射转换
        public string convertToNum(string level)
        {
            if (level == "本科生") return "1";
            if (level == "研究生") return "2";
            if (level == "博士生") return "3";
            else return "4";
        }

    }
}


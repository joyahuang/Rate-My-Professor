using RateMyCourse;
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
    public partial class alterInfo : Form
    {
        Person f;
        string major;
        string college;
        string startYear;
        string trainLevel;
        //static string connStr = "Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True";
        SqlConnection myConn = VitalMessage.myconn;
        public alterInfo(){
            InitializeComponent();
        }
        public alterInfo(Person person)
        {
            f = person;
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //从UI里取修改后的值
            getNewInfo();
            //更新数据库
            updateInfo();
            //更新person页面
            updatePersonUI();
            this.Close();

        }
        private void alterInfo_Load(object sender, EventArgs e)
        {
            
        }
        //从UI里取修改后的值
        private void getNewInfo()
        {
            major = textBox4.Text;
            college = textBox5.Text;
            startYear = comboBox1.SelectedItem.ToString();
            trainLevel = comboBox3.Text;
        }
        //更新数据库
        private void updateInfo()
        {
            string update = "UPDATE myUser SET umj = '" + major + "', uclg = '" + college + "', uermy = '" + startYear + "', upro = '" + convertToNum(trainLevel) + "' WHERE myuID = '" + VitalMessage.uid.ToString() + "'";
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
            MessageBox.Show("修改成功！");
        }
        //更新person页面
        private void updatePersonUI()
        {
            
            f.label9.Text = major;
            f.label14.Text = college;
            f.label8.Text = startYear;
            f.label13.Text = trainLevel;
        }
        public string convertToNum(string level)
        {
            if (level == "本科生") return "1";
            if (level == "研究生") return "2";
            if (level == "博士生") return "3";
            else return "4";
        }

        private void alterInfo_Load_1(object sender, EventArgs e)
        {
            //显示当前信息
            for (int i = 2010; i <= 2030; i++)
            {
                comboBox1.Items.Add(i);
            }
            textBox4.Text = f.label9.Text;
            textBox5.Text = f.label14.Text;
            //如果入学年份为空，则默认显示第一项
            if (f.label8.Text == "-" || f.label8.Text == "") comboBox1.SelectedIndex = 0;
            else
            {
                //eg.如果是2011 则为第二项，则下标为2011 - 2010 = 1
                comboBox1.SelectedIndex = int.Parse(f.label8.Text) - 2010;
            }
            //如果培养层次为空，则默认显示第一项
            if (f.label13.Text == "-") comboBox3.SelectedIndex = 0;
            else
            {
                comboBox3.SelectedIndex = int.Parse(convertToNum(f.label13.Text)) - 1;
            }
        }
    }
}


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
    public partial class coursesComment : Form
    {
        int cID;
        SqlConnection myconn;
        public coursesComment(int cID_, SqlConnection conn)
        {
            InitializeComponent();
            myconn = conn;
            this.cID = cID_;
            
       
        }
        private void coursesComment_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length<=0)
            {
                MessageBox.Show("请填写完整");
                return;
            }else if(richTextBox1.Text.Length>100){
                MessageBox.Show("你写太多了，可能进不了数据库");
                return;
            }
            string ass = "insert into Review values('" + VitalMessage.uid + "','" + cID.ToString() + "','" + DateTime.Now.ToString("d") + "','0','" + richTextBox1.Text + "')";
            SqlCommand asscmd = new SqlCommand(ass, myconn);
            myconn.Open();
            {
                try { asscmd.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            myconn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();      
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "";

            richTextBox1.ForeColor = Color.Black;
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            { richTextBox1.Text = "请输入评论";
            richTextBox1.ForeColor = Color.LightGray;
            }
        }
    }
}

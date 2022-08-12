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
using System.IO;
namespace DatabaseCD
{
    public partial class alterPhoto : Form
    {
        //static string conn = @"Data Source=.;Initial Catalog=DatabaseCD;Integrated Security=True";
        SqlConnection myconn = VitalMessage.myconn;

        Byte[] UpdataPicture;
        int sig = 0;
        Person person;
        public alterPhoto()
        {
            InitializeComponent();
        }
        public alterPhoto(Person p)
        {
            person = p;
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //出错了
            openFileDialog1.Title = "选择头像";
            openFileDialog1.Filter = @"图片文件(*.gif,*.jpg,*.jepg,*.png,*.bmp)|*.gif,*.jpg,*.jepg,*.png,*.bmp|
                                       所有文件(*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            string file = openFileDialog1.FileName;
            if (file.Length == 0)
            {
                MessageBox.Show("未选择图片");
                return;
            }
            sig = 1;
            Console.WriteLine(file);
            pictureBox2.Image = System.Drawing.Image.FromFile(file);
            //转换为二进制文件
            
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            UpdataPicture = new byte[fs.Length];
            fs.Read(UpdataPicture, 0, Convert.ToInt32(fs.Length));
            fs.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (sig == 0) { 
                MessageBox.Show("未选择图片");
                return;
            }

            SqlDataAdapter myadapter = new SqlDataAdapter("select * from myUser WHERE myuid =" + VitalMessage.uid.ToString(), myconn);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);

            mytable.Rows[0]["upic"] = UpdataPicture;
            SqlCommandBuilder cmd = new SqlCommandBuilder(myadapter);
            try
            { myadapter.Update(mytable.GetChanges()); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }


            var ms = new System.IO.MemoryStream(UpdataPicture);
            var bmp = new Bitmap(ms);
            ms.Dispose();
            person.pictureBox1.Image = bmp;
            this.Close();

        }
        private void alterPhoto_Load(object sender, EventArgs e)
        {
            byte[] MyData = new byte[0];
            {
               
                myconn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myconn;
                cmd.CommandText = "SELECT dbo.myUser.upic FROM dbo.myUser WHERE myuID="+VitalMessage.uid.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (Convert.IsDBNull(sdr["upic"])) {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

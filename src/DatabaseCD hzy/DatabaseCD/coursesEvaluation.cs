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
    public partial class coursesEvaluation : Form
    {
        int cID;
        int scoring=0;
        int tcptc=0;
        int help=0;
        int hwl=0;
        int allScore=0;
        //请修改数据库connection
        SqlConnection myconn ;
        public coursesEvaluation(int cID_, SqlConnection conn)
        {
            InitializeComponent();
            this.cID = cID_;
            myconn = conn;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.starfull;
            pictureBox2.Image = Properties.Resources.staremp;
            pictureBox3.Image = Properties.Resources.staremp;
            pictureBox4.Image = Properties.Resources.staremp;
            pictureBox5.Image = Properties.Resources.staremp;
            scoring = 1;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.starfull;
            pictureBox2.Image = Properties.Resources.starfull;
            pictureBox3.Image = Properties.Resources.staremp;
            pictureBox4.Image = Properties.Resources.staremp;
            pictureBox5.Image = Properties.Resources.staremp;
            scoring = 2;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.starfull;
            pictureBox2.Image = Properties.Resources.starfull;
            pictureBox3.Image = Properties.Resources.starfull;
            pictureBox4.Image = Properties.Resources.staremp;
            pictureBox5.Image = Properties.Resources.staremp;
            scoring = 3;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.starfull;
            pictureBox2.Image = Properties.Resources.starfull;
            pictureBox3.Image = Properties.Resources.starfull;
            pictureBox4.Image = Properties.Resources.starfull;
            pictureBox5.Image = Properties.Resources.staremp;
            scoring = 4;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.starfull;
            pictureBox2.Image = Properties.Resources.starfull;
            pictureBox3.Image = Properties.Resources.starfull;
            pictureBox4.Image = Properties.Resources.starfull;
            pictureBox5.Image = Properties.Resources.starfull;
            scoring = 5;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.starfull;
            pictureBox9.Image = Properties.Resources.staremp;
            pictureBox8.Image = Properties.Resources.staremp;
            pictureBox7.Image = Properties.Resources.staremp;
            pictureBox6.Image = Properties.Resources.staremp;
            tcptc = 1;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.starfull;
            pictureBox9.Image = Properties.Resources.starfull;
            pictureBox8.Image = Properties.Resources.staremp;
            pictureBox7.Image = Properties.Resources.staremp;
            pictureBox6.Image = Properties.Resources.staremp;
            tcptc = 2;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.starfull;
            pictureBox9.Image = Properties.Resources.starfull;
            pictureBox8.Image = Properties.Resources.starfull;
            pictureBox7.Image = Properties.Resources.staremp;
            pictureBox6.Image = Properties.Resources.staremp;
            tcptc = 3;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.starfull;
            pictureBox9.Image = Properties.Resources.starfull;
            pictureBox8.Image = Properties.Resources.starfull;
            pictureBox7.Image = Properties.Resources.starfull;
            pictureBox6.Image = Properties.Resources.staremp;
            tcptc = 4;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.starfull;
            pictureBox9.Image = Properties.Resources.starfull;
            pictureBox8.Image = Properties.Resources.starfull;
            pictureBox7.Image = Properties.Resources.starfull;
            pictureBox6.Image = Properties.Resources.starfull;
            tcptc = 5;
        }
        private void coursesEvaluation_Load(object sender, EventArgs e){        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.starfull;
            pictureBox14.Image = Properties.Resources.staremp;
            pictureBox13.Image = Properties.Resources.staremp;
            pictureBox12.Image = Properties.Resources.staremp;
            pictureBox11.Image = Properties.Resources.staremp;
            help = 1;
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.starfull;
            pictureBox14.Image = Properties.Resources.starfull;
            pictureBox13.Image = Properties.Resources.staremp;
            pictureBox12.Image = Properties.Resources.staremp;
            pictureBox11.Image = Properties.Resources.staremp;
            help = 2;
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.starfull;
            pictureBox14.Image = Properties.Resources.starfull;
            pictureBox13.Image = Properties.Resources.starfull;
            pictureBox12.Image = Properties.Resources.staremp;
            pictureBox11.Image = Properties.Resources.staremp;
            help = 3;
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.starfull;
            pictureBox14.Image = Properties.Resources.starfull;
            pictureBox13.Image = Properties.Resources.starfull;
            pictureBox12.Image = Properties.Resources.starfull;
            pictureBox11.Image = Properties.Resources.staremp;
            help = 4;
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.starfull;
            pictureBox14.Image = Properties.Resources.starfull;
            pictureBox13.Image = Properties.Resources.starfull;
            pictureBox12.Image = Properties.Resources.starfull;
            pictureBox11.Image = Properties.Resources.starfull;
            help = 5;
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.starfull;
            pictureBox19.Image = Properties.Resources.staremp;
            pictureBox18.Image = Properties.Resources.staremp;
            pictureBox17.Image = Properties.Resources.staremp;
            pictureBox16.Image = Properties.Resources.staremp;
            allScore = 1;
        }

        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.starfull;
            pictureBox19.Image = Properties.Resources.starfull;
            pictureBox18.Image = Properties.Resources.staremp;
            pictureBox17.Image = Properties.Resources.staremp;
            pictureBox16.Image = Properties.Resources.staremp;
            allScore = 2;
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.starfull;
            pictureBox19.Image = Properties.Resources.starfull;
            pictureBox18.Image = Properties.Resources.starfull;
            pictureBox17.Image = Properties.Resources.staremp;
            pictureBox16.Image = Properties.Resources.staremp;
            allScore = 3;
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.starfull;
            pictureBox19.Image = Properties.Resources.starfull;
            pictureBox18.Image = Properties.Resources.starfull;
            pictureBox17.Image = Properties.Resources.starfull;
            pictureBox16.Image = Properties.Resources.staremp;
            allScore = 4;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.starfull;
            pictureBox19.Image = Properties.Resources.starfull;
            pictureBox18.Image = Properties.Resources.starfull;
            pictureBox17.Image = Properties.Resources.starfull;
            pictureBox16.Image = Properties.Resources.starfull;
            allScore = 5;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hwl = comboBox1.SelectedIndex+1;
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (scoring == 0 || tcptc == 0 || help == 0 || hwl == 0 || allScore == 0) {
                MessageBox.Show("请填写完整");
                return;
            }
            string ass = "insert into Assessment values('" + VitalMessage.uid + "','" + cID.ToString() + "','" + scoring.ToString() + "','" + tcptc.ToString() + "','" + help.ToString() + "','" + hwl.ToString() + "','" + allScore.ToString() + "')";
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
    }
}

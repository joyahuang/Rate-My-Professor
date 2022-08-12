using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RateMyCourse
{
    public partial class Square : Form
    {
        Hot hot = new Hot();
        Red red = new Red();
        Black black = new Black();
        public Square()
        {
            InitializeComponent();
            //simpleButton1.BringToFront();
        }

        private void Square_Load(object sender, EventArgs e)
        {
            //初始化三个page
            hot.TopLevel = false;
            red.TopLevel = false;
            black.TopLevel = false;

            //绑定到tabControl
            xtraTabControl1.TabPages[0].Controls.Add(hot);
            xtraTabControl1.TabPages[1].Controls.Add(red);
            xtraTabControl1.TabPages[2].Controls.Add(black);

            //最开始显示热门
            xtraTabControl1.SelectedTabPageIndex = 0;
            hot.Show();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
                hot.Show();
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
                red.Show();
            else
                black.Show();
                
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

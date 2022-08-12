using DevExpress.Utils.Filtering.Internal;
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
    public partial class MainForm : Form
    {
        Point point = new Point(0, 0);
        bool mouseDown = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Square s = new Square();
            s.TopLevel = false;
            panel2.Controls.Add(s);
            s.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            label1.Text = "Course Information";
            panel2.Controls.Clear();
            StaticCourse staticCourse = new StaticCourse();
            staticCourse.TopLevel = false;
            panel2.Controls.Add(staticCourse);
            staticCourse.Show();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            label1.Text = "Personal Infromation";
            panel2.Controls.Clear();
            Person person = new Person();
            person.TopLevel = false;
            panel2.Controls.Add(person);
            person.Show();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            label1.Text = "Hot Course";
            panel2.Controls.Clear();
            Square s = new Square();
            s.TopLevel = false;
            panel2.Controls.Add(s);
            s.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
                if (point != e.Location) {
                    this.Location = new Point(this.Location.X + (e.Location.X - point.X), this.Location.Y + (e.Location.Y - point.Y));
                    Application.DoEvents();
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Location = new Point(this.Location.X + (e.Location.X - point.X), this.Location.Y + (e.Location.Y - point.Y));
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            point = e.Location;
        }
    }
}

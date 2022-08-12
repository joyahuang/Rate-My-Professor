namespace RateMyCourse
{
    partial class Collect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colcname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcclg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcsms = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colctype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchelp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchwl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcscoring = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colctcptc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.AllowDrop = true;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.cardView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(730, 566);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // cardView1
            // 
            this.cardView1.Appearance.CardCaption.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.CardCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.FieldValue.Options.UseTextOptions = true;
            this.cardView1.Appearance.FieldValue.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.cardView1.Appearance.FocusedCardCaption.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            this.cardView1.CardWidth = 167;
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcname,
            this.colcclg,
            this.colcsms,
            this.colctype,
            this.colchelp,
            this.colchwl,
            this.colcscoring,
            this.colctcptc,
            this.colcID,
            this.coltID});
            this.cardView1.DetailHeight = 292;
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            this.cardView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colcclg, DevExpress.Data.ColumnSortOrder.Descending)});
            this.cardView1.Click += new System.EventHandler(this.cardView1_Click);
            // 
            // colcname
            // 
            this.colcname.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colcname.AppearanceCell.BorderColor = System.Drawing.Color.IndianRed;
            this.colcname.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcname.AppearanceCell.Options.UseBackColor = true;
            this.colcname.AppearanceCell.Options.UseBorderColor = true;
            this.colcname.AppearanceCell.Options.UseFont = true;
            this.colcname.AppearanceCell.Options.UseForeColor = true;
            this.colcname.AppearanceCell.Options.UseTextOptions = true;
            this.colcname.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcname.Caption = "课程名称";
            this.colcname.FieldName = "cname";
            this.colcname.MinWidth = 115;
            this.colcname.Name = "colcname";
            this.colcname.Visible = true;
            this.colcname.VisibleIndex = 4;
            this.colcname.Width = 177;
            // 
            // colcclg
            // 
            this.colcclg.AppearanceCell.Options.UseTextOptions = true;
            this.colcclg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcclg.Caption = "开课学院";
            this.colcclg.FieldName = "cclg";
            this.colcclg.MinWidth = 42;
            this.colcclg.Name = "colcclg";
            this.colcclg.Visible = true;
            this.colcclg.VisibleIndex = 0;
            this.colcclg.Width = 144;
            // 
            // colcsms
            // 
            this.colcsms.AppearanceCell.Options.UseTextOptions = true;
            this.colcsms.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcsms.Caption = "开课学期";
            this.colcsms.FieldName = "csms";
            this.colcsms.MinWidth = 115;
            this.colcsms.Name = "colcsms";
            this.colcsms.Visible = true;
            this.colcsms.VisibleIndex = 6;
            this.colcsms.Width = 433;
            // 
            // colctype
            // 
            this.colctype.AppearanceCell.Options.UseTextOptions = true;
            this.colctype.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colctype.Caption = "课程类型";
            this.colctype.FieldName = "ctype";
            this.colctype.MinWidth = 115;
            this.colctype.Name = "colctype";
            this.colctype.Visible = true;
            this.colctype.VisibleIndex = 8;
            this.colctype.Width = 177;
            // 
            // colchelp
            // 
            this.colchelp.AppearanceCell.Options.UseTextOptions = true;
            this.colchelp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colchelp.Caption = "教师热心程度";
            this.colchelp.FieldName = "chelp";
            this.colchelp.MinWidth = 115;
            this.colchelp.Name = "colchelp";
            this.colchelp.Visible = true;
            this.colchelp.VisibleIndex = 1;
            this.colchelp.Width = 177;
            // 
            // colchwl
            // 
            this.colchwl.AppearanceCell.Options.UseTextOptions = true;
            this.colchwl.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colchwl.Caption = "作业量";
            this.colchwl.FieldName = "chwl";
            this.colchwl.MinWidth = 115;
            this.colchwl.Name = "colchwl";
            this.colchwl.Visible = true;
            this.colchwl.VisibleIndex = 2;
            this.colchwl.Width = 177;
            // 
            // colcID
            // 
            this.colcID.AppearanceCell.Options.UseTextOptions = true;
            this.colcID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcID.Caption = "课程号";
            this.colcID.FieldName = "cID";
            this.colcID.MinWidth = 115;
            this.colcID.Name = "colcID";
            this.colcID.Visible = true;
            this.colcID.VisibleIndex = 3;
            this.colcID.Width = 115;
            // 
            // colcscoring
            // 
            this.colcscoring.AppearanceCell.Options.UseTextOptions = true;
            this.colcscoring.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcscoring.Caption = "给分情况";
            this.colcscoring.FieldName = "cscoring";
            this.colcscoring.MinWidth = 115;
            this.colcscoring.Name = "colcscoring";
            this.colcscoring.Visible = true;
            this.colcscoring.VisibleIndex = 5;
            this.colcscoring.Width = 177;
            // 
            // colctcptc
            // 
            this.colctcptc.AppearanceCell.Options.UseTextOptions = true;
            this.colctcptc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colctcptc.Caption = "课程质量";
            this.colctcptc.FieldName = "ctcptc";
            this.colctcptc.MinWidth = 115;
            this.colctcptc.Name = "colctcptc";
            this.colctcptc.Visible = true;
            this.colctcptc.VisibleIndex = 7;
            this.colctcptc.Width = 433;
            // 
            // coltID
            // 
            this.coltID.AppearanceCell.Options.UseTextOptions = true;
            this.coltID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coltID.Caption = "教师号";
            this.coltID.FieldName = "tID";
            this.coltID.MinWidth = 115;
            this.coltID.Name = "coltID";
            this.coltID.Visible = true;
            this.coltID.VisibleIndex = 9;
            this.coltID.Width = 187;
            // 
            // Collect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 566);
            this.Controls.Add(this.gridControl1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Collect";
            this.Text = "Collect";
            this.Load += new System.EventHandler(this.Collect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
     //   private DatabaseCDDataSet1TableAdapters.CourseTableAdapter courseTableAdapter;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcclg;
        private DevExpress.XtraGrid.Columns.GridColumn colchelp;
        private DevExpress.XtraGrid.Columns.GridColumn colchwl;
        private DevExpress.XtraGrid.Columns.GridColumn colcID;
        private DevExpress.XtraGrid.Columns.GridColumn colcname;
        private DevExpress.XtraGrid.Columns.GridColumn colcscoring;
        private DevExpress.XtraGrid.Columns.GridColumn colcsms;
        private DevExpress.XtraGrid.Columns.GridColumn colctcptc;
        private DevExpress.XtraGrid.Columns.GridColumn colctype;
        private DevExpress.XtraGrid.Columns.GridColumn coltID;
    }
}
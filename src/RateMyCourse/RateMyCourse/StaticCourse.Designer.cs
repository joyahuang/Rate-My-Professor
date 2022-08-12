namespace RateMyCourse
{
    partial class StaticCourse
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.staticCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
           // this.databaseCDDataSet = new RateMyCourse.DatabaseCDDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colctype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcclg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcsms = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcallScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.colcscoring = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colctcptc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchelp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchwl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcassnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcid = new DevExpress.XtraGrid.Columns.GridColumn();
          //  this.staticCourseTableAdapter = new RateMyCourse.DatabaseCDDataSetTableAdapters.StaticCourseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticCourseBindingSource)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.databaseCDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.staticCourseBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(88, 102, 88, 102);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(88, 102, 88, 102);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl1});
            this.gridControl1.Size = new System.Drawing.Size(800, 758);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // staticCourseBindingSource
            // 
            this.staticCourseBindingSource.DataMember = "StaticCourse";
           // this.staticCourseBindingSource.DataSource = this.databaseCDDataSet;
            // 
            // databaseCDDataSet
            // 
           // this.databaseCDDataSet.DataSetName = "DatabaseCDDataSet";
            //this.databaseCDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcname,
            this.coltname,
            this.colctype,
            this.colcclg,
            this.colcsms,
            this.colcallScore,
            this.colcscoring,
            this.colctcptc,
            this.colchelp,
            this.colchwl,
            this.colcassnum,
            this.colcid});
            this.gridView1.DetailHeight = 10741;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colcscoring, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colcname
            // 
            this.colcname.Caption = "课程名";
            this.colcname.FieldName = "cname";
            this.colcname.MaxWidth = 200;
            this.colcname.MinWidth = 100;
            this.colcname.Name = "colcname";
            this.colcname.OptionsColumn.AllowEdit = false;
            this.colcname.Visible = true;
            this.colcname.VisibleIndex = 0;
            this.colcname.Width = 100;
            // 
            // coltname
            // 
            this.coltname.Caption = "授课教师";
            this.coltname.FieldName = "tname";
            this.coltname.MaxWidth = 100;
            this.coltname.MinWidth = 50;
            this.coltname.Name = "coltname";
            this.coltname.OptionsColumn.AllowEdit = false;
            this.coltname.Visible = true;
            this.coltname.VisibleIndex = 1;
            this.coltname.Width = 50;
            // 
            // colctype
            // 
            this.colctype.Caption = "课程类型";
            this.colctype.FieldName = "ctype";
            this.colctype.MaxWidth = 200;
            this.colctype.MinWidth = 100;
            this.colctype.Name = "colctype";
            this.colctype.OptionsColumn.AllowEdit = false;
            this.colctype.Visible = true;
            this.colctype.VisibleIndex = 2;
            this.colctype.Width = 100;
            // 
            // colcclg
            // 
            this.colcclg.Caption = "开设学院";
            this.colcclg.FieldName = "cclg";
            this.colcclg.MaxWidth = 300;
            this.colcclg.MinWidth = 200;
            this.colcclg.Name = "colcclg";
            this.colcclg.OptionsColumn.AllowEdit = false;
            this.colcclg.Visible = true;
            this.colcclg.VisibleIndex = 3;
            this.colcclg.Width = 200;
            // 
            // colcsms
            // 
            this.colcsms.Caption = "开设时间";
            this.colcsms.FieldName = "csms";
            this.colcsms.MaxWidth = 200;
            this.colcsms.MinWidth = 100;
            this.colcsms.Name = "colcsms";
            this.colcsms.OptionsColumn.AllowEdit = false;
            this.colcsms.Visible = true;
            this.colcsms.VisibleIndex = 4;
            this.colcsms.Width = 100;
            // 
            // colcallScore
            // 
            this.colcallScore.Caption = "总体印象分";
            this.colcallScore.ColumnEdit = this.repositoryItemRatingControl1;
            this.colcallScore.FieldName = "callScore";
            this.colcallScore.MaxWidth = 100;
            this.colcallScore.MinWidth = 100;
            this.colcallScore.Name = "colcallScore";
            this.colcallScore.OptionsColumn.AllowEdit = false;
            this.colcallScore.OptionsColumn.ShowInExpressionEditor = false;
            this.colcallScore.Visible = true;
            this.colcallScore.VisibleIndex = 5;
            this.colcallScore.Width = 100;
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.FillPrecision = DevExpress.XtraEditors.RatingItemFillPrecision.Exact;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            this.repositoryItemRatingControl1.ReadOnly = true;
            // 
            // colcscoring
            // 
            this.colcscoring.Caption = "给分情况";
            this.colcscoring.FieldName = "cscoring";
            this.colcscoring.MaxWidth = 150;
            this.colcscoring.MinWidth = 100;
            this.colcscoring.Name = "colcscoring";
            this.colcscoring.OptionsColumn.AllowEdit = false;
            this.colcscoring.Visible = true;
            this.colcscoring.VisibleIndex = 6;
            this.colcscoring.Width = 100;
            // 
            // colctcptc
            // 
            this.colctcptc.Caption = "教师热心程度";
            this.colctcptc.FieldName = "ctcptc";
            this.colctcptc.MaxWidth = 100;
            this.colctcptc.MinWidth = 100;
            this.colctcptc.Name = "colctcptc";
            this.colctcptc.OptionsColumn.AllowEdit = false;
            this.colctcptc.Visible = true;
            this.colctcptc.VisibleIndex = 7;
            this.colctcptc.Width = 100;
            // 
            // colchelp
            // 
            this.colchelp.Caption = "课程质量";
            this.colchelp.FieldName = "chelp";
            this.colchelp.MaxWidth = 100;
            this.colchelp.MinWidth = 100;
            this.colchelp.Name = "colchelp";
            this.colchelp.OptionsColumn.AllowEdit = false;
            this.colchelp.Visible = true;
            this.colchelp.VisibleIndex = 8;
            this.colchelp.Width = 100;
            // 
            // colchwl
            // 
            this.colchwl.Caption = "作业用时/周";
            this.colchwl.FieldName = "chwl";
            this.colchwl.MaxWidth = 100;
            this.colchwl.MinWidth = 100;
            this.colchwl.Name = "colchwl";
            this.colchwl.OptionsColumn.AllowEdit = false;
            this.colchwl.Visible = true;
            this.colchwl.VisibleIndex = 9;
            this.colchwl.Width = 100;
            // 
            // colcassnum
            // 
            this.colcassnum.Caption = "评论数";
            this.colcassnum.FieldName = "cassnum";
            this.colcassnum.MinWidth = 100;
            this.colcassnum.Name = "colcassnum";
            this.colcassnum.OptionsColumn.AllowEdit = false;
            this.colcassnum.Visible = true;
            this.colcassnum.VisibleIndex = 10;
            this.colcassnum.Width = 100;
            // 
            // colcid
            // 
            this.colcid.Caption = "课程号";
            this.colcid.FieldName = "cid";
            this.colcid.MinWidth = 60;
            this.colcid.Name = "colcid";
            this.colcid.OptionsColumn.AllowEdit = false;
            this.colcid.Visible = true;
            this.colcid.VisibleIndex = 11;
            this.colcid.Width = 60;
            // 
            // staticCourseTableAdapter
            // 
           // this.staticCourseTableAdapter.ClearBeforeFill = true;
            // 
            // StaticCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 758);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StaticCourse";
            this.Text = "StaticCourse";
            this.Load += new System.EventHandler(this.StaticCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticCourseBindingSource)).EndInit();
           // ((System.ComponentModel.ISupportInitialize)(this.databaseCDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        //private DatabaseCDDataSet databaseCDDataSet;
        private System.Windows.Forms.BindingSource staticCourseBindingSource;
        //private DatabaseCDDataSetTableAdapters.StaticCourseTableAdapter staticCourseTableAdapter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcname;
        private DevExpress.XtraGrid.Columns.GridColumn coltname;
        private DevExpress.XtraGrid.Columns.GridColumn colctype;
        private DevExpress.XtraGrid.Columns.GridColumn colcclg;
        private DevExpress.XtraGrid.Columns.GridColumn colcsms;
        private DevExpress.XtraGrid.Columns.GridColumn colcscoring;
        private DevExpress.XtraGrid.Columns.GridColumn colctcptc;
        private DevExpress.XtraGrid.Columns.GridColumn colchelp;
        private DevExpress.XtraGrid.Columns.GridColumn colchwl;
        private DevExpress.XtraGrid.Columns.GridColumn colcallScore;
        private DevExpress.XtraGrid.Columns.GridColumn colcassnum;
        private DevExpress.XtraGrid.Columns.GridColumn colcid;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
    }
}
namespace DatabaseCD
{
    partial class coursesComment
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.university5DataSet1 = new DatabaseCD.university5DataSet();
            this.commentTableAdapter1 = new DatabaseCD.university5DataSetTableAdapters.commentTableAdapter();
            this.university5DataSet11 = new DatabaseCD.university5DataSet1();
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentTableAdapter = new DatabaseCD.university5DataSet1TableAdapters.commentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.university5DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.university5DataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(373, 137);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
            this.richTextBox1.Leave += new System.EventHandler(this.richTextBox1_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(403, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "提交评价";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // university5DataSet1
            // 
            this.university5DataSet1.DataSetName = "university5DataSet";
            this.university5DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commentTableAdapter1
            // 
            this.commentTableAdapter1.ClearBeforeFill = true;
            // 
            // university5DataSet11
            // 
            this.university5DataSet11.DataSetName = "university5DataSet1";
            this.university5DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commentBindingSource
            // 
            this.commentBindingSource.DataMember = "comment";
            this.commentBindingSource.DataSource = this.university5DataSet11;
            // 
            // commentTableAdapter
            // 
            this.commentTableAdapter.ClearBeforeFill = true;
            // 
            // coursesComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 162);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "coursesComment";
            this.Text = "coursesComment";
            this.Load += new System.EventHandler(this.coursesComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.university5DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.university5DataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private university5DataSet university5DataSet1;
        private university5DataSetTableAdapters.commentTableAdapter commentTableAdapter1;
        private university5DataSet1 university5DataSet11;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private university5DataSet1TableAdapters.commentTableAdapter commentTableAdapter;
    }
}
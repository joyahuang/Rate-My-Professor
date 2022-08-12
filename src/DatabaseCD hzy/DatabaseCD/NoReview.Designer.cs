namespace DatabaseCD
{
    partial class NoReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoReview));
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(155, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "还没有人提交评论，快来抢沙发吧";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton4.Appearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton4.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.simpleButton4.Appearance.Options.UseBackColor = true;
            this.simpleButton4.Appearance.Options.UseBorderColor = true;
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Appearance.Options.UseForeColor = true;
            this.simpleButton4.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.simpleButton4.AppearanceDisabled.BorderColor = System.Drawing.Color.Silver;
            this.simpleButton4.AppearanceDisabled.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton4.AppearanceDisabled.ForeColor = System.Drawing.Color.Silver;
            this.simpleButton4.AppearanceDisabled.Options.UseBackColor = true;
            this.simpleButton4.AppearanceDisabled.Options.UseBorderColor = true;
            this.simpleButton4.AppearanceDisabled.Options.UseFont = true;
            this.simpleButton4.AppearanceDisabled.Options.UseForeColor = true;
            this.simpleButton4.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.simpleButton4.AppearanceHovered.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.simpleButton4.AppearanceHovered.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton4.AppearanceHovered.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.simpleButton4.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton4.AppearanceHovered.Options.UseBorderColor = true;
            this.simpleButton4.AppearanceHovered.Options.UseFont = true;
            this.simpleButton4.AppearanceHovered.Options.UseForeColor = true;
            this.simpleButton4.AppearancePressed.BackColor = System.Drawing.Color.White;
            this.simpleButton4.AppearancePressed.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.simpleButton4.AppearancePressed.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton4.AppearancePressed.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.simpleButton4.AppearancePressed.Options.UseBackColor = true;
            this.simpleButton4.AppearancePressed.Options.UseBorderColor = true;
            this.simpleButton4.AppearancePressed.Options.UseFont = true;
            this.simpleButton4.AppearancePressed.Options.UseForeColor = true;
            this.simpleButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButton4.Location = new System.Drawing.Point(194, 100);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(128, 39);
            this.simpleButton4.TabIndex = 31;
            this.simpleButton4.Text = "我要评论";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // NoReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoReview";
            this.Text = "NoReview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;

    }
}
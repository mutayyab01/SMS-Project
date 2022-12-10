namespace STDMGDB
{
    partial class stdindatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stdindatabase));
            this.femalepanel = new System.Windows.Forms.Panel();
            this.femalestd = new System.Windows.Forms.Label();
            this.malepanel = new System.Windows.Forms.Panel();
            this.malestd = new System.Windows.Forms.Label();
            this.totalpanel = new System.Windows.Forms.Panel();
            this.totalstd = new System.Windows.Forms.Label();
            this.femalepanel.SuspendLayout();
            this.malepanel.SuspendLayout();
            this.totalpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // femalepanel
            // 
            this.femalepanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.femalepanel.Controls.Add(this.femalestd);
            this.femalepanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.femalepanel.Location = new System.Drawing.Point(293, 172);
            this.femalepanel.Name = "femalepanel";
            this.femalepanel.Size = new System.Drawing.Size(295, 232);
            this.femalepanel.TabIndex = 5;
            // 
            // femalestd
            // 
            this.femalestd.AutoSize = true;
            this.femalestd.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.femalestd.Location = new System.Drawing.Point(19, 90);
            this.femalestd.Name = "femalestd";
            this.femalestd.Size = new System.Drawing.Size(180, 35);
            this.femalestd.TabIndex = 0;
            this.femalestd.Text = "FEMALE: 100";
            this.femalestd.MouseEnter += new System.EventHandler(this.femalestd_MouseEnter);
            this.femalestd.MouseLeave += new System.EventHandler(this.femalestd_MouseLeave);
            // 
            // malepanel
            // 
            this.malepanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.malepanel.Controls.Add(this.malestd);
            this.malepanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.malepanel.Location = new System.Drawing.Point(0, 172);
            this.malepanel.Name = "malepanel";
            this.malepanel.Size = new System.Drawing.Size(293, 232);
            this.malepanel.TabIndex = 4;
            // 
            // malestd
            // 
            this.malestd.AutoSize = true;
            this.malestd.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.malestd.Location = new System.Drawing.Point(28, 90);
            this.malestd.Name = "malestd";
            this.malestd.Size = new System.Drawing.Size(147, 35);
            this.malestd.TabIndex = 0;
            this.malestd.Text = "MALE: 100";
            this.malestd.MouseEnter += new System.EventHandler(this.malestd_MouseEnter);
            this.malestd.MouseLeave += new System.EventHandler(this.malestd_MouseLeave);
            // 
            // totalpanel
            // 
            this.totalpanel.BackColor = System.Drawing.Color.Gray;
            this.totalpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalpanel.Controls.Add(this.totalstd);
            this.totalpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalpanel.Location = new System.Drawing.Point(0, 0);
            this.totalpanel.Name = "totalpanel";
            this.totalpanel.Size = new System.Drawing.Size(588, 172);
            this.totalpanel.TabIndex = 3;
            // 
            // totalstd
            // 
            this.totalstd.AutoSize = true;
            this.totalstd.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalstd.Location = new System.Drawing.Point(161, 61);
            this.totalstd.Name = "totalstd";
            this.totalstd.Size = new System.Drawing.Size(291, 35);
            this.totalstd.TabIndex = 0;
            this.totalstd.Text = "TOTAL STUDENT : 100";
            this.totalstd.MouseEnter += new System.EventHandler(this.totalstd_MouseEnter);
            this.totalstd.MouseLeave += new System.EventHandler(this.totalstd_MouseLeave);
            // 
            // stdindatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 404);
            this.Controls.Add(this.femalepanel);
            this.Controls.Add(this.malepanel);
            this.Controls.Add(this.totalpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "stdindatabase";
            this.Text = "STATICS FORM";
            this.femalepanel.ResumeLayout(false);
            this.femalepanel.PerformLayout();
            this.malepanel.ResumeLayout(false);
            this.malepanel.PerformLayout();
            this.totalpanel.ResumeLayout(false);
            this.totalpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel femalepanel;
        private System.Windows.Forms.Label femalestd;
        private System.Windows.Forms.Panel malepanel;
        private System.Windows.Forms.Label malestd;
        private System.Windows.Forms.Panel totalpanel;
        private System.Windows.Forms.Label totalstd;
    }
}
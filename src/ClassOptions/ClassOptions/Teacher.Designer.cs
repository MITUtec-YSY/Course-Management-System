namespace ClassOptions
{
    partial class Teacher
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher));
            this.MinLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TeacherID = new System.Windows.Forms.Label();
            this.TeacherName = new System.Windows.Forms.Label();
            this.TurnBack = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.EditDataLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MinLabel
            // 
            this.MinLabel.BackColor = System.Drawing.Color.Cyan;
            this.MinLabel.Location = new System.Drawing.Point(694, -1);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(50, 28);
            this.MinLabel.TabIndex = 4;
            this.MinLabel.Text = "最小化";
            this.MinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MinLabel_Click);
            // 
            // CloseLabel
            // 
            this.CloseLabel.BackColor = System.Drawing.Color.Cyan;
            this.CloseLabel.Location = new System.Drawing.Point(750, -1);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(50, 28);
            this.CloseLabel.TabIndex = 5;
            this.CloseLabel.Text = "关闭";
            this.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseLabel_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Location = new System.Drawing.Point(12, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 388);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.viewList_DoubleClick);
            // 
            // TeacherID
            // 
            this.TeacherID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeacherID.ForeColor = System.Drawing.Color.White;
            this.TeacherID.Location = new System.Drawing.Point(12, 24);
            this.TeacherID.Name = "TeacherID";
            this.TeacherID.Size = new System.Drawing.Size(179, 23);
            this.TeacherID.TabIndex = 7;
            this.TeacherID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TeacherName
            // 
            this.TeacherName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeacherName.ForeColor = System.Drawing.Color.White;
            this.TeacherName.Location = new System.Drawing.Point(197, 24);
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.Size = new System.Drawing.Size(179, 23);
            this.TeacherName.TabIndex = 8;
            this.TeacherName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TurnBack
            // 
            this.TurnBack.BackColor = System.Drawing.Color.Cyan;
            this.TurnBack.Location = new System.Drawing.Point(618, -1);
            this.TurnBack.Name = "TurnBack";
            this.TurnBack.Size = new System.Drawing.Size(50, 28);
            this.TurnBack.TabIndex = 9;
            this.TurnBack.Text = "上一步";
            this.TurnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TurnBack.Click += new System.EventHandler(this.TurnBack_Click);
            // 
            // ClassLabel
            // 
            this.ClassLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClassLabel.ForeColor = System.Drawing.Color.White;
            this.ClassLabel.Location = new System.Drawing.Point(382, 24);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(179, 23);
            this.ClassLabel.TabIndex = 10;
            this.ClassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditDataLabel
            // 
            this.EditDataLabel.BackColor = System.Drawing.Color.White;
            this.EditDataLabel.Location = new System.Drawing.Point(10, 3);
            this.EditDataLabel.Name = "EditDataLabel";
            this.EditDataLabel.Size = new System.Drawing.Size(63, 21);
            this.EditDataLabel.TabIndex = 19;
            this.EditDataLabel.Text = "设置";
            this.EditDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditDataLabel.Click += new System.EventHandler(this.EditDataLabel_Click);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditDataLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.TurnBack);
            this.Controls.Add(this.TeacherName);
            this.Controls.Add(this.TeacherID);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Teacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label TeacherID;
        private System.Windows.Forms.Label TeacherName;
        private System.Windows.Forms.Label TurnBack;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label EditDataLabel;
    }
}


namespace ClassOptions
{
    partial class Student
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
            this.MinLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TeacherID = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.TurnBack = new System.Windows.Forms.Label();
            this.HClassList = new System.Windows.Forms.Label();
            this.ScoreList = new System.Windows.Forms.Label();
            this.SelectList = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CollegeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MajorLabel = new System.Windows.Forms.Label();
            this.GradeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.CreditSearch = new System.Windows.Forms.Label();
            this.TeacherSearch = new System.Windows.Forms.Label();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.EditDataLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(89, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(699, 388);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.viewList_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewList_RightClick);
            // 
            // TeacherID
            // 
            this.TeacherID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeacherID.ForeColor = System.Drawing.Color.White;
            this.TeacherID.Location = new System.Drawing.Point(86, 24);
            this.TeacherID.Name = "TeacherID";
            this.TeacherID.Size = new System.Drawing.Size(179, 23);
            this.TeacherID.TabIndex = 7;
            this.TeacherID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StudentName
            // 
            this.StudentName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StudentName.ForeColor = System.Drawing.Color.White;
            this.StudentName.Location = new System.Drawing.Point(271, 24);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(179, 23);
            this.StudentName.TabIndex = 8;
            this.StudentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TurnBack
            // 
            this.TurnBack.BackColor = System.Drawing.Color.Cyan;
            this.TurnBack.Location = new System.Drawing.Point(582, -1);
            this.TurnBack.Name = "TurnBack";
            this.TurnBack.Size = new System.Drawing.Size(50, 28);
            this.TurnBack.TabIndex = 9;
            this.TurnBack.Text = "上一步";
            this.TurnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TurnBack.Click += new System.EventHandler(this.TurnBack_Click);
            // 
            // HClassList
            // 
            this.HClassList.BackColor = System.Drawing.Color.White;
            this.HClassList.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HClassList.Location = new System.Drawing.Point(13, 125);
            this.HClassList.Name = "HClassList";
            this.HClassList.Size = new System.Drawing.Size(62, 64);
            this.HClassList.TabIndex = 10;
            this.HClassList.Text = "已选课程";
            this.HClassList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HClassList.Click += new System.EventHandler(this.HClassList_Click);
            // 
            // ScoreList
            // 
            this.ScoreList.BackColor = System.Drawing.Color.White;
            this.ScoreList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScoreList.Location = new System.Drawing.Point(34, 200);
            this.ScoreList.Name = "ScoreList";
            this.ScoreList.Size = new System.Drawing.Size(41, 43);
            this.ScoreList.TabIndex = 11;
            this.ScoreList.Text = "成绩查询";
            this.ScoreList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ScoreList.Click += new System.EventHandler(this.ScoreList_Click);
            // 
            // SelectList
            // 
            this.SelectList.BackColor = System.Drawing.Color.White;
            this.SelectList.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectList.Location = new System.Drawing.Point(13, 200);
            this.SelectList.Name = "SelectList";
            this.SelectList.Size = new System.Drawing.Size(62, 64);
            this.SelectList.TabIndex = 12;
            this.SelectList.Text = "待选课程";
            this.SelectList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectList.Click += new System.EventHandler(this.SelectList_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CollegeLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.MajorLabel);
            this.panel1.Controls.Add(this.GradeLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(89, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 388);
            this.panel1.TabIndex = 13;
            // 
            // CollegeLabel
            // 
            this.CollegeLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CollegeLabel.ForeColor = System.Drawing.Color.White;
            this.CollegeLabel.Location = new System.Drawing.Point(182, 221);
            this.CollegeLabel.Name = "CollegeLabel";
            this.CollegeLabel.Size = new System.Drawing.Size(294, 23);
            this.CollegeLabel.TabIndex = 5;
            this.CollegeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "学 院：";
            // 
            // MajorLabel
            // 
            this.MajorLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MajorLabel.ForeColor = System.Drawing.Color.White;
            this.MajorLabel.Location = new System.Drawing.Point(182, 158);
            this.MajorLabel.Name = "MajorLabel";
            this.MajorLabel.Size = new System.Drawing.Size(294, 23);
            this.MajorLabel.TabIndex = 3;
            this.MajorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GradeLabel
            // 
            this.GradeLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GradeLabel.ForeColor = System.Drawing.Color.White;
            this.GradeLabel.Location = new System.Drawing.Point(182, 94);
            this.GradeLabel.Name = "GradeLabel";
            this.GradeLabel.Size = new System.Drawing.Size(294, 23);
            this.GradeLabel.TabIndex = 2;
            this.GradeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(96, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "专 业：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "年 级：";
            // 
            // SearchLabel
            // 
            this.SearchLabel.BackColor = System.Drawing.Color.White;
            this.SearchLabel.Location = new System.Drawing.Point(38, 226);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(37, 38);
            this.SearchLabel.TabIndex = 14;
            this.SearchLabel.Text = "年级查询";
            this.SearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SearchLabel.Click += new System.EventHandler(this.Search_Class);
            // 
            // CreditSearch
            // 
            this.CreditSearch.BackColor = System.Drawing.Color.White;
            this.CreditSearch.Location = new System.Drawing.Point(36, 226);
            this.CreditSearch.Name = "CreditSearch";
            this.CreditSearch.Size = new System.Drawing.Size(37, 38);
            this.CreditSearch.TabIndex = 15;
            this.CreditSearch.Text = "选择学分";
            this.CreditSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CreditSearch.Click += new System.EventHandler(this.Search_Credit);
            // 
            // TeacherSearch
            // 
            this.TeacherSearch.BackColor = System.Drawing.Color.White;
            this.TeacherSearch.Location = new System.Drawing.Point(38, 226);
            this.TeacherSearch.Name = "TeacherSearch";
            this.TeacherSearch.Size = new System.Drawing.Size(37, 38);
            this.TeacherSearch.TabIndex = 16;
            this.TeacherSearch.Text = "选择老师";
            this.TeacherSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TeacherSearch.Click += new System.EventHandler(this.Search_Teacher);
            // 
            // SaveLabel
            // 
            this.SaveLabel.BackColor = System.Drawing.Color.Cyan;
            this.SaveLabel.Location = new System.Drawing.Point(638, -1);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(50, 28);
            this.SaveLabel.TabIndex = 17;
            this.SaveLabel.Text = "保存";
            this.SaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveLabel.Click += new System.EventHandler(this.SaveLabel_Click);
            // 
            // EditDataLabel
            // 
            this.EditDataLabel.BackColor = System.Drawing.Color.White;
            this.EditDataLabel.Location = new System.Drawing.Point(12, 74);
            this.EditDataLabel.Name = "EditDataLabel";
            this.EditDataLabel.Size = new System.Drawing.Size(63, 21);
            this.EditDataLabel.TabIndex = 18;
            this.EditDataLabel.Text = "设置";
            this.EditDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditDataLabel.Click += new System.EventHandler(this.EditDataLabel_Click);
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditDataLabel);
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SelectList);
            this.Controls.Add(this.ScoreList);
            this.Controls.Add(this.HClassList);
            this.Controls.Add(this.TurnBack);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.TeacherID);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.TeacherSearch);
            this.Controls.Add(this.CreditSearch);
            this.Controls.Add(this.SearchLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label TeacherID;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.Label TurnBack;
        private System.Windows.Forms.Label HClassList;
        private System.Windows.Forms.Label ScoreList;
        private System.Windows.Forms.Label SelectList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GradeLabel;
        private System.Windows.Forms.Label MajorLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label CreditSearch;
        private System.Windows.Forms.Label TeacherSearch;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CollegeLabel;
        private System.Windows.Forms.Label EditDataLabel;
    }
}
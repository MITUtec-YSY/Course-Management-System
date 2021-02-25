namespace ClassOptions
{
    partial class Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control));
            this.MinLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ControlID = new System.Windows.Forms.Label();
            this.AddLabel = new System.Windows.Forms.Label();
            this.ClassManage = new System.Windows.Forms.Label();
            this.TeacherManage = new System.Windows.Forms.Label();
            this.StudentManage = new System.Windows.Forms.Label();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.CollegePanel = new System.Windows.Forms.Panel();
            this.DelCollege = new System.Windows.Forms.Label();
            this.AddCollegeButton = new System.Windows.Forms.Button();
            this.CollegeNameBox = new System.Windows.Forms.TextBox();
            this.CollegeCodeBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CollegeAddRadioButton = new System.Windows.Forms.RadioButton();
            this.ClassPanel = new System.Windows.Forms.Panel();
            this.ClassCollegeCB = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.AddClassButton = new System.Windows.Forms.Button();
            this.ClassIntroductBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ClassCapBox = new System.Windows.Forms.TextBox();
            this.ClassCreditBox = new System.Windows.Forms.TextBox();
            this.ClassGradeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassNameBox = new System.Windows.Forms.TextBox();
            this.ClassIDBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentPanel = new System.Windows.Forms.Panel();
            this.StudentCollegeCB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.StudentAddButton = new System.Windows.Forms.Button();
            this.StudentMajorBox = new System.Windows.Forms.TextBox();
            this.StudentGradeBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.StudentNameBox = new System.Windows.Forms.TextBox();
            this.StudentIDBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TeacherPanel = new System.Windows.Forms.Panel();
            this.TeacherAddButton = new System.Windows.Forms.Button();
            this.TeacherNameBox = new System.Windows.Forms.TextBox();
            this.TeacherIDBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StudentAddRadioButton1 = new System.Windows.Forms.RadioButton();
            this.TeacherAddRadioButton = new System.Windows.Forms.RadioButton();
            this.ClassAddRadioButton = new System.Windows.Forms.RadioButton();
            this.SAVELabel = new System.Windows.Forms.Label();
            this.AddPanel.SuspendLayout();
            this.CollegePanel.SuspendLayout();
            this.ClassPanel.SuspendLayout();
            this.StudentPanel.SuspendLayout();
            this.TeacherPanel.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(109, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(679, 388);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.viewList_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewList_RightClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // ControlID
            // 
            this.ControlID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ControlID.ForeColor = System.Drawing.Color.White;
            this.ControlID.Location = new System.Drawing.Point(106, 24);
            this.ControlID.Name = "ControlID";
            this.ControlID.Size = new System.Drawing.Size(179, 23);
            this.ControlID.TabIndex = 7;
            this.ControlID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddLabel
            // 
            this.AddLabel.BackColor = System.Drawing.Color.White;
            this.AddLabel.Location = new System.Drawing.Point(12, 50);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(91, 78);
            this.AddLabel.TabIndex = 10;
            this.AddLabel.Text = "添加";
            this.AddLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ClassManage
            // 
            this.ClassManage.BackColor = System.Drawing.Color.White;
            this.ClassManage.Location = new System.Drawing.Point(13, 153);
            this.ClassManage.Name = "ClassManage";
            this.ClassManage.Size = new System.Drawing.Size(91, 78);
            this.ClassManage.TabIndex = 11;
            this.ClassManage.Text = "课程管理";
            this.ClassManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClassManage.Click += new System.EventHandler(this.ClassManage_Click);
            // 
            // TeacherManage
            // 
            this.TeacherManage.BackColor = System.Drawing.Color.White;
            this.TeacherManage.Location = new System.Drawing.Point(13, 256);
            this.TeacherManage.Name = "TeacherManage";
            this.TeacherManage.Size = new System.Drawing.Size(91, 78);
            this.TeacherManage.TabIndex = 12;
            this.TeacherManage.Text = "教师管理";
            this.TeacherManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TeacherManage.Click += new System.EventHandler(this.TeacherManage_Click);
            // 
            // StudentManage
            // 
            this.StudentManage.BackColor = System.Drawing.Color.White;
            this.StudentManage.Location = new System.Drawing.Point(12, 360);
            this.StudentManage.Name = "StudentManage";
            this.StudentManage.Size = new System.Drawing.Size(91, 78);
            this.StudentManage.TabIndex = 13;
            this.StudentManage.Text = "学生管理";
            this.StudentManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StudentManage.Click += new System.EventHandler(this.StudentManage_Click);
            // 
            // AddPanel
            // 
            this.AddPanel.BackColor = System.Drawing.Color.White;
            this.AddPanel.Controls.Add(this.CollegePanel);
            this.AddPanel.Controls.Add(this.CollegeAddRadioButton);
            this.AddPanel.Controls.Add(this.ClassPanel);
            this.AddPanel.Controls.Add(this.StudentPanel);
            this.AddPanel.Controls.Add(this.TeacherPanel);
            this.AddPanel.Controls.Add(this.StudentAddRadioButton1);
            this.AddPanel.Controls.Add(this.TeacherAddRadioButton);
            this.AddPanel.Controls.Add(this.ClassAddRadioButton);
            this.AddPanel.Location = new System.Drawing.Point(109, 50);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(679, 388);
            this.AddPanel.TabIndex = 14;
            // 
            // CollegePanel
            // 
            this.CollegePanel.Controls.Add(this.DelCollege);
            this.CollegePanel.Controls.Add(this.AddCollegeButton);
            this.CollegePanel.Controls.Add(this.CollegeNameBox);
            this.CollegePanel.Controls.Add(this.CollegeCodeBox);
            this.CollegePanel.Controls.Add(this.label16);
            this.CollegePanel.Controls.Add(this.label15);
            this.CollegePanel.Location = new System.Drawing.Point(132, 35);
            this.CollegePanel.Name = "CollegePanel";
            this.CollegePanel.Size = new System.Drawing.Size(518, 331);
            this.CollegePanel.TabIndex = 16;
            // 
            // DelCollege
            // 
            this.DelCollege.AutoSize = true;
            this.DelCollege.BackColor = System.Drawing.Color.White;
            this.DelCollege.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DelCollege.Location = new System.Drawing.Point(447, 267);
            this.DelCollege.Name = "DelCollege";
            this.DelCollege.Size = new System.Drawing.Size(53, 12);
            this.DelCollege.TabIndex = 5;
            this.DelCollege.Text = "删除学院";
            this.DelCollege.Click += new System.EventHandler(this.DelCollege_Click);
            // 
            // AddCollegeButton
            // 
            this.AddCollegeButton.Location = new System.Drawing.Point(219, 258);
            this.AddCollegeButton.Name = "AddCollegeButton";
            this.AddCollegeButton.Size = new System.Drawing.Size(75, 23);
            this.AddCollegeButton.TabIndex = 4;
            this.AddCollegeButton.Text = "添加";
            this.AddCollegeButton.UseVisualStyleBackColor = true;
            this.AddCollegeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CollegeNameBox
            // 
            this.CollegeNameBox.Location = new System.Drawing.Point(193, 169);
            this.CollegeNameBox.Name = "CollegeNameBox";
            this.CollegeNameBox.Size = new System.Drawing.Size(166, 21);
            this.CollegeNameBox.TabIndex = 3;
            // 
            // CollegeCodeBox
            // 
            this.CollegeCodeBox.Location = new System.Drawing.Point(193, 113);
            this.CollegeCodeBox.Name = "CollegeCodeBox";
            this.CollegeCodeBox.Size = new System.Drawing.Size(166, 21);
            this.CollegeCodeBox.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(122, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "学院名称：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(122, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "学院编号：";
            // 
            // CollegeAddRadioButton
            // 
            this.CollegeAddRadioButton.AutoSize = true;
            this.CollegeAddRadioButton.Location = new System.Drawing.Point(25, 249);
            this.CollegeAddRadioButton.Name = "CollegeAddRadioButton";
            this.CollegeAddRadioButton.Size = new System.Drawing.Size(71, 16);
            this.CollegeAddRadioButton.TabIndex = 15;
            this.CollegeAddRadioButton.TabStop = true;
            this.CollegeAddRadioButton.Text = "添加学院";
            this.CollegeAddRadioButton.Click += new System.EventHandler(this.RadioButton_Change);
            this.CollegeAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // ClassPanel
            // 
            this.ClassPanel.Controls.Add(this.ClassCollegeCB);
            this.ClassPanel.Controls.Add(this.label14);
            this.ClassPanel.Controls.Add(this.AddClassButton);
            this.ClassPanel.Controls.Add(this.ClassIntroductBox);
            this.ClassPanel.Controls.Add(this.label6);
            this.ClassPanel.Controls.Add(this.ClassCapBox);
            this.ClassPanel.Controls.Add(this.ClassCreditBox);
            this.ClassPanel.Controls.Add(this.ClassGradeBox);
            this.ClassPanel.Controls.Add(this.label5);
            this.ClassPanel.Controls.Add(this.label4);
            this.ClassPanel.Controls.Add(this.label3);
            this.ClassPanel.Controls.Add(this.ClassNameBox);
            this.ClassPanel.Controls.Add(this.ClassIDBox);
            this.ClassPanel.Controls.Add(this.label2);
            this.ClassPanel.Controls.Add(this.label1);
            this.ClassPanel.Location = new System.Drawing.Point(132, 35);
            this.ClassPanel.Name = "ClassPanel";
            this.ClassPanel.Size = new System.Drawing.Size(518, 329);
            this.ClassPanel.TabIndex = 3;
            // 
            // ClassCollegeCB
            // 
            this.ClassCollegeCB.FormattingEnabled = true;
            this.ClassCollegeCB.Location = new System.Drawing.Point(384, 79);
            this.ClassCollegeCB.Name = "ClassCollegeCB";
            this.ClassCollegeCB.Size = new System.Drawing.Size(119, 20);
            this.ClassCollegeCB.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(312, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "所属学院：";
            // 
            // AddClassButton
            // 
            this.AddClassButton.Location = new System.Drawing.Point(234, 291);
            this.AddClassButton.Name = "AddClassButton";
            this.AddClassButton.Size = new System.Drawing.Size(75, 23);
            this.AddClassButton.TabIndex = 12;
            this.AddClassButton.Text = "添加";
            this.AddClassButton.UseVisualStyleBackColor = true;
            this.AddClassButton.Click += new System.EventHandler(this.AddClassButton_Click);
            // 
            // ClassIntroductBox
            // 
            this.ClassIntroductBox.Location = new System.Drawing.Point(90, 169);
            this.ClassIntroductBox.Multiline = true;
            this.ClassIntroductBox.Name = "ClassIntroductBox";
            this.ClassIntroductBox.Size = new System.Drawing.Size(413, 95);
            this.ClassIntroductBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "课程简介：";
            // 
            // ClassCapBox
            // 
            this.ClassCapBox.Location = new System.Drawing.Point(443, 120);
            this.ClassCapBox.Name = "ClassCapBox";
            this.ClassCapBox.Size = new System.Drawing.Size(60, 21);
            this.ClassCapBox.TabIndex = 9;
            // 
            // ClassCreditBox
            // 
            this.ClassCreditBox.Location = new System.Drawing.Point(271, 122);
            this.ClassCreditBox.Name = "ClassCreditBox";
            this.ClassCreditBox.Size = new System.Drawing.Size(54, 21);
            this.ClassCreditBox.TabIndex = 8;
            // 
            // ClassGradeBox
            // 
            this.ClassGradeBox.Location = new System.Drawing.Point(90, 122);
            this.ClassGradeBox.Name = "ClassGradeBox";
            this.ClassGradeBox.Size = new System.Drawing.Size(62, 21);
            this.ClassGradeBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "课程容量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "课程学分：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "选修学期：";
            // 
            // ClassNameBox
            // 
            this.ClassNameBox.Location = new System.Drawing.Point(90, 79);
            this.ClassNameBox.Name = "ClassNameBox";
            this.ClassNameBox.Size = new System.Drawing.Size(174, 21);
            this.ClassNameBox.TabIndex = 3;
            // 
            // ClassIDBox
            // 
            this.ClassIDBox.Location = new System.Drawing.Point(90, 35);
            this.ClassIDBox.Name = "ClassIDBox";
            this.ClassIDBox.Size = new System.Drawing.Size(174, 21);
            this.ClassIDBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "课程编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程名称：";
            // 
            // StudentPanel
            // 
            this.StudentPanel.Controls.Add(this.StudentCollegeCB);
            this.StudentPanel.Controls.Add(this.label13);
            this.StudentPanel.Controls.Add(this.StudentAddButton);
            this.StudentPanel.Controls.Add(this.StudentMajorBox);
            this.StudentPanel.Controls.Add(this.StudentGradeBox);
            this.StudentPanel.Controls.Add(this.label9);
            this.StudentPanel.Controls.Add(this.label10);
            this.StudentPanel.Controls.Add(this.StudentNameBox);
            this.StudentPanel.Controls.Add(this.StudentIDBox);
            this.StudentPanel.Controls.Add(this.label11);
            this.StudentPanel.Controls.Add(this.label12);
            this.StudentPanel.Location = new System.Drawing.Point(132, 35);
            this.StudentPanel.Name = "StudentPanel";
            this.StudentPanel.Size = new System.Drawing.Size(518, 323);
            this.StudentPanel.TabIndex = 14;
            // 
            // StudentCollegeCB
            // 
            this.StudentCollegeCB.FormattingEnabled = true;
            this.StudentCollegeCB.Location = new System.Drawing.Point(209, 164);
            this.StudentCollegeCB.Name = "StudentCollegeCB";
            this.StudentCollegeCB.Size = new System.Drawing.Size(119, 20);
            this.StudentCollegeCB.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(138, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "学生年级：";
            // 
            // StudentAddButton
            // 
            this.StudentAddButton.Location = new System.Drawing.Point(253, 264);
            this.StudentAddButton.Name = "StudentAddButton";
            this.StudentAddButton.Size = new System.Drawing.Size(75, 23);
            this.StudentAddButton.TabIndex = 17;
            this.StudentAddButton.Text = "添加";
            this.StudentAddButton.UseVisualStyleBackColor = true;
            this.StudentAddButton.Click += new System.EventHandler(this.StudentAddButton_Click);
            // 
            // StudentMajorBox
            // 
            this.StudentMajorBox.Location = new System.Drawing.Point(209, 125);
            this.StudentMajorBox.Name = "StudentMajorBox";
            this.StudentMajorBox.Size = new System.Drawing.Size(174, 21);
            this.StudentMajorBox.TabIndex = 16;
            // 
            // StudentGradeBox
            // 
            this.StudentGradeBox.Location = new System.Drawing.Point(209, 201);
            this.StudentGradeBox.Name = "StudentGradeBox";
            this.StudentGradeBox.Size = new System.Drawing.Size(76, 21);
            this.StudentGradeBox.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "学生专业：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "学院编号：";
            // 
            // StudentNameBox
            // 
            this.StudentNameBox.Location = new System.Drawing.Point(209, 83);
            this.StudentNameBox.Name = "StudentNameBox";
            this.StudentNameBox.Size = new System.Drawing.Size(174, 21);
            this.StudentNameBox.TabIndex = 12;
            // 
            // StudentIDBox
            // 
            this.StudentIDBox.Location = new System.Drawing.Point(209, 39);
            this.StudentIDBox.Name = "StudentIDBox";
            this.StudentIDBox.Size = new System.Drawing.Size(174, 21);
            this.StudentIDBox.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(138, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "学生学号：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(138, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "学生姓名：";
            // 
            // TeacherPanel
            // 
            this.TeacherPanel.Controls.Add(this.TeacherAddButton);
            this.TeacherPanel.Controls.Add(this.TeacherNameBox);
            this.TeacherPanel.Controls.Add(this.TeacherIDBox);
            this.TeacherPanel.Controls.Add(this.label7);
            this.TeacherPanel.Controls.Add(this.label8);
            this.TeacherPanel.Location = new System.Drawing.Point(132, 35);
            this.TeacherPanel.Name = "TeacherPanel";
            this.TeacherPanel.Size = new System.Drawing.Size(518, 323);
            this.TeacherPanel.TabIndex = 13;
            // 
            // TeacherAddButton
            // 
            this.TeacherAddButton.Location = new System.Drawing.Point(238, 239);
            this.TeacherAddButton.Name = "TeacherAddButton";
            this.TeacherAddButton.Size = new System.Drawing.Size(75, 23);
            this.TeacherAddButton.TabIndex = 8;
            this.TeacherAddButton.Text = "添加";
            this.TeacherAddButton.UseVisualStyleBackColor = true;
            this.TeacherAddButton.Click += new System.EventHandler(this.TeacherAddButton_Click);
            // 
            // TeacherNameBox
            // 
            this.TeacherNameBox.Location = new System.Drawing.Point(209, 137);
            this.TeacherNameBox.Name = "TeacherNameBox";
            this.TeacherNameBox.Size = new System.Drawing.Size(174, 21);
            this.TeacherNameBox.TabIndex = 7;
            // 
            // TeacherIDBox
            // 
            this.TeacherIDBox.Location = new System.Drawing.Point(209, 93);
            this.TeacherIDBox.Name = "TeacherIDBox";
            this.TeacherIDBox.Size = new System.Drawing.Size(174, 21);
            this.TeacherIDBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "教师工号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "教师姓名：";
            // 
            // StudentAddRadioButton1
            // 
            this.StudentAddRadioButton1.AutoSize = true;
            this.StudentAddRadioButton1.Location = new System.Drawing.Point(25, 209);
            this.StudentAddRadioButton1.Name = "StudentAddRadioButton1";
            this.StudentAddRadioButton1.Size = new System.Drawing.Size(71, 16);
            this.StudentAddRadioButton1.TabIndex = 2;
            this.StudentAddRadioButton1.TabStop = true;
            this.StudentAddRadioButton1.Text = "添加学生";
            this.StudentAddRadioButton1.UseVisualStyleBackColor = true;
            this.StudentAddRadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_Change);
            // 
            // TeacherAddRadioButton
            // 
            this.TeacherAddRadioButton.AutoSize = true;
            this.TeacherAddRadioButton.Location = new System.Drawing.Point(25, 165);
            this.TeacherAddRadioButton.Name = "TeacherAddRadioButton";
            this.TeacherAddRadioButton.Size = new System.Drawing.Size(71, 16);
            this.TeacherAddRadioButton.TabIndex = 1;
            this.TeacherAddRadioButton.TabStop = true;
            this.TeacherAddRadioButton.Text = "添加教师";
            this.TeacherAddRadioButton.UseVisualStyleBackColor = true;
            this.TeacherAddRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_Change);
            // 
            // ClassAddRadioButton
            // 
            this.ClassAddRadioButton.AutoSize = true;
            this.ClassAddRadioButton.Location = new System.Drawing.Point(25, 118);
            this.ClassAddRadioButton.Name = "ClassAddRadioButton";
            this.ClassAddRadioButton.Size = new System.Drawing.Size(71, 16);
            this.ClassAddRadioButton.TabIndex = 0;
            this.ClassAddRadioButton.TabStop = true;
            this.ClassAddRadioButton.Text = "添加课程";
            this.ClassAddRadioButton.UseVisualStyleBackColor = true;
            this.ClassAddRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_Change);
            // 
            // SAVELabel
            // 
            this.SAVELabel.BackColor = System.Drawing.Color.Cyan;
            this.SAVELabel.Location = new System.Drawing.Point(593, -1);
            this.SAVELabel.Name = "SAVELabel";
            this.SAVELabel.Size = new System.Drawing.Size(50, 28);
            this.SAVELabel.TabIndex = 15;
            this.SAVELabel.Text = "保存";
            this.SAVELabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SAVELabel.Click += new System.EventHandler(this.SAVELabel_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SAVELabel);
            this.Controls.Add(this.AddPanel);
            this.Controls.Add(this.StudentManage);
            this.Controls.Add(this.TeacherManage);
            this.Controls.Add(this.ClassManage);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.ControlID);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.AddPanel.ResumeLayout(false);
            this.AddPanel.PerformLayout();
            this.CollegePanel.ResumeLayout(false);
            this.CollegePanel.PerformLayout();
            this.ClassPanel.ResumeLayout(false);
            this.ClassPanel.PerformLayout();
            this.StudentPanel.ResumeLayout(false);
            this.StudentPanel.PerformLayout();
            this.TeacherPanel.ResumeLayout(false);
            this.TeacherPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label ControlID;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label ClassManage;
        private System.Windows.Forms.Label TeacherManage;
        private System.Windows.Forms.Label StudentManage;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.RadioButton TeacherAddRadioButton;
        private System.Windows.Forms.RadioButton ClassAddRadioButton;
        private System.Windows.Forms.RadioButton StudentAddRadioButton1;
        private System.Windows.Forms.Panel ClassPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClassNameBox;
        private System.Windows.Forms.TextBox ClassIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ClassCapBox;
        private System.Windows.Forms.TextBox ClassCreditBox;
        private System.Windows.Forms.TextBox ClassGradeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ClassIntroductBox;
        private System.Windows.Forms.Button AddClassButton;
        private System.Windows.Forms.Label SAVELabel;
        private System.Windows.Forms.Panel TeacherPanel;
        private System.Windows.Forms.TextBox TeacherNameBox;
        private System.Windows.Forms.TextBox TeacherIDBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button TeacherAddButton;
        private System.Windows.Forms.Panel StudentPanel;
        private System.Windows.Forms.TextBox StudentMajorBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox StudentNameBox;
        private System.Windows.Forms.TextBox StudentIDBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox StudentGradeBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button StudentAddButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ClassCollegeCB;
        private System.Windows.Forms.ComboBox StudentCollegeCB;
        private System.Windows.Forms.RadioButton CollegeAddRadioButton;
        private System.Windows.Forms.Panel CollegePanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox CollegeNameBox;
        private System.Windows.Forms.TextBox CollegeCodeBox;
        private System.Windows.Forms.Button AddCollegeButton;
        private System.Windows.Forms.Label DelCollege;
    }
}


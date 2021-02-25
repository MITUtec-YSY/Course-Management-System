using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ClassManageSystem.Classes;
using ClassManageSystem;

namespace ClassOption.UI
{
    /// <summary>
    /// 课程信息面板
    /// </summary>
    public class StudentClassMI : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label ClassIDLabel;
        private Label ClassNameLabel;
        private Label ClassCreditLabel;
        private Label ClassIntroductLabel;
        private ListView listView1;
        private Label label5;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label CloseLabel;

        private bool PointFlag;
        private Label Grade_Label;
        private Label label7;
        private Label CollegeLabel;
        private Label label8;
        private Label ClassCap;
        private Label label9;
        private ColumnHeader ColumnHeader4;
        private Point OldPoint;

        /// <summary>
        /// 课程信息面板构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        /// <param name="teacher"></param>
        public StudentClassMI(ClassPackage package, ClassManageTool tool, string teacher = null) : base()
        {
            InitializeComponent();
            if (null != package.ClassID)
                ClassIDLabel.Text = package.ClassID;
            else
                ClassIDLabel.Text = "未知";
            if (null != package.ClassName)
                ClassNameLabel.Text = package.ClassName;
            else
                ClassNameLabel.Text = "未知";
            ClassCreditLabel.Text = package.Credit.ToString();
            Grade_Label.Text = package.ClassGrade.ToString();
            if (null != package.Introduction)
                ClassIntroductLabel.Text = package.Introduction;
            else
                ClassIntroductLabel.Text = "暂无简介";
            ClassCap.Text = package.ClassMax.ToString();
            bool f = false;
            if (tool.IsnNull)
                for (int i = 0; i < tool.Length; i++)
                    if (package.ClassCollege.ToString() == tool[i].Name)
                    {
                        CollegeLabel.Text = tool[i].Data;
                        f = true;
                        break;
                    }
            if (!f)
                CollegeLabel.Text = package.ClassCollege.ToString();
            if (null == teacher)
            {
                if (null != package.Teachers)
                {
                    ListViewItem item = new ListViewItem();
                    for (int i = 0; i < package.Teachers.Length; i++)
                    {
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(package.Teachers[i].TeacherID);
                        item.SubItems.Add(tool.GetTeacherName(package.Teachers[i].TeacherID));
                        if (null == package.Teachers[i].Students)
                            item.SubItems.Add("0");
                        else
                            item.SubItems.Add(package.Teachers[i].Students.Length.ToString());
                    }
                }
            }
            else
            {
                ListViewItem item = new ListViewItem();
                item = listView1.Items.Add("1");
                item.SubItems.Add(teacher);
                item.SubItems.Add(tool.GetTeacherName(teacher));
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentClassMI));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClassIDLabel = new System.Windows.Forms.Label();
            this.ClassNameLabel = new System.Windows.Forms.Label();
            this.ClassCreditLabel = new System.Windows.Forms.Label();
            this.ClassIntroductLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.Grade_Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CollegeLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ClassCap = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "课程名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "学    分：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "课程简介：";
            // 
            // ClassIDLabel
            // 
            this.ClassIDLabel.Location = new System.Drawing.Point(106, 31);
            this.ClassIDLabel.Name = "ClassIDLabel";
            this.ClassIDLabel.Size = new System.Drawing.Size(100, 12);
            this.ClassIDLabel.TabIndex = 4;
            this.ClassIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassNameLabel
            // 
            this.ClassNameLabel.Location = new System.Drawing.Point(106, 61);
            this.ClassNameLabel.Name = "ClassNameLabel";
            this.ClassNameLabel.Size = new System.Drawing.Size(100, 12);
            this.ClassNameLabel.TabIndex = 5;
            this.ClassNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassCreditLabel
            // 
            this.ClassCreditLabel.Location = new System.Drawing.Point(375, 61);
            this.ClassCreditLabel.Name = "ClassCreditLabel";
            this.ClassCreditLabel.Size = new System.Drawing.Size(100, 12);
            this.ClassCreditLabel.TabIndex = 6;
            this.ClassCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassIntroductLabel
            // 
            this.ClassIntroductLabel.Location = new System.Drawing.Point(106, 115);
            this.ClassIntroductLabel.Name = "ClassIntroductLabel";
            this.ClassIntroductLabel.Size = new System.Drawing.Size(273, 66);
            this.ClassIntroductLabel.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeader4});
            this.listView1.Location = new System.Drawing.Point(108, 184);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(351, 86);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "教工号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "教师姓名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "授课教师：";
            // 
            // CloseLabel
            // 
            this.CloseLabel.BackColor = System.Drawing.Color.White;
            this.CloseLabel.ForeColor = System.Drawing.Color.Black;
            this.CloseLabel.Location = new System.Drawing.Point(465, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(41, 23);
            this.CloseLabel.TabIndex = 10;
            this.CloseLabel.Text = "关闭";
            this.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // Grade_Label
            // 
            this.Grade_Label.Location = new System.Drawing.Point(375, 31);
            this.Grade_Label.Name = "Grade_Label";
            this.Grade_Label.Size = new System.Drawing.Size(100, 12);
            this.Grade_Label.TabIndex = 12;
            this.Grade_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "选修学期：";
            // 
            // CollegeLabel
            // 
            this.CollegeLabel.Location = new System.Drawing.Point(106, 89);
            this.CollegeLabel.Name = "CollegeLabel";
            this.CollegeLabel.Size = new System.Drawing.Size(179, 12);
            this.CollegeLabel.TabIndex = 14;
            this.CollegeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "所属学院：";
            // 
            // ClassCap
            // 
            this.ClassCap.Location = new System.Drawing.Point(375, 89);
            this.ClassCap.Name = "ClassCap";
            this.ClassCap.Size = new System.Drawing.Size(100, 12);
            this.ClassCap.TabIndex = 16;
            this.ClassCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "课程容量：";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "人数";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StudentClassMI
            // 
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(507, 282);
            this.Controls.Add(this.ClassCap);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CollegeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Grade_Label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ClassIntroductLabel);
            this.Controls.Add(this.ClassCreditLabel);
            this.Controls.Add(this.ClassNameLabel);
            this.Controls.Add(this.ClassIDLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentClassMI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 窗体鼠标按下方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.Y < 28)
            {
                PointFlag = true;
                OldPoint = new Point(e.X, e.Y);
            }
        }
        /// <summary>
        /// 窗体鼠标移动方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (PointFlag)
                Location = new Point(Location.X + e.X - OldPoint.X, Location.Y + e.Y - OldPoint.Y);
        }
        /// <summary>
        /// 窗体鼠标释放方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            PointFlag = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManageSystem;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;

namespace ClassOption.UI
{
    /// <summary>
    /// 学生信息面板
    /// </summary>
    public partial class StudentDataForm : Form
    {
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 学生信息面板构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        public StudentDataForm(StudentPackage package, ClassManageTool tool)
        {
            InitializeComponent();
            StudentID.Text = package.ID;
            StudentName.Text = package.Name;
            StudentGrade.Text = "大 " + (package.Grade / 2).ToString() + " ";
            if (0 == package.Grade % 2)
                StudentGrade.Text += "下学期";
            else
                StudentGrade.Text += "上学期";
            StudentCollege.Text = tool.GetCollege(package.College);
            StudentMajor.Text = package.Major;
            listView1.Clear();
            ListViewItem item;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("得分", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("教师", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("学院", 120, HorizontalAlignment.Center);
            float credits = 0, sum = 0;
            if (null != package.Classes)
            {
                for (int i = 0; i < package.Classes.Length; i++)
                {
                    ClassPackage @class = tool.GetClass(package.Classes[i].Class);
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(package.Classes[i].Class);
                    item.SubItems.Add(@class.ClassName);
                    item.SubItems.Add(package.Classes[i].Score.ToString());
                    item.SubItems.Add(tool.GetTeacherName(package.Classes[i].Teacher));
                    item.SubItems.Add(tool.GetCollege(@class.ClassCollege));
                    float credit = tool.GetClass(package.Classes[i].Class).Credit;
                    credits += credit;
                    sum += credit * tool.GetGPA(package.Classes[i].Score);
                }
                item = listView1.Items.Add("");
                item = listView1.Items.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("平均绩点：");
                item.SubItems.Add((sum / credits).ToString()); 
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
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

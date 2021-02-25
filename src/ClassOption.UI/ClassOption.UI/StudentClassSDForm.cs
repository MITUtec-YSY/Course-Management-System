using ClassManageSystem;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassOption.UI
{
    /// <summary>
    /// 学生课程操作面板
    /// </summary>
    public partial class StudentClassSDForm : Form
    {
        unsafe private bool* Flag;
        private bool Type;
        private ClassManageTool Tool;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 学生课程操作面板构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        /// <param name="type"></param>
        /// <param name="flag"></param>
        /// <param name="fg"></param>
        unsafe public StudentClassSDForm(StudentPackage package, ClassManageTool tool, bool type, bool *flag, bool* fg)
        {
            Flag = flag;
            Type = type;
            Tool = tool;
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
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = true;
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("教师", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("学院", 120, HorizontalAlignment.Center);
            
            if (Type)
            {
                ClassPackage[] classes = tool.GetClasses();
                int index = 0;
                if (null != classes)
                {
                    for (int i = 0; i < classes.Length; i++)
                    {
                        bool f = false;
                        if (null != package.Classes)
                            for (int j = 0; j < package.Classes.Length; j++)
                                if (package.Classes[j].Class == classes[i].ClassID)
                                {
                                    f = true;
                                    break;
                                }
                        if (!f)
                            if (null != classes[i].Teachers)
                                for (int j = 0; j < classes[i].Teachers.Length; j++)
                                {
                                    item = listView1.Items.Add((index + 1).ToString());
                                    item.SubItems.Add(classes[i].ClassID);
                                    item.SubItems.Add(classes[i].ClassName);
                                    item.SubItems.Add(tool.GetTeacherName(classes[i].Teachers[j].TeacherID));
                                    item.SubItems.Add(tool.GetCollege(classes[i].ClassCollege));
                                    item.SubItems.Add(classes[i].Teachers[j].TeacherID);
                                }
                    }
                }
                if (0 == listView1.Items.Count)
                {
                    MessageBox.Show("当前暂时没有可以选择的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    *fg = false;
                }
            }
            else
            {
                if (null != package.Classes)
                    for (int i = 0; i < package.Classes.Length; i++)
                    {
                        ClassPackage @class = tool.GetClass(package.Classes[i].Class);
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(package.Classes[i].Class);
                        item.SubItems.Add(@class.ClassName);
                        item.SubItems.Add(tool.GetTeacherName(package.Classes[i].Teacher));
                        item.SubItems.Add(package.Classes[i].Score.ToString());
                        item.SubItems.Add(tool.GetCollege(@class.ClassCollege));
                    }
                if (0 == listView1.Items.Count)
                {
                    MessageBox.Show("当前暂时没有可以删除的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    *fg = false;
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        unsafe private void OK_Button_Click(object sender, EventArgs e)
        {
            if (Type)
            {
                if (0 == listView1.SelectedItems.Count)
                    MessageBox.Show("请至少选择一门课程进行添加", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                        Tool.SelectClass(StudentID.Text, listView1.SelectedItems[i].SubItems[5].Text, listView1.SelectedItems[i].SubItems[1].Text);
                    *Flag = true;
                    MessageBox.Show("课程添加完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                if (0 == listView1.SelectedItems.Count)
                    MessageBox.Show("请至少选择一门课程进行退选", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                        Tool.DelClassStudent(listView1.SelectedItems[i].SubItems[1].Text, listView1.SelectedItems[i].SubItems[5].Text, StudentID.Text);
                    *Flag = true;
                    MessageBox.Show("课程退选完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
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

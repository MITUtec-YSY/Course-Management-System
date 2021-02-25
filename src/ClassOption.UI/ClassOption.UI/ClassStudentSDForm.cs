using ClassManageSystem;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;
using ClassManageSystem.Teachers;
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
    /// 课程列表添加或删除学生窗口
    /// </summary>
    public partial class ClassStudentSDForm : Form
    {
        unsafe private bool* Flag;
        private ClassManageTool Tool;
        private int xPos1;
        private int yPos1;
        private int xPos2;
        private int yPos2;
        private int xPos3;
        private int yPos3;
        private string ClassID;
        private string TeacherID;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 课程列表添加或删除学生窗口构造函数
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="classID"></param>
        /// <param name="flag"></param>
        /// <param name="f"></param>
        unsafe public ClassStudentSDForm(ClassManageTool tool, string classID, bool* flag, bool* f)
        {
            Tool = tool;
            Flag = flag;
            ClassID = classID;
            TeacherID = "";
            InitializeComponent();
            Init(f);
            TeacherSelectName.Text = "";
            ClassNameSelect.Text = Tool.GetClass(classID).ClassName;
        }

        unsafe private void Init(bool* f)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            ClassPackage classes = Tool.GetClass(ClassID);
            listView1.GridLines = true;
            listView1.Scrollable = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 100, HorizontalAlignment.Center);
            listView1.Click += new EventHandler(listView1_Click);
            listView1.MouseMove += new MouseEventHandler(listView1_MouseMove);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
            if (null != classes.Teachers)
            {
                ListViewItem item;
                for (int i = 0; i < classes.Teachers.Length; i++)
                {
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(classes.Teachers[i].TeacherID);
                    item.SubItems.Add(Tool.GetTeacherName(classes.Teachers[i].TeacherID));
                }
            }
            else
            {
                MessageBox.Show("当前课程没有可操作的教师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                *f = false;
            }
            listView2.GridLines = true;
            listView2.Scrollable = true;
            listView2.FullRowSelect = true;
            listView2.MultiSelect = true;
            listView2.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("学生学号", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("学生姓名", 100, HorizontalAlignment.Center);
            listView2.Click += new EventHandler(listView2_Click);
            listView2.MouseMove += new MouseEventHandler(listView2_MouseMove);
            listView2.MouseDown += new MouseEventHandler(listView2_MouseDown);
            listView3.GridLines = true;
            listView3.Scrollable = true;
            listView3.FullRowSelect = true;
            listView3.MultiSelect = true;
            listView3.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView3.Columns.Add("学生学号", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("学生姓名", 100, HorizontalAlignment.Center);
            listView3.Click += new EventHandler(listView3_Click);
            listView3.MouseMove += new MouseEventHandler(listView3_MouseMove);
            listView3.MouseDown += new MouseEventHandler(listView3_MouseDown);
        }

        /// <summary>
        /// 实时跟踪listView1的当前坐标
        /// </summary>
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            xPos1 = e.X;
            yPos1 = e.Y;
        }
        /// <summary>
        /// 触发listView1空白处点击事件
        /// </summary>
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (null==listView1.HitTest(xPos1, yPos1).Item)
            {
                TeacherID = "";
                listView2.Items.Clear();
                listView3.Items.Clear();
                button1.Enabled = false;
                button2.Enabled = false;
                TeacherSelectName.Text = "";
            }
        }
        /// <summary>
        /// 实时跟踪listView1的当前坐标
        /// </summary>
        private void listView2_MouseMove(object sender, MouseEventArgs e)
        {
            xPos2 = e.X;
            yPos2 = e.Y;
        }
        /// <summary>
        /// 触发listView1空白处点击事件
        /// </summary>
        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (null == listView2.HitTest(xPos2, yPos2).Item)
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }
        /// <summary>
         /// 实时跟踪listView1的当前坐标
         /// </summary>
        private void listView3_MouseMove(object sender, MouseEventArgs e)
        {
            xPos3 = e.X;
            yPos3 = e.Y;
        }
        /// <summary>
        /// 触发listView1空白处点击事件
        /// </summary>
        private void listView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (null == listView3.HitTest(xPos3, yPos3).Item)
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }
        /// <summary>
        /// 窗体鼠标按下方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            PointFlag = true;
            OldPoint = new Point(e.X, e.Y);
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

        private void listView1_Click(object sender, EventArgs e)
        {
            TeacherID = listView1.SelectedItems[0].SubItems[1].Text;
            TeacherSelectName.Text = listView1.SelectedItems[0].SubItems[2].Text;
            listView1_Click();
        }
        private void listView1_Click()
        {
            listView2.Items.Clear();
            listView3.Items.Clear();
            StudentPackage[] students = Tool.GetStudents();
            ClassPackage package = Tool.GetClass(ClassID);
            if (null != package.Teachers)
            {
                int index = 0;
                for (int i = 0; i < package.Teachers.Length; i++)
                    if (TeacherID == package.Teachers[i].TeacherID)
                    {
                        if (null != package.Teachers[i].Students)
                            for (int j = 0; j < package.Teachers[i].Students.Length; j++)
                            {
                                ListViewItem item = listView2.Items.Add((index + 1).ToString());
                                item.SubItems.Add(package.Teachers[i].Students[j]);
                                item.SubItems.Add(Tool.GetStudentName(package.Teachers[i].Students[j]));
                                index++;
                            }
                        break;
                    }
            }
            if (null != students)
            {
                bool f = false;
                for (int i = 0; i < students.Length; i++)
                {
                    f = false;
                    if (null != package.Teachers)
                        for (int j = 0; j < package.Teachers.Length; j++)
                            if (null != package.Teachers[j].Students)
                                for (int k = 0; k < package.Teachers[j].Students.Length; k++)
                                    if (package.Teachers[j].Students[k] == students[i].ID)
                                    {
                                        f = true;
                                        break;
                                    }
                    if (!f)
                    {
                        ListViewItem item = listView3.Items.Add((i + 1).ToString());
                        item.SubItems.Add(students[i].ID);
                        item.SubItems.Add(students[i].Name);
                    }
                }
            }
        }
        private void listView2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
        }
        private void listView3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        unsafe private void button1_Click(object sender, EventArgs e)
        {
            if (0 < listView2.SelectedItems.Count)
            {
                for (int i = 0; i < listView2.SelectedItems.Count; i++)
                    Tool.DropClass(ClassID, TeacherID, listView2.SelectedItems[i].SubItems[1].Text);
                *Flag = true;
                listView1_Click();
            }
        }
        unsafe private void button2_Click(object sender, EventArgs e)
        {
            if (0 < listView3.SelectedItems.Count)
            {
                for (int i = 0; i < listView3.SelectedItems.Count; i++)
                    Tool.SelectClass(listView3.SelectedItems[i].SubItems[1].Text, TeacherID, ClassID);
                *Flag = true;
                listView1_Click();
            }
        }
    }
}

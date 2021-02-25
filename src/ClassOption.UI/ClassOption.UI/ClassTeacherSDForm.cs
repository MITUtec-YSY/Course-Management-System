using ClassManageSystem;
using ClassManageSystem.Classes;
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
    /// 课程修改教师窗体
    /// </summary>
    public partial class ClassTeacherSDForm : Form
    {
        unsafe private bool* Flag;
        private ClassManageTool Tool;
        private string ClassID;
        private int xPos1;
        private int yPos1;
        private int xPos2;
        private int yPos2;
        private int xPos3;
        private int yPos3;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 课程修改教师窗体构造函数
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        /// <param name="f"></param>
        unsafe public ClassTeacherSDForm(ClassManageTool tool, bool* flag, bool *f)
        {
            Tool = tool;
            Flag = flag;
            ClassID = "";
            InitializeComponent();
            Init(f);
            ClassNameSelect.Text = "";
        }

        unsafe private void Init(bool *f)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            ClassPackage[] classes = Tool.GetClasses();
            listView1.GridLines = true;
            listView1.Scrollable = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 100, HorizontalAlignment.Center);
            listView1.Click += new EventHandler(listView1_Click);
            listView1.MouseMove += new MouseEventHandler(listView1_MouseMove);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
            if (null != classes)
            {
                ListViewItem item;
                for (int i = 0; i < classes.Length; i++)
                {
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(classes[i].ClassID);
                    item.SubItems.Add(classes[i].ClassName);
                }
            }
            else
            {
                MessageBox.Show("当前没有可操作的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                *f = false;
            }
            listView2.GridLines = true;
            listView2.Scrollable = true;
            listView2.FullRowSelect = true;
            listView2.MultiSelect = true;
            listView2.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("教师工号", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("教师姓名", 100, HorizontalAlignment.Center);
            listView2.Click += new EventHandler(listView2_Click);
            listView2.MouseMove += new MouseEventHandler(listView2_MouseMove);
            listView2.MouseDown += new MouseEventHandler(listView2_MouseDown);
            listView3.GridLines = true;
            listView3.Scrollable = true;
            listView3.FullRowSelect = true;
            listView3.MultiSelect = true;
            listView3.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView3.Columns.Add("教师工号", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("教师姓名", 100, HorizontalAlignment.Center);
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
                ClassID = "";
                button1.Enabled = false;
                button2.Enabled = false;
                listView2.Items.Clear();
                listView3.Items.Clear();
                ClassNameSelect.Text = "";
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
            ClassID = listView1.SelectedItems[0].SubItems[1].Text;
            ClassNameSelect.Text = listView1.SelectedItems[0].SubItems[2].Text;
            listView1_Click();
        }
        private void listView1_Click()
        {
            if ("" != ClassID)
            {
                listView2.Items.Clear();
                listView3.Items.Clear();
                TeacherPackage[] teachers = Tool.GetTeachers();
                ClassPackage package = Tool.GetClass(ClassID);
                if (null != package.Teachers)
                {
                    for (int i = 0; i < package.Teachers.Length; i++)
                    {
                        ListViewItem item = listView2.Items.Add((i + 1).ToString());
                        item.SubItems.Add(package.Teachers[i].TeacherID);
                        item.SubItems.Add(Tool.GetTeacherName(package.Teachers[i].TeacherID));
                    }
                }
                if (null != teachers)
                {
                    bool f = false;
                    for (int i = 0; i < teachers.Length; i++)
                    {
                        f = false;
                        for (int j = 0; j < listView2.Items.Count; j++)
                        {
                            if (listView2.Items[j].SubItems[1].Text == teachers[i].ID)
                            {
                                f = true;
                                break;
                            }
                        }
                        if (!f)
                        {
                            ListViewItem item = listView3.Items.Add((i + 1).ToString());
                            item.SubItems.Add(teachers[i].ID);
                            item.SubItems.Add(teachers[i].Name);
                        }
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
                for(int i = 0; i < listView2.SelectedItems.Count; i++)
                    Tool.DelClassTeacher(ClassID, listView2.SelectedItems[i].SubItems[1].Text);
                *Flag = true;
                listView1_Click();
            }
        }
        unsafe private void button2_Click(object sender, EventArgs e)
        {
            if (0 < listView3.SelectedItems.Count)
            {
                for (int i = 0; i < listView3.SelectedItems.Count; i++)
                    Tool.AddClassTeacher(ClassID, listView3.SelectedItems[i].SubItems[1].Text);
                *Flag = true;
                listView1_Click();
            }
        }
    }
}

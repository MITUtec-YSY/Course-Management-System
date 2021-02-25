using ClassManageSystem;
using ClassManageSystem.Classes;
using Microsoft.VisualBasic;
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
    public partial class ClassScoreEdit : Form
    {
        unsafe private bool* Flag;
        private ClassManageTool Tool;
        private string TeacherID;
        private string ClassID;
        private int xPos;
        private int yPos;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 课程修改分数窗体构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        /// <param name="f"></param>
        unsafe public ClassScoreEdit(ClassPackage package, ClassManageTool tool, bool* flag, bool* f)
        {
            Flag = flag;
            Tool = tool;
            InitializeComponent();
            label2.Text = "";
            label1.Text += package.ClassName;
            ClassID = package.ClassID;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("教师工号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("教师姓名", 80, HorizontalAlignment.Center);
            listView1.Click += new EventHandler(listView1_Click);
            listView1.MouseMove += new MouseEventHandler(listView1_MouseMove);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
            if (null != package.Teachers)
            {
                for(int i = 0; i < package.Teachers.Length; i++)
                {
                    ListViewItem item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(package.Teachers[i].TeacherID);
                    item.SubItems.Add(Tool.GetTeacherName(package.Teachers[i].TeacherID));
                }
            }
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.LabelEdit = true;
            listView2.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("学生学号", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("学生姓名", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("学生专业", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("学生分数", 80, HorizontalAlignment.Center);
            listView2.DoubleClick += new EventHandler(listView2_DoubleClick);
            if (0 == listView1.Items.Count)
            {
                MessageBox.Show("本课程没有可以上课的教师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                *f = false;
            }
        }

        /// <summary>
        /// 教师列表单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_Click(object sender, EventArgs e)
        {
            TeacherID = listView1.SelectedItems[0].SubItems[1].Text;
            label2.Text = "教师：" + listView1.SelectedItems[0].SubItems[2].Text;
            listView1_Click();
        }
        /// <summary>
        /// 教师列表单击事件主方法
        /// </summary>
        private void listView1_Click()
        {
            listView2.Items.Clear();
            float sum = 0;
            int pass = 0;
            TeacherStudentPackage[] packages = Tool.GetStudentsT(ClassID, TeacherID);
            if (null != packages)
            {
                ListViewItem item;
                for (int i = 0; i < packages.Length; i++)
                {
                    item = listView2.Items.Add((i + 1).ToString());
                    item.SubItems.Add(packages[i].studentID);
                    item.SubItems.Add(packages[i].studentName);
                    item.SubItems.Add(packages[i].studentMajor);
                    item.SubItems.Add(packages[i].Score.ToString());
                    sum += packages[i].Score;
                    if (60 <= packages[i].Score)
                        pass++;
                }
                item = listView2.Items.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("平均分:");
                item.SubItems.Add((sum / packages.Length).ToString());
                item = listView2.Items.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("及格率:");
                item.SubItems.Add(((float)pass / packages.Length * 100) + " %");
            }
        }
        /// <summary>
        /// 教师列表空点击事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            xPos = e.X;
            yPos = e.Y;
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (null == listView1.HitTest(xPos, yPos).Item) 
            {
                label2.Text = "";
                listView2.Items.Clear();
            }
        }
        /// <summary>
        /// 学生列表双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void listView2_DoubleClick(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入分数", "提示");
            float score = 0;
            if (float.TryParse(str, out score))
            {
                if (0 <= score)
                {
                    Tool.EditScoreT(ClassID, listView2.SelectedItems[0].SubItems[1].Text, score);
                    *Flag = true;
                    listView1_Click();
                }
                else
                    MessageBox.Show("输入的分数无效\r\n请输入正确的分数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("输入的分数无效\r\n请输入正确形式的分数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 取消按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 确定保存事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void button1_Click(object sender, EventArgs e)
        {
            Tool.Save();
            *Flag = false;
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

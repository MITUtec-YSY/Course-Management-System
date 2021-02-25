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
using MRsystem.Collections;

namespace ClassOptions
{
    /// <summary>
    /// 教师窗口
    /// </summary>
    public partial class Teacher : Form
    {
        private ClassManageTool Tool;    //课程管理组件
        private TeacherClassPackage[] classPackages;    //教师课程列表
        private TeacherStudentPackage[] studentPackages;    //教师课程学生列表
        private StringStack StringStack;   //字符串堆栈
        private TeacherChangeScore ChangeScore;    //教师修改分数窗体
        private string ID;    //教师工号

        private Point OldPoint;   //鼠标定位点
        private bool PointFlag;   //鼠标点击窗体拖动标志

        private bool Edited;   //数据修改标志

        /// <summary>
        /// 教师窗口构造函数
        /// </summary>
        /// <param name="teacherID">教师工号</param>
        /// <param name="tool">课程管理组件</param>
        public Teacher(string  teacherID, ClassManageTool tool)
        {
            Tool = tool;
            StringStack = new StringStack();
            PointFlag = false;
            Edited = false;
            ID = teacherID;
            ChangeScore = null;
            classPackages = Tool.GetClassesT(teacherID);
            InitializeComponent();
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        private void InitList()
        {
            if (0 == StringStack.Count)
            {
                listView1.Clear();
                ListViewItem item = new ListViewItem();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 200, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 300, HorizontalAlignment.Center);
                listView1.Columns.Add("课程学分", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("课程容量", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("课程人数", 70, HorizontalAlignment.Center);
                if (null != classPackages)
                {
                    for (int i = 0; i < classPackages.Length; i++)
                    {
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(classPackages[i].classID);
                        item.SubItems.Add(classPackages[i].className);
                        item.SubItems.Add(classPackages[i].classCredit.ToString());
                        item.SubItems.Add(classPackages[i].classMax.ToString());
                        string[] vs = Tool.GetTeacherStudent(ID, classPackages[i].classID);
                        if (null == vs)
                            item.SubItems.Add((0).ToString());
                        else
                            item.SubItems.Add(vs.Length.ToString());
                    }
                }
                if (0 == StringStack.Count)
                    TurnBack.Visible = false;
                else
                    TurnBack.Visible = true;
                ClassLabel.Visible = false;
            }
            else if (1 == StringStack.Count)
            {
                ClassLabel.Visible = true;
                listView1.Clear();
                ListViewItem item = new ListViewItem();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("学号", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("姓名", 200, HorizontalAlignment.Center);
                listView1.Columns.Add("专业", 250, HorizontalAlignment.Center);
                listView1.Columns.Add("年级", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("成绩", 70, HorizontalAlignment.Center);
                studentPackages = Tool.GetStudentsT(StringStack.Peek(), ID);
                if (studentPackages != null)
                {
                    int i, pass = 0;
                    float sum = 0;
                    for (i = 0; i < studentPackages.Length; i++)
                    {
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(studentPackages[i].studentID);
                        item.SubItems.Add(studentPackages[i].studentName);
                        item.SubItems.Add(studentPackages[i].studentMajor);
                        item.SubItems.Add(studentPackages[i].Grade.ToString());
                        item.SubItems.Add(studentPackages[i].Score.ToString());
                        sum += studentPackages[i].Score;
                        if (60 <= studentPackages[i].Score)
                            pass++;
                    }
                    item = listView1.Items.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("平均分：");
                    item.SubItems.Add((sum / i).ToString());
                    item = listView1.Items.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("及格率：");
                    item.SubItems.Add(((float)pass / i * 100).ToString() + "%");
                }
                if (0 == StringStack.Count)
                    TurnBack.Visible = false;
                else
                    TurnBack.Visible = true;
            }
            else if (2 == StringStack.Count)
            {
                if (null != ChangeScore)
                    ChangeScore.Dispose();
                ChangeScore = null;
                if (0 == StringStack.Count)
                    TurnBack.Visible = false;
                else
                    TurnBack.Visible = true;
                StringStack.Pop();
                InitList();
            }
        }
        /// <summary>
        /// 保存到文件
        /// </summary>
        private void Save()
        {
            Tool.Save();
            Edited = false;
        }

        /// <summary>
        /// 表单双击方法（存在不安全的指针引用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void viewList_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView1.SelectedItems.Count;
            if (1 == StringStack.Count)
                if ("" != listView1.SelectedItems[0].SubItems[0].Text)
                {
                    fixed (bool* p = &Edited)
                    {
                        ChangeScore = new TeacherChangeScore(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, StringStack.Peek(), listView1.SelectedItems[0].SubItems[5].Text, Tool, p);
                    }
                    ChangeScore.ShowDialog(this);
                }
            if (null != classPackages)
                for (int i = 0; i < classPackages.Length; i++)
                    if (classPackages[i].classID == StringStack.Peek())
                    {
                        ClassLabel.Text = "科目：" + classPackages[i].className;
                        ClassLabel.Visible = true;
                        break;
                    }
            StringStack.Push(listView1.SelectedItems[0].SubItems[1].Text);
            if (!ClassLabel.Visible)
                ClassLabel.Text = "科目：" + listView1.SelectedItems[0].SubItems[2].Text;
            InitList();
        }
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            TeacherID.Text = "教工号：" + ID;
            TeacherName.Text = "姓名：" + Tool.GetTeacherName(ID);
            InitList();
        }
        /// <summary>
        /// 窗体鼠标按下方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.Y < 28/* && e.Y - Location.Y < 0*/)
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
        /// <summary>
        /// 窗体最小化方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinLabel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 窗体关闭方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            if (Edited)
            {
                DialogResult result = MessageBox.Show(this, "事件已修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    Save();
                    Application.Exit();
                }
                else if (DialogResult.No == result)
                    Application.Exit();
            }
            else
                Application.Exit();
        }
        /// <summary>
        /// 返回上一步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnBack_Click(object sender, EventArgs e)
        {
            StringStack.Pop();
            InitList();
            if (0 == StringStack.Count)
                TurnBack.Visible = false;
            else
                TurnBack.Visible = true;
        }

        private void EditDataLabel_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(TeacherID.Text);
            form.ShowDialog(this);
            GC.Collect();
        }
    }
}

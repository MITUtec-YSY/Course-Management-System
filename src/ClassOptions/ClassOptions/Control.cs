using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassOption.UI;
using ClassManageSystem;
using MRsystem.Collections;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;
using ClassManageSystem.Teachers;
using System.Text.RegularExpressions;

namespace ClassOptions
{
    /// <summary>
    /// 教师窗口
    /// </summary>
    public partial class Control : Form
    {
        private new ContextMenuStrip ContextMenuStrip;
        private ToolStripMenuItem TeacherDelMenuItem;
        private ToolStripMenuItem TeacherEditMenuItem;
        private ToolStripMenuItem TeacherAddToMenuItem;
        private ToolStripMenuItem StudentDelMenuItem;
        private ToolStripMenuItem StudentEditMenuItem;
        private ToolStripMenuItem StudentDataMenuItem;
        private ToolStripMenuItem StudentSelectMenuItem;
        private ToolStripMenuItem StudentDropMenuItem;
        private ToolStripMenuItem ClassDelMenuItem;
        private ToolStripMenuItem ClassInforamtionMenuItem;
        private ToolStripMenuItem ClassEditMenuItem;
        private ToolStripMenuItem ClassAddTMenuItem;
        private ToolStripMenuItem ClassAddSMenuItem;
        private ToolStripMenuItem ReflushMenuItem;

        private ClassManageTool Tool;    //课程管理组件
        private StringStack StringStack;   //字符串堆栈
        private string ID;    //管理员ID

        private Point OldPoint;   //鼠标定位点
        private bool PointFlag;   //鼠标点击窗体拖动标志
        private bool Edit;
        private int xPos;
        private int yPos;

        /// <summary>
        /// 教师窗口构造函数
        /// </summary>
        /// <param name="controlID">教师工号</param>
        /// <param name="tool">课程管理组件</param>
        public Control(string  controlID, ClassManageTool tool)
        {
            Tool = tool;
            StringStack = new StringStack();
            PointFlag = false;
            Edit = false;
            ID = controlID;
            InitializeComponent();
            AddLabel.BackColor = Color.White;
            listView1.Visible = false;
            SAVELabel.Visible = false;
            ClassPanel.Visible = false;
            TeacherPanel.Visible = false;
            StudentPanel.Visible = false;
            CollegePanel.Visible = false;
            AddPanel.Visible = false;
            ClassCollegeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            StudentCollegeCB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        private void InitList()
        {
            
        }
        /// <summary>
        /// 保存到文件
        /// </summary>
        private void Save()
        {
            Tool.Save();
        }

        /// <summary>
        /// 表单双击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, EventArgs e)
        {
            if (ClassManage.BackColor == Color.Yellow)
                ClassInforamtionMenuItem_Click(null, null);
            else if (TeacherManage.BackColor == Color.Yellow)
                TeacherAddToMenuItem_Click(null, null);
            else if (StudentManage.BackColor == Color.Yellow)
                StudentDataMenuItem_Click(null, null);
            GC.Collect();
        }
        /// <summary>
        /// 表单右键方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_RightClick(object sender, MouseEventArgs e)
        {
            if (ClassManage.BackColor == Color.Yellow)
            {
                ContextMenuStrip = new ContextMenuStrip();
                ClassDelMenuItem = new ToolStripMenuItem("删除课程");
                ClassDelMenuItem.Click += new EventHandler(ClassDelMenuItem_Click);
                ClassInforamtionMenuItem = new ToolStripMenuItem("课程详情");
                ClassInforamtionMenuItem.Click += new EventHandler(ClassInforamtionMenuItem_Click);
                ClassEditMenuItem = new ToolStripMenuItem("修改课程信息");
                ClassEditMenuItem.Click += new EventHandler(ClassEditMenuItem_Click);
                ClassAddTMenuItem = new ToolStripMenuItem("课程成绩管理");
                ClassAddTMenuItem.Click += new EventHandler(ClassScoreEdit_Click);
                ClassAddSMenuItem = new ToolStripMenuItem("添加/删除学生");
                ClassAddSMenuItem.Click += new EventHandler(ClassAddSMenuItem_Click);
                ReflushMenuItem = new ToolStripMenuItem("更新");
                ReflushMenuItem.Click += new EventHandler(ReflushList_Click);
                ContextMenuStrip.Items.Add(ClassInforamtionMenuItem);
                ContextMenuStrip.Items.Add(ClassEditMenuItem);
                ContextMenuStrip.Items.Add(ClassAddTMenuItem);
                ContextMenuStrip.Items.Add(ClassAddSMenuItem);
                ContextMenuStrip.Items.Add(ClassDelMenuItem);
                ContextMenuStrip.Items.Add(ReflushMenuItem);
            }
            else if (TeacherManage.BackColor == Color.Yellow)
            {
                ContextMenuStrip = new ContextMenuStrip();
                TeacherDelMenuItem = new ToolStripMenuItem("删除教师");
                TeacherDelMenuItem.Click += new EventHandler(TeacherDelMenuItem_Click);
                TeacherEditMenuItem = new ToolStripMenuItem("修改教师信息");
                TeacherEditMenuItem.Click += new EventHandler(TeacherEditMenuItem_Click);
                TeacherAddToMenuItem = new ToolStripMenuItem("添加到课程");
                TeacherAddToMenuItem.Click += new EventHandler(TeacherAddToMenuItem_Click);
                ReflushMenuItem = new ToolStripMenuItem("更新");
                ReflushMenuItem.Click += new EventHandler(ReflushList_Click);
                ContextMenuStrip.Items.Add(TeacherAddToMenuItem);
                ContextMenuStrip.Items.Add(TeacherEditMenuItem);
                ContextMenuStrip.Items.Add(TeacherDelMenuItem);
                ContextMenuStrip.Items.Add(ReflushMenuItem);
            }
            else if (StudentManage.BackColor == Color.Yellow)
            {
                ContextMenuStrip = new ContextMenuStrip();
                StudentDelMenuItem = new ToolStripMenuItem("删除学生");
                StudentDelMenuItem.Click += new EventHandler(StudentDelMenuItem_Click);
                StudentDataMenuItem = new ToolStripMenuItem("学生详细信息");
                StudentDataMenuItem.Click += new EventHandler(StudentDataMenuItem_Click);
                StudentEditMenuItem = new ToolStripMenuItem("修改学生信息");
                StudentEditMenuItem.Click += new EventHandler(StudentEditMenuItem_Click);
                StudentSelectMenuItem = new ToolStripMenuItem("学生选课");
                StudentSelectMenuItem.Click += new EventHandler(StudentSelectMenuItem_Click);
                StudentDropMenuItem = new ToolStripMenuItem("学生退课");
                StudentDropMenuItem.Click += new EventHandler(StudentDropMenuItem_Click);
                ReflushMenuItem = new ToolStripMenuItem("更新");
                ReflushMenuItem.Click += new EventHandler(ReflushList_Click);
                ContextMenuStrip.Items.Add(StudentDataMenuItem);
                ContextMenuStrip.Items.Add(StudentEditMenuItem);
                ContextMenuStrip.Items.Add(StudentSelectMenuItem);
                ContextMenuStrip.Items.Add(StudentDropMenuItem);
                ContextMenuStrip.Items.Add(StudentDelMenuItem);
                ContextMenuStrip.Items.Add(ReflushMenuItem);
            }
            if (MouseButtons.Right == e.Button)
                if (null != ContextMenuStrip)
                    ContextMenuStrip.Show(listView1, e.Location);
        }
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ControlID.Text = "管理员： " + ID;
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
            else
            {
                listView1.Visible = false;
                SAVELabel.Visible = false;
                ClassPanel.Visible = false;
                TeacherPanel.Visible = false;
                StudentPanel.Visible = false;
                AddPanel.Visible = false;
                AddLabel.BackColor = Color.White;
                TeacherManage.BackColor = Color.White;
                StudentManage.BackColor = Color.White;
                ClassManage.BackColor = Color.White;
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
        /// 实时跟踪listView1的当前坐标
        /// </summary>
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            xPos = e.X;
            yPos = e.Y;
        }
        /// <summary>
        /// 触发listView1空白处点击事件
        /// </summary>
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.HitTest(xPos, yPos).Item == null)
            {
                ContextMenuStrip = new ContextMenuStrip();
                ReflushMenuItem = new ToolStripMenuItem("更新");
                if (Color.Yellow == ClassManage.BackColor) 
                {
                    ClassAddTMenuItem = new ToolStripMenuItem("课程教师操作");
                    ClassAddTMenuItem.Click += new EventHandler(ClassAddTMenuItem_Click);
                    ContextMenuStrip.Items.Add(ClassAddTMenuItem);
                }
                ReflushMenuItem.Click += new EventHandler(ReflushList_Click);
                ContextMenuStrip.Items.Add(ReflushMenuItem);
                if (MouseButtons.Right == e.Button)
                    ContextMenuStrip.Show(listView1, e.Location);
            }
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SAVELabel_Click(object sender, EventArgs e)
        {
            Save();
            Edit = false;
            SAVELabel.Visible = false;
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
            if (Edit)
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
        /// 课程管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassManage_Click(object sender, EventArgs e)
        {
            AddLabel.BackColor = Color.White;
            ClassManage.BackColor = Color.Yellow;
            TeacherManage.BackColor = Color.White;
            StudentManage.BackColor = Color.White;
            AddPanel.Visible = false;
            listView1.Visible = true;
            listView1.Clear();
            ClassPackage[] packages = Tool.GetClasses();
            if (null != packages)
            {
                ListViewItem item;
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 140, HorizontalAlignment.Center);
                listView1.Columns.Add("选修学期", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("课程简介",200, HorizontalAlignment.Center);
                listView1.Columns.Add("学分", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("最大容量", 70, HorizontalAlignment.Center);
                for (int i = 0; i < packages.Length; i++)
                {
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(packages[i].ClassID);
                    item.SubItems.Add(packages[i].ClassName);
                    item.SubItems.Add(packages[i].ClassGrade.ToString());
                    item.SubItems.Add(packages[i].Introduction);
                    item.SubItems.Add(packages[i].Credit.ToString());
                    item.SubItems.Add(packages[i].ClassMax.ToString());
                }
            }
            else
                MessageBox.Show("当前没有课程数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 教师管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherManage_Click(object sender, EventArgs e)
        {
            AddLabel.BackColor = Color.White;
            ClassManage.BackColor = Color.White;
            TeacherManage.BackColor = Color.Yellow;
            StudentManage.BackColor = Color.White;
            AddPanel.Visible = false;
            listView1.Visible = true;
            listView1.Clear();
            TeacherPackage[] packages = Tool.GetTeachers();
            if (null != packages)
            {
                ListViewItem item;
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("教工号", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("姓名", 120, HorizontalAlignment.Center);
                for (int i = 0; i < packages.Length; i++)
                {
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(packages[i].ID);
                    item.SubItems.Add(packages[i].Name);
                }
            }
            else
                MessageBox.Show("当前没有教师数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 学生管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentManage_Click(object sender, EventArgs e)
        {
            AddLabel.BackColor = Color.White;
            ClassManage.BackColor = Color.White;
            TeacherManage.BackColor = Color.White;
            StudentManage.BackColor = Color.Yellow;
            AddPanel.Visible = false;
            listView1.Visible = true;
            listView1.Clear();
            StudentPackage[] packages = Tool.GetStudents();
            if (null != packages)
            {
                ListViewItem item;
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("学号", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("姓名", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("专业", 230, HorizontalAlignment.Center);
                listView1.Columns.Add("年级", 140, HorizontalAlignment.Center);
                for(int i = 0; i < packages.Length; i++)
                {
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(packages[i].ID);
                    item.SubItems.Add(packages[i].Name);
                    item.SubItems.Add(packages[i].Major);
                    if (packages[i].Grade % 2 == 0)
                        item.SubItems.Add("大学 " + (packages[i].Grade / 2) + " 年级" + " 下学期");
                    else
                        item.SubItems.Add("大学 " + (packages[i].Grade / 2) + " 年级" + " 上学期");
                }
            }
            else
                MessageBox.Show("当前没有学生数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            AddLabel.BackColor = Color.Yellow;
            ClassManage.BackColor = Color.White;
            TeacherManage.BackColor = Color.White;
            StudentManage.BackColor = Color.White;
            listView1.Visible = false;
            AddPanel.Visible = true;
            listView1.Clear();
        }

        /// <summary>
        /// 刷新（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReflushList_Click(object sender, EventArgs e)
        {
            if (ClassManage.BackColor == Color.Yellow)
                ClassManage_Click(null, null);
            else if (TeacherManage.BackColor == Color.Yellow)
                TeacherManage_Click(null, null);
            else if (StudentManage.BackColor == Color.Yellow)
                StudentManage_Click(null, null);
            GC.Collect();
        }
        /// <summary>
        /// 删除教师（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherDelMenuItem_Click(object sender, EventArgs e)
        {
            string str = listView1.SelectedItems[0].SubItems[2].Text;
            DialogResult result = MessageBox.Show("是否删除 \"" + str + "\" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                Tool.DelTeacher(listView1.SelectedItems[0].SubItems[1].Text);
                Edit = true;
                SAVELabel.Visible = true;
                GC.Collect();
            }
            TeacherManage_Click(null, null);
        }
        /// <summary>
        /// 修改教师数据（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void TeacherEditMenuItem_Click(object sender, EventArgs e)
        {
            fixed(bool* p = &Edit)
            {
                TeacherEditForm editForm = new TeacherEditForm(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, Tool, p);
                editForm.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            TeacherManage_Click(null, null);
        }
        /// <summary>
        /// 将教师添加到课程（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void TeacherAddToMenuItem_Click(object sender, EventArgs e)
        {
            fixed(bool* p = &Edit)
            {
                TeacherAddToClass teacherAddTo = new TeacherAddToClass(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, Tool, p);
                teacherAddTo.ShowDialog();
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            TeacherManage_Click(null, null);
        }
        /// <summary>
        /// 删除学生（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentDelMenuItem_Click(object sender, EventArgs e)
        {
            string str = listView1.SelectedItems[0].SubItems[2].Text;
            DialogResult result = MessageBox.Show("是否删除 \"" + str + "\" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                Tool.DelStudent(listView1.SelectedItems[0].SubItems[1].Text);
                Edit = true;
                SAVELabel.Visible = true;
                GC.Collect();
            }
            StudentManage_Click(null, null);
        }
        /// <summary>
        /// 修改学生数据（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void StudentEditMenuItem_Click(object sender, EventArgs e)
        {
            fixed(bool* p = &Edit)
            {
                StudentEditForm form = new StudentEditForm(Tool.GetStudentData(listView1.SelectedItems[0].SubItems[1].Text), Tool, p);
                form.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            StudentManage_Click(null, null);
        }
        /// <summary>
        /// 学生详细信息数据（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentDataMenuItem_Click(object sender, EventArgs e)
        {
            StudentDataForm dataForm = new StudentDataForm(Tool.GetStudentData(listView1.SelectedItems[0].SubItems[1].Text), Tool);
            dataForm.ShowDialog(this);
            GC.Collect();
            StudentManage_Click(null, null);
        }
        /// <summary>
        /// 学生选课（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void StudentSelectMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = true;
            fixed (bool* p = &Edit)
            {
                StudentClassSDForm form = new StudentClassSDForm(Tool.GetStudentData(listView1.SelectedItems[0].SubItems[1].Text), Tool, true, p, &flag);
                if (flag)
                    form.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            StudentManage_Click(null, null);
        }
        /// <summary>
        /// 学生退课（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void StudentDropMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = true;
            fixed (bool* p = &Edit)
            {
                StudentClassSDForm form = new StudentClassSDForm(Tool.GetStudentData(listView1.SelectedItems[0].SubItems[1].Text), Tool, false, p, &flag);
                if (flag)
                    form.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            StudentManage_Click(null, null);
        }
        /// <summary>
        /// 删除课程（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassDelMenuItem_Click(object sender, EventArgs e)
        {
            string str = listView1.SelectedItems[0].SubItems[2].Text;
            DialogResult result = MessageBox.Show("是否删除 \"" + str + "\" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                Tool.DelClass(listView1.SelectedItems[0].SubItems[1].Text);
                Edit = true;
                SAVELabel.Visible = true;
                GC.Collect();
            }
            ClassManage_Click(null, null);
        }
        /// <summary>
        /// 课程详细信息（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassInforamtionMenuItem_Click(object sender, EventArgs e)
        {
            StudentClassMI classMI = new StudentClassMI(Tool.GetClass(listView1.SelectedItems[0].SubItems[1].Text), Tool);
            classMI.ShowDialog(this);
            GC.Collect();
        }
        /// <summary>
        /// 修改课程数据（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void ClassEditMenuItem_Click(object sender, EventArgs e)
        {
            fixed(bool* p = &Edit)
            {
                ClassEditForm form = new ClassEditForm(Tool.GetClass(listView1.SelectedItems[0].SubItems[1].Text), Tool, p);
                form.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            ClassManage_Click(null, null);
        }
        /// <summary>
        /// 添加教师到课程（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void ClassAddTMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = true;
            fixed (bool* p = &Edit)
            {
                ClassTeacherSDForm form = new ClassTeacherSDForm(Tool, p, &flag);
                if (flag)
                    form.ShowDialog();
            }
            if (Edit)
                SAVELabel.Visible = true;
            GC.Collect();
        }
        /// <summary>
        /// 添加学生到课程（右键项）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void ClassAddSMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = true;
            fixed (bool* p = &Edit)
            {
                ClassStudentSDForm form = new ClassStudentSDForm(Tool, listView1.SelectedItems[0].SubItems[1].Text, p, &flag);
                if (flag)
                    form.ShowDialog(this);
            }
            if (Edit)
                SAVELabel.Visible = true;
            GC.Collect();
        }
        /// <summary>
        /// 课程学生成绩修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void ClassScoreEdit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            fixed (bool* p = &Edit)
            {
                ClassScoreEdit form = new ClassScoreEdit(Tool.GetClass(listView1.SelectedItems[0].SubItems[1].Text), Tool, p, &flag);
                if (flag)
                    form.ShowDialog(this);
            }
            GC.Collect();
            if (Edit)
                SAVELabel.Visible = true;
            ClassManage_Click(null, null);
        }

        /// <summary>
        /// 添加课程按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClassButton_Click(object sender, EventArgs e)
        {
            int grade = 0, cap = 0;
            float credit = 0;
            bool f = false;
            if ("" == ClassIDBox.Text)
                MessageBox.Show("课程编号不可为空\r\n请输入课程编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string reg = "[0-9]{8}";
                bool m = Regex.Match(ClassIDBox.Text, reg).Success;
                if (m)
                {
                    int college = 0;
                    if (!int.TryParse((string)ClassCollegeCB.SelectedValue, out college)) 
                    {
                        ClassCollegeCB.SelectedIndex = 0;
                        MessageBox.Show("课程学院编号无效\r\n请输入有效的学院编号", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if ("" == ClassNameBox.Text)
                            MessageBox.Show("课程名称不可为空\r\n请输入课程名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if ("" == ClassCreditBox.Text)
                            MessageBox.Show("课程学分不可为空\r\n请输入课程学分", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            f = float.TryParse(ClassCreditBox.Text, out credit);
                            if (f)
                            {
                                if ("" == ClassCapBox.Text)
                                    MessageBox.Show("课程容量不可为空\r\n请输入课程容量", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                {
                                    f = int.TryParse(ClassCapBox.Text, out cap);
                                    if (f)
                                    {
                                        f = int.TryParse(ClassGradeBox.Text, out grade);
                                        if (!f)
                                            grade = 0;
                                        ClassPackage[] packages = Tool.GetClasses();
                                        f = false;
                                        if (null != packages)
                                            for (int i = 0; i < packages.Length; i++)
                                                if (packages[i].ClassID == ClassIDBox.Text)
                                                {
                                                    f = true;
                                                    break;
                                                }
                                        if (!f)
                                        {
                                            Tool.AddClass(ClassIDBox.Text, ClassNameBox.Text, grade, college, ClassIntroductBox.Text, credit, cap);
                                            Edit = true;
                                            SAVELabel.Visible = true;
                                            ClassIDBox.Text = "";
                                            ClassNameBox.Text = "";
                                            ClassIntroductBox.Text = "";
                                            ClassGradeBox.Text = "";
                                            ClassCapBox.Text = "";
                                            ClassCreditBox.Text = "";
                                            MessageBox.Show("课程添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show("添加失败\r\n课程已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        ClassCapBox.Text = "";
                                        MessageBox.Show("课程容量无效\r\n请输入有效的课程容量", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                ClassCreditBox.Text = "";
                                MessageBox.Show("课程学分无效\r\n请输入有效的学分", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    ClassIDBox.Text = "";
                    MessageBox.Show("课程编号无效\r\n请输入有效的课程编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 添加教师按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherAddButton_Click(object sender, EventArgs e)
        {
            if ("" == TeacherIDBox.Text)
                MessageBox.Show("教师工号不可为空\r\n请输入教师工号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string reg = "[0-9]{7}";
                bool m = Regex.Match(TeacherIDBox.Text, reg).Success;
                if (m)
                {
                    bool f = false;
                    TeacherPackage[] packages = Tool.GetTeachers();
                    if (null != packages)
                        for (int i = 0; i < packages.Length; i++)
                            if (packages[i].ID == TeacherIDBox.Text)
                            {
                                f = true;
                                break;
                            }
                    if (!f)
                    {
                        Tool.AddTeacher(TeacherIDBox.Text, TeacherNameBox.Text);
                        MessageBox.Show("教师添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TeacherIDBox.Text = "";
                        TeacherNameBox.Text = "";
                        Edit = true;
                        SAVELabel.Visible = true;
                    }
                    else
                        MessageBox.Show("添加失败\r\n教师已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TeacherIDBox.Text = "";
                    MessageBox.Show("教师工号无效\r\n请输入有效的教师工号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 添加学生按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentAddButton_Click(object sender, EventArgs e)
        {
            if ("" == StudentIDBox.Text)
                MessageBox.Show("学生学号不可为空\r\n请输入学生学号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string reg = "[0-9]{10}";
                bool m = Regex.Match(StudentIDBox.Text, reg).Success;
                if (m)
                {
                    if ("" == StudentNameBox.Text)
                        MessageBox.Show("学生姓名不可为空\r\n请输入学生姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if ("" == StudentMajorBox.Text)
                        MessageBox.Show("学生专业不可为空\r\n请输入学生专业", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        int college = 0;
                        if (!int.TryParse((string)StudentCollegeCB.SelectedValue, out college))
                        {
                            StudentCollegeCB.SelectedIndex = 0; ;
                            MessageBox.Show("学生学院编号无效\r\n请输入正确的学院编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if ("" == StudentGradeBox.Text)
                                MessageBox.Show("学生年级不可为空\r\n请输入学生年级", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                int grade = 0;
                                bool f = int.TryParse(StudentGradeBox.Text, out grade);
                                if (f)
                                {
                                    StudentPackage[] packages = Tool.GetStudents();
                                    f = false;
                                    if (null != packages)
                                        for (int i = 0; i < packages.Length; i++)
                                            if (packages[i].ID == StudentIDBox.Text)
                                            {
                                                f = true;
                                                break;
                                            }
                                    if (!f)
                                    {
                                        Tool.AddStudent(StudentIDBox.Text, StudentNameBox.Text, StudentMajorBox.Text, grade, college);
                                        Edit = true;
                                        SAVELabel.Visible = true;
                                        MessageBox.Show("添加学生成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        StudentIDBox.Text = "";
                                        StudentNameBox.Text = "";
                                        StudentMajorBox.Text = "";
                                        StudentGradeBox.Text = "";
                                    }
                                    else
                                        MessageBox.Show("添加失败\r\n学生已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    StudentGradeBox.Text = "";
                                    MessageBox.Show("学生年级无效\r\n请输入有效的学生年级", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    StudentIDBox.Text = "";
                    MessageBox.Show("学生学号无效\r\n请输入有效的学生学号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RadioButton_Change(object sender, EventArgs e)
        {
            if (ClassAddRadioButton.Checked)
            {
                DataTable dt = new DataTable();
                dt.TableName = "College";
                dt.Columns.Add("CollegeCode");
                dt.Columns.Add("CollegeName");
                if (Tool.IsnNull)
                    for (int i = 0; i < Tool.Length; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["CollegeCode"] = Tool[i].Name;
                        row["CollegeName"] = Tool[i].Data;
                        dt.Rows.Add(row);
                    }
                ClassCollegeCB.DataSource = dt;
                ClassCollegeCB.DisplayMember = "CollegeName";
                ClassCollegeCB.ValueMember = "CollegeCode";
                ClassPanel.Visible = true;
                StudentPanel.Visible = false;
                TeacherPanel.Visible = false;
                CollegePanel.Visible = false;
            }
            else if (TeacherAddRadioButton.Checked)
            {
                ClassPanel.Visible = false;
                StudentPanel.Visible = false;
                TeacherPanel.Visible = true;
                CollegePanel.Visible = false;
            }
            else if (StudentAddRadioButton1.Checked)
            {
                StudentPanel.Refresh();
                ClassPanel.Visible = false;
                StudentPanel.Visible = true;
                TeacherPanel.Visible = false;
                CollegePanel.Visible = false;
            }
            else if (CollegeAddRadioButton.Checked)
            {
                DataTable dt = new DataTable();
                dt.TableName = "College";
                dt.Columns.Add("CollegeCode");
                dt.Columns.Add("CollegeName");
                if (Tool.IsnNull)
                    for (int i = 1; i < Tool.Length; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["CollegeCode"] = Tool[i].Name;
                        row["CollegeName"] = Tool[i].Data;
                        dt.Rows.Add(row);
                    }
                StudentCollegeCB.DataSource = dt;
                StudentCollegeCB.DisplayMember = "CollegeName";
                StudentCollegeCB.ValueMember = "CollegeCode";
                ClassPanel.Visible = false;
                StudentPanel.Visible = false;
                TeacherPanel.Visible = false;
                CollegePanel.Visible = true;
            }
        }
        /// <summary>
        /// 添加学院按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ("" == CollegeCodeBox.Text)
                MessageBox.Show("学院编号不可为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ("" == CollegeNameBox.Text)
                MessageBox.Show("学院名称不可为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Regex regex = new Regex("[0-9]*");
                if (regex.IsMatch(CollegeCodeBox.Text))
                {
                    bool f = false;
                    for(int i = 0; i < Tool.Length; i++)
                    {
                        if (CollegeCodeBox.Text == Tool[i].Name || CollegeNameBox.Text == Tool[i].Data)
                        {
                            f = true;
                            break;
                        }
                    }
                    if (!f)
                    {
                        Tool.AddCollege(CollegeCodeBox.Text, CollegeNameBox.Text);
                        Edit = true;
                        SAVELabel.Visible = true;
                        MessageBox.Show("添加学生成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CollegeNameBox.Text = "";
                        CollegeCodeBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("学院存在\r\n请重新输入学院", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CollegeCodeBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("学院编号格式错误\r\n请输入正确的学院编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CollegeCodeBox.Text = "";
                }
            }
        }
        /// <summary>
        /// 删除学院按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelCollege_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入学院名称：", "删除学院");
            if ("" != str)
            {
                if ("通识课程" != str)
                {
                    if (Tool.DelCollege(str))
                    {
                        MessageBox.Show("学院删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Edit = true;
                        SAVELabel.Visible = true;
                    }
                    else
                        MessageBox.Show("学院不存在\r\n删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("输入学院名称无效", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("学院名称不可为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

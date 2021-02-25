using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRsystem.Collections;
using ClassManageSystem;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;
using System.Threading;
using ClassOption.UI;
using Microsoft.VisualBasic;

namespace ClassOptions
{
    /// <summary>
    /// 学生窗体
    /// </summary>
    public partial class Student : Form
    {
        private ClassManageTool Tool;    //课程管理组件
        private ClassManageSystem.StudentClassPackage[] ClassPackages;
        private StudentClassSelect[] ClassSelects;
        private string ID;    //学生学号
        private int Grade;    //学生年级
        private int College;

        private new ContextMenuStrip ContextMenuStrip;
        private ToolStripMenuItem 成绩menuItem;
        private ToolStripMenuItem 课程menuItem;
        private ToolStripMenuItem 空menuItem;
        private ToolStripMenuItem 退选menuItem;
        private StudentClassMI StudentClassMI;

        private Point OldPoint;   //鼠标定位点
        private bool PointFlag;   //鼠标点击窗体拖动标志

        private bool Edited;   //数据修改标志
        private bool ClassFlag;
        private bool ScoreFlag;
        private bool SelectFlag;
        private bool GradeFlag;
        private bool CreditFlag;
        private bool TeacherFlag;
        private int grade;
        private string teacher;
        private float credit;

        /// <summary>
        /// 学生窗体构造函数
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="tool">课程管理组件</param>
        public Student(string studentID, ClassManageTool tool)
        {
            Tool = tool;
            PointFlag = false;
            Edited = false;
            ID = studentID;
            ClassPackages = null;
            StudentClassMI = null;
            ClassSelects = null;
            ClassFlag = false;
            ScoreFlag = false;
            SelectFlag = false;
            GradeFlag = false;
            CreditFlag = false;
            TeacherFlag = false;
            InitializeComponent();
            TurnBack.Visible = false;
            ScoreList.Visible = false;
            SearchLabel.Visible = false;
            TeacherSearch.Visible = false;
            CreditSearch.Visible = false;
            SaveLabel.Visible = false;
            StudentPackage package = Tool.GetStudentData(studentID);
            Grade = package.Grade;
            GradeLabel.Text = "大学 " + (package.Grade / 2) + " 年级";
            if (Grade % 2 == 0)
                GradeLabel.Text += " 下学期";
            else
                GradeLabel.Text += " 上学期";
            MajorLabel.Text = package.Major;
            College = package.College;
            bool f = false;
            if (Tool.IsnNull)
                for (int i = 0; i < tool.Length; i++)
                    if (package.College.ToString() == Tool[i].Name)
                    {
                        CollegeLabel.Text = Tool[i].Data;
                        f = true;
                        break;
                    }
            if (!f)
                CollegeLabel.Text = package.College.ToString();
            StudentName.Text = package.Name;
        }


        /// <summary>
        /// 初始化列表
        /// </summary>
        private void InitList()
        {
            if (ClassFlag)
            {
                listView1.Clear();
                ListViewItem item = new ListViewItem();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 160, HorizontalAlignment.Center);
                listView1.Columns.Add("选修学期", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("课程学分", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("教师", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("开课学院", 130, HorizontalAlignment.Center);
                ClassPackages = Tool.GetClassS(ID);
                if (null != ClassPackages)
                {
                    for (int i = 0; i < ClassPackages.Length; i++)
                    {
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(ClassPackages[i].classID);
                        item.SubItems.Add(ClassPackages[i].className);
                        item.SubItems.Add(ClassPackages[i].classGrade.ToString());
                        item.SubItems.Add(ClassPackages[i].classCredit.ToString());
                        item.SubItems.Add(ClassPackages[i].teacherName);
                        bool f = false;
                        if (Tool.IsnNull)
                            for (int j = 0; j < Tool.Length; j++)
                                if (ClassPackages[i].classCollege.ToString() == Tool[j].Name)
                                {
                                    item.SubItems.Add(Tool[j].Data);
                                    f = true;
                                    break;
                                }
                        if (!f)
                            item.SubItems.Add(ClassPackages[i].classCollege.ToString());
                    }
                }
                Label_Move();
                TurnBack.Visible = false;
            }
            else if (ScoreFlag)
            {
                listView1.Clear();
                ListViewItem item = new ListViewItem();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 160, HorizontalAlignment.Center);
                listView1.Columns.Add("选修学期", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("课程学分", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("教师", 70, HorizontalAlignment.Center);
                listView1.Columns.Add("成绩", 70, HorizontalAlignment.Center);
                if (null == ClassPackages)
                    ClassPackages = Tool.GetClassS(ID);
                if (null != ClassPackages)
                {
                    for (int i = 0; i < ClassPackages.Length; i++)
                    {
                        item = listView1.Items.Add((i + 1).ToString());
                        item.SubItems.Add(ClassPackages[i].classID);
                        item.SubItems.Add(ClassPackages[i].className);
                        item.SubItems.Add(ClassPackages[i].classGrade.ToString());
                        item.SubItems.Add(ClassPackages[i].classCredit.ToString());
                        item.SubItems.Add(ClassPackages[i].teacherName);
                        item.SubItems.Add(ClassPackages[i].Score.ToString());
                    }
                }
            }
            else if (SelectFlag)
            {
                listView1.Clear();
                ListViewItem item = new ListViewItem();
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("选修学期", 60, HorizontalAlignment.Center);
                listView1.Columns.Add("简介", 160, HorizontalAlignment.Center);
                listView1.Columns.Add("学分", 50, HorizontalAlignment.Center);
                listView1.Columns.Add("开课学院", 140, HorizontalAlignment.Center);
                ClassPackages = Tool.GetClassS(ID);
                if (null == ClassSelects)
                    ClassSelects = Tool.GetClassS();
                if (null != ClassSelects)
                {
                    int index = 0;
                    bool Find = false;
                    for (int i = 0; i < ClassSelects.Length; i++)
                    {
                        bool flag = false;
                        if (ClassSelects[i].classCollege == College || 0 == ClassSelects[i].classCollege)
                        {
                            if (0 < ClassSelects[i].classMax)
                                if (null != ClassSelects[i].TeacherIDs)
                                    for (int j = 0; j < ClassSelects[i].TeacherIDs.Length; j++)
                                        if (null != Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID))
                                        {
                                            if (ClassSelects[i].classMax > Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID).Length)
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            flag = true;
                                            break;
                                        }
                            if (ClassSelects[i].classGrade > Grade)
                                flag = false;
                            if (flag)
                            {
                                Find = false;
                                if (null != ClassPackages)
                                    for (int j = 0; j < ClassPackages.Length; j++)
                                        if (ClassPackages[j].classID == ClassSelects[i].classID)
                                        {
                                            Find = true;
                                            break;
                                        }
                                if (!Find)
                                {
                                    item = listView1.Items.Add((index + 1).ToString());
                                    item.SubItems.Add(ClassSelects[i].classID);
                                    item.SubItems.Add(ClassSelects[i].className);
                                    item.SubItems.Add(ClassSelects[i].classGrade.ToString());
                                    item.SubItems.Add(ClassSelects[i].classIntroduct);
                                    item.SubItems.Add(ClassSelects[i].classCredit.ToString());                                  
                                    bool f = false;
                                    if (Tool.IsnNull)
                                        for (int j = 0; j < Tool.Length; j++)
                                            if (ClassSelects[i].classCollege.ToString() == Tool[j].Name)
                                            {
                                                item.SubItems.Add(Tool[j].Data);
                                                f = true;
                                                break;
                                            }
                                    if (!f)
                                        item.SubItems.Add(ClassSelects[i].classCollege.ToString());
                                    index++;
                                }
                            }
                        }
                    }
                }
                Label_Move();
                if (0 == listView1.Items.Count)
                    MessageBox.Show("当前没有可以选择的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TurnBack.Visible = false;
            }
            else if (GradeFlag)
                Search_Class();
            else if (CreditFlag)
                Search_Teacher();
            else if(CreditFlag)
                Search_Credit();
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
        /// 表单双击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, EventArgs e)
        {
            if (!ScoreFlag)
                课程MenuItem_Click(sender, e);
        }
        /// <summary>
        /// 表单右键方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_RightClick(object sender, MouseEventArgs e)
        {
            if (ClassFlag)
            {
                ContextMenuStrip = new ContextMenuStrip();
                成绩menuItem = new ToolStripMenuItem("显示成绩");
                成绩menuItem.Click += new EventHandler(成绩MenuItem_Click);
                ContextMenuStrip.Items.Add(成绩menuItem);
                课程menuItem = new ToolStripMenuItem("课程详情");
                课程menuItem.Click += new EventHandler(课程MenuItem_Click);
                ContextMenuStrip.Items.Add(课程menuItem);
                空menuItem = new ToolStripMenuItem(" ");
                ContextMenuStrip.Items.Add(空menuItem);
                退选menuItem = new ToolStripMenuItem("退选");
                退选menuItem.Click += new EventHandler(退选MenuItem_Click);
                ContextMenuStrip.Items.Add(退选menuItem);
                if (e.Button == MouseButtons.Right)
                    ContextMenuStrip.Show(listView1, e.Location);
            }
            else if (SelectFlag || CreditFlag || TeacherFlag || GradeFlag)
            {
                ContextMenuStrip = new ContextMenuStrip();
                课程menuItem = new ToolStripMenuItem("课程详情");
                课程menuItem.Click += new EventHandler(课程MenuItem_Click);
                ContextMenuStrip.Items.Add(课程menuItem);
                空menuItem = new ToolStripMenuItem(" ");
                ContextMenuStrip.Items.Add(空menuItem);
                退选menuItem = new ToolStripMenuItem("选课");
                退选menuItem.Click += new EventHandler(选课MenuItem_Click);
                ContextMenuStrip.Items.Add(退选menuItem);
                if (e.Button == MouseButtons.Right)
                    ContextMenuStrip.Show(listView1, e.Location);
            }
        }
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            TeacherID.Text = ID;
            SelectFlag = false;
            ClassFlag = false;
            InitList();
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
                ClassFlag = false;
                ScoreFlag = false;
                SelectFlag = false;
                GradeFlag = false;
                CreditFlag = false;
                TeacherFlag = false;
                TurnBack.Visible = false;
                Label_Move();
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
            if (ScoreFlag)
            {
                ClassFlag = true;
                ScoreFlag = false;
                SelectFlag = false;
                GradeFlag = false;
                CreditFlag = false;
                TeacherFlag = false;
            }
            else if (CreditFlag || TeacherFlag || GradeFlag)
            {
                ClassFlag = false;
                ScoreFlag = false;
                SelectFlag = true;
                GradeFlag = false;
                CreditFlag = false;
                TeacherFlag = false;
            }
            InitList();
        }

        /// <summary>
        /// 已选课程按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HClassList_Click(object sender, EventArgs e)
        {
            ClassFlag = true;
            ScoreFlag = false;
            SelectFlag = false;
            GradeFlag = false;
            CreditFlag = false;
            TeacherFlag = false;
            InitList();
            if (0 == listView1.Items.Count)
                MessageBox.Show("当前没有已选择的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 成绩查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreList_Click(object sender, EventArgs e)
        {
            if (0 == listView1.Items.Count)
                MessageBox.Show("当前没有已选择的课程\r\n不能显示成绩", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ClassFlag = false;
                ScoreFlag = true;
                SelectFlag = false;
                GradeFlag = false;
                CreditFlag = false;
                TeacherFlag = false;
                TurnBack.Visible = true;
                InitList();
            }
        }
        /// <summary>
        /// 选课按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectList_Click(object sender, EventArgs e)
        {
            ClassFlag = false;
            ScoreFlag = false;
            SelectFlag = true;
            GradeFlag = false;
            CreditFlag = false;
            TeacherFlag = false;
            InitList();
        }
        /// <summary>
        /// 按课程年级查找
        /// </summary>
        private void Search_Class()
        {
            ClassFlag = false;
            ScoreFlag = false;
            SelectFlag = false;
            GradeFlag = true;
            CreditFlag = false;
            TeacherFlag = false;
            listView1.Clear();
            ListViewItem item = new ListViewItem();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 160, HorizontalAlignment.Center);
            listView1.Columns.Add("选修学期", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("简介", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("课程学分", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("开课学院", 120, HorizontalAlignment.Center);
            ClassPackages = Tool.GetClassS(ID);
            if (null == ClassSelects)
                ClassSelects = Tool.GetClassS();
            if (null != ClassSelects)
            {
                int index = 0;
                bool Find = false;
                for (int i = 0; i < ClassSelects.Length; i++)
                {
                    bool flag = false;
                    if (ClassSelects[i].classCollege == College || 0 == ClassSelects[i].classCollege)
                    {
                        if (0 < ClassSelects[i].classMax)
                            if (null != ClassSelects[i].TeacherIDs)
                                for (int j = 0; j < ClassSelects[i].TeacherIDs.Length; j++)
                                    if (null != Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID))
                                    {
                                        if (ClassSelects[i].classMax > Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID).Length)
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        flag = true;
                                        break;
                                    }
                        if (ClassSelects[i].classGrade != grade)
                            flag = false;
                        if (flag)
                        {
                            Find = false;
                            for (int j = 0; j < ClassPackages.Length; j++)
                                if (ClassPackages[j].classID == ClassSelects[i].classID)
                                {
                                    Find = true;
                                    break;
                                }
                            if (!Find)
                            {
                                item = listView1.Items.Add((index + 1).ToString());
                                item.SubItems.Add(ClassSelects[i].classID);
                                item.SubItems.Add(ClassSelects[i].className);
                                item.SubItems.Add(ClassSelects[i].classGrade.ToString());
                                item.SubItems.Add(ClassSelects[i].classIntroduct);
                                item.SubItems.Add(ClassSelects[i].classCredit.ToString());
                                bool f = false;
                                if (Tool.IsnNull)
                                    for (int j = 0; j < Tool.Length; j++)
                                        if (ClassSelects[i].classCollege.ToString() == Tool[j].Name)
                                        {
                                            item.SubItems.Add(Tool[j].Data);
                                            f = true;
                                            break;
                                        }
                                if (!f)
                                    item.SubItems.Add(ClassSelects[i].classCollege.ToString());
                                index++;
                            }
                        }
                    }    
                }
            }
            Label_Move();
            if (0 == listView1.Items.Count)
                MessageBox.Show("当前年级没有可以选择的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TurnBack.Visible = true;
        }
        /// <summary>
        /// 按课程年级查找事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Class(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入课程年级", "查询课程", "课程年级（示例：3）");
            grade = 0;
            bool f = int.TryParse(str, out grade);
            if ("" == str)
                MessageBox.Show("输入课程年级为空\r\n课程年级不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!f)
                MessageBox.Show("输入课程年级无效\r\n课程年级 \"" + str + "\"不是正确的年级表示方法", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (grade > Grade)
                MessageBox.Show("无法查询超过学生年级的课程", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Search_Class();
        }
        private void Search_Teacher()
        {
            ClassFlag = false;
            ScoreFlag = false;
            SelectFlag = false;
            GradeFlag = false;
            CreditFlag = false;
            TeacherFlag = true;
            listView1.Clear();
            ListViewItem item = new ListViewItem();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 160, HorizontalAlignment.Center);
            listView1.Columns.Add("选修学期", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("简介", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("课程学分", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("课程教师", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("开课学院", 70, HorizontalAlignment.Center);
            ClassPackages = Tool.GetClassS(ID);
            if (null == ClassSelects)
                ClassSelects = Tool.GetClassS();
            if (null != ClassSelects)
            {
                int index = 0;
                bool Find = false;
                for (int i = 0; i < ClassSelects.Length; i++)
                {
                    bool flag = false;
                    if (ClassSelects[i].classCollege == College || 0 == ClassSelects[i].classCollege)
                    {
                        if (0 < ClassSelects[i].classMax)
                            if (null != ClassSelects[i].TeacherIDs)
                                for (int j = 0; j < ClassSelects[i].TeacherIDs.Length; j++)
                                    if (ClassSelects[i].TeacherNames[j] == teacher)
                                    {
                                        if (null != Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID))
                                        {
                                            if (ClassSelects[i].classMax > Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID).Length)
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                        if (flag)
                        {
                            Find = false;
                            for (int j = 0; j < ClassPackages.Length; j++)
                                if (ClassPackages[j].classID == ClassSelects[i].classID)
                                {
                                    Find = true;
                                    break;
                                }
                            if (!Find)
                            {
                                item = listView1.Items.Add((index + 1).ToString());
                                item.SubItems.Add(ClassSelects[i].classID);
                                item.SubItems.Add(ClassSelects[i].className);
                                item.SubItems.Add(ClassSelects[i].classGrade.ToString());
                                item.SubItems.Add(ClassSelects[i].classIntroduct);
                                item.SubItems.Add(ClassSelects[i].classCredit.ToString());
                                item.SubItems.Add(teacher);
                                bool f = false;
                                if (Tool.IsnNull)
                                    for (int j = 0; j < Tool.Length; j++)
                                        if (ClassSelects[i].classCollege.ToString() == Tool[j].Name)
                                        {
                                            item.SubItems.Add(Tool[j].Data);
                                            f = true;
                                            break;
                                        }
                                if (!f)
                                    item.SubItems.Add(ClassSelects[i].classCollege.ToString());
                                index++;
                            }
                        }
                    }   
                }
            }
            Label_Move();
            if (0 == listView1.Items.Count)
                MessageBox.Show(" \"" + teacher + "\" 老师当前没有可选择的课程\r\n请检查查询教师名字是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TurnBack.Visible = true;
        }
        /// <summary>
        /// 按教师名查找课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Teacher(object sender, EventArgs e)
        {
            teacher = Interaction.InputBox("请输入教师名", "查询课程", "教师名");
            if ("" == teacher)
                MessageBox.Show("输入教师名为空\r\n教师名不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Search_Teacher();
        }
        private void Search_Credit()
        {
            ClassFlag = false;
            ScoreFlag = false;
            SelectFlag = false;
            GradeFlag = false;
            CreditFlag = true;
            TeacherFlag = false;
            listView1.Clear();
            ListViewItem item = new ListViewItem();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 160, HorizontalAlignment.Center);
            listView1.Columns.Add("选修学期", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("简介", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("课程学分", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("开课学院", 120, HorizontalAlignment.Center);
            ClassPackages = Tool.GetClassS(ID);
            if (null == ClassSelects)
                ClassSelects = Tool.GetClassS();
            if (null != ClassSelects)
            {
                int index = 0;
                bool Find = false;
                for (int i = 0; i < ClassSelects.Length; i++)
                {
                    bool flag = false;
                    if (ClassSelects[i].classCollege == College || 0 == ClassSelects[i].classCollege)
                    {
                        if (0 < ClassSelects[i].classMax)
                            if (null != ClassSelects[i].TeacherIDs)
                                for (int j = 0; j < ClassSelects[i].TeacherIDs.Length; j++)
                                    if (null != Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID))
                                    {
                                        if (ClassSelects[i].classMax > Tool.GetTeacherStudent(ClassSelects[i].TeacherIDs[j], ClassSelects[i].classID).Length)
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        flag = true;
                                        break;
                                    }
                        if (ClassSelects[i].classCredit != credit)
                            flag = false;
                        if (flag)
                        {
                            Find = false;
                            for (int j = 0; j < ClassPackages.Length; j++)
                                if (ClassPackages[j].classID == ClassSelects[i].classID)
                                {
                                    Find = true;
                                    break;
                                }
                            if (!Find)
                            {
                                item = listView1.Items.Add((index + 1).ToString());
                                item.SubItems.Add(ClassSelects[i].classID);
                                item.SubItems.Add(ClassSelects[i].className);
                                item.SubItems.Add(ClassSelects[i].classGrade.ToString());
                                item.SubItems.Add(ClassSelects[i].classIntroduct);
                                item.SubItems.Add(ClassSelects[i].classCredit.ToString());
                                bool f = false;
                                if (Tool.IsnNull)
                                    for (int j = 0; j < Tool.Length; j++)
                                        if (ClassSelects[i].classCollege.ToString() == Tool[j].Name)
                                        {
                                            item.SubItems.Add(Tool[j].Data);
                                            f = true;
                                            break;
                                        }
                                if (!f)
                                    item.SubItems.Add(ClassSelects[i].classCollege.ToString());
                                index++;
                            }
                        }
                    }   
                }
            }
            Label_Move();
            if (0 == listView1.Items.Count)
                MessageBox.Show("此学分当前没有可以选择的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TurnBack.Visible = true;
    }
        /// <summary>
        /// 按学分查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Credit(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入学分", "查询课程", "学分（示例：2.5）");
            credit = 0;
            bool f = float.TryParse(str, out credit);
            if ("" == str)
                MessageBox.Show("输入学分为空\r\n学分不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!f)
                MessageBox.Show("输入学分错误\r\n学分 \"" + str + "\" 不是正确的学分表示方式", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Search_Credit(); 
        }
        /// <summary>
        /// 标签移动（左侧按钮组动画实现方法）
        /// </summary>
        private void Label_Move()
        {
            if (ClassFlag)
            {
                if (0 != listView1.Items.Count)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (250 > SelectList.Location.Y)
                            SelectList.Location = new Point(SelectList.Location.X, SelectList.Location.Y + 1);
                        else
                            break;
                    }
                    for (int i = 0; i < 50; i++)
                        if (325 < CreditSearch.Location.Y)
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (275 < TeacherSearch.Location.Y)
                        {
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        }
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (226 < SearchLabel.Location.Y)
                        {
                            SearchLabel.Location = new Point(SearchLabel.Location.X, SearchLabel.Location.Y - 1);
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        }
                        else
                            break;
                    SearchLabel.Visible = false;
                    TeacherSearch.Visible = false;
                    CreditSearch.Visible = false;
                    ScoreList.Visible = true;
                    listView1.Visible = true;
                    panel1.Visible = false;
                }
                else
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (200 < SelectList.Location.Y)
                            SelectList.Location = new Point(SelectList.Location.X, SelectList.Location.Y - 1);
                        else
                            break;
                    }
                    ScoreList.Visible = false;
                }
            }
            else if (SelectFlag || CreditFlag || TeacherFlag || GradeFlag)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (200 < SelectList.Location.Y)
                        SelectList.Location = new Point(SelectList.Location.X, SelectList.Location.Y - 1);
                    else
                        break;
                }
                if (0 != listView1.Items.Count)
                {
                    listView1.Visible = true;
                    SearchLabel.Visible = true;
                    TeacherSearch.Visible = true;
                    for (int i = 0; i < 50; i++)
                        if (275 > SearchLabel.Location.Y)
                        {
                            SearchLabel.Location = new Point(SearchLabel.Location.X, SearchLabel.Location.Y + 1);
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y + 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y + 1);
                        }
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (325 > TeacherSearch.Location.Y)
                        {
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y + 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y + 1);
                        }
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (375 > CreditSearch.Location.Y)
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y + 1);
                        else
                            break;
                    ScoreList.Visible = false;
                    CreditSearch.Visible = true;
                    panel1.Visible = false;
                }
                else
                {
                    for (int i = 0; i < 50; i++)
                        if (325 < CreditSearch.Location.Y)
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (275 < TeacherSearch.Location.Y)
                        {
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        }
                        else
                            break;
                    for (int i = 0; i < 50; i++)
                        if (226 < SearchLabel.Location.Y)
                        {
                            SearchLabel.Location = new Point(SearchLabel.Location.X, SearchLabel.Location.Y - 1);
                            TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                            CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                        }
                        else
                            break;
                }
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    if (200 < SelectList.Location.Y)
                        SelectList.Location = new Point(SelectList.Location.X, SelectList.Location.Y - 1);
                    else
                        break;
                }
                for (int i = 0; i < 50; i++)
                    if (325 < CreditSearch.Location.Y)
                        CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                    else
                        break;
                for (int i = 0; i < 50; i++)
                    if (275 < TeacherSearch.Location.Y)
                    {
                        TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                        CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                    }
                    else
                        break;
                for (int i = 0; i < 50; i++)
                    if (226 < SearchLabel.Location.Y)
                    {
                        SearchLabel.Location = new Point(SearchLabel.Location.X, SearchLabel.Location.Y - 1);
                        TeacherSearch.Location = new Point(TeacherSearch.Location.X, TeacherSearch.Location.Y - 1);
                        CreditSearch.Location = new Point(CreditSearch.Location.X, CreditSearch.Location.Y - 1);
                    }
                    else
                        break; 
                ScoreList.Visible = false;
                listView1.Visible = false;
                panel1.Visible = true;
            }
        }
        /// <summary>
        /// 右键成绩显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 成绩MenuItem_Click(object sender, EventArgs e)
        {
            TurnBack.Visible = true;
            ScoreList_Click(null, new EventArgs());
            ContextMenuStrip.Dispose();
        }
        /// <summary>
        /// 右键课程详情显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 课程MenuItem_Click(object sender, EventArgs e)
        {
            if (ClassFlag)
            {
                for (int i = 0; i < ClassPackages.Length; i++)
                    if (listView1.SelectedItems[0].SubItems[1].Text == ClassPackages[i].classID)
                    {
                        StudentClassMI = new StudentClassMI(Tool.GetClassS(listView1.SelectedItems[0].SubItems[1].Text, true), Tool, ClassPackages[i].teacherID);
                        break;
                    }
            }
            else
                StudentClassMI = new StudentClassMI(Tool.GetClassS(listView1.SelectedItems[0].SubItems[1].Text, true), Tool);
            if (null != StudentClassMI)
                StudentClassMI.ShowDialog(this);
            StudentClassMI = null;
            GC.Collect();
            if (null != ContextMenuStrip)
                ContextMenuStrip.Dispose();
        }
        /// <summary>
        /// 右键课程退选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退选MenuItem_Click(object sender, EventArgs e)
        {
            string str = "是否退选课程：" + listView1.SelectedItems[0].SubItems[2].Text + " ？\r\n" +
                "退选后课程将不再显示在你的课程中";
            DialogResult result = MessageBox.Show(str, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes==result)
                for(int i = 0; i < ClassPackages.Length; i++)
                {
                    if (ClassPackages[i].classID == listView1.SelectedItems[0].SubItems[1].Text)
                    {
                        Edited = true;
                        SaveLabel.Visible = true;
                        Tool.DropClass(ID, ClassPackages[i].teacherID, listView1.SelectedItems[0].SubItems[1].Text);
                        break;
                    }
                }
            InitList();
            ContextMenuStrip.Dispose();
        }
        /// <summary>
        /// 右键课程退选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void 选课MenuItem_Click(object sender, EventArgs e)
        {
            StudentSelectClass selectClass;
            fixed (bool* p = &Edited)
            {
                selectClass = new StudentSelectClass(Tool.GetClassS(listView1.SelectedItems[0].SubItems[1].Text, true), Tool, ID, p);
            }
            selectClass.ShowDialog(this);
            if (Edited)
                SaveLabel.Visible = true;
            GC.Collect();
            InitList();
            ContextMenuStrip.Dispose();
        }
        private void SaveLabel_Click(object sender, EventArgs e)
        {
            Save();
            SaveLabel.Visible = false;
        }

        private void EditDataLabel_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(TeacherID.Text);
            form.ShowDialog(this);
            GC.Collect();
        }
    }
}

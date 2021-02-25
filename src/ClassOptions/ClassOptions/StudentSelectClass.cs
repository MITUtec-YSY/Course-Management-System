using ClassManageSystem;
using ClassManageSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassOptions
{
    /// <summary>
    /// 学生选课窗体
    /// </summary>
    public partial class StudentSelectClass : Form
    {
        private ClassManageTool Tool;   //课程管理系统组件引用
        private string sID;     //学生学号
        unsafe private bool* Edit;    //修改标志（不安全的指针引用）
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 学生选课窗体构造函数（存在不安全的指针引用）
        /// </summary>
        /// <param name="package">课程数据包</param>
        /// <param name="tool">课程管理系统组件引用</param>
        /// <param name="id">学生学号</param>
        /// <param name="edit">修改标志（不安全的指针引用）</param>
        unsafe public StudentSelectClass(ClassPackage package, ClassManageTool tool, string id, bool *edit)
        {
            Edit = edit;
            Tool = tool;
            sID = id;
            InitializeComponent();
            listView1.FullRowSelect = true;
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
            if (null != package.Teachers)
            {
                int sum = 0;
                ListViewItem item = new ListViewItem();
                for (int i = 0; i < package.Teachers.Length; i++)
                {
                    sum = 0;
                    if (null != package.Teachers[i].Students)
                        if (package.ClassMax <= package.Teachers[i].Students.Length)
                            continue;
                        else
                            sum = package.Teachers[i].Students.Length;
                    item = listView1.Items.Add((i + 1).ToString());
                    item.SubItems.Add(package.Teachers[i].TeacherID);
                    item.SubItems.Add(tool.GetTeacherName(package.Teachers[i].TeacherID));
                    item.SubItems.Add(package.ClassMax.ToString());
                    item.SubItems.Add((package.ClassMax - sum).ToString());
                }
            }
            OK_Button.Enabled = false;
        }

        private void listView_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void Form_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void ClassIDLabel_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void ClassNameLabel_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void ClassCreditLabel_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void label5_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }
        private void Grade_Label_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
                OK_Button.Enabled = true;
            else
                OK_Button.Enabled = false;
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 选课按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void OK_Button_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
            {
                string str = Tool.SelectClass(sID, listView1.SelectedItems[0].SubItems[1].Text, ClassIDLabel.Text);
                if ("选课成功" == str)
                    *Edit = true;
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("请选择一位老师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OK_Button.Enabled = false;
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
    }
}

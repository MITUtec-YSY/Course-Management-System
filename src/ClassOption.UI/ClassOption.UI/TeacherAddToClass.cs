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

namespace ClassOption.UI
{
    /// <summary>
    /// 教师添加到课程窗体
    /// </summary>
    public partial class TeacherAddToClass : Form
    {
        private ClassManageTool Tool;
        unsafe private bool* Flag;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 教师添加到课程窗体构造函数
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="teacherName"></param>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        unsafe public TeacherAddToClass(string teacherID, string teacherName, ClassManageTool tool, bool *flag)
        {
            InitializeComponent();
            Flag = flag;
            Tool = tool;
            TeacherID.Text = teacherID;
            TeacherName.Text = teacherName;
            Init();
        }

        private void Init()
        {
            ClassPackage[] packages = Tool.GetClasses();
            TeacherClassPackage[] teacherClasses = Tool.GetClassesT(TeacherID.Text);
            if (null != packages)
            {
                int index = 0;
                ListViewItem item;
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.MultiSelect = true;
                listView1.DoubleClick += new EventHandler(viewList_DoubleClick);
                listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
                listView1.Columns.Add("课程编号", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("课程名称", 140, HorizontalAlignment.Center);
                for(int i = 0; i < packages.Length; i++)
                {
                    bool f = false;
                    if (null != teacherClasses)
                        for (int j = 0; j < teacherClasses.Length; j++)
                            if (teacherClasses[j].classID == packages[i].ClassID)
                            {
                                f = true;
                                break;
                            }
                    if (!f)
                    {
                        item = listView1.Items.Add((index + 1).ToString());
                        item.SubItems.Add(packages[i].ClassID);
                        item.SubItems.Add(packages[i].ClassName);
                        index++;
                    }
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        unsafe private void OK_Button_Click(object sender, EventArgs e)
        {
            if (0 < listView1.SelectedItems.Count)
            {
                for(int i = 0; i < listView1.SelectedItems.Count; i++)
                    Tool.AddClassTeacher(listView1.SelectedItems[i].SubItems[1].Text, TeacherID.Text);
                MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                *Flag = true;
                Close();
            }
            else
                MessageBox.Show("请至少选择一门科目进行添加", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void viewList_DoubleClick(object sender, EventArgs e)
        {
            StudentClassMI classMI = new StudentClassMI(Tool.GetClass(listView1.SelectedItems[0].SubItems[1].Text), Tool);
            classMI.ShowDialog(this);
            GC.Collect();
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

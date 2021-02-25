using ClassManageSystem;
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
    public partial class StudentEditForm : Form
    {
        unsafe private bool* Flag;
        private ClassManageTool Tool;
        private string studentName;
        private string studentMajor;
        private int studentCollege;
        private string studentGrade;
        private Point OldPoint;
        private bool PointFlag;

        /// <summary>
        /// 修改学生信息窗体构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        unsafe public StudentEditForm(StudentPackage package, ClassManageTool tool, bool* flag)
        {
            Tool = tool;
            Flag = flag;
            InitializeComponent();
            StudentID.Text = package.ID;
            StudentNameBox.Text = studentName = package.Name;
            StudentMajorBox.Text = studentMajor = package.Major;
            StudentGradeBox.Text = studentGrade = package.Grade.ToString();
            StudentCollegeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            if (tool.IsnNull)
            {
                DataTable dt = new DataTable();
                studentCollege = 0;
                dt.TableName = "College";
                dt.Columns.Add("CollegeCode");
                dt.Columns.Add("CollegeName");
                for (int i = 1; i < tool.Length; i++)
                {
                    DataRow row = dt.NewRow();
                    row["CollegeCode"] = tool[i].Name;
                    row["CollegeName"] = tool[i].Data;
                    dt.Rows.Add(row);
                    if (tool[i].Name == package.College.ToString())
                        studentCollege = i - 1;
                }
                StudentCollegeCB.DataSource = dt;
                StudentCollegeCB.DisplayMember = "CollegeName";
                StudentCollegeCB.ValueMember = "CollegeCode";
                StudentCollegeCB.SelectedIndex = studentCollege;
            }
        }

        private void ReSet_Button_Click(object sender, EventArgs e)
        {
            StudentNameBox.Text = studentName;
            StudentMajorBox.Text = studentMajor;
            StudentGradeBox.Text = studentGrade;
            StudentCollegeCB.SelectedIndex = studentCollege;
        }

        unsafe private void button1_Click(object sender, EventArgs e)
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
                    StudentCollegeCB.SelectedIndex = studentCollege;
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
                            Tool.EditStudentGrade(StudentID.Text, grade);
                            Tool.EditStudentMajor(StudentID.Text, StudentMajorBox.Text, college);
                            Tool.EditStudentName(StudentID.Text, StudentNameBox.Text);
                            *Flag = true;
                            MessageBox.Show("学生信息修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
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

        private void Cancel_Button_Click(object sender, EventArgs e)
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

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
    public partial class ClassEditForm : Form
    {
        unsafe private bool* Flag;
        private ClassManageTool Tool;
        private string ClassName;
        private string ClassGrade;
        private string ClassCredit;
        private string ClassCap;
        private int ClassCollege;
        private string ClassIntroduct;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 课程数据修改窗体构造函数
        /// </summary>
        /// <param name="package"></param>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        unsafe public ClassEditForm(ClassPackage package, ClassManageTool tool, bool* flag)
        {
            Flag = flag;
            Tool = tool;
            ClassName = package.ClassName;
            ClassIntroduct = package.Introduction;
            ClassGrade = package.ClassGrade.ToString();
            ClassCredit = package.Credit.ToString();
            ClassCap = package.ClassMax.ToString();
            InitializeComponent();
            ClassID.Text = package.ClassID;
            ClassNameBox.Text = ClassName;
            ClassIntroductBox.Text = ClassIntroduct;
            ClassGradeBox.Text = ClassGrade;
            ClassCreditBox.Text = ClassCredit;
            ClassCapBox.Text = ClassCap;
            ClassCollegeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            if (tool.IsnNull)
            {
                DataTable dt = new DataTable();
                ClassCollege = 0;
                dt.TableName = "College";
                dt.Columns.Add("CollegeCode");
                dt.Columns.Add("CollegeName");
                for(int i = 0; i < tool.Length; i++)
                {
                    DataRow row = dt.NewRow();
                    row["CollegeCode"] = tool[i].Name;
                    row["CollegeName"] = tool[i].Data;
                    dt.Rows.Add(row);
                    if (tool[i].Name == package.ClassCollege.ToString())
                        ClassCollege = i;
                }
                ClassCollegeCB.DataSource = dt;
                ClassCollegeCB.DisplayMember = "CollegeName";
                ClassCollegeCB.ValueMember = "CollegeCode";
                ClassCollegeCB.SelectedIndex = ClassCollege;
            }
        }
        /// <summary>
        /// 关闭/取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ClassNameBox.Text = ClassName;
            ClassIntroductBox.Text = ClassIntroduct;
            ClassGradeBox.Text = ClassGrade;
            ClassCreditBox.Text = ClassCredit;
            ClassCollegeCB.SelectedIndex = ClassCollege;
            ClassCapBox.Text = ClassCap;
        }
        /// <summary>
        /// 确认修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void OK_Button_Click(object sender, EventArgs e)
        {
            int grade = 0, cap = 0, college = 0;
            float credit = 0;
            bool f = false;
            string str = "";
            for (int i = 0; i < Tool.Length; i++)
                if (Tool[i].Name == (string)ClassCollegeCB.SelectedValue)
                {
                    str = Tool[i].Name;
                    break;
                }
            if (!int.TryParse(str, out college))
            {
                ClassCollegeCB.SelectedIndex = -1;
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
                        f = int.TryParse(ClassGradeBox.Text, out grade);
                        if (f)
                        {
                            if ("" == ClassCapBox.Text)
                                MessageBox.Show("课程容量不可为空\r\n请输入课程容量", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                f = int.TryParse(ClassCapBox.Text, out cap);
                                if (f)
                                {
                                    Tool.EditClass(ClassID.Text, credit);
                                    Tool.EditClass(ClassID.Text, cap);
                                    Tool.EditClass(ClassID.Text, ClassIntroductBox.Text);
                                    Tool.EditClass(ClassID.Text, grade, college);
                                    *Flag = true;
                                    MessageBox.Show("课程数据修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Close();
                                }
                                else
                                {
                                    ClassCapBox.Text = "";
                                    MessageBox.Show("课程容量无效\r\n请输入有效的课程容量", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                            MessageBox.Show("课程选修学期无效\r\n请输入有效的学期数", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ClassCreditBox.Text = "";
                        MessageBox.Show("课程学分无效\r\n请输入有效的学分", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

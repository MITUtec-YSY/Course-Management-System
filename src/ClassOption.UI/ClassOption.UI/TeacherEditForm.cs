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

namespace ClassOption.UI
{
    /// <summary>
    /// 教师数据修改窗体
    /// </summary>
    public partial class TeacherEditForm : Form
    {
        private ClassManageTool Tool;
        unsafe private bool* Flag;
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 教师数据修改窗体构造函数
        /// </summary>
        /// <param name="teacher_id"></param>
        /// <param name="teacher_name"></param>
        /// <param name="tool"></param>
        /// <param name="flag"></param>
        unsafe public TeacherEditForm(string teacher_id, string teacher_name, ClassManageTool tool, bool *flag)
        {
            InitializeComponent();
            TeacherID.Text = teacher_id;
            TeacherNameOld.Text = teacher_name;
            Flag = flag;
            Tool = tool;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        unsafe private void OK_Button_Click(object sender, EventArgs e)
        {
            if ("" == textBox1.Text)
                MessageBox.Show("姓名不能为空\r\n请输入姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Tool.EditTeacherName(TeacherID.Text, textBox1.Text);
                *Flag = true;
                MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
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

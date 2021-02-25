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

namespace ClassOptions
{
    /// <summary>
    /// 教师成绩更改窗口
    /// </summary>
    public partial class TeacherChangeScore : Form
    {
        private ClassManageTool Tool;   //课程管理组件
        private unsafe bool* Flag;    //修改标志（不安全的指针引用）
        private string ID;    //学生学号
        private string SN;    //学生姓名
        private string SC;    //学生课程
        private string SCORE;    //学生分数
        private bool PointFlag;
        private Point OldPoint;

        /// <summary>
        /// 教师成绩更改窗口构造函数（存在不安全的指针引用）
        /// </summary>
        /// <param name="student_id">学生学号</param>
        /// <param name="student_name">学生姓名</param>
        /// <param name="student_class">学生课程</param>
        /// <param name="score">学生分数</param>
        /// <param name="tool">课程管理组件（引用传递）</param>
        /// <param name="flag">修改标志（不安全的指针引用）</param>
        unsafe public TeacherChangeScore(string student_id, string student_name, string student_class, string score, ClassManageTool tool, bool *flag)
        {
            Tool = tool;
            Flag = flag;
            ID = student_id;
            SN = student_name;
            SC = student_class;
            SCORE = score;
            InitializeComponent();
        }
        //确定按钮（存在不安全的指针引用）
        unsafe private void OKButton_Click(object sender, EventArgs e)
        {
            if ("" != ScoreBox.Text)
            {
                float temp = 0;
                bool f = float.TryParse(ScoreBox.Text, out temp);
                if (f)
                {
                    Tool.EditScoreT(SC, ID, temp);
                    *Flag = true;
                }
            }
            Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TeacherChangeScore_Load(object sender, EventArgs e)
        {
            NameLabel.Text = SN;
            ScoreLabel.Text = SCORE;
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

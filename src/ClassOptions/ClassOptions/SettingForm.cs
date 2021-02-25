using MRsystem.Collections.MRI;
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
    /// 设置窗体
    /// </summary>
    public partial class SettingForm : Form
    {
        private string ID;

        /// <summary>
        /// 设置窗体构造函数
        /// </summary>
        /// <param name="id"></param>
        public SettingForm(string id)
        {
            ID = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("" == textBox1.Text)
                MessageBox.Show("密码不能为空\r\n请输入密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (6 < textBox1.Text.Length)
                    MessageBox.Show("密码不能长度不能小于6位数\r\n请重新输入密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        MRI mri = new MRI("bin\\ClassManageSystem.mri");
                        string path = mri.Search("RunPath", "MRIFile");
                        mri.Close();
                        mri = new MRI(path);
                        mri.ChangeVaule("E"+ID, "PassWord", textBox1.Text);
                        mri.Flush();
                        mri.Close();
                        MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("配置文件异常\r\n密码修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Close();
                    }
                }
            }
        }
    }
}

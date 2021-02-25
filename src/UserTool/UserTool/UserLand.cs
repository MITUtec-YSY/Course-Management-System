using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ClassManageSystem;
using MRsystem.Collections.MRI;

namespace UserTool
{
    public class UserLand : Form
    {
        private bool FormMouseDownFlag;
        private Point mousePoint;
        private string PathX;
        private string PathI;

        private AboutForm aboutForm;

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private TextBox UserNameBox;
        private TextBox PassWordBox;
        private Label label1;
        private Label label2;
        private Label LandButton;
        private Label HelpLabel;
        private Label AboutLabel;
        private Label label3;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLand));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.PassWordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LandButton = new System.Windows.Forms.Label();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(238)))), ((int)(((byte)(194)))));
            this.menuStrip1.BackgroundImage = global::UserTool.Properties.Resources.guanbi1;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(344, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(25, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(238)))), ((int)(((byte)(194)))));
            this.menuStrip2.BackgroundImage = global::UserTool.Properties.Resources.zuixiaohua1;
            this.menuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Location = new System.Drawing.Point(286, 10);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(25, 25);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MenuStrip2_ItemClicked);
            // 
            // UserNameBox
            // 
            this.UserNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameBox.Location = new System.Drawing.Point(98, 61);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(267, 14);
            this.UserNameBox.TabIndex = 2;
            // 
            // PassWordBox
            // 
            this.PassWordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassWordBox.Location = new System.Drawing.Point(100, 105);
            this.PassWordBox.Name = "PassWordBox";
            this.PassWordBox.PasswordChar = '*';
            this.PassWordBox.Size = new System.Drawing.Size(243, 14);
            this.PassWordBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密  码：";
            // 
            // LandButton
            // 
            this.LandButton.Image = global::UserTool.Properties.Resources.next;
            this.LandButton.Location = new System.Drawing.Point(94, 166);
            this.LandButton.Name = "LandButton";
            this.LandButton.Size = new System.Drawing.Size(207, 47);
            this.LandButton.TabIndex = 6;
            this.LandButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LandButton_MouseDown);
            // 
            // HelpLabel
            // 
            this.HelpLabel.Location = new System.Drawing.Point(311, 166);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(61, 20);
            this.HelpLabel.TabIndex = 9;
            this.HelpLabel.Text = "帮助";
            this.HelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HelpLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelpWeb);
            // 
            // AboutLabel
            // 
            this.AboutLabel.Location = new System.Drawing.Point(311, 193);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(61, 20);
            this.AboutLabel.TabIndex = 10;
            this.AboutLabel.Text = "关于";
            this.AboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AboutLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AboutButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "  ";
            // 
            // UserLand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::UserTool.Properties.Resources.land;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.LandButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassWordBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserLand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIsit用户登陆";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public UserLand(string pathx, string pathi)
        {
            PathX = pathx;
            PathI = pathi;
            InitializeComponent();
            FormMouseDownFlag = false;
            aboutForm = null;
        }

        public void CloseAbout()
        {
            aboutForm = null;
        }

        private void Landing()
        {
            LAND_REQUEST _REQUEST = ClassManageTool.Landing(UserNameBox.Text, PassWordBox.Text, PathI);
            Process process;
            ProcessStartInfo startInfo;
            string[] vs = new string[2];
            string s = "";
            switch (_REQUEST)
            {
                case LAND_REQUEST.PW_FAIL:
                    MessageBox.Show("密码输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PassWordBox.Text = "";
                    break;
                case LAND_REQUEST.UR_FAIL:
                    MessageBox.Show("用户名不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserNameBox.Text = "";
                    PassWordBox.Text = "";
                    break;
                case LAND_REQUEST.ON_CONTROL:
                    vs[0] = "control";
                    vs[1] = UserNameBox.Text;
                    s = vs[0] + " " + vs[1] + " ";
                    s = s.Trim();
                    process = new Process();
                    startInfo = new ProcessStartInfo(PathX, s);
                    process.StartInfo = startInfo;
                    process.Start();
                    Application.Exit();
                    break;
                case LAND_REQUEST.ON_STUDENT:
                    vs[0] = "student";
                    vs[1] = UserNameBox.Text;
                    s = vs[0] + " " + vs[1] + " ";
                    s = s.Trim();
                    process = new Process();
                    startInfo = new ProcessStartInfo(PathX, s);
                    process.StartInfo = startInfo;
                    process.Start();
                    Application.Exit();
                    break;
                case LAND_REQUEST.ON_TEACHER:
                    vs[0] = "teacher";
                    vs[1] = UserNameBox.Text;
                    s = vs[0] + " " + vs[1] + " ";
                    s = s.Trim();
                    process = new Process();
                    startInfo = new ProcessStartInfo(PathX, s);
                    process.StartInfo = startInfo;
                    process.Start();
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void LandButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UserNameBox.Text == "")
                {
                    MessageBox.Show("请输入用户名");
                    UserNameBox.Text = "";
                    PassWordBox.Text = "";
                }
                else if (PassWordBox.Text == "")
                {
                    MessageBox.Show("密码不能为空");
                    UserNameBox.Text = "";
                    PassWordBox.Text = "";
                }
                else
                    Landing();
            }
        }
        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Y < 40)
                {
                    //MessageBox.Show("dianji");
                    mousePoint = new Point(e.X, e.Y);
                    FormMouseDownFlag = true;
                }
            }
        }
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (FormMouseDownFlag)
            {
                Point temp = e.Location;
                int x = Location.X + temp.X - mousePoint.X;
                int y = Location.Y + temp.Y - mousePoint.Y;
                Location = new Point(x, y);
            }
        }
        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (FormMouseDownFlag)
                FormMouseDownFlag = false;
        }

        private void MenuStrip1_ItemClicked(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show(null, "是否退出登陆", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        private void MenuStrip2_ItemClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.WindowState = FormWindowState.Minimized;
        }
        private void HelpWeb(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("www.mitutec.com");
        }
        private void AboutButton_Click(object sender, MouseEventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm(this);
                aboutForm.Show();
            }
        }
    }
}

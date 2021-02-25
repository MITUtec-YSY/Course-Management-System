using AbMessage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRsystem.Collections.MRI;

namespace UserTool
{
    class MoreInfoForm : MoreInfo
    {
        private AboutForm aboutForm;

        private string RunTimeEnvir;
        private string ForSystem;
        private string WithSystem;

        private Label RunTimeLabel;
        private Label ForSystemLabel;
        private Label WithSystemLabel;
        private Label CloseLabel;

        public MoreInfoForm()
        {
            RunTimeEnvir = ForSystem = WithSystem = "";
        }

        public MoreInfoForm(AboutForm about) : this()
        {
            aboutForm = about;
            InitFileRead();
            Init(); 
        }

        private void InitFileRead()
        {
            MRI mri = new MRI("bin\\ClassManageSystem.mri");
            RunTimeEnvir = mri.Search("Runtime", "RuntimeEnvironment");
            ForSystem = mri.Search("Runtime", "ForWindows");
            WithSystem = mri.Search("Runtime", "WithWindows");
        }

        private void Init()
        {
            RunTimeLabel = new Label
            {
                Location = new Point(30, 270),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  运 行 环 境：" + RunTimeEnvir
            };
            RunTimeLabel.MouseDown += new MouseEventHandler(OpenAboutNET);
            Controls.Add(RunTimeLabel);

            ForSystemLabel = new Label
            {
                Location = new Point(30, 350),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  支 持 系 统：" + ForSystem
            };
            Controls.Add(ForSystemLabel);

            WithSystemLabel = new Label
            {
                Location = new Point(30, 430),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  兼 容 系 统：" + WithSystem
            };
            Controls.Add(WithSystemLabel);

            CloseLabel = new Label
            {
                Location = new Point(90, 490),
                Size = new Size(200, 40),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(18, 238, 194),
                Font = new Font("", 20.0F),
                Text = "关 闭",
                TextAlign = ContentAlignment.MiddleCenter
            };
            CloseLabel.MouseDown += new MouseEventHandler(CloseButton);
            Controls.Add(CloseLabel);
        }
        private void OpenAboutNET(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(@"About\NETABOUT.pdf");
        }
        private void CloseButton(object sender, MouseEventArgs e)
        {
            aboutForm.CloseMoreInfo();
            Close();
        }
    }
}

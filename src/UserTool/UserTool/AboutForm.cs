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
    class AboutForm : About
    {
        string SWName;
        string SWVersion;
        string DBVersion;
        string EVerison;

        private UserLand userLand;
        private MoreInfoForm moreInfo;

        private Label SoftWareName;
        private Label SoftWareVersion;
        private Label DataBaseVersion;
        private Label EncryptionVersion;
        private Label MoreInfoButton;

        public AboutForm()
        {
            moreInfo = null;
            menuStrip1.MouseDown += new MouseEventHandler(CloseRebuild);
            InitFileRead();
            Init();
            SWName = SWVersion = DBVersion = EVerison = "";
        }
        public AboutForm(UserLand user) : this()
        {
            userLand = user;
        }

        public void CloseMoreInfo()
        {
            moreInfo = null;
        }

        private void InitFileRead()
        {
            MRI mri = new MRI("bin\\ClassManageSystem.mri");
            SWName = mri.Search("ClassManage", "SoftWareName");
            SWVersion = mri.Search("ClassManage", "SoftWareVersion");
            DBVersion = mri.Search("ClassManage", "DataBaseVersion");
            EVerison = mri.Search("ClassManage", "EncryptionVersion");
            mri.Close();
        }

        private void Init()
        {
            SoftWareName = new Label
            {
                Location = new Point(40, 270),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  软 件 名 称：" + SWName
            };
            Controls.Add(SoftWareName);

            SoftWareVersion = new Label
            {
                Location = new Point(40, 330),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  软 件 版 本：" + SWVersion
            };
            Controls.Add(SoftWareVersion);

            DataBaseVersion = new Label
            {
                Location = new Point(40, 390),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  数据库版本：" + DBVersion
            };
            Controls.Add(DataBaseVersion);

            EncryptionVersion = new Label
            {
                Location = new Point(40, 450),
                Size = new Size(300, 20),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "  密 钥 版 本：" + EVerison
            };
            Controls.Add(EncryptionVersion);

            MoreInfoButton = new Label
            {
                Location = new Point(90, 500),
                Size = new Size(200, 40),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(18, 238, 194),
                Font = new Font("", 20.0F),
                Text = "附加信息",
                TextAlign = ContentAlignment.MiddleCenter
            };
            MoreInfoButton.MouseDown += new MouseEventHandler(MoreInfo_MouseDown);
            Controls.Add(MoreInfoButton);
        }

        private void CloseRebuild(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (userLand != null)
                    userLand.CloseAbout();
                if (moreInfo != null)
                    moreInfo.Close();
                Close();
            }
        }
        private void MoreInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (moreInfo == null)
                {
                    moreInfo = new MoreInfoForm(this);
                    moreInfo.Show();
                }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.SuspendLayout();
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.ResumeLayout(false);

        }
    }
}

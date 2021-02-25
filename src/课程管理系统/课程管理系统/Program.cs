using System;
using UserTool;
using System.Threading;
using System.Windows.Forms;
using MRsystem.Collections.MRI;

namespace 课程管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool NewFlag;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mutex mutex = new Mutex(true, "ClassManageSystem", out NewFlag);
            if (NewFlag)
            {
                string PathX = "", PathI = "";
                try
                {
                    MRI mri = new MRI("bin\\ClassManageSystem.mri");
                    PathX = mri.Search("RunPath", "RUNMain");
                    PathI = mri.Search("RunPath", "MRIFile");
                    if ("" == PathX)
                        throw new Exception();
                    if ("" == PathI)
                        throw new Exception();
                    Application.Run(new UserLand(PathX, PathI));
                    mutex.ReleaseMutex();
                }
                catch (Exception)
                {
                    MessageBox.Show("系统组件丢失，程序无法加载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(null, "程序已经启动，若要启动新程序，请结束正在运行的程序", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}

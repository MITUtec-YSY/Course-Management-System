using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManageSystem;
using MRsystem.Collections.MRI;

namespace ClassOptions
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            //arg = new string[2];
            //arg[0] = "student";
            //arg[1] = "1612480232";
            try
            {
                MRI mri = new MRI("bin\\ClassManageSystem.mri");
                ClassManageTool Tool = new ClassManageTool(mri.Search("RunPath", "MRXFile"), mri.Search("RunPath", "MRIFile"));
                if (1 < arg.Length)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    switch (arg[0].ToLower())
                    {
                        case "control":
                            Application.Run(new Control(arg[1], Tool));
                            break;
                        case "teacher":
                            Application.Run(new Teacher(arg[1], Tool));
                            break;
                        case "student":
                            Application.Run(new Student(arg[1], Tool));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("请通过启动器启动本程序");
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("程序外部资源异常\r\n程序无法启动");
                Application.Exit();
            }
            
        }
    }
}

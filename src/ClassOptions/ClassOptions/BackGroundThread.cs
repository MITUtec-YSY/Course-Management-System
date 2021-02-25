using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ClassManageSystem;

namespace ClassOptions
{
    class BackGroundThread
    {
        private ClassManageTool Tool;

        public BackGroundThread(ClassManageTool tool)
        {
            Tool = tool;
        }

        public void Run(ref bool Flag)
        {
            int i = 0;
            while (Flag)
            {
                Thread.Sleep(1000);
                i++;
                if (300 < i)
                {
                    Tool.Save();
                    i = 0;
                }
            }
        }
    }
}

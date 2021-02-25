using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件数据读取组件
    /// </summary>
    public class MRIReader : MRIbase
    {
        /// <summary>
        /// MRI文件数据读取组件构造函数
        /// </summary>
        public MRIReader() : base()
        {

        }
        /// <summary>
        /// MRI文件数据读取组件构造函数
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRIReader(string path) : base()
        {
            try
            {
                Open(path, FILE_OPEN.READ_ONLY);
            }
            catch(MRIException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 文件打开方法（如果已经打开文件 文件打开失败 | 如果未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Open(string path)
        {
            try
            {
                Open(path, FILE_OPEN.READ_ONLY);
            }
            catch (MRIException e)
            {
                throw e;
            }
        }
    }
}

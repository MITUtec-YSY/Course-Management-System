using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件数据删除组件
    /// </summary>
    public class MRIDel : MRIbase
    {
        /// <summary>
        /// MRI文件数据删除组件构造函数
        /// </summary>
        public MRIDel()
        {

        }
        /// <summary>
        /// MRI文件数据删除组件构造函数
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRIDel(string path) : base(path)
        {

        }

        /// <summary>
        /// 文件打开方法（如果已经打开文件 文件打开失败 | 如果未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Open(string path)
        {
            try
            {
                Open(path, FILE_OPEN.BOTH);
            }
            catch (MRIException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 删除指定段落的所有数据
        /// </summary>
        /// <param name="section">指定的段落</param>
        public void Del(string section)
        {
            MRILink.Del(section);
        }
        /// <summary>
        /// 删除指定段落中的指定键
        /// </summary>
        /// <param name="section">指定的段落</param>
        /// <param name="key">指定的键名</param>
        public void Del(string section, string key)
        {
            MRILink.Del(section, key);
        }
    }
}

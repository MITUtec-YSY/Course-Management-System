using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件数据添加组件
    /// </summary>
    public class MRIAdd : MRIbase
    {
        /// <summary>
        /// MRI文件数据添加组件构造函数
        /// </summary>
        public MRIAdd() : base()
        {

        }
        /// <summary>
        /// MRI文件数据添加组件构造函数
        /// </summary>
        /// <param name="path"></param>
        public MRIAdd(string path) : base(path)
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
            catch(MRIException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 向MRI文件中添加一个新的字段
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="note">注释</param>
        /// <param name="type">注释类型</param>
        public void Add(string section, string note, NoteType type)
        {
            MRILink.Add(section, note, type);
        }
        /// <summary>
        /// 向MRI文件的指定段落中添加一个新的记录
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键名</param>
        /// <param name="vaule">键值</param>
        /// <param name="note">注释</param>
        /// <param name="type">注释类型</param>
        public void Add(string section, string key, string vaule, string note, NoteType type)
        {
            MRILink.Add(section, key, vaule, note, type);
        }
    }
}

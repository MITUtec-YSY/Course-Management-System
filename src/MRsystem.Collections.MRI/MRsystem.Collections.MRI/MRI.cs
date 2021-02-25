using System;
using System.Xml;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件操作组件
    /// </summary>
    public class MRI : MRIbase
    {
        /// <summary>
        /// MRI文件操作组件构造函数
        /// </summary>
        public MRI() : base()
        {

        }
        /// <summary>
        /// MRI文件操作组件构造函数（默认以读写方式打开）
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRI(string path) : base(path)
        {

        }
        /// <summary>
        /// MRI文件操作组件构造函数
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        public MRI(string path, FILE_OPEN open) : base(path, open)
        {

        }

        /// <summary>
        /// 文件打开方法（如果构造函数已经打开文件 文件打开失败 | 如果构造函数未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        public new void Open(string path, FILE_OPEN open)
        {
            try
            {
                base.Open(path, open);
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
        /// <summary>
        /// 修改MRI文件中的段名
        /// </summary>
        /// <param name="osection">老的段名</param>
        /// <param name="nsection">新的段名</param>
        public void ChangeSection(string osection, string nsection)
        {
            MRILink.Edit(osection, nsection);
        }
        /// <summary>
        /// 修改MRI文件中的段名
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="okey">老的键名</param>
        /// <param name="nkey">新的键名</param>
        public void ChangeKey(string section, string okey, string nkey)
        {
            MRILink.Edit(section, okey, nkey, 0);
        }
        /// <summary>
        /// 修改MRI文件中的段名
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键名</param>
        /// <param name="nvaule">新的键值</param>
        public void ChangeVaule(string section, string key, string nvaule)
        {
            MRILink.Edit(section, key, nvaule, 0);
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

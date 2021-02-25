using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件数据修改组件
    /// </summary>
    public class MRIChange : MRIbase
    {
        /// <summary>
        /// MRI文件数据修改组件构造函数
        /// </summary>
        public MRIChange()
        {

        }
        /// <summary>
        /// MRI文件数据修改组件构造函数
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRIChange(string path) : base(path)
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
        public void ChangeVaule(string section, string key,string nvaule)
        {
            MRILink.Edit(section, key, nvaule, 0);
        }
    }
}
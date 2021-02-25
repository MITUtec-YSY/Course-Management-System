using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRX
{
    /// <summary>
    /// MRX文件操作组件
    /// </summary>
    public class MRX : MRXbase
    {
        /// <summary>
        /// MRX版本
        /// </summary>
        public new string Version
        {
            get { return base.Version; }
            set { base.Version = value; }
        }
        /// <summary>
        /// MRX编码
        /// </summary>
        public new string EnCode
        {
            get { return base.EnCode; }
            set { base.EnCode = value; }
        }
        /// <summary>
        /// MRX模式
        /// </summary>
        public new string Mode
        {
            get { return base.Mode; }
            set { base.Mode = value; }
        }
        /// <summary>
        /// MRX语言
        /// </summary>
        public new string Language
        {
            get { return base.Language; }
            set { base.Language = value; }
        }

        /// <summary>
        /// MRX文件操作组件构造函数
        /// </summary>
        public MRX() : base()
        {

        }
        /// <summary>
        /// MRX文件操作组件构造函数（以读写方式打开）
        /// </summary>
        public MRX(string path) : base(path)
        {

        }
        /// <summary>
        /// MRX文件操作组件构造函数
        /// </summary>
        public MRX(string path, FILE_OPEN open) : base(path, open)
        {

        }

        /// <summary>
        /// 文件打开方法（如果构造函数已经打开文件 文件打开失败 | 如果构造函数未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        public new void Open(string path, FILE_OPEN open = FILE_OPEN.BOTH)
        {
            try
            {
                base.Open(path, open);
            }
            catch (MRXException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 向指定位置添加一个目录
        /// </summary>
        /// <param name="path">位置路径</param>
        /// <param name="name">目录名</param>
        public void AddEntry(string[] path, string name)
        {
            MRXLink.Add(path, name);
        }
        /// <summary>
        /// 从指定位置删除一个目录
        /// </summary>
        /// <param name="path">位置路径</param>
        /// <param name="name">目录名</param>
        public void DelEntry(string[] path, string name)
        {
            MRXLink.Del(path, name);
        }
        /// <summary>
        /// 修改指定位置的指定目录名
        /// </summary>
        /// <param name="path">位置路径</param>
        /// <param name="name_o">当前的目录名</param>
        /// <param name="name_n">新的目录名</param>
        public void EditEntry(string[] path, string name_o, string name_n)
        {
            MRXLink.Edit(path, name_o, name_n);
        }
        /// <summary>
        /// 在指定目录添加一个键
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public void AddKey(string[] path, string key, string data, SUBKEY_TYPE type = SUBKEY_TYPE.STRING)
        {
            MRXLink.AddKey(path, key, data, type);
        }
        /// <summary>
        /// 从指定目录删除一个键
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        public void DelKey(string[] path, string key)
        {
            MRXLink.DelKey(path, key);
        }
        /// <summary>
        /// 修改指定目录中的指定键的键名
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key_o">原始的键名</param>
        /// <param name="key_n">新的键名</param>
        public void EditKey(string[] path, string key_o, string key_n)
        {
            MRXLink.EditKey(path, key_o, key_n);
        }
        /// <summary>
        /// 修改指定目录中的指定键的键类型
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <param name="type">新的键类型</param>
        public void EditKey(string[] path, string key, SUBKEY_TYPE type)
        {
            MRXLink.EditKey(path, key, type);
        }
        /// <summary>
        /// 修改指定目录中的指定键的键值
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <param name="data">新的键值</param>
        /// <param name="flag">区分标识</param>
        public void EditKey(string[] path, string key, string data, bool flag)
        {
            MRXLink.EditKey(path, key, data, flag);
        }
        /// <summary>
        /// 修改指定目录中的指定键的键值和键类型
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <param name="data">新的键值</param>
        /// <param name="type">新的键类型</param>
        public void EditKey(string[] path, string key, string data, SUBKEY_TYPE type)
        {
            MRXLink.EditKey(path, key, data, type);
        }
        /// <summary>
        /// 获取指定目录中的所有次级目录名
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>返回目录名组</returns>
        public string[] GetEntrys(string[] path)
        {
            return MRXLink.GetEntrys(path);
        }
        /// <summary>
        /// 获取指定目录中的指定键的所有键信息
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <returns>返回键数据包</returns>
        public KeyPackage GetKeyPackage(string[] path, string key)
        {
            return MRXLink.GetKey(path, key);
        }
        /// <summary>
        /// 获取指定目录中的指定键并将其转换为格式化字符串
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <param name="key">键名</param>
        /// <returns>返回格式化字符串</returns>
        public string GetString(string[] path, string key)
        {
            return MRXLink.KeyToString(path, key);
        }
        /// <summary>
        /// 获取指定目录中的所有键的所有键信息
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <returns>返回键数据包组</returns>
        public KeyPackage[] GetAllKeys(string[] path)
        {
            return MRXLink.GetKeys(path);
        }
        /// <summary>
        /// 获取指定目录中的所有键键并将其转换为格式化字符串组
        /// </summary>
        /// <param name="path">键位置路径</param>
        /// <returns>返回格式化字符串组</returns>
        public string[] GetAllStrs(string[] path)
        {
            return MRXLink.GetKeyStrs(path);
        }
        /// <summary>
        /// 获取整个记录表中的数据并格式化为字符串组
        /// </summary>
        /// <returns>返回格式化字符串组</returns>
        public string[] ToStrings()
        {
            return MRXLink.GetAllStrs(0);
        }
    }
}

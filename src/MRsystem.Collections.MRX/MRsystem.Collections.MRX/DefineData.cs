using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRX
{
    /// <summary>
    /// 键值类型
    /// </summary>
    public enum SUBKEY_TYPE
    {
        /// <summary>
        /// 整数
        /// </summary>
        INT,
        /// <summary>
        /// 二进制
        /// </summary>
        BINARY,
        /// <summary>
        /// 字符串
        /// </summary>
        STRING,

    }

    /// <summary>
    /// 功能模式类型
    /// </summary>
    public enum FUNCTION_MODE
    {
        /// <summary>
        /// 程序模式
        /// </summary>
        DTYMODE,
        /// <summary>
        /// 工具模式
        /// </summary>
        TOOLMODE,
        /// <summary>
        /// 文件模式
        /// </summary>
        FILEMODE,
        /// <summary>
        /// 自动模式
        /// </summary>
        AUTOMODE,
    }

    /// <summary>
    /// 语言模式类型
    /// </summary>
    public enum LANGUAGE_MODE
    {
        /// <summary>
        /// 中文模式
        /// </summary>
        CHINESE,
        /// <summary>
        /// 英文模式
        /// </summary>
        ENGLISH,
    }

    /// <summary>
    /// 编码类型
    /// </summary>
    public enum CODE_MODE
    {
        /// <summary>
        /// GB2312模式
        /// </summary>
        GB2312,
        /// <summary>
        /// Unicode模式
        /// </summary>
        UNICODE,
        /// <summary>
        /// UTF8模式
        /// </summary>
        UTF8,
        /// <summary>
        /// ASCⅡ码模式
        /// </summary>
        ASCII,
    }
}

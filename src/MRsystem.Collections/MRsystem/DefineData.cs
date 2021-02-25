using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections
{
    /// <summary>
    /// 文件编译类型
    /// </summary>
    public enum COMPILER
    {
        /// <summary>
        /// 米兔系统配置文件（MITU System Initialization File）
        /// </summary>
        MRI,
        /// <summary>
        /// 米兔配置文件扩展（MITU Configure File Extensible）
        /// </summary>
        MRX,
        /// <summary>
        /// 米兔可执行文件扩展[兼容Windows]（MITU Display To You Extensible Compatible）
        /// </summary>
        XYC,
        /// <summary>
        /// 米兔数据库文件（MITU DataBase File）
        /// </summary>
        MRDB,
    }

    /// <summary>
    /// 文件功能类型
    /// </summary>
    public enum FUNCTION_MODE
    {
        /// <summary>
        /// 应用程序模式
        /// </summary>
        DTY_MODE,
        /// <summary>
        /// 工具模式
        /// </summary>
        TOOL_MODE,
        /// <summary>
        /// 文件模式
        /// </summary>
        FILE_MODE,
        /// <summary>
        /// 自动模式
        /// </summary>
        AUTO_MODE,
    }

    /// <summary>
    /// 语言模式
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
    public enum ENCODE_MODE
    {
        /// <summary>
        /// 默认类型
        /// </summary>
        NORMAL,
        /// <summary>
        /// GB2312编码
        /// </summary>
        GB2312,
        /// <summary>
        /// ASCⅡ编码
        /// </summary>
        ASCII,
        /// <summary>
        /// Unicode编码
        /// </summary>
        Unicode,
        /// <summary>
        /// UTF8编码
        /// </summary>
        UTF8,
    }

    /// <summary>
    /// 值类型
    /// </summary>
    public enum KEY_TYPE
    {
        /// <summary>
        /// 字符串类型
        /// </summary>
        String,
        /// <summary>
        /// 整数类型
        /// </summary>
        Int,
        /// <summary>
        /// 二进制类型
        /// </summary>
        Binary,


    }
    /// <summary>
    /// 文件操作方式
    /// </summary>
    public enum FILE_OPEN
    {
        /// <summary>
        /// 默认模式
        /// </summary>
        NONE,
        /// <summary>
        /// 只读模式
        /// </summary>
        READ_ONLY,
        /// <summary>
        /// 读写模式
        /// </summary>
        BOTH,
    };
}

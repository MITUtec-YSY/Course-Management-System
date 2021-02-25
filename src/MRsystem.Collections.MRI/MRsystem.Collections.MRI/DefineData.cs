using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// 注释类型标志
    /// </summary>
    public enum NoteType
    {
        /// <summary>
        /// 无注释
        /// </summary>
        No_Note,
        /// <summary>
        /// 单行注释“//”
        /// </summary>
        Sing_Note,
        /// <summary>
        /// 多行注释“/* */”
        /// </summary>
        Mitl_note,
    }

    /// <summary>
    /// 文件操作错误信标
    /// </summary>
    public enum FILE_FAIL
    {
        /// <summary>
        /// 文件打开失败 文件已经打开
        /// </summary>
        OPEN_FAIL_ISOPENED,
        /// <summary>
        /// 还未打开过文件
        /// </summary>
        OPEN_NORMAL,
        /// <summary>
        /// 文件打开成功
        /// </summary>
        OPEN_SUCCESSFUL,
        /// <summary>
        /// 文件保存成功
        /// </summary>
        SAVE_SUCCESSFUL,
    }

    internal class DefineData
    {
        public static string MRIname = "MR Initialization File";
        public static string MRIversion = "version = 1.0.0.1";

        public static int OPEN_FAIL_ISOPENED = -1;
        public static int OPEN_NORMAL = 0;
        public static int OPEN_SUCCESSFUL = 1;

        public static int SAVE_SUCCESSFUL = 1;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件处理异常类
    /// </summary>
    public class MRIException : SystemException
    {
        /// <summary>
        /// 指示错误的字符串
        /// </summary>
        public string Error;

        /// <summary>
        /// MRI文件处理异常类构造函数
        /// </summary>
        /// <param name="error">错误内容</param>
        public MRIException(string error) : base()
        {
            Error = error;
        }

        /// <summary>
        /// 读取错误
        /// </summary>
        /// <returns>返回错误内容</returns>
        public string GetError()
        {
            return Error;
        }
    }
}

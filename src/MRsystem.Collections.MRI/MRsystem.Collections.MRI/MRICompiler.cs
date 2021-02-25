using System;
using System.IO;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件编译组件
    /// </summary>
    public class MRICompiler : MRIbase
    {
        private string CompilerString;  //编译文件路径
        private COMPILER COMPILER;   //文件编译类型

        /// <summary>
        /// MRI文件编译组件构造函数
        /// </summary>
        public MRICompiler() : base()
        {
            CompilerString = "";
            COMPILER = COMPILER.MRI;
        }
        /// <summary>
        /// MRI文件编译组件构造函数
        /// </summary>
        /// <param name="path">输出文件路径</param>
        public MRICompiler(string path) : base()
        {
            COMPILER = COMPILER.MRI;
            CompilerString = "";
            string[] str = path.Split('.');
            for (int i = 0; i < str.Length - 1; i++)
                CompilerString += str[i];
            CompilerString += "." + COMPILER.ToString();
        }
        /// <summary>
        /// MRI文件编译组件构造函数
        /// </summary>
        /// <param name="path">输出文件路径</param>
        /// <param name="type">输出文件类型</param>
        public MRICompiler(string path, COMPILER type) : base()
        {
            COMPILER = type;
            CompilerString = "";
            string[] str = path.Split('.');
            for (int i = 0; i < str.Length - 1; i++)
                CompilerString += str[i];
            CompilerString += "." + COMPILER.ToString();
        }

        /// <summary>
        /// 打开文件并将文件数据读取至字符串数组中
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回打开的字符串数组</returns>
        public string[] Open(string path)
        {
            string[] vs = null;
            try
            {
                StreamReader = new StreamReader(path);
                StringLink link = new StringLink();
                while (!StreamReader.EndOfStream)
                {
                    string s = StreamReader.ReadLine();
                    link.Add(s);
                }
                vs = link.Read();
            }
            catch(System.Exception e)
            {
                throw new MRIException("文件打开错误：\r\n" + e.ToString());
            }
            return vs;
        }
        /// <summary>
        /// 将MRI文件编译成指定类型并写入文件（输出为默认文件类型和默认路径）
        /// </summary>
        /// <param name="source">编译源数据</param>
        public void Compiler(string[] source)
        {
            try
            {
                Compiler(source, CompilerString, COMPILER);
            }
            catch (MRIException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 将MRI文件编译成指定类型并写入指定文件（输出为默认文件类型）
        /// </summary>
        /// <param name="path">编译后的文件路径（如果路径为空则编译到源文件目录）</param>
        /// <param name="source">编译源数据</param>
        public void Compiler(string[] source, string path)
        {
            try
            {
                Compiler(source, path, COMPILER);
            }
            catch(MRIException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 将MRI文件编译成指定类型并写入指定文件和指定类型
        /// </summary>
        /// <param name="path">编译后的文件路径（如果路径为空则编译到源文件目录）</param>
        /// <param name="type">编译类型</param>
        /// <param name="source">编译源数据</param>
        public void Compiler(string[] source, string path, COMPILER type)
        {
            if (null == path || "" == path || string.Empty == path)
                throw new MRIException("不能编译到未知的文件");
            switch (type)
            {
                case COMPILER.MRI:
                    try
                    {
                        Read(source);
                        ToMRI(path);
                    }
                    catch (MRIException e)
                    {
                        throw e;
                    }
                    break;
                case COMPILER.MRX:
                    try
                    {
                        Read(source);
                        ToMRX(path);
                    }
                    catch (MRIException e)
                    {
                        throw e;
                    }
                    break;
                case COMPILER.XYC:
                    try
                    {
                        Read(source);
                        ToXYC(path);
                    }
                    catch (MRIException e)
                    {
                        throw e;
                    }
                    break;
                case COMPILER.MRDB:
                    try
                    {
                        Read(source);
                        ToMRDB(path);
                    }
                    catch (MRIException e)
                    {
                        throw e;
                    }
                    break;
                default:
                    throw new MRIException("不能编译文件到未知的类型");
            }
            MRILink.Clean();
        }

        /// <summary>
        /// 销毁MRI文件编译组件的所有使用资源
        /// </summary>
        public new void Destroy()
        {
            GC.Collect();
        }

        /// <summary>
        /// MRI语法检测方法
        /// </summary>
        /// <param name="source">检测源数据</param>
        /// <returns>返回检测结果</returns>
        public static string MRICheck(string[] source)
        {
            string Result = NO_ERROR;

            int Line = 1;    //行数指示器
            int Index = 0;    //数组指示器

            bool HaveSection = false;   //段落之前的数据
            bool Flag = true;    //循环标志

            bool IsSingle = false;    //进入单行注释
            bool IsMulit = false;    //进入多行注释
            bool IsSection = false;   //进入段落数据标志
            bool IsKey = false;    //进入键数据标志
            bool IsEnvaule = false;   //准备进入数据
            bool IsVaule = false;    //进入值数据标志

            CharStack SignStack = new CharStack();   //符号堆栈
            CharStack CodeStack = new CharStack();   //代码堆栈

            string Error = string.Empty;   //错误代码

            char ch = '\0';

            if (null != source)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    for (int j = 0; j < source[i].Length; j++)
                        CodeStack.Push(source[i][j]);
                    if (i < source.Length - 1)
                        CodeStack.Push('\n');
                }
                string reader = CodeStack.Read();
                CodeStack.Clean();
                while (reader.Length > Index && Flag)
                {
                    ch = reader[Index++];  //获取一个字符
                    if (IsSingle)    //单行注释中
                    {
                        while ('\n' != ch && reader.Length > Index)
                        {
                            CodeStack.Push(ch);
                            ch = reader[Index++];   //获取一个字符
                        }
                        CodeStack.Clean();
                        Line++;
                        IsSingle = false;
                    }
                    else if (IsMulit)
                    {
                        switch (ch)
                        {
                            case '\n':
                                CodeStack.Push(ch);
                                Line++;
                                break;
                            case '*':
                                if (0 == SignStack.Count)
                                    SignStack.Push(ch);
                                else if ('*' == SignStack.Peek())
                                    CodeStack.Push(ch);
                                break;
                            case '/':
                                if (0 != SignStack.Count)
                                {
                                    if ('*' == SignStack.Peek())
                                    {
                                        SignStack.Clean();
                                        CodeStack.Clean();
                                        IsMulit = false;
                                    }
                                }
                                else
                                    CodeStack.Push(ch);
                                break;
                            default:
                                CodeStack.Push(ch);
                                break;
                        }
                    }
                    else if (!HaveSection)
                    {
                        if (IsSection)  //在段落中
                        {
                            if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                                CodeStack.Push(ch);
                            else if ('0' <= ch && '9' >= ch)   //如果是数字
                            {
                                if (0 != CodeStack.Count)    //如果数字不为开头
                                    CodeStack.Push(ch);   //数据入栈
                                else   //数据开头，报错
                                {
                                    Flag = false;
                                    Error = ERROR_SIGN;
                                }
                            }
                            else if (']' == ch)    //如果为段落结束符号‘]’
                            {
                                if (0 == CodeStack.Count)   //如果数据堆栈中数据为空，报错
                                {
                                    Flag = false;
                                    Error = ERROR_EMPTY;
                                }
                                else if ('[' == SignStack.Peek())  //数据堆栈中数据不为空
                                {
                                    SignStack.Pop();
                                    CodeStack.Clean();
                                    IsSection = false;
                                    HaveSection = true;

                                }
                            }
                            else
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else   //没有在段落中
                        {
                            switch (ch)
                            {
                                case '[':
                                    SignStack.Push(ch);
                                    IsSection = true;
                                    break;
                                case '/':
                                    if (0 == SignStack.Count)
                                        SignStack.Push(ch);
                                    else
                                    {
                                        if ('/' == SignStack.Peek())
                                        {
                                            IsSingle = true;
                                            SignStack.Pop();
                                        }
                                        else if ('[' == SignStack.Peek())
                                        {
                                            Flag = false;
                                            Error = ERROR_SIGN;
                                        }
                                    }
                                    break;
                                case '*':
                                    if (0 == SignStack.Count)
                                    {
                                        Flag = false;
                                        Error = ERROR_SIGN;
                                    }
                                    else
                                    {
                                        if ('/' == SignStack.Peek())
                                        {
                                            IsMulit = true;
                                            SignStack.Pop();
                                        }
                                        else
                                        {
                                            Flag = false;
                                            Error = ERROR_SIGN;
                                        }
                                    }
                                    break;
                                case '\n':
                                    Line++;
                                    break;
                                case '\r':
                                    break;
                                case ' ':
                                    break;
                                default:
                                    Flag = false;
                                    Error = ERROR_HEAD;
                                    break;
                            }
                        }
                    }
                    else if (IsSection)
                    {
                        if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                            CodeStack.Push(ch);
                        else if ('0' <= ch && '9' >= ch)   //如果是数字
                        {
                            if (0 != CodeStack.Count)    //如果数字不为开头
                                CodeStack.Push(ch);   //数据入栈
                            else   //数据开头，报错
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else if (']' == ch)    //如果为段落结束符号‘]’
                        {
                            if (0 == CodeStack.Count)   //如果数据堆栈中数据为空，报错
                            {
                                Flag = false;
                                Error = ERROR_EMPTY;
                            }
                            else if ('[' == SignStack.Peek())  //数据堆栈中数据不为空
                            {
                                SignStack.Pop();
                                CodeStack.Clean();
                                IsSection = false;
                                HaveSection = true;
                            }
                        }
                        else
                        {
                            Flag = false;
                            Error = ERROR_SIGN;
                        }
                    }
                    else if (IsKey)
                    {
                        if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)   //如果是字母和下划线，直接入栈
                            CodeStack.Push(ch);
                        else if ('0' <= ch && '9' >= ch)   //如果是数字
                        {
                            if (0 != CodeStack.Count)   //如果数字不为开头
                                CodeStack.Push(ch);   //数据入栈
                            else   //数据开头，报错
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else if ('=' == ch)    //如果为键结束符号‘=’
                        {
                            CodeStack.Clean();
                            IsKey = false;
                            IsEnvaule = true;
                        }
                        else if (' ' == ch)   //如果符号为空格
                        {
                            while (' ' == ch)    //清除
                                ch = reader[Index++];
                            if ('=' == ch)    //检查空格后数据是否为结束符
                            {
                                CodeStack.Clean();
                                IsKey = false;
                                IsEnvaule = true;
                            }
                            else   //空格后非结束符，符号错误
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                    }
                    else if (IsEnvaule)
                    {
                        while (' ' == ch)
                            ch = reader[Index++];
                        if ('\"' == ch)
                        {
                            SignStack.Push(ch);
                            IsVaule = true;
                            IsEnvaule = false;
                        }
                        else
                        {
                            Flag = false;
                            Error = ERROR_VAULE;
                        }
                    }
                    else if (IsVaule)
                    {
                        switch (ch)
                        {
                            case '\\':
                                if ('\\' == SignStack.Peek())   //如果符号栈顶元素为转义符号，则将符号栈顶元素移除，将转义字符作为字符写入数据
                                {
                                    SignStack.Pop();
                                    CodeStack.Push(ch);
                                }
                                else
                                    SignStack.Push(ch);
                                break;
                            case '\"':
                                if ('\\' == SignStack.Peek())   //如果符号栈顶元素为转义符号，则将符号栈顶元素移除，将双引号作为字符写入数据
                                {
                                    SignStack.Pop();
                                    CodeStack.Push(ch);
                                }
                                else if ('\"' == SignStack.Peek())   //如果符号栈顶元素为双引号，则值结束
                                {
                                    SignStack.Pop();
                                    CodeStack.Clean();
                                    IsVaule = false;
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                break;
                            case '\n':
                                Flag = false;
                                Error = ERROR_END;
                                break;
                            case ' ':
                                if ('\\' == SignStack.Peek())
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                else
                                    CodeStack.Push(ch);
                                break;
                            default:
                                CodeStack.Push(ch);
                                break;
                        }
                    }
                    else
                    {
                        switch (ch)
                        {
                            case '/':
                                if ('/' == SignStack.Peek())
                                {
                                    SignStack.Pop();
                                    IsSingle = true;
                                }
                                else
                                    SignStack.Push(ch);
                                break;
                            case '[':
                                if ('/' == SignStack.Peek())
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                else
                                {
                                    SignStack.Push(ch);
                                    IsSection = true;
                                }
                                break;
                            case '*':
                                if ('/' == SignStack.Peek())
                                {
                                    SignStack.Pop();
                                    IsMulit = true;
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_SIGN;
                                }
                                break;
                            case ' ':
                                if (0 != SignStack.Count)
                                {
                                    if ('/' == SignStack.Peek())
                                    {
                                        Flag = false;
                                        Error = ERROR_COMP;
                                    }
                                }
                                break;
                            case '\n':
                                Line++;
                                break;
                            case '\r':
                                break;
                            default:
                                if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                                {
                                    if ('/' == SignStack.Peek())
                                    {
                                        Flag = false;
                                        Error = ERROR_UNEXP;
                                    }
                                    else
                                    {
                                        IsKey = true;
                                        CodeStack.Push(ch);
                                    }
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                break;
                        }
                    }
                }

                if (Flag)
                {
                    if (0 != CodeStack.Count || 0 != SignStack.Count)
                        Result = "语法检测出现错误：\r\n\r\n         错误代码：  " + ERROR_END + "\r\n\r\n         错误位置：  第 " + Line + " 行";
                    else if (IsMulit || IsSection || IsKey || IsEnvaule || IsVaule)
                        Result = "语法检测出现错误：\r\n\r\n         错误代码：  " + ERROR_END + "\r\n\r\n         错误位置：  第 " + Line + " 行";
                }
                else
                    Result = "语法检测出现错误：\r\n\r\n         错误代码：  " + Error + "\r\n\r\n         错误位置：  第 " + Line + " 行";
            }
            else
                Result = "语法检测失败：程序错误";
            return Result;
        }

        /*隐藏的父类方法*/
        private new void Flush(bool Type = false) { }
        private new void Flush(string path, bool Type = false) { }
        private new string[] MRIRead() { return null; }
        private new string[] MRIRead(bool flag) { return null; }
        private new string[] GetSections() { return null; }
        private new string[] GetKeys(string section) { return null; }
        private new string Search(string section, string key) { return null; }
    
        private void Read(string[] source)
        {
            MRILink.Clean();
            int Line = 1;    //行数指示器
            int Index = 0;    //数组指示器

            bool HaveSection = false;   //段落之前的数据
            bool Flag = true;    //循环标志

            bool IsSingle = false;    //进入单行注释
            bool IsMulit = false;    //进入多行注释
            bool IsSection = false;   //进入段落数据标志
            bool IsKey = false;    //进入键数据标志
            bool IsEnvaule = false;   //准备进入数据
            bool IsVaule = false;    //进入值数据标志

            CharStack SignStack = new CharStack();   //符号堆栈
            CharStack CodeStack = new CharStack();   //代码堆栈

            string Section = string.Empty;   //段落名
            string Key = string.Empty;    //键名
            string Vaule = string.Empty;   //键值
            string Note = string.Empty;    //注释

            string Error = string.Empty;   //错误代码

            char ch = '\0';

            if (null != source)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    for (int j = 0; j < source[i].Length; j++)
                        CodeStack.Push(source[i][j]);
                    if (i < source.Length - 1)
                        CodeStack.Push('\n');
                }
                string reader = CodeStack.Read();
                CodeStack.Clean();
                while (reader.Length > Index && Flag)
                {

                    ch = reader[Index++];  //获取一个字符
                    if (IsSingle)    //单行注释中
                    {
                        while ('\n' != ch && reader.Length > Index)
                        {
                            CodeStack.Push(ch);
                            ch = reader[Index++];  //获取一个字符
                        }
                        Note = CodeStack.Read();
                        CodeStack.Clean();
                        MRILink.Add(Section, Key, Vaule, Note, NoteType.Sing_Note);
                        Key = string.Empty;
                        Vaule = string.Empty;
                        Note = string.Empty;
                        Line++;
                        IsSingle = false;
                    }
                    else if (IsMulit)
                    {
                        switch (ch)
                        {
                            case '\n':
                                CodeStack.Push(ch);
                                Line++;
                                break;
                            case '*':
                                if (0 == SignStack.Count)
                                    SignStack.Push(ch);
                                else if ('*' == SignStack.Peek())
                                    CodeStack.Push(ch);
                                break;
                            case '/':
                                if (0 != SignStack.Count)
                                {
                                    if ('*' == SignStack.Peek())
                                    {
                                        SignStack.Clean();
                                        Note = CodeStack.Read();
                                        CodeStack.Clean();
                                        MRILink.Add(Section, Key, Vaule, Note, NoteType.Mitl_note);
                                        Key = string.Empty;
                                        Vaule = string.Empty;
                                        Note = string.Empty;
                                        IsMulit = false;
                                    }
                                }
                                else
                                    CodeStack.Push(ch);
                                break;
                            default:
                                CodeStack.Push(ch);
                                break;
                        }
                    }
                    else if (!HaveSection)
                    {
                        if (IsSection)  //在段落中
                        {
                            if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                                CodeStack.Push(ch);
                            else if ('0' <= ch && '9' >= ch)   //如果是数字
                            {
                                if (0 != CodeStack.Count)    //如果数字不为开头
                                    CodeStack.Push(ch);   //数据入栈
                                else   //数据开头，报错
                                {
                                    Flag = false;
                                    Error = ERROR_SIGN;
                                }
                            }
                            else if (']' == ch)    //如果为段落结束符号‘]’
                            {
                                if (0 == CodeStack.Count)   //如果数据堆栈中数据为空，报错
                                {
                                    Flag = false;
                                    Error = ERROR_EMPTY;
                                }
                                else if ('[' == SignStack.Peek())  //数据堆栈中数据不为空
                                {
                                    SignStack.Pop();
                                    Section = CodeStack.Read();
                                    CodeStack.Clean();
                                    IsSection = false;
                                    HaveSection = true;

                                }
                            }
                            else
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else   //没有在段落中
                        {
                            switch (ch)
                            {
                                case '[':
                                    SignStack.Push(ch);
                                    IsSection = true;
                                    break;
                                case '/':
                                    if (0 == SignStack.Count)
                                        SignStack.Push(ch);
                                    else
                                    {
                                        if ('/' == SignStack.Peek())
                                        {
                                            IsSingle = true;
                                            SignStack.Pop();
                                        }
                                        else if ('[' == SignStack.Peek())
                                        {
                                            Flag = false;
                                            Error = ERROR_SIGN;
                                        }
                                    }
                                    break;
                                case '*':
                                    if (0 == SignStack.Count)
                                    {
                                        Flag = false;
                                        Error = ERROR_SIGN;
                                    }
                                    else
                                    {
                                        if ('/' == SignStack.Peek())
                                        {
                                            IsMulit = true;
                                            SignStack.Pop();
                                        }
                                        else
                                        {
                                            Flag = false;
                                            Error = ERROR_SIGN;
                                        }
                                    }
                                    break;
                                case '\n':
                                    Line++;
                                    break;
                                case '\r':
                                    break;
                                case ' ':
                                    break;
                                default:
                                    Flag = false;
                                    Error = ERROR_HEAD;
                                    break;
                            }
                        }
                    }
                    else if (IsSection)
                    {
                        if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                            CodeStack.Push(ch);
                        else if ('0' <= ch && '9' >= ch)   //如果是数字
                        {
                            if (0 != CodeStack.Count)    //如果数字不为开头
                                CodeStack.Push(ch);   //数据入栈
                            else   //数据开头，报错
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else if (']' == ch)    //如果为段落结束符号‘]’
                        {
                            if (0 == CodeStack.Count)   //如果数据堆栈中数据为空，报错
                            {
                                Flag = false;
                                Error = ERROR_EMPTY;
                            }
                            else if ('[' == SignStack.Peek())  //数据堆栈中数据不为空
                            {
                                SignStack.Pop();
                                Section = CodeStack.Read();
                                CodeStack.Clean();
                                IsSection = false;
                                HaveSection = true;
                            }
                        }
                        else
                        {
                            Flag = false;
                            Error = ERROR_SIGN;
                        }
                    }
                    else if (IsKey)
                    {
                        if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)   //如果是字母和下划线，直接入栈
                            CodeStack.Push(ch);
                        else if ('0' <= ch && '9' >= ch)   //如果是数字
                        {
                            if (0 != CodeStack.Count)   //如果数字不为开头
                                CodeStack.Push(ch);   //数据入栈
                            else   //数据开头，报错
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                        else if ('=' == ch)    //如果为键结束符号‘=’
                        {
                            Key = CodeStack.Read();
                            CodeStack.Clean();
                            IsKey = false;
                            IsEnvaule = true;
                        }
                        else if (' ' == ch)   //如果符号为空格
                        {
                            while (' ' == ch)    //清除
                                ch = reader[Index++];
                            if ('=' == ch)    //检查空格后数据是否为结束符
                            {
                                Key = CodeStack.Read();
                                CodeStack.Clean();
                                IsKey = false;
                                IsEnvaule = true;
                            }
                            else   //空格后非结束符，符号错误
                            {
                                Flag = false;
                                Error = ERROR_SIGN;
                            }
                        }
                    }
                    else if (IsEnvaule)
                    {
                        while (' ' == ch)
                            ch = reader[Index++];
                        if ('\"' == ch)
                        {
                            SignStack.Push(ch);
                            IsVaule = true;
                            IsEnvaule = false;
                        }
                        else
                        {
                            Flag = false;
                            Error = ERROR_VAULE;
                        }
                    }
                    else if (IsVaule)
                    {
                        switch (ch)
                        {
                            case '\\':
                                if ('\\' == SignStack.Peek())   //如果符号栈顶元素为转义符号，则将符号栈顶元素移除，将转义字符作为字符写入数据
                                {
                                    SignStack.Pop();
                                    CodeStack.Push(ch);
                                }
                                else
                                    SignStack.Push(ch);
                                break;
                            case '\"':
                                if ('\\' == SignStack.Peek())   //如果符号栈顶元素为转义符号，则将符号栈顶元素移除，将双引号作为字符写入数据
                                {
                                    SignStack.Pop();
                                    CodeStack.Push(ch);
                                }
                                else if ('\"' == SignStack.Peek())   //如果符号栈顶元素为双引号，则值结束
                                {
                                    Vaule = CodeStack.Read();
                                    SignStack.Pop();
                                    CodeStack.Clean();
                                    IsVaule = false;
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                break;
                            case '\n':
                                Flag = false;
                                Error = ERROR_END;
                                break;
                            case ' ':
                                if ('\\' == SignStack.Peek())
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                else
                                    CodeStack.Push(ch);
                                break;
                            default:
                                CodeStack.Push(ch);
                                break;
                        }
                    }
                    else
                    {
                        switch (ch)
                        {
                            case '/':
                                if ('/' == SignStack.Peek())
                                {
                                    SignStack.Pop();
                                    IsSingle = true;
                                }
                                else
                                    SignStack.Push(ch);
                                break;
                            case '[':
                                if ('/' == SignStack.Peek())
                                {
                                    Flag = false;
                                    Error = ERROR_UNEXP;
                                }
                                else
                                {
                                    SignStack.Push(ch);
                                    IsSection = true;
                                    Section = string.Empty;
                                    Key = string.Empty;
                                    Vaule = string.Empty;
                                    Note = string.Empty;
                                }
                                break;
                            case '*':
                                if ('/' == SignStack.Peek())
                                {
                                    SignStack.Pop();
                                    IsMulit = true;
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_SIGN;
                                }
                                break;
                            case ' ':
                                if (0 != SignStack.Count)
                                {
                                    if ('/' == SignStack.Peek())
                                    {
                                        Flag = false;
                                        Error = ERROR_COMP;
                                    }
                                }
                                break;
                            case '\n':
                                if (string.Empty != Section)
                                {
                                    if (string.Empty != Key && string.Empty != Vaule)
                                    {
                                        MRILink.Add(Section, Key, Vaule, string.Empty, NoteType.No_Note);
                                        Key = string.Empty;
                                        Vaule = string.Empty;
                                        Note = string.Empty;
                                    }
                                    else
                                    {
                                        MRILink.Add(Section, string.Empty, NoteType.No_Note);
                                        Key = string.Empty;
                                        Vaule = string.Empty;
                                        Note = string.Empty;
                                    }
                                }
                                Line++;
                                break;
                            case '\r':
                                break;
                            default:
                                if ('A' <= ch && 'Z' >= ch || 'a' <= ch && 'z' >= ch || '_' == ch)
                                {
                                    if ('/' == SignStack.Peek())
                                    {
                                        Flag = false;
                                        Error = ERROR_UNEXP;
                                    }
                                    else
                                    {
                                        IsKey = true;
                                        CodeStack.Push(ch);
                                    }
                                }
                                else
                                {
                                    Flag = false;
                                    Error = ERROR_END;
                                }
                                break;
                        }
                    }
                }
                if (string.Empty != Key)
                    MRILink.Add(Section, Key, Vaule, string.Empty, NoteType.No_Note);
                if (Flag)
                {
                    if (0 != CodeStack.Count || 0 != SignStack.Count)
                    {
                        MRILink.Clean();
                        throw new MRIException("文件读取错误：\r\n\r\n         错误代码：  " + ERROR_END + "\r\n\r\n         错误位置：  第 " + Line + " 行");
                    }
                    else if (IsMulit || IsSection || IsKey || IsEnvaule || IsVaule)
                    {
                        MRILink.Clean();
                        throw new MRIException("文件读取错误：\r\n\r\n         错误代码：  " + ERROR_END + "\r\n\r\n         错误位置：  第 " + Line + " 行");
                    }
                }
                else
                {
                    MRILink.Clean();
                    throw new MRIException("文件读取错误：\r\n\r\n         错误代码：  " + Error + "\r\n\r\n         错误位置：  第 " + Line + " 行");
                }
            }
            else
                throw new MRIException("文件读取失败：程序错误");
        }   
        private void ToMRI(string path)
        {
            string[] vs = MRILink.Read(true);
            if (null != vs)
            {
                try
                {
                    FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Close();
                    fileStream.Dispose();
                    StreamWriter = new StreamWriter(path);
                    for (int i = 0; i < vs.Length; i++)
                        StreamWriter.WriteLine(vs[i]);
                    StreamWriter.Flush();
                    StreamWriter.Close();
                    StreamWriter.Dispose();
                }
                catch (System.Exception e)
                {
                    throw new MRIException("文件写入失败：" + e.ToString());
                }
            }
        }
        private void ToMRX(string path)
        {
            StringLink link = new StringLink();
            link.Add("<!mrx " + DefineData.MRIversion + " encode = \"auto\" mode = \"automode\" lang = \"English\"/!>");
            link.Add("<MRX>");
            link.Add("");
            string[] Sections = MRILink.GetSections();
            if (null != Sections)
            {
                for(int i = 0; i < Sections.Length; i++)
                {
                    link.Add("  " + "<Entry name = \"" + Sections[i] + "\" >");
                    string[] Keys = MRILink.GetKeys(Sections[i]);
                    if (null != Keys)
                    {
                        for(int j = 0; j < Keys.Length; j++)
                            link.Add("      " + "<Subkey name = \"" + Keys[j] + "\">" + MRILink.Find(Sections[i], Keys[j]) + "</Key>");
                    }
                    link.Add("  " + "</Entry>");
                    link.Add("");
                }
            }
            link.Add("</MRX>");
            string[] vs = link.Read();
            if (null != vs)
            {
                try
                {
                    FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Close();
                    fileStream.Dispose();
                    StreamWriter = new StreamWriter(path);
                    for (int i = 0; i < vs.Length; i++)
                        StreamWriter.WriteLine(vs[i]);
                    StreamWriter.Flush();
                    StreamWriter.Close();
                    StreamWriter.Dispose();
                }
                catch (System.Exception e)
                {
                    throw new MRIException("文件写入失败：" + e.ToString());
                }
            }
        }
        private void ToXYC(string path)
        {

        }
        private void ToMRDB(string path)
        {

        }
    }
}

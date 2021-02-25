using System;
using System.Collections.Generic;
using System.Text;
using MRsystem.Collections;
using MRsystem.Exception;
using System.IO;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI文件操作基类（抽象类-已完成所有基本功能实现 可直接继承后使用）
    /// </summary>
    abstract public class MRIbase
    {
        /// <summary>
        /// 文件不可解析
        /// </summary>
        public static string ERROR_HEAD = "文件不可解析";
        /// <summary>
        /// 文件中存在不应该存在此处的错误字符
        /// </summary>
        public static string ERROR_SIGN = "文件中存在不应该存在此处的错误字符";
        /// <summary>
        /// 文件中存在不匹配的符号
        /// </summary>
        public static string ERROR_COMP = "文件中存在不匹配的符号";
        /// <summary>
        /// 文件中没有查询到可以用于结束的边界
        /// </summary>
        public static string ERROR_END = "文件中没有查询到可以用于结束的边界";
        /// <summary>
        /// 文件中存在异常的空数据字段
        /// </summary>
        public static string ERROR_EMPTY = "文件中存在异常的空数据字段";
        /// <summary>
        /// 文件中存在错误的值类型
        /// </summary>
        public static string ERROR_VAULE = "文件中存在错误的值类型";
        /// <summary>
        /// 文件中存在预料之外的字符
        /// </summary>
        public static string ERROR_UNEXP = "文件中存在预料之外的字符";
        /// <summary>
        /// 文件打开错误
        /// </summary>
        public static string ERROR_OPEN = "文件打开错误";
        /// <summary>
        /// 无错误
        /// </summary>
        public static string NO_ERROR = "无错误";


        /// <summary>
        /// MRI文件数据结构化储存器
        /// </summary>
        protected MRILink MRILink;
        /// <summary>
        /// MRI文件路径
        /// </summary>
        protected string Path { get; private set; }
        /// <summary>
        /// 文件操作方式
        /// </summary>
        protected FILE_OPEN FILE_OPEN;
        /// <summary>
        /// 文件读取器
        /// </summary>
        protected StreamReader StreamReader;
        /// <summary>
        /// 文件写入器
        /// </summary>
        protected StreamWriter StreamWriter;
        /// <summary>
        /// 文件打开标志
        /// </summary>
        protected bool OPENFLAG;

        /// <summary>
        /// MRI文件操作基类构造函数（未打开文件）
        /// </summary>
        public MRIbase()
        {
            MRILink = new MRILink();
            Path = "";
            FILE_OPEN = FILE_OPEN.NONE;
            StreamReader = null;
            StreamWriter = null;
            OPENFLAG = false;
        }
        /// <summary>
        /// MRI文件操作基类构造函数（默认以读写模式打开）
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRIbase(string path) : this(path, FILE_OPEN.BOTH)
        {

        }
        /// <summary>
        /// MRI文件操作基类构造函数（打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        public MRIbase(string path, FILE_OPEN open) : this()
        {
            try
            {
                Open(path, open);
            }
            catch(MRIException e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// 刷新文件操作流以写入到文件
        /// </summary>
        /// <param name="Type">写入方式（true：写入无注释数据 | false：写入有注释数据）</param>
        /// <returns>返回写入结果</returns>
        public void Flush(bool Type = false)
        {
            if (FILE_OPEN.BOTH == FILE_OPEN)
            {
                try
                {
                    string[] vs = null;
                    if (Type)
                    {
                        vs = MRILink.Read(true);
                        if (null != vs)
                        {
                            FileStream fileStream = File.Open(Path, FileMode.Create, FileAccess.ReadWrite);
                            fileStream.Close();
                            fileStream.Dispose();
                            StreamWriter = new StreamWriter(Path, false, Encoding.Default);
                            for (int i = 0; i < vs.Length; i++)
                                StreamWriter.WriteLine(vs[i]);
                            StreamWriter.Flush();
                            StreamWriter.Close();
                            StreamWriter.Dispose();
                        }
                    }
                    else
                    {
                        vs = MRILink.Read();
                        if (null != vs)
                        {
                            FileStream fileStream = File.Open(Path, FileMode.Create, FileAccess.ReadWrite);
                            fileStream.Close();
                            fileStream.Dispose();
                            StreamWriter = new StreamWriter(Path, false, Encoding.Default);
                            for (int i = 0; i < vs.Length; i++)
                                StreamWriter.WriteLine(vs[i]);
                            StreamWriter.Flush();
                            StreamWriter.Close();
                            StreamWriter.Dispose();
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw new MRIException("文件写入失败：" + e.ToString());
                }
            }
            else
                throw new MRIException("文件不可写入");
        }
        /// <summary>
        /// 刷新文件操作流以写入到新文件
        /// </summary>
        /// <param name="path">新文件路径</param>
        /// <param name="Type">写入方式（true：写入无注释数据 | false：写入有注释数据）</param>
        /// <returns>返回写入结果</returns>
        public void Flush(string path, bool Type = false)
        {
            try
            {
                string[] vs = null;
                if (Type)
                {
                    vs = MRILink.Read(true);
                    if (null != vs)
                    {
                        FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
                        fileStream.Close();
                        fileStream.Dispose();
                        StreamWriter = new StreamWriter(path, false, Encoding.Default);
                        for (int i = 0; i < vs.Length; i++)
                            StreamWriter.WriteLine(vs[i]);
                        StreamWriter.Flush();
                        StreamWriter.Close();
                        StreamWriter.Dispose();
                    }
                }
                else
                {
                    vs = MRILink.Read();
                    if (null != vs)
                    {
                        FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
                        fileStream.Close();
                        fileStream.Dispose();
                        StreamWriter = new StreamWriter(path, false, Encoding.Default);
                        for (int i = 0; i < vs.Length; i++)
                            StreamWriter.WriteLine(vs[i]);
                        StreamWriter.Flush();
                        StreamWriter.Close();
                        StreamWriter.Dispose();
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new MRIException("文件写入失败：" + e.ToString());
            }
        }
        /// <summary>
        /// MRI文件操作流关闭
        /// </summary>
        public void Close()
        {
            MRILink.Clean();
            Path = string.Empty;
            FILE_OPEN = FILE_OPEN.NONE;
            StreamReader.Dispose();
            OPENFLAG = false;
        }
        /// <summary>
        /// 销毁MRI文件操作基类的所有使用资源
        /// </summary>
        public void Destroy()
        {
            Close();
            MRILink.Destroy();
            GC.Collect();
        }

        /// <summary>
        /// 输出文件中读取的格式化后的数据
        /// </summary>
        /// <returns>格式化数据</returns>
        public string[] MRIRead()
        {
            return MRILink.ScreenRead();
        }
        /// <summary>
        /// 输出文件中读取的格式化后的数据（无注释）
        /// </summary>
        /// <param name="flag">区分信标</param>
        /// <returns>格式化数据</returns>
        public string[] MRIRead(bool flag)
        {
            return MRILink.ScreenRead(flag);
        }

        /// <summary>
        /// 获取文件中的所有段落
        /// </summary>
        /// <returns>段落组</returns>
        public string[] GetSections()
        {
            return MRILink.GetSections();
        }
        /// <summary>
        /// 获取文件中指定段落的所有键名
        /// </summary>
        /// <param name="section">段落名</param>
        /// <returns>返回键名组</returns>
        public string[] GetKeys(string section)
        {
            return MRILink.GetKeys(section);
        }
        /// <summary>
        /// 查询指定段落中指定键的值
        /// </summary>
        /// <param name="section">段落名</param>
        /// <param name="key">键名</param>
        /// <returns>返回查询结果</returns>
        public string Search(string section, string key)
        {
            return MRILink.Find(section, key);
        }

        /// <summary>
        /// 文件打开方法（如果构造函数已经打开文件 文件打开失败 | 如果构造函数未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        protected void Open(string path, FILE_OPEN open)
        {
            if (OPENFLAG)
                throw new MRIException("MRI操作器已经打开了一个文件 若要打开新的文件请关闭现有操作器");
            else
            {
                if ("" == path)
                    throw new MRIException("文件路径不能作为具体操作路径");
                else if (File.Exists(path))
                {
                    if (FILE_OPEN.BOTH == open || FILE_OPEN.READ_ONLY == open)
                    {
                        try
                        {
                            StreamReader = new StreamReader(path, Encoding.Default);
                            ReadFromTEXT(StreamReader);
                            Path = path;
                            FILE_OPEN = open;
                            OPENFLAG = true;
                        }
                        catch (MRIException e)
                        {
                            throw e;
                        }
                        catch (System.Exception e)
                        {
                            throw new MRIException("文件打开失败：" + e.ToString());
                        }
                        finally
                        {
                            StreamReader.Close();
                        }
                    }
                    else
                        throw new MRIException("未知的文件操作类型");
                }
                else
                    throw new MRIException("文件打开失败：文件不存在");
            }
        }
        /// <summary>
        /// 从文件中读取MRI文件并将数据写入文件记录表
        /// </summary>
        /// <param name="reader">文件操作器</param>
        protected void ReadFromTEXT(StreamReader reader)
        {
            int Line = 1;    //行数指示器

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

            if (null != reader)
            {
                do
                {
                    
                    ch = (char)reader.Read();   //获取一个字符
                    if (IsSingle)    //单行注释中
                    {
                        while ('\n' != ch && !reader.EndOfStream)
                        {
                            CodeStack.Push(ch);
                            ch = (char)reader.Read();   //获取一个字符
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
                                case '\t':
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
                        else if (' ' == ch || '\t' == ch)   //如果符号为空格
                        {
                            while (' ' == ch || '\t' == ch)    //清除
                                ch = (char)reader.Read();
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
                        while (' ' == ch || '\t' == ch)
                            ch = (char)reader.Read();
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
                            case '\t':
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
                            case '\t':
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
                                    Error = ERROR_UNEXP;
                                }
                                break;
                        }
                    }
                } while (!reader.EndOfStream && Flag);
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
    }
}

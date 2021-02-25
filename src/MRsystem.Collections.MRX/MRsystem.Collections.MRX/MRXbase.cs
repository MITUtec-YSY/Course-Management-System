using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MRsystem.Exception;
using System.Text.RegularExpressions;

namespace MRsystem.Collections.MRX
{
    /// <summary>
    /// MRX文件操作基类（抽象类-已完成所有基本功能实现 可直接继承后使用）
    /// </summary>
    abstract public class MRXbase
    {
        /// <summary>
        /// MRX版本
        /// </summary>
        public string Version { get; protected set; }
        /// <summary>
        /// MRX编码
        /// </summary>
        public string EnCode { get; protected set; }
        /// <summary>
        /// MRX模式
        /// </summary>
        public string Mode { get; protected set; }
        /// <summary>
        /// MRX语言
        /// </summary>
        public string Language { get; protected set; }
        /// <summary>
        /// 文件路径
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
        /// MRX记录表
        /// </summary>
        protected EntryNode MRXLink;

        /// <summary>
        /// MRX文件操作基类构造函数（未打开文件）
        /// </summary>
        public MRXbase()
        {
            Path = "";
            Version = "1.0.0.1";
            EnCode = "auto";
            Mode = "automode";
            Language = "English";
            FILE_OPEN = FILE_OPEN.NONE;
            StreamReader = null;
            StreamWriter = null;
            OPENFLAG = false;
            MRXLink = new EntryNode("MRX");
        }
        /// <summary>
        /// MRX文件操作基类构造函数（默认以读写模式打开）
        /// </summary>
        /// <param name="path">文件路径</param>
        public MRXbase(string path) : this(path, FILE_OPEN.BOTH)
        {

        }
        /// <summary>
        /// MRX文件操作基类构造函数（打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        public MRXbase(string path, FILE_OPEN open) : this()
        {
            Path = path;
            FILE_OPEN = open;
        }

        /// <summary>
        /// 刷新文件操作流以写入到文件
        /// </summary>
        /// <returns>返回写入结果</returns>
        public void Flush()
        {
            if (FILE_OPEN.BOTH == FILE_OPEN)
            {
                try
                {
                    StringLink stringLink = new StringLink();
                    string[] vs = null;
                    string head = "<!mrx version=" + Version + " encode=\"" + EnCode + "\" mode=\"" + Mode + "\" lang=\"" + Language + "\"/!>";
                    stringLink.Add(head);
                    stringLink.Append(MRXLink.GetAllStrs());
                    vs = stringLink.Read();
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
                catch (System.Exception e)
                {
                    throw new MRXException("文件写入失败：" + e.ToString());
                }
            }
            else
                throw new MRXException("文件不可写入");
        }
        /// <summary>
        /// MRX文件操作流关闭
        /// </summary>
        public void Close()
        {
            MRXLink.Destroy();
            Path = string.Empty;
            FILE_OPEN = FILE_OPEN.NONE;
            if (null != StreamReader)
                StreamReader.Dispose();
            OPENFLAG = false;
        }
        /// <summary>
        /// 销毁MRI文件操作基类的所有使用资源
        /// </summary>
        public void Destroy()
        {
            Close();
            MRXLink.Destroy();
            GC.Collect();
        }

        /// <summary>
        /// 文件打开方法（如果构造函数已经打开文件 文件打开失败 | 如果构造函数未打开文件 则打开文件）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="open">文件打开方式</param>
        protected void Open(string path, FILE_OPEN open)
        {
            if (OPENFLAG)
                throw new MRXException("MRX操作器已经打开了一个文件 若要打开新的文件请关闭现有操作器");
            else
            {
                if ("" == path && "" == Path)
                    throw new MRXException("文件路径不能作为具体操作路径");
                else
                {
                    if ("" == path)
                        path = Path;
                    if (File.Exists(path))
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
                            catch (MRXException e)
                            {
                                throw e;
                            }
                            catch (System.Exception e)
                            {
                                throw new MRXException("文件打开失败：" + e.ToString());
                            }
                            finally
                            {
                                StreamReader.Close();
                            }
                        }
                        else
                            throw new MRXException("未知的文件操作类型");
                    }
                    else
                        throw new MRXException("文件打开失败：文件不存在");
                }
            }
        }
        /// <summary>
        /// 从文件中读取MRX文件并将数据写入文件记录表
        /// </summary>
        /// <param name="reader">文件操作器</param>
        protected void ReadFromTEXT(StreamReader reader)
        {
            int Line = 1; //行数记录器

            string Error = "";
            CharStack charStack = new CharStack();   //字符串分解字符堆栈
            CharStack signStack = new CharStack();   //符号堆栈
            bool HaveHead = false;    //头指示器

            char ch = '\0';

            do
            {
                ch = (char)reader.Read();
                if (!HaveHead)
                {
                    switch (ch)
                    {
                        case '<':
                            signStack.Push(ch);
                            break;
                        case '!':
                            if (signStack.Peek() == '<')
                                signStack.Push(ch);
                            else if (signStack.Peek() == '!')
                                signStack.Pop();
                            else
                                throw new MRXException("错误的文件结构： 第 " + Line + " 行");
                            break;
                        case '>':
                            if (signStack.Peek() == '<')
                            {
                                signStack.Pop();
                                HaveHead = true;
                            }
                            else
                                throw new MRXException("错误的文件结构： 第 " + Line + " 行");
                            break;
                        case '/':
                            if (signStack.Peek() != '!')
                                throw new MRXException("错误的文件结构： 第 " + Line + " 行");
                            break;
                        case '\n':
                            Line++;
                            break;
                        default:
                            while (' ' == ch && !reader.EndOfStream)
                                ch = (char)reader.Read();
                            while (' ' != ch && !reader.EndOfStream)
                            {
                                switch (ch)
                                {
                                    case '\"':
                                        if (signStack.Peek() != '\"')
                                        {
                                            signStack.Push(ch);
                                            ch = (char)reader.Read();
                                        }
                                        else
                                        {
                                            signStack.Pop();
                                            ch = ' ';
                                        }
                                        break;
                                    default:
                                        charStack.Push(ch);
                                        ch = (char)reader.Read();
                                        break;
                                }
                            }
                            string data = charStack.Read().ToLower();
                            string answer = "";
                            switch (data)
                            {
                                case "mrx":
                                    charStack.Clean();
                                    break;
                                case "version":
                                    while (' ' == ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    while ('=' != ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    if ('=' == ch)
                                    {
                                        ch = (char)reader.Read();
                                        while (' ' == ch && !reader.EndOfStream)
                                            ch = (char)reader.Read();
                                        while (' ' != ch && !reader.EndOfStream)
                                        {
                                            charStack.Push(ch);
                                            ch = (char)reader.Read();
                                        }
                                        if (0 < charStack.Count)
                                        {
                                            answer = charStack.Read();
                                            Version = answer;
                                        }
                                        charStack.Clean();
                                    }
                                    break;
                                case "encode":
                                    while (' ' == ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    while ('\"' != ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    if ('\"' == ch)
                                    {
                                        ch = (char)reader.Read();
                                        while (' ' == ch && !reader.EndOfStream)
                                            ch = (char)reader.Read();
                                        while ('\"' != ch && !reader.EndOfStream)
                                        {
                                            charStack.Push(ch);
                                            ch = (char)reader.Read();
                                        }
                                        if (0 < charStack.Count)
                                        {
                                            answer = charStack.Read();
                                            EnCode = answer;
                                        }
                                        charStack.Clean();
                                    }
                                    break;
                                case "mode":
                                    while (' ' == ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    while ('\"' != ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    if ('\"' == ch)
                                    {
                                        ch = (char)reader.Read();
                                        while (' ' == ch && !reader.EndOfStream)
                                            ch = (char)reader.Read();
                                        while ('\"' != ch && !reader.EndOfStream)
                                        {
                                            charStack.Push(ch);
                                            ch = (char)reader.Read();
                                        }
                                        if (0 < charStack.Count)
                                        {
                                            answer = charStack.Read();
                                            Mode = answer;
                                        }
                                        charStack.Clean();
                                    }
                                    break;
                                case "lang":
                                    while (' ' == ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    while ('\"' != ch && !reader.EndOfStream)
                                        ch = (char)reader.Read();
                                    if ('\"' == ch)
                                    {
                                        ch = (char)reader.Read();
                                        while (' ' == ch && !reader.EndOfStream)
                                            ch = (char)reader.Read();
                                        while ('\"' != ch && !reader.EndOfStream)
                                        {
                                            charStack.Push(ch);
                                            ch = (char)reader.Read();
                                        }
                                        if (0 < charStack.Count)
                                        {
                                            answer = charStack.Read();
                                            Language = answer;
                                        }
                                        charStack.Clean();
                                    }
                                    break;
                                default:
                                    string[] vs = data.Split('=');
                                    if (1 < vs.Length)
                                    {
                                        switch (vs[0].ToLower())
                                        {
                                            case "version":
                                                Version = Regex.Replace(vs[1], "\"", "");
                                                charStack.Clean();
                                                break;
                                            case "encode":
                                                EnCode = Regex.Replace(vs[1], "\"", "");
                                                charStack.Clean();
                                                break;
                                            case "mode":
                                                Mode = Regex.Replace(vs[1], "\"", "");
                                                charStack.Clean();
                                                break;
                                            case "lang":
                                                Language = Regex.Replace(vs[1], "\"", "");
                                                charStack.Clean();
                                                break;
                                            default:
                                                charStack.Clean();
                                                break;
                                        }
                                    }
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    switch (Mode.ToLower())
                    {
                        case "dtymode":
                            ReadAUTO(reader, ref Line, ref Error);
                            break;
                        case "toolmode":
                            ReadAUTO(reader, ref Line, ref Error);
                            break;
                        case "filemode":
                            ReadAUTO(reader, ref Line, ref Error);
                            break;
                        case "automode":
                            ReadAUTO(reader, ref Line, ref Error);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            } while (!reader.EndOfStream);
        }

        /// <summary>
        /// 程序模式文件读取方法
        /// </summary>
        /// <param name="reader">文件读取器</param>
        /// <param name="line">读取行数</param>
        /// <param name="error">错误代码</param>
        private void ReadDTY(StreamReader reader, ref int line, ref string error)
        {

        }
        /// <summary>
        /// 工具模式文件读取方法
        /// </summary>
        /// <param name="reader">文件读取器</param>
        /// <param name="line">读取行数</param>
        /// <param name="error">错误代码</param>
        private void ReadTOOL(StreamReader reader, ref int line, ref string error)
        {

        }
        /// <summary>
        /// 文件模式文件读取方法
        /// </summary>
        /// <param name="reader">文件读取器</param>
        /// <param name="line">读取行数</param>
        /// <param name="error">错误代码</param>
        private void ReadFILE(StreamReader reader, ref int line, ref string error)
        {

        }
        /// <summary>
        /// 自动模式文件读取方法
        /// </summary>
        /// <param name="reader">文件读取器</param>
        /// <param name="line">读取行数</param>
        /// <param name="error">错误代码</param>
        private void ReadAUTO(StreamReader reader, ref int line, ref string error)
        {
            bool NoError = true;
            bool Entry = false;
            bool Key = false;
            bool temp = false;

            string Keyname = "";
            string Keytype = "";
            string keydata = "";

            int temps = 0;
            char ch = '\0';
            string EntryName = "";
            CharStack charStack = new CharStack();
            CharStack signStack = new CharStack();
            StringStack stringStack = new StringStack();
            ch = (char)reader.Read();
            do
            {
                if (Entry)
                {
                    while (!temp && !reader.EndOfStream)
                    {
                        if ('\"' == ch)
                        {
                            temps++;
                            if (2 <= temps)
                                temp = true;
                        }
                        if ('\n' == ch)
                            line++;
                        charStack.Push(ch);
                        ch = (char)reader.Read();
                    }
                    temps = 0;
                    temp = false;
                    string[] entryvs = charStack.Read().Split('=');
                    if (1 < entryvs.Length)
                    {
                        for (int i = 0; i < entryvs.Length; i++)
                        {
                            entryvs[i] = Regex.Replace(entryvs[i], " ", "");
                            entryvs[i] = Regex.Replace(entryvs[i], "\"", "");
                        }
                        switch (entryvs[0].ToLower())
                        {
                            case "name":
                                EntryName = entryvs[1];
                                break;
                            default:
                                break;
                        }
                    }
                    charStack.Clean();
                    while ('>' != ch && !reader.EndOfStream)
                    {
                        if ('\n' == ch)
                            line++;
                        ch = (char)reader.Read();
                    }
                    if ('>' == ch)
                    {
                        signStack.Pop();
                        Entry = false;
                        stringStack.Push(EntryName);
                        EntryName = "";
                    }
                }
                else if (Key)
                {
                    while ('>' != ch && !reader.EndOfStream)
                    {
                        while (!temp && !reader.EndOfStream)
                        {
                            if ('\"' == ch)
                            {
                                temps++;
                                if (2 <= temps)
                                    temp = true;
                            }
                            if ('\n' == ch)
                                line++;
                            charStack.Push(ch);
                            ch = (char)reader.Read();
                        }
                        temps = 0;
                        temp = false;
                        string[] entryvs = charStack.Read().Split('=');
                        if (1 < entryvs.Length)
                        {
                            for (int i = 0; i < entryvs.Length; i++)
                            {
                                entryvs[i] = Regex.Replace(entryvs[i], " ", "");
                                entryvs[i] = Regex.Replace(entryvs[i], "\"", "");
                            }
                            switch (entryvs[0].ToLower())
                            {
                                case "name":
                                    Keyname = entryvs[1];
                                    break;
                                case "type":
                                    Keytype = entryvs[1];
                                    break;
                                default:
                                    break;
                            }
                        }
                        charStack.Clean();
                    }
                    signStack.Pop();
                    charStack.Clean();
                    ch = (char)reader.Read();
                    while ('<' != ch && !reader.EndOfStream)
                    {
                        if ('\n' == ch)
                            line++;
                        charStack.Push(ch);
                        ch = (char)reader.Read();
                    }
                    keydata = charStack.Read();
                    charStack.Clean();
                    while ('>' != ch && !reader.EndOfStream)
                    {
                        if ('\n' == ch)
                            line++;
                        ch = (char)reader.Read();
                    }
                    ch = (char)reader.Read();
                    switch (Keytype.ToLower())
                    {
                        case "binary":
                            MRXLink.AddKey(stringStack.Read(), Keyname, keydata, SUBKEY_TYPE.BINARY);
                            break;
                        case "int":
                            MRXLink.AddKey(stringStack.Read(), Keyname, keydata, SUBKEY_TYPE.INT);
                            break;
                        case "string":
                        default:
                            MRXLink.AddKey(stringStack.Read(), Keyname, keydata, SUBKEY_TYPE.STRING);
                            break;
                    }
                    Keyname = "";
                    Keytype = "string";
                    keydata = "";
                    Key = false;
                }
                else
                {
                    while ('<' != ch && !reader.EndOfStream)
                    {
                        if ('\n' == ch)
                            line++;
                        ch = (char)reader.Read();
                    }
                    signStack.Push(ch);
                    ch = (char)reader.Read();
                    while (' ' != ch && !reader.EndOfStream)
                    {
                        if ('\n' == ch)
                            line++;
                        if ('/' == ch)
                            signStack.Push(ch);
                        else if ('>' == ch)
                            break;
                        else
                            charStack.Push(ch);
                        ch = (char)reader.Read();
                    }
                    if ('>' == ch)
                    {
                        signStack.Clean();
                        stringStack.Pop();
                        charStack.Clean();
                    }
                    else if (' ' == ch)
                    {
                        switch (charStack.Read().ToLower())
                        {
                            case "entry":
                                Entry = true;
                                charStack.Clean();
                                break;
                            case "key":
                                Key = true;
                                charStack.Clean();
                                break;
                            default:
                                break;
                        }
                    }
                }
            } while (!reader.EndOfStream && NoError);
        }
    }
}

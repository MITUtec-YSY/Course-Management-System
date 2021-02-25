using System;
using MRsystem.Collections;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections.MRI
{
    /// <summary>
    /// MRI键-值节点
    /// </summary>
    public class KeyNode
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string Key;
        /// <summary>
        /// 值
        /// </summary>
        public string Vaule;
        /// <summary>
        /// 注释
        /// </summary>
        public string Note;
        /// <summary>
        /// 注释类型
        /// </summary>
        public NoteType NoteType;
        /// <summary>
        /// 下一个键-值节点
        /// </summary>
        public KeyNode Next;
        /// <summary>
        /// 上一个键-值节点
        /// </summary>
        public KeyNode Pre;
        /// <summary>
        /// 主动内存回收
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }
    }
    /// <summary>
    /// MRI段落节点
    /// </summary>
    public class SectionNode
    {
        /// <summary>
        /// MRI段落
        /// </summary>
        public string Section;
        /// <summary>
        /// 注释
        /// </summary>
        public string Note;
        /// <summary>
        /// 注释类型
        /// </summary>
        public NoteType NoteType;
        /// <summary>
        /// 段落子键数目
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// MRI段落节点下一个节点
        /// </summary>
        public SectionNode Next;
        /// <summary>
        /// MRI段落节点上一个节点
        /// </summary>
        public SectionNode Pre;
        private KeyNode keyHead;
        private KeyNode keyEnd;

        /// <summary>
        /// MRI段落节点构造函数
        /// </summary>
        public SectionNode()
        {
            keyHead = new KeyNode
            {
                Key = string.Empty,
                Vaule = string.Empty,
                Note = string.Empty,
                Next = null,
                Pre = null,
            };
            keyEnd = keyHead;
            Count = 0;
        }
        /// <summary>
        /// MRI段落节点复制构造函数（只可复制段落名和段落注释）
        /// </summary>
        /// <param name="_copy_node">复制源</param>
        public SectionNode(SectionNode _copy_node)
        {
            Section = _copy_node.Section;
            Note = _copy_node.Note;
        }

        /// <summary>
        /// 向MRI段落中添加一个子键
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="vaule">键值</param>
        /// <param name="note">键注释</param>
        /// <param name="nflag">注释类型</param>
        public void Add(string key, string vaule, string note, NoteType nflag)
        {
            if (string.Empty != key || string.Empty != note)
            {
                keyEnd.Next = new KeyNode
                {
                    Key = key,
                    Vaule = vaule,
                    Note = note,
                    NoteType = nflag,
                    Next = null,
                    Pre = keyEnd,
                };
                keyEnd = keyEnd.Next;
                Count++;
            }
        }
        /// <summary>
        /// 从MRI段落中删除指定键
        /// </summary>
        /// <param name="key">键名</param>
        public void Del(string key)
        {
            KeyNode node = keyHead.Next;
            while (null != node)
            {
                if (node.Key == key)
                {
                    if (null == node.Next)
                        node.Pre.Next = null;
                    else
                    {
                        node.Next.Pre = node.Pre;
                        node.Pre.Next = node.Next;
                    }
                    node.Destroy();
                    Count--;
                }
                node = node.Next;
            }
        }
        /// <summary>
        /// 修改MRI段落中指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="vaule">键值</param>
        /// <param name="flag">区分函数参数</param>
        public void Edit(string key, string vaule, int flag)
        {
            KeyNode node = keyHead.Next;
            while (null != node)
            {
                if (node.Key == key)
                {
                    node.Vaule = vaule;
                    break;
                }
                node = node.Next;
            }
        }
        /// <summary>
        /// 修改MRI段落中指定键的键名
        /// </summary>
        /// <param name="key">制定的键</param>
        /// <param name="nkey">新的键名</param>
        public void Edit(string key, string nkey)
        {
            KeyNode node = keyHead.Next;
            while (null != node)
            {
                if (node.Key == key)
                {
                    node.Key = nkey;
                    break;
                }
                node = node.Next;
            }
        }
        /// <summary>
        /// 从MRI段落中获取指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>返回键值</returns>
        public string Seach(string key)
        {
            string seach = null;
            if (0 < Count)
            {
                KeyNode node = keyHead.Next;
                while (null != node)
                {
                    if (node.Key == key)
                    {
                        seach = node.Vaule;
                        break;
                    }
                    node = node.Next;
                }
            }
            return seach;
        }
        /// <summary>
        /// 将MRI段落节点的所有数据导出为文件输出的字符串流
        /// </summary>
        /// <returns>返回MRI段落字符串组</returns>
        public string[] Read()
        {
            CharStack stack = new CharStack();
            string[] vs = new string[Count + 1];
            vs[0] = "[" + Section + "]";
            switch (NoteType)
            {
                case NoteType.Sing_Note:
                    vs[0] += "    " + "//" + Note;
                    break;
                case NoteType.Mitl_note:
                    vs[0] += "    " + "/*" + Note + "*/";
                    break;
                default:
                    break;
            }
            if (0 < Count)
            {
                KeyNode node = keyHead.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (node.Key == string.Empty)
                    {
                        switch (node.NoteType)
                        {
                            case NoteType.Sing_Note:
                                vs[i + 1] = "//" + node.Note;
                                break;
                            case NoteType.Mitl_note:
                                vs[i + 1] = "/*" + node.Note + "*/";
                                break;
                            default:
                                break;
                        } 
                    }
                    else
                    {
                        char[] vs_c = node.Vaule.ToCharArray();
                        stack.Clean();
                        for(int j = 0; j < vs_c.Length; j++)
                        {
                            if ('\"' == vs_c[j])
                            {
                                stack.Push('\\');
                                stack.Push('\"');
                            }
                            else if('\\'== vs_c[j])
                            {
                                stack.Push('\\');
                                stack.Push('\\');
                            }
                            else
                                stack.Push(vs_c[j]);
                        }
                        vs[i + 1] = node.Key + " = " + "\"" + stack.Read() + "\"";
                        switch (node.NoteType)
                        {
                            case NoteType.Sing_Note:
                                vs[i + 1] += "    " + "//" + node.Note;
                                break;
                            case NoteType.Mitl_note:
                                vs[i + 1] += "    " + "/*" + node.Note + "*/";
                                break;
                            default:
                                break;
                        }
                    }
                    node = node.Next;
                }
            }
            return vs;
        }
        /// <summary>
        /// 将MRI段落节点的所有数据导出为文件输出的字符串流（无注释）
        /// </summary>
        /// <param name="flag">指示标志</param>
        /// <returns>返回字符串流</returns>
        public string[] Read(bool flag)
        {
            CharStack stack = new CharStack();
            StringLink link = new StringLink();
            string[] vs = null;
            link.Add("[" + Section + "]");
            if (0 < Count)
            {
                KeyNode node = keyHead.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (node.Key != string.Empty)
                    {
                        char[] vs_c = node.Vaule.ToCharArray();
                        stack.Clean();
                        for (int j = 0; j < vs_c.Length; j++)
                        {
                            if ('\"' == vs_c[j])
                            {
                                stack.Push('\\');
                                stack.Push('\"');
                            }
                            else if ('\\' == vs_c[j])
                            {
                                stack.Push('\\');
                                stack.Push('\\');
                            }
                            else
                                stack.Push(vs_c[j]);
                        }
                        link.Add(node.Key + " = " + "\"" + stack.Read() + "\"");
                    }
                    node = node.Next;
                }
                vs = link.Read();
            }
            return vs;
        }
        /// <summary>
        /// 将MRI段落节点的所有数据导出为显示输出的字符串流
        /// </summary>
        /// <returns>返回MRI段落字符串组</returns>
        public string[] ScreenRead()
        {
            string[] vs = new string[Count + 1];
            vs[0] = "[" + Section + "]";
            switch (NoteType)
            {
                case NoteType.Sing_Note:
                    vs[0] += "    " + "//" + Note;
                    break;
                case NoteType.Mitl_note:
                    vs[0] += "    " + "/*" + Note + "*/";
                    break;
                default:
                    break;
            }
            if (0 < Count)
            {
                KeyNode node = keyHead.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (node.Key == string.Empty)
                    {
                        switch (node.NoteType)
                        {
                            case NoteType.Sing_Note:
                                vs[i + 1] = "//" + node.Note;
                                break;
                            case NoteType.Mitl_note:
                                vs[i + 1] = "/*" + node.Note + "*/";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        vs[i + 1] = node.Key + " = " + "\"" + node.Vaule + "\"";
                        switch (node.NoteType)
                        {
                            case NoteType.Sing_Note:
                                vs[i + 1] += "    " + "//" + node.Note;
                                break;
                            case NoteType.Mitl_note:
                                vs[i + 1] += "    " + "/*" + node.Note + "*/";
                                break;
                            default:
                                break;
                        }
                    }
                    node = node.Next;
                }
            }
            return vs;
        }
        /// <summary>
        /// 将MRI段落节点的所有数据导出为文件输出的字符串流（无注释）
        /// </summary>
        /// <param name="flag">指示标志</param>
        /// <returns>返回字符串流</returns>
        public string[] ScreenRead(bool flag)
        {
            StringLink link = new StringLink();
            string[] vs = null;
            link.Add("[" + Section + "]");
            if (0 < Count)
            {
                KeyNode node = keyHead.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (node.Key != string.Empty)
                        link.Add(node.Key + " = " + "\"" + node.Vaule + "\"");
                    node = node.Next;
                }
                vs = link.Read();
            }
            return vs;
        }
        /// <summary>
        /// 获取段落中包含的所有键的键名
        /// </summary>
        /// <returns>返回键名组</returns>
        public string[] GetKeys()
        {
            StringLink link = new StringLink();
            KeyNode node = keyHead.Next;
            while (null != node)
            {
                link.Add(node.Key);
                node = node.Next;
            }
            return link.Read();
        }

        /// <summary>
        /// 主动内存回收
        /// </summary>
        public void Destroy()
        {
            while (0 < Count)
            {
                keyEnd = keyEnd.Pre;
                keyEnd.Next.Destroy();
                Count--;
            }
            GC.Collect();
        }
    }

    /// <summary>
    /// MRI文件记录表
    /// </summary>
    public class MRILink
    {
        private SectionNode Head;
        private SectionNode End;
        private SectionNode Now;
        /// <summary>
        /// 获取注释链表中的元素个数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// MRI文件记录表构造函数
        /// </summary>
        public MRILink()
        {
            Head = new SectionNode
            {
                Section = DefineData.MRIname + " " + DefineData.MRIversion,
                Note = string.Empty,
                NoteType = NoteType.No_Note,
                Next = null,
                Pre = null,
            };
            End = Head;
            Now = Head;
            Count = 0;
        }

        /// <summary>
        /// 向记录表中添加一个段
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="note">注释</param>
        /// <param name="type">注释类型</param>
        public void Add(string section, string note, NoteType type)
        {
            if (string.Empty == section)
                Head.Add(string.Empty, string.Empty, note, type);
            else
            {
                bool Flag = false;
                Now = Head;
                while (null != Now.Next && !Flag)
                {
                    if (Now.Next.Section == section)
                    {
                        Flag = true;
                        if (NoteType.No_Note == Now.Next.NoteType)
                        {
                            Now.Next.Note = note;
                            Now.Next.NoteType = type;
                        }
                    }
                    Now = Now.Next;
                }
                if (!Flag)
                {
                    SectionNode node = new SectionNode
                    {
                        Section = section,
                        Note = note,
                        NoteType = type,
                        Next = null,
                        Pre = End,
                    };
                    End.Next = node;
                    End = End.Next;
                    Now = End;
                    Count++;
                }
            }
        }
        /// <summary>
        /// 向记录表的指定段中添加一个键
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键名</param>
        /// <param name="vaule">键值</param>
        /// <param name="note">注释</param>
        /// <param name="type">注释类型</param>
        public void Add(string section, string key, string vaule, string note, NoteType type)
        {
            if (string.Empty == section)
                Head.Add(string.Empty, string.Empty, note, type);
            else
            {
                if (Now.Section == section)
                    Now.Add(key, vaule, note, type);
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            if (string.Empty == key)
                            {
                                if (NoteType.No_Note == Now.NoteType)
                                {
                                    Now.Note = note;
                                    Now.NoteType = type;
                                }
                            }
                            else
                                Now.Add(key, vaule, note, type);
                            break;
                        }
                        Now = Now.Next;
                    }
                    if (null == Now)
                    {
                        if (string.Empty == key)
                            Add(section, note, type);
                        else
                        {
                            Add(section, string.Empty, NoteType.No_Note);
                            Add(section, key, vaule, note, type);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 清空文件记录表
        /// </summary>
        public void Clean()
        {
            while (0 < Count)
            {
                End = End.Pre;
                End.Next.Destroy();
                Count--;
            }
            Head.Destroy();
            Head = new SectionNode
            {
                Section = DefineData.MRIname + " " + DefineData.MRIversion,
                Note = string.Empty,
                NoteType = NoteType.No_Note,
                Next = null,
                Pre = null,
            };
            End = Head;
            Now = Head;
            Count = 0;
        }
        /// <summary>
        /// 从记录表中删除指定段
        /// </summary>
        /// <param name="section">段名</param>
        public void Del(string section)
        {
            if (string.Empty != section)
            {
                if (Now.Section == section)
                {
                    if (null == Now.Next)
                        Now.Pre.Next = null;
                    else
                    {
                        Now.Next.Pre = Now.Pre;
                        Now.Pre.Next = Now.Next;
                    }
                    Now.Destroy();
                    Count--;
                    Now = End;
                }
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            if (null == Now.Next)
                                Now.Pre.Next = null;
                            else
                            {
                                Now.Next.Pre = Now.Pre;
                                Now.Pre.Next = Now.Next;
                            }
                            Now.Destroy();
                            Count--;
                            Now = End;
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
        }
        /// <summary>
        /// 从记录表指定段中删除指定键
        /// </summary>
        /// <param name="section">段名</param>
        /// <param name="key">键名</param>
        public void Del(string section, string key)
        {
            if (string.Empty != section)
            {
                if (Now.Section == section)
                    Now.Del(key);
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            Now.Del(key);
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定段名
        /// </summary>
        /// <param name="section">原段名</param>
        /// <param name="nsection">新段名</param>
        public void Edit(string section, string nsection)
        {
            if (string.Empty != section)
            {
                if (Now.Section == section)
                    Now.Section = nsection;
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            Now.Section = nsection;
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定段名中的指定键名
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="nkey"></param>
        public void Edit(string section,string key,string nkey)
        {
            if (string.Empty != section)
            {
                if (Now.Section == section)
                    Now.Edit(key, nkey);
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            Now.Edit(key, nkey);
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定段中的指定记录的值
        /// </summary>
        /// <param name="section">指定的段落</param>
        /// <param name="key">指定的键</param>
        /// <param name="nvaule">新的键值</param>
        /// <param name="flag">区分函数标志</param>
        public void Edit(string section, string key, string nvaule, int flag)
        {
            if (string.Empty != section)
            {
                if (Now.Section == section)
                    Now.Edit(key, nvaule, flag);
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            Now.Edit(key, nvaule, flag);
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
        }
        /// <summary>
        /// 从表中读取指定段落中指定键的值
        /// </summary>
        /// <param name="section">指定的段落</param>
        /// <param name="key">指定的键</param>
        /// <returns>返回键值</returns>
        public string Find(string section, string key)
        {
            string str = null;
            if (string.Empty != section)
            {
                if (Now.Section == section)
                    str = Now.Seach(key);
                else
                {
                    Now = Head.Next;
                    while (null != Now)
                    {
                        if (Now.Section == section)
                        {
                            str = Now.Seach(key);
                            break;
                        }
                        Now = Now.Next;
                    }
                }
            }
            return str;
        }
        /// <summary>
        /// 将整个记录表转换为用于文件的字符串数组输出
        /// </summary>
        /// <returns>返回转换的字符串数组</returns>
        public string[] Read()
        {
            string[] vs = null;
            StringLink link = new StringLink();
            string[] temp = Head.Read();
            for (int i = 1; i < temp.Length; i++)
                link.Add(temp[i]);
            Now = Head.Next;
            while (null != Now)
            {
                temp = Now.Read();
                if (null != temp)
                {
                    for (int i = 0; i < temp.Length; i++)
                        link.Add(temp[i]);
                    link.Add("");
                }
                Now = Now.Next;
            }
            vs = link.Read();
            Now = Head;
            return vs;
        }
        /// <summary>
        /// 将整个记录表转换为用于文件的字符串流输出（无注释）
        /// </summary>
        /// <param name="flag">区分信标</param>
        /// <returns>返回字符串流</returns>
        public string[] Read(bool flag)
        {
            string[] vs = null;
            StringLink link = new StringLink();
            string[] temp = null;
            Now = Head.Next;
            while (null != Now)
            {
                temp = Now.Read(flag);
                if (null != temp)
                {
                    for (int i = 0; i < temp.Length; i++)
                        link.Add(temp[i]);
                    link.Add("");
                }
                Now = Now.Next;
            }
            vs = link.Read();
            Now = Head;
            return vs;
        }
        /// <summary>
        /// 将整个记录表转换为用于显示的字符串数组输出
        /// </summary>
        /// <returns>返回转换的字符串数组</returns>
        public string[] ScreenRead()
        {
            string[] vs = null;
            StringLink link = new StringLink();
            string[] temp = Head.ScreenRead();
            for (int i = 1; i < temp.Length; i++)
                link.Add(temp[i]);
            Now = Head.Next;
            while (null != Now)
            {
                temp = Now.ScreenRead();
                if (null != temp)
                {
                    for (int i = 0; i < temp.Length; i++)
                        link.Add(temp[i]);
                    link.Add("");
                }
                Now = Now.Next;
            }
            vs = link.Read();
            Now = Head;
            return vs;
        }
        /// <summary>
        /// 将整个记录表转换为用于显示的字符串流输出（无注释）
        /// </summary>
        /// <param name="flag">区分信标</param>
        /// <returns>返回字符串流</returns>
        public string[] ScreenRead(bool flag)
        {
            string[] vs = null;
            StringLink link = new StringLink();
            string[] temp = null;
            Now = Head.Next;
            while (null != Now)
            {
                temp = Now.ScreenRead(flag);
                if (null != temp)
                {
                    for (int i = 0; i < temp.Length; i++)
                        link.Add(temp[i]);
                    link.Add("");
                }
                Now = Now.Next;
            }
            vs = link.Read();
            Now = Head;
            return vs;
        }
        /// <summary>
        /// 获取记录表中的所有段落
        /// </summary>
        /// <returns>返回段落组</returns>
        public string[] GetSections()
        {
            StringLink link = new StringLink();
            Now = Head.Next;
            while (null != Now)
            {
                link.Add(Now.Section);
                Now = Now.Next;
            }
            Now = Head.Next;
            return link.Read();
        }
        /// <summary>
        /// 获取记录表指定段落中的所有键名
        /// </summary>
        /// <param name="section">指定的段落</param>
        /// <returns>返回键名组</returns>
        public string[] GetKeys(string section)
        {
            string[] vs = null;
            if (Now.Section == section)
                vs = Now.GetKeys();
            else
            {
                Now = Head.Next;
                while (null != Now)
                {
                    if (Now.Section == section)
                    {
                        vs = Now.GetKeys();
                        break;
                    }
                    Now = Now.Next;
                }
            }
            return vs;
        }

        /// <summary>
        /// 销毁记录表
        /// </summary>
        public void Destroy()
        {
            while (0 < Count) 
            {
                End = End.Pre;
                End.Next.Destroy();
                Count--;
            }
            Head.Destroy();
            GC.Collect();
        }
    }
}

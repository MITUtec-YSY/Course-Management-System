using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections
{
    /// <summary>
    /// 字符串链节点
    /// </summary>
    public class StringNode
    {
        /// <summary>
        /// 字符串元素
        /// </summary>
        public string Str;
        /// <summary>
        /// 字符串链表下一元素
        /// </summary>
        public StringNode Next;
        /// <summary>
        /// 字符串链表上一元素
        /// </summary>
        public StringNode Pre;
        /// <summary>
        /// 从内存中删除
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }
    }

    /// <summary>
    /// 字符串链表
    /// </summary>
    public class StringLink
    {
        private StringNode Head;
        private StringNode End;
        /// <summary>
        /// 获取字符串链表中的元素个数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 字符串链表构造函数
        /// </summary>
        public StringLink()
        {
            Head = new StringNode
            {
                Str = null,
                Next = null,
                Pre = null,
            };
            End = Head;
            Count = 0;
        }
        /// <summary>
        /// 字符串链表复制构造函数
        /// </summary>
        /// <param name="_copy_link">复制源</param>
        public StringLink(StringLink _copy_link)
        {
            Clean();
            string[] vs = _copy_link.Read();
            for (int i = 0; i < vs.Length; i++)
                Add(vs[i]);
        }

        /// <summary>
        /// 向字符串链表最后添加一个字符串
        /// </summary>
        /// <param name="_new_string">添加的字符串</param>
        public void Add(string _new_string)
        {
            StringNode node = new StringNode
            {
                Str = _new_string,
                Next = null,
                Pre = End,
            };
            End.Next = node;
            End = End.Next;
            Count++;
        }
        /// <summary>
        /// 向字符串链表指定索引位置添加一个字符串
        /// </summary>
        /// <param name="_new_strings">添加的字符串</param>
        /// <param name="index">需要添加的位置索引</param>
        public void Add(string _new_strings, int index)
        {
            if (index <= Count)
            {
                StringNode node = Head;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                StringNode newNode = new StringNode
                {
                    Str = _new_strings,
                    Next = node.Next,
                    Pre = node,
                };
                node.Next.Pre = newNode;
                node.Next = newNode;
                Count++;
            }
            else
                Add(_new_strings);
        }
        /// <summary>
        /// 向字符串链表后追加字符串组
        /// </summary>
        /// <param name="_append_strings">追加的源字符串链表</param>
        public void Append(StringLink _append_strings)
        {
            string[] vs = _append_strings.Read();
            for (int i = 0; i < vs.Length; i++)
                Add(vs[i]);
        }
        /// <summary>
        /// 向字符串链表后追加字符串组
        /// </summary>
        /// <param name="_append_strings">追加的源字符串数组</param>
        public void Append(string[] _append_strings)
        {
            for (int i = 0; i < _append_strings.Length; i++)
                Add(_append_strings[i]);
        }
        /// <summary>
        /// 清理字符串链表
        /// </summary>
        public void Clean()
        {
            while (0 < Count)
            {
                End = End.Pre;
                End.Next.Destroy();
                Count--;
            }
            End = Head;
            End.Next = null;
            Head.Pre = null;
        }
        /// <summary>
        /// 从字符串链表中删除指定的字符串
        /// </summary>
        /// <param name="_del_string">需删除的字符串</param>
        public void Del(string _del_string)
        {
            StringNode node = Head.Next;
            while (null != node)
            {
                if (node.Str == _del_string) 
                {
                    node.Pre.Next = node.Next;
                    node.Next.Pre = node.Pre;
                    node.Destroy();
                    Count--;
                    break;
                }
                node = node.Next;
            }
        }
        /// <summary>
        /// 从字符串链表中删除指定索引的字符串
        /// </summary>
        /// <param name="index">需删除字符串的索引值</param>
        public void Del(int index)
        {
            if (index < Count)
            {
                StringNode node = Head.Next;
                for(int i = 0; i < index; i++)
                    Head = Head.Next;
                node.Pre.Next = node.Next;
                node.Next.Pre = node.Pre;
                node.Destroy();
                Count--;
            }
        }
        /// <summary>
        /// 将整个链表输出为字符串数组
        /// </summary>
        /// <returns>返回字符串数组</returns>
        public string[] Read()
        {
            string[] vs = null;
            if (0 < Count)
            {
                vs = new string[Count];
                StringNode node = Head.Next;
                for (int i = 0; i < Count; i++)
                {
                    vs[i] = node.Str;
                    node = node.Next;
                }
            }
            return vs;
        }
        /// <summary>
        /// 查找字符串链表中是否存在指定字符串
        /// </summary>
        /// <param name="str">指定的字符串</param>
        /// <returns>返回查找结果</returns>
        public bool Seek(string str)
        {
            bool Flag = false;
            StringNode node = Head.Next;
            while (null != node)
            {
                if (node.Str == str)
                {
                    Flag = true;
                    break;
                }
                node = node.Next;
            }
            return Flag;
        }
        /// <summary>
        /// 通过索引值读取指定索引值的字符串
        /// </summary>
        /// <param name="index">指定的索引值</param>
        /// <returns>返回对应字符串</returns>
        public string this[int index]
        {
            get
            {
                string str = null;
                if (index < Count) 
                {
                    StringNode node = Head.Next;
                    for(int i = 0; i < index; i++)
                        node = node.Next;
                    str = node.Str;
                }
                return str;
            }
        }
    }
}

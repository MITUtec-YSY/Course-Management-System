using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections
{
    /// <summary>
    /// 字符串堆栈结构体
    /// </summary>
    public class StringStackNode
    {
        /// <summary>
        /// 堆栈字符元素
        /// </summary>
        public string sign;
        /// <summary>
        /// 堆栈下一个元素
        /// </summary>
        public StringStackNode Next;
        /// <summary>
        /// 堆栈上一个元素
        /// </summary>
        public StringStackNode Pre;
    }
    /// <summary>
    /// 字符串堆栈
    /// </summary>
    public class StringStack
    {
        private StringStackNode Buttom;   //字符堆栈栈底
        private StringStackNode Top;    //字符堆栈栈顶
        /// <summary>
        /// 字符堆栈字符数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 字符堆栈构造函数
        /// </summary>
        public StringStack()
        {
            Buttom = new StringStackNode
            {
                sign = "",
                Next = null,
                Pre = null,
            };
            Top = Buttom;
            Count = 0;
        }
        /// <summary>
        /// 字符堆栈复制构造函数
        /// </summary>
        /// <param name="_copy_stack">复制源</param>
        public StringStack(StringStack _copy_stack)
        {
            Clean();
            string[] copystr = _copy_stack.Read();
            for (int i = 0; i < copystr.Length; i++)
                Push(copystr[i]);
        }

        /// <summary>
        /// 将字符堆栈添加在本堆栈之后
        /// </summary>
        /// <param name="_append_stack">添加源堆栈</param>
        public void Append(StringStack _append_stack)
        {
            string[] copystr = _append_stack.Read();
            for (int i = 0; i < copystr.Length; i++)
                Push(copystr[i]);
        }
        /// <summary>
        /// 字符入栈
        /// </summary>
        /// <param name="ch">入栈字符</param>
        public void Push(string ch)
        {
            StringStackNode node = new StringStackNode
            {
                sign = ch,
                Next = null,
                Pre = Top,
            };
            Top.Next = node;
            Top = Top.Next;
            Count++;
        }
        /// <summary>
        /// 字符出栈
        /// </summary>
        /// <returns>返回栈顶元素</returns>
        public string Pop()
        {
            string ch = "";
            if (0 < Count)
            {
                ch = Top.sign;
                Top = Top.Pre;
                Top.Next = null;
                Count--;
            }
            return ch;
        }
        /// <summary>
        /// 查看栈顶
        /// </summary>
        /// <returns>返回栈顶元素</returns>
        public string Peek()
        {
            return Top.sign;
        }
        /// <summary>
        /// 字符串出队（将字符连接成字符串）
        /// </summary>
        /// <returns>返回字符堆栈中的字符串</returns>
        public string[] Read()
        {
            string[] str = null;
            StringLink stringLink = new StringLink();
            StringStackNode node = Buttom.Next;
            while (null != node)
            {
                stringLink.Add(node.sign);
                node = node.Next;
            }
            str = stringLink.Read();
            return str;
        }
        /// <summary>
        /// 清空堆栈
        /// </summary>
        public void Clean()
        {
            Buttom.Next = null;
            Buttom.Pre = null;
            Top = Buttom;
            Count = 0;
        }
    }
}

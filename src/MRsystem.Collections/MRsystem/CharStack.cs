using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections
{
    /// <summary>
    /// 字符堆栈结构体
    /// </summary>
    public class CharNode
    {
        /// <summary>
        /// 堆栈字符元素
        /// </summary>
        public char sign;
        /// <summary>
        /// 堆栈下一个元素
        /// </summary>
        public CharNode Next;
        /// <summary>
        /// 堆栈上一个元素
        /// </summary>
        public CharNode Pre;
    }
    /// <summary>
    /// 字符堆栈
    /// </summary>
    public class CharStack
    {
        private CharNode Buttom;   //字符堆栈栈底
        private CharNode Top;    //字符堆栈栈顶
        /// <summary>
        /// 字符堆栈字符数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 字符堆栈构造函数
        /// </summary>
        public CharStack()
        {
            Buttom = new CharNode
            {
                sign = '\0',
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
        public CharStack(CharStack _copy_stack)
        {
            Clean();
            string copystr = _copy_stack.Read();
            for(int i = 0; i < copystr.Length; i++)
                Push(copystr[i]);
        }
   
        /// <summary>
        /// 将字符堆栈添加在本堆栈之后
        /// </summary>
        /// <param name="_append_stack">添加源堆栈</param>
        public void Append(CharStack _append_stack)
        {
            string copystr = _append_stack.Read();
            for (int i = 0; i < copystr.Length; i++)
                Push(copystr[i]);
        }
        /// <summary>
        /// 字符入栈
        /// </summary>
        /// <param name="ch">入栈字符</param>
        public void Push(char ch)
        {
            CharNode node = new CharNode
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
        public char Pop()
        {
            char ch = '\0';
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
        public char Peek()
        {
            return Top.sign;
        }
        /// <summary>
        /// 字符串出队（将字符连接成字符串）
        /// </summary>
        /// <returns>返回字符堆栈中的字符串</returns>
        public string Read()
        {
            string str = string.Empty;
            CharNode node = Buttom.Next;
            while (null != node)
            {
                str += node.sign;
                node = node.Next;
            }
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

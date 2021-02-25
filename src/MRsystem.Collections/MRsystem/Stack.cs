using System;
using MRsystem.Exception;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用数据堆栈
        /// </summary>
        public class Stack
        {
            /// <summary>
            /// 获取堆栈中包含的元素个数
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// 堆栈大小限制
            /// </summary>
            private int Size { get; set; }
            /// <summary>
            /// 堆栈栈底
            /// </summary>
            private StackNode Buttom;
            /// <summary>
            /// 堆栈栈顶
            /// </summary>
            private StackNode Top;

            /// <summary>
            /// 通用数据堆栈默认构造函数
            /// </summary>
            public Stack()
            {
                Buttom = new StackNode
                {
                    Pre = null
                };
                Size = -1;
                Top = Buttom;
                Count = 0;
            }
            /// <summary>
            /// 通用数据堆栈构造函数重载+1
            /// </summary>
            /// <param name="size">堆栈限制长度</param>
            public Stack(int size) : this()
            {
                Size = size;
            }
            /// <summary>
            /// 通用数据堆栈复制构造函数
            /// </summary>
            /// <param name="stack">复制元数据</param>
            public Stack(Stack stack)
            {
                Buttom = new StackNode
                {
                    Pre = null
                };
                Top = Buttom;
                Count = 0;
                object[] temp = stack.ToArray();
                if (null != temp)
                {
                    Stack temps = new Stack();
                    foreach (object i in temp)
                        temps.Push(i);
                    temp = temps.ToArray();
                    foreach (object i in temp)
                        Push(i);
                }
            }
            /// <summary>
            /// 从堆栈中移除所有元素
            /// </summary>
            public void Clear()
            {
                StackNode node;
                while (0 == Count)
                {
                    node = Top;
                    Top = Top.Pre;
                    node.Destroy();
                    Count--;
                }
            }
            /// <summary>
            /// 查询某个元素是否在堆栈中
            /// </summary>
            /// <param name="obj">查询数据</param>
            /// <returns>返回查询结果（false：数据不在堆栈中||true：数据在堆栈中）</returns>
            public bool Seek(object obj)
            {
                bool ReturnTemp = false;
                StackNode node = Top;
                while (null != node.Pre && false == ReturnTemp)
                {
                    if (node.data.Equals(obj))
                        ReturnTemp = true;
                    node = node.Pre;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 返回堆栈栈顶的元素（不删除栈顶元素）
            /// </summary>
            /// <returns>返回数据</returns>
            public object Peek()
            {
                return Top.data;
            }
            /// <summary>
            /// 向堆栈顶部添加一个元素
            /// </summary>
            /// <param name="obj">添加对象</param>
            /// <returns>返回添加状态</returns>
            public CollectionsError Push(object obj)
            {
                CollectionsError error = CollectionsError.NO_ERROR;
                if (0 < Size)
                    if (Size <= Count)
                        error = CollectionsError.OUT_OF_BOUNDES;
                if (CollectionsError.NO_ERROR == error)
                {
                    StackNode stackNode = new StackNode(obj);
                    stackNode.Pre = Top;
                    Top = stackNode;
                    Count++;
                }
                return error;
            }
            /// <summary>
            /// 返回并删除栈顶元素
            /// </summary>
            /// <returns>栈顶元素</returns>
            public object Pop()
            {
                object ReturnTemp = Top.data;
                if (0 < Count)
                {
                    StackNode node = Top;
                    Top = Top.Pre;
                    node.Destroy();
                    Count--;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 复制堆栈到一个新的数组中
            /// </summary>
            /// <returns>返回的数组</returns>
            public object[] ToArray()
            {
                object[] ReturnTemp = null;
                if (0 < Count)
                {
                    ReturnTemp = new object[Count];
                    StackNode node = Top;
                    for (int i = 0; i < Count; i++)
                    {
                        ReturnTemp[i] = node.data;
                        node = node.Pre;
                    }
                }
                return ReturnTemp;
            }
        }
        /// <summary>
        /// 通用数据堆栈节点
        /// </summary>
        class StackNode
        {
            /// <summary>
            /// 堆栈节点数据
            /// </summary>
            public object data { get; private set; }
            /// <summary>
            /// 堆栈上一个
            /// </summary>
            public StackNode Pre { get; set; }

            /// <summary>
            /// 堆栈节点默认构造函数
            /// </summary>
            public StackNode() { data = null; }
            /// <summary>
            /// 堆栈节点构造函数重载+1
            /// </summary>
            /// <param name="obj">初始化参数</param>
            public StackNode(object obj) { data = obj; }
            /// <summary>
            /// 堆栈节点复制构造函数
            /// </summary>
            /// <param name="stackNode">复制元数据</param>
            public StackNode(StackNode stackNode) { data = stackNode.data; }
            /// <summary>
            /// 从内存中清除数据
            /// </summary>
            public void Destroy() { GC.Collect(); }
        }
    }
}

using MRsystem.Exception;
using System;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用数据堆栈
        /// </summary>
        /// <typeparam name="T">类型名（必须含有无参数的构造函数）</typeparam>
        public class IStack<T> where T : new()
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
            private IStackNode<T> Buttom;
            /// <summary>
            /// 堆栈栈顶
            /// </summary>
            private IStackNode<T> Top;

            /// <summary>
            /// 通用数据堆栈默认构造函数
            /// </summary>
            public IStack()
            {
                Buttom = new IStackNode<T>
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
            public IStack(int size) : this()
            {
                Size = size;
            }
            /// <summary>
            /// 通用数据堆栈复制构造函数
            /// </summary>
            /// <param name="stack">复制元数据</param>
            public IStack(IStack<T> stack) : this()
            {
                T[] temp = stack.ToArray();
                if(null != temp)
                {
                    IStack<T> temps = new IStack<T>();
                    foreach (T i in temp)
                        temps.Push(i);
                    temp = temps.ToArray();
                    foreach (T i in temp)
                        Push(i);
                }
            }
            /// <summary>
            /// 从堆栈中移除所有元素
            /// </summary>
            public void Clear()
            {
                IStackNode<T> node;
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
            /// <param name="t">查询数据</param>
            /// <returns>返回查询结果（false：数据不在堆栈中||true：数据在堆栈中）</returns>
            public bool Seek(T t)
            {
                bool ReturnTemp = false;
                IStackNode<T> stackNode = Top;
                while (null != stackNode.Pre && false == ReturnTemp)
                {
                    if (stackNode.Data.Equals(t))
                        ReturnTemp = true;
                    stackNode = stackNode.Pre;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 返回堆栈栈顶的元素（不删除栈顶元素）
            /// </summary>
            /// <returns>返回数据</returns>
            public T Peek()
            {
                return Top.Data;
            }
            /// <summary>
            /// 向堆栈顶部添加一个元素
            /// </summary>
            /// <param name="t">添加对象</param>
            /// <returns>返回添加状态</returns>
            public CollectionsError Push(T t)
            {
                CollectionsError error = CollectionsError.NO_ERROR;
                if (0 < Size)
                    if (Size <= Count)
                        error = CollectionsError.OUT_OF_BOUNDES;
                if (CollectionsError.NO_ERROR == error)
                {
                    IStackNode<T> stackNode = new IStackNode<T>(t);
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
            public T Pop()
            {
                T ReturnTemp = Top.Data;
                if (0 < Count)
                {
                    IStackNode<T> node = Top;
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
            public T[] ToArray()
            {
                T[] ReturnTemp = null;
                if (0 < Count)
                {
                    ReturnTemp = new T[Count];
                    IStackNode<T> node = Top;
                    for(int i = 0; i < Count; i++)
                    {
                        ReturnTemp[i] = node.Data;
                        node = node.Pre;
                    }
                }
                return ReturnTemp;
            }
        }
        /// <summary>
        /// 通用数据堆栈节点
        /// </summary>
        /// <typeparam name="T">类型名（必须含有无参数的构造函数）</typeparam>
        class IStackNode<T> where T : new()
        {
            /// <summary>
            /// 堆栈节点数据
            /// </summary>
            public T Data { get; private set; }
            /// <summary>
            /// 堆栈上一个
            /// </summary>
            public IStackNode<T> Pre { get; set; }

            /// <summary>
            /// 堆栈节点默认构造函数
            /// </summary>
            public IStackNode() { Data = default(T); }
            /// <summary>
            /// 堆栈节点构造函数+1
            /// </summary>
            /// <param name="t">初始化参数</param>
            public IStackNode(T t) { Data = t; }
            /// <summary>
            /// 堆栈节点复制构造函数
            /// </summary>
            /// <param name="stackNode">复制元数据</param>
            public IStackNode(IStackNode<T> stackNode) { Data = stackNode.Data; }
            /// <summary>
            /// 从内存中清除
            /// </summary>
            public void Destroy() { GC.Collect(); }
        }
    }
}

using MRsystem.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用数据队列
        /// </summary>
        /// <typeparam name="T">类型名（必须含有无参数的构造函数）</typeparam>
        public class IQueue<T> where T : new()
        {
            /// <summary>
            /// 获取队列中包含的元素个数
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// 队列限制大小
            /// </summary>
            private int Size { get; set; }
            /// <summary>
            /// 队列头
            /// </summary>
            private IQueueNode<T> HEAD;
            /// <summary>
            /// 队列尾
            /// </summary>
            private IQueueNode<T> END;

            /// <summary>
            /// 通用数据队列默认构造函数
            /// </summary>
            public IQueue()
            {
                HEAD = new IQueueNode<T>
                {
                    Next = null
                };
                END = HEAD;
                Size = -1;
                Count = 0;
            }
            /// <summary>
            /// 通用数据队列默认构造函数（设定初始化大小 | 超过限制大小则返回溢出）
            /// </summary>
            /// <param name="size"></param>
            public IQueue(int size) : this()
            {
                Size = size;
            }
            /// <summary>
            /// 通用数据队列复制构造函数
            /// </summary>
            /// <param name="queue">复制元数据</param>
            public IQueue(IQueue<T> queue) : this()
            {
                T[] temp = queue.ToArray();
                if (null != temp)
                    foreach (T i in temp)
                        Enqueue(i);
            }
            /// <summary>
            /// 从队列中移除所有元素
            /// </summary>
            public void Clear()
            {
                IQueueNode<T> node;
                while (0 < Count)
                {
                    node = HEAD.Next;
                    HEAD.Next = HEAD.Next.Next;
                    node.Destroy();
                    Count--;
                }
            }
            /// <summary>
            /// 查询某个元素是否在队列中
            /// </summary>
            /// <param name="t">查询数据</param>
            /// <returns>返回查询结果（false：数据不在队列中||true：数据在队列中）</returns>
            public bool Seek(T t)
            {
                bool ReturnTemp = false;
                IQueueNode<T> node = HEAD.Next;
                while (null != node && false == ReturnTemp)
                {
                    if (t.Equals(node.data))
                        ReturnTemp = true;
                    node = node.Next;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 向队列中添加一个元素
            /// </summary>
            /// <param name="t">添加元素</param>
            /// <returns>返回添加状态</returns>
            public CollectionsError Enqueue(T t)
            {
                CollectionsError error = CollectionsError.NO_ERROR;
                if (0 < Size)
                    if (Size <= Count)
                        error = CollectionsError.OUT_OF_BOUNDES;
                if (CollectionsError.NO_ERROR == error)
                {
                    IQueueNode<T> queueNode = new IQueueNode<T>(t)
                    {
                        Next = null
                    };
                    END.Next = queueNode;
                    END = END.Next;
                    Count++;
                }
                return error;
            }
            /// <summary>
            /// 返回队列队首的元素（不删除队首元素）
            /// </summary>
            /// <returns>队首元素</returns>
            public T Peek()
            {
                return HEAD.Next.data;
            }
            /// <summary>
            /// 返回并删除队首元素
            /// </summary>
            /// <returns>队首元素</returns>
            public T Dequeue()
            {
                IQueueNode<T> node = HEAD.Next;
                T ReturnTemp = default(T);
                if (0 < Count)
                {
                    ReturnTemp = node.data;
                    HEAD.Next = node.Next;
                    node.Destroy();
                    Count--;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 复制队列到一个新的数组中
            /// </summary>
            /// <returns>返回的数组</returns>
            public T[] ToArray()
            {
                T[] ReturnTemp = null;
                if (0 < Count)
                {
                    ReturnTemp = new T[Count];
                    IQueueNode<T> node = HEAD.Next;
                    for (int i = 0; i < Count; i++)
                    {
                        ReturnTemp[i] = node.data;
                        node = node.Next;
                    }
                }
                return ReturnTemp;
            }
        }
        /// <summary>
        /// 通用数据队列节点
        /// </summary>
        /// <typeparam name="T">类型名（必须含有无参数的构造函数）</typeparam>
        class IQueueNode<T> where T : new()
        {
            /// <summary>
            /// 通用数据队列节点数据
            /// </summary>
            public T data { get; private set; }
            /// <summary>
            /// 通用数据队列节点上一个
            /// </summary>
            public IQueueNode<T> Next { get; set; }

            /// <summary>
            /// 通用数据队列节点默认构造函数
            /// </summary>
            public IQueueNode() { data = default(T); }
            /// <summary>
            /// 通用数据队列节点构造函数重载+1
            /// </summary>
            /// <param name="t">初始化参数</param>
            public IQueueNode(T t) { data = t; }
            /// <summary>
            /// 通用数据队列节点复制构造函数
            /// </summary>
            /// <param name="queueNode">复制元数据</param>
            public IQueueNode(IQueueNode<T> queueNode) { data = queueNode.data; }
            /// <summary>
            /// 从内存中清除
            /// </summary>
            public void Destroy() { GC.Collect(); }
        }
    }
}

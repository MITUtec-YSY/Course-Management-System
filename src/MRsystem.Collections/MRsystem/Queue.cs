using MRsystem.Exception;
using System;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用数据队列
        /// </summary>
        public class Queue
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
            private QueueNode HEAD;
            /// <summary>
            /// 队列尾
            /// </summary>
            private QueueNode END;

            /// <summary>
            /// 通用数据队列默认构造函数
            /// </summary>
            public Queue()
            {
                HEAD = new QueueNode
                {
                    Next = null
                };
                END = HEAD;
                Size = -1;
                Count = 0;
            }
            /// <summary>
            /// 通用数据队列构造函数（指定队列长度 | 超出长度则返回异常）
            /// </summary>
            /// <param name="size">指定的队列长度</param>
            public Queue(int size) : this()
            {
                Size = size;
            }
            /// <summary>
            /// 通用数据队列复制构造函数
            /// </summary>
            /// <param name="queue">复制元数据</param>
            public Queue(Queue queue) : this()
            {
                object[] temp = queue.ToArray();
                if (null != temp)
                    foreach (object i in temp)
                        Enqueue(i);
            }
            /// <summary>
            /// 从队列中移除所有元素
            /// </summary>
            public void Clear()
            {
                QueueNode node;
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
            /// <param name="obj">查询数据</param>
            /// <returns>返回查询结果（false：数据不在队列中||true：数据在队列中）</returns>
            public bool Seek(object obj)
            {
                bool ReturnTemp = false;
                QueueNode node = HEAD.Next;
                while (null != node && false == ReturnTemp)
                {
                    if (obj.Equals(node.data))
                        ReturnTemp = true;
                    node = node.Next;
                }
                return ReturnTemp;
            }
            /// <summary>
            /// 向队列中添加一个元素
            /// </summary>
            /// <param name="obj">添加元素</param>
            /// <returns>返回添加状态</returns>
            public CollectionsError Enqueue(object obj)
            {
                CollectionsError error = CollectionsError.NO_ERROR;
                if (0 < Size)
                    if (Size <= Count)
                        error = CollectionsError.OUT_OF_BOUNDES;
                if (CollectionsError.NO_ERROR == error)
                {
                    QueueNode queueNode = new QueueNode(obj)
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
            public object Peek()
            {
                return HEAD.Next.data;
            }
            /// <summary>
            /// 返回并删除队首元素
            /// </summary>
            /// <returns>队首元素</returns>
            public object Dequeue()
            {
                QueueNode node = HEAD.Next;
                object ReturnTemp = null;
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
            public object[] ToArray()
            {
                object[] ReturnTemp = null;
                if (0 < Count)
                {
                    ReturnTemp = new object[Count];
                    QueueNode node = HEAD.Next;
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
        class QueueNode
        {
            /// <summary>
            /// 通用数据队列节点数据
            /// </summary>
            public object data { get; private set; }
            /// <summary>
            /// 通用数据队列节点上一个
            /// </summary>
            public QueueNode Next { get; set; }

            /// <summary>
            /// 通用数据队列节点默认构造函数
            /// </summary>
            public QueueNode() { data = null; }
            /// <summary>
            /// 通用数据队列节点构造函数重载+1
            /// </summary>
            /// <param name="obj">初始化参数</param>
            public QueueNode(object obj) { data = obj; }
            /// <summary>
            /// 通用数据队列节点复制构造函数
            /// </summary>
            /// <param name="queueNode">复制元数据</param>
            public QueueNode(QueueNode queueNode) { data = queueNode.data; }
            /// <summary>
            /// 从内存中清除
            /// </summary>
            public void Destroy() { GC.Collect(); }
        }
    }
}

using MRsystem.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用数据表单
        /// </summary>
        public class List
        {
            /// <summary>
            /// 获取通用数据表单中的元素个数
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// 获取通用数据表单的设定大小
            /// </summary>
            public int Capacity { get; set; }
            /// <summary>
            /// 获取表单大小是否固定
            /// </summary>
            public bool IsConstSize { get; private set; }
            /// <summary>
            /// 获取表单是否只读
            /// </summary>
            public bool IsReadOnly { get; set; }
            /// <summary>
            /// 表单头
            /// </summary>
            private ListNode Head;
            /// <summary>
            /// 表单尾
            /// </summary>
            private ListNode End;

            /// <summary>
            /// 通用数据表单默认构造函数
            /// </summary>
            public List()
            {
                Head = new ListNode
                {
                    Next = null
                };
                End = Head;
                Capacity = 0;
                Count = 0;
                IsConstSize = false;
                IsReadOnly = false;
            }
            /// <summary>
            /// 通用数据表单构造函数重载+1
            /// </summary>
            /// <param name="size">数据表单初始化大小</param>
            public List(int size) : this()
            {
                Capacity = size;
                for(int i = 0; i < size; i++)
                {
                    ListNode listNode = new ListNode();
                    End.Next = listNode;
                    listNode.Next = null;
                    Count++;
                }
            }
            /// <summary>
            /// 通用数据表单复制构造函数
            /// </summary>
            /// <param name="list">复制元数据</param>
            public List(List list)
            {
                Head = new ListNode
                {
                    Next = null
                };
                End = Head;
                Count = 0;
                ListNode listNode = list.Head.Next;
                while (null != listNode)
                {
                    Add(listNode.data);
                    listNode = listNode.Next;
                }
            }
            /// <summary>
            /// 向表单尾部添加元素
            /// </summary>
            /// <param name="obj">添加的元素</param>
            /// <returns>返回添加状态（true：添加成功||false：添加失败[表单只读或大小固定]）</returns>
            public CollectionsError Append(object obj)
            {
                CollectionsError Flag = CollectionsError.NO_ERROR;
                if (!IsReadOnly)
                {
                    if (Count == Capacity)
                        if (IsConstSize)
                            Flag = CollectionsError.OUT_OF_BOUNDES;
                        else
                            Capacity++;
                    if (CollectionsError.NO_ERROR == Flag)
                    {
                        ListNode listNode = new ListNode(obj);
                        End.Next = listNode;
                        listNode.Next = null;
                        Count++;
                    }
                }
                else
                    Flag = CollectionsError.READ_ONLY;
                return Flag;
            }
            /// <summary>
            /// 向表单中添加数据（根据哈希值进行插入）
            /// </summary>
            /// <param name="obj">插入的元素</param>
            /// <returns>返回添加状态（true：添加成功||false：添加失败[表单只读或大小固定]）</returns>
            public CollectionsError Add(object obj)
            {
                CollectionsError Flag = CollectionsError.NO_ERROR;
                if (!IsReadOnly)
                {
                    if (Count == Capacity)
                        if (IsConstSize)
                            Flag = CollectionsError.OUT_OF_BOUNDES;
                        else
                            Capacity++;
                    if (CollectionsError.NO_ERROR == Flag)
                    {
                        ListNode listNode = new ListNode(obj);
                        ListNode node = Head;
                        while (null != node.Next)
                        {
                            if (0 < node.Next.data.GetHashCode().CompareTo(obj.GetHashCode()))
                            {
                                listNode.Next = node.Next.Next;
                                node.Next = listNode;
                                break;
                            }
                            node = node.Next;
                        }
                        if (null == node.Next)
                        {
                            node.Next = listNode;
                            listNode.Next = null;
                            End = listNode;
                        }
                        Count++;
                    }
                }
                else
                    Flag = CollectionsError.READ_ONLY;
                return Flag;
            }
            /// <summary>
            /// 向表单中指定位置添加数据
            /// </summary>
            /// <param name="obj">插入的元素</param>
            /// <param name="index">插入元素的位置</param>
            /// <returns>返回添加状态（true：添加成功||false：添加失败[表单只读或大小固定]）</returns>
            public CollectionsError Add(object obj, int index)
            {
                CollectionsError Flag = CollectionsError.NO_ERROR;
                if (!IsReadOnly)
                {
                    if (Count == Capacity)
                        if (IsConstSize)
                            Flag = CollectionsError.OUT_OF_BOUNDES;
                        else
                            Capacity++;
                    if (CollectionsError.NO_ERROR == Flag)
                    {
                        ListNode listNode = new ListNode(obj);
                        ListNode node = Head;
                        if (index >= Count)
                            Flag = CollectionsError.OUT_OF_BOUNDES;
                        else
                        {
                            for (int i = 0; i < index; i++)
                                node = node.Next;
                            listNode.Next = node.Next.Next;
                            node.Next = listNode;
                        }
                        Count++;
                    }
                }
                else
                    Flag = CollectionsError.READ_ONLY;
                return Flag;
            }
            /// <summary>
            /// 清空表单中的所有数据
            /// </summary>
            public void Clear()
            {
                ListNode node = Head.Next;
                for (int i=0; i < Count; i++)
                {
                    Head.Next = node.Next;
                    node.Destroy();
                    node = Head.Next;
                }
                Count = 0;
                End = Head;
                Head.Next = null;
            }
            /// <summary>
            /// 判断指定元素是否存在于表单中
            /// </summary>
            /// <param name="obj">查询的元素</param>
            /// <returns>查询结果（true：元素在表单中||false：元素不在表单中）</returns>
            public bool Seek(object obj)
            {
                bool Flag = false;
                ListNode listNode = Head.Next;
                while (!Flag && null != listNode)
                {
                    if (obj.GetHashCode().Equals(listNode.GetHashCode()))
                        Flag = true;
                    listNode = listNode.Next;
                }
                return Flag;
            }
            /// <summary>
            /// 获取指定元素的索引
            /// </summary>
            /// <param name="obj">查询的元素</param>
            /// <returns>返回元素索引（-1为无法找到元素）</returns>
            public int GetIndex(object obj)
            {
                int index = 0;
                if (Seek(obj))
                {
                    ListNode listNode = Head.Next;
                    while (null != listNode)
                    {
                        if (obj.GetHashCode().Equals(listNode.GetHashCode()))
                            break;
                        listNode = listNode.Next;
                        index++;
                    }
                }
                else
                    index = -1;
                return index;
            }
            /// <summary>
            /// 删除表单中的指定元素
            /// </summary>
            /// <param name="obj">删除的元素</param>
            public void Del(object obj)
            {
                ListNode nodeList = Head;
                while (null != nodeList.Next)
                {
                    if (obj.GetHashCode().Equals(nodeList.Next.GetHashCode()))
                    {
                        ListNode node = nodeList.Next;
                        nodeList.Next = node.Next;
                        node.Destroy();
                        Count--;
                    }
                    nodeList = nodeList.Next;
                }
                End = nodeList;
            }
            /// <summary>
            /// 删除指定索引的元素
            /// </summary>
            /// <param name="index">删除元素的索引</param>
            public void Del(int index)
            {
                if (0 <= index)
                {
                    if (index < Count)
                    {
                        ListNode listNode = Head;
                        int i = 0;
                        while (null != listNode.Next)
                        {
                            if (i == index)
                            {
                                ListNode node = listNode.Next;
                                listNode.Next = node.Next;
                                node.Destroy();
                                Count--;
                            }
                            i++;
                            listNode = listNode.Next;
                        }
                        End = listNode;
                    }
                    throw new CollectionsException("表单上边界溢出");
                }
                throw new CollectionsException("参数值不在允许值范围之内");
            }
            /// <summary>
            /// 设置表单的容量
            /// </summary>
            /// <param name="size">表单容量</param>
            /// <param name="isconst">表单大小是否可变</param>
            public void SetSize(int size, bool isconst)
            {
                if (size < Count)
                {
                    if (isconst)
                    {
                        ListNode node = Head;
                        for (int i = 0; i < size; i++)
                            node = node.Next;
                        End = node;
                        End.Next = null;
                        while (null != node)
                        {
                            ListNode list = node;
                            node = node.Next;
                            list.Destroy();
                            Count--;
                        }
                    }
                }
                IsConstSize = isconst;
                Capacity = size;
            }
            /// <summary>
            /// 通用数据表单索引器
            /// </summary>
            /// <param name="index">索引值</param>
            /// <returns>表单索引对应数据</returns>
            public object this[int index]
            {
                get
                {
                    object ReturnTemp = null;
                    if (index < Count)
                    {
                        ListNode node = Head.Next;
                        for (int i = 0; i < index; i++)
                            node = node.Next;
                        ReturnTemp = node.data;
                    }
                    else
                        throw new CollectionsException("表单上边界溢出");
                    return ReturnTemp;
                }

                set
                {
                    if (index < Count)
                    {
                        ListNode node = Head.Next;
                        for (int i = 0; i < index; i++)
                            node = node.Next;
                        node.data = value;
                    }
                    else
                        throw new CollectionsException("表单上边界溢出");
                }
            }
        }
        /// <summary>
        /// 通用数据表单节点
        /// </summary>
        class ListNode
        {
            /// <summary>
            /// 节点数据
            /// </summary>
            public object data { get; internal set; }
            /// <summary>
            /// 指向下一节点
            /// </summary>
            public ListNode Next { get; set; }

            /// <summary>
            /// 通用数据表单节点默认构造函数
            /// </summary>
            public ListNode() { data = null; }
            /// <summary>
            /// 通用数据表单构造函数重载+1
            /// </summary>
            /// <param name="obj">初始化数据</param>
            public ListNode(object obj) { data = obj; }
            /// <summary>
            /// 通用数据表单复制构造函数
            /// </summary>
            /// <param name="listNode"></param>
            public ListNode(ListNode listNode) { data = listNode.data; }
            /// <summary>
            /// 内存回收器
            /// </summary>
            public void Destroy() { GC.Collect(); }
        }
    }
}

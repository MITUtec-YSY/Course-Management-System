using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManageSystem.Teachers
{
    /// <summary>
    /// 教师数据结构体
    /// </summary>
    public struct TeacherPackage
    {
        /// <summary>
        /// 教师工号
        /// </summary>
        public string ID;
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string Name;
    }
    /// <summary>
    /// 教师二叉树节点
    /// </summary>
    public class TeacherNode
    {
        /// <summary>
        /// 教师工号
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// 二叉树左孩子
        /// </summary>
        public TeacherNode lChild;
        /// <summary>
        /// 二叉树右孩子
        /// </summary>
        public TeacherNode rChild;

        /// <summary>
        /// 教师二叉树节点构造函数
        /// </summary>
        /// <param name="id">教师编号</param>
        /// <param name="name">教师名字</param>
        public TeacherNode(string id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// 从内存中回收空间
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }

        /// <summary>
        /// 确定左值是否小于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator < (TeacherNode left, TeacherNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.ID.CompareTo(right.ID) < 0)
                        flag = true;
                    else
                        flag = false;
                }
                else
                    flag = false;
            }
            else
            {
                if (null != (object)right)
                    flag = true;
                else
                    flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 确定左值是否大于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >(TeacherNode left, TeacherNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.ID.CompareTo(right.ID) > 0)
                        flag = true;
                    else
                        flag = false;
                }
                else
                    flag = true;
            }
            else
                flag = false;
            return flag;
        }
        /// <summary>
        /// 确定左值是否小于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator <=(TeacherNode left, TeacherNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 确定左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(TeacherNode left, TeacherNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 确定左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(TeacherNode left, TeacherNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 确定左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(TeacherNode left, TeacherNode right)
        {
            return !(left == right);
        }
        /// <summary>
        /// 确定指定对象是否等于当前对象（已重写）
        /// </summary>
        /// <param name="obj">指定对象</param>
        /// <returns>返回结果</returns>
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (null != obj)
            {
                if (GetType() == obj.GetType())
                    flag = (this == (TeacherNode)obj);
                else
                    flag = false;
            }
            else
                flag = false;
            return flag;
        }
        /// <summary>
        /// 作为重写的哈希函数
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// 教师二叉树
    /// </summary>
    public class TeacherTree
    {
        /// <summary>
        /// 教师数目
        /// </summary>
        public int Count { get; private set; }
        private TeacherNode Tree;    //教师二叉树

        /// <summary>
        /// 教师二叉树构造函数
        /// </summary>
        public TeacherTree()
        {
            Count = 0;
            Tree = null;
        }

        /// <summary>
        /// 向二叉树中添加一个节点
        /// </summary>
        /// <param name="id">节点教师编号</param>
        /// <param name="name">节点教师姓名</param>
        public void Add(string id, string name)
        {
            bool Equals = false;
            if (null == Tree)
            {
                Tree = new TeacherNode(id, name)
                {
                    lChild = null,
                    rChild = null,
                };
                Count++;
            }
            else
            {
                TeacherNode newNode = new TeacherNode(id, name)
                {
                    lChild = null,
                    rChild = null,
                };
                TeacherNode p = Tree, s = Tree;
                while (null != p)
                {
                    s = p;
                    if (p > newNode)
                        p = p.lChild;
                    else if (p < newNode)
                        p = p.rChild;
                    else
                    {
                        Equals = true;
                        break;
                    }
                }
                if (!Equals)
                {
                    if (s > newNode)
                        s.lChild = newNode;
                    else if (p < newNode)
                        s.rChild = newNode;
                    Count++;
                }
            }
        }
        /// <summary>
        /// 删除一个指定的节点
        /// </summary>
        /// <param name="id">删除节点的教师编号</param>
        public void Del(string id)
        {
            if (null != Tree)
            {
                bool Find = false;
                TeacherNode p = Tree, s = null;
                s = p;
                if (id == Tree.ID)
                {
                    if (null == Tree.lChild && null == Tree.rChild)
                    {
                        Tree.Destroy();
                        Tree = null;
                    }
                    else if (null == Tree.lChild)
                    {
                        Tree = Tree.rChild;
                        p.Destroy();
                    }
                    else if (null == Tree.rChild)
                    {
                        Tree = Tree.lChild;
                        p.Destroy();
                    }
                    else
                    {
                        Tree = Tree.lChild;
                        s = Tree;
                        while (null != s.rChild)
                            s = s.rChild;
                        s.rChild = p.rChild;
                        p.Destroy();
                    }
                    Count--;
                }
                else
                {
                    while (null != p)
                    {
                        if (id == p.ID)
                        {
                            Find = true;
                            break;
                        }
                        else
                        {
                            s = p;
                            if (id.CompareTo(p.ID) > 0)
                                p = p.rChild;
                            else
                                p = p.lChild;
                        }
                    }
                    if (Find)
                    {
                        if (null == p.lChild && null == p.rChild)
                        {
                            if (s.lChild == p)
                                s.lChild = null;
                            else
                                s.rChild = null;
                            p.Destroy();
                        }
                        else if (null == p.lChild)
                        {
                            if (s.lChild == p)
                                s.lChild = p.rChild;
                            else
                                s.rChild = p.rChild;
                            p.Destroy();
                        }
                        else if (null == p.rChild)
                        {
                            if (s.lChild == p)
                                s.lChild = p.lChild;
                            else
                                s.rChild = p.lChild;
                            p.Destroy();
                        }
                        else
                        {
                            if (s.lChild == p)
                                s.lChild = p.lChild;
                            else
                                s.rChild = p.lChild;
                            s = p.lChild;
                            while (null != s.rChild)
                                s = s.rChild;
                            s.rChild = p.rChild;
                            p.Destroy();
                        }
                        Count--;
                    }
                }
            }
        }
        /// <summary>
        /// 查询指定教师
        /// </summary>
        /// <param name="id">查询的教师编号</param>
        /// <returns>返回教师姓名</returns>
        public string Search(string id)
        {
            string name = null;
            TeacherNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    name = p.Name;
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return name;
        }
        /// <summary>
        /// 修改指定教师的教师编号
        /// </summary>
        /// <param name="id">指定的教师</param>
        /// <param name="idn">新的教师编号</param>
        public void Edit(string id, string idn)
        {
            string name = Search(id);
            if (null != name)
            {
                Del(id);
                Add(idn, name);
            }
        }
        /// <summary>
        /// 修改指定教师的姓名
        /// </summary>
        /// <param name="id">指定的教师编号</param>
        /// <param name="name">修改的名字</param>
        /// <param name="flag">区分标识</param>
        public void Edit(string id, string name, bool flag)
        {
            TeacherNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    p.Name = name;
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }

        /// <summary>
        /// 获取所有老师数据
        /// </summary>
        /// <returns>老师组</returns>
        public TeacherPackage[] GetTeachers()
        {
            TeacherPackage[] teachers = null;
            if (0 < Count)
            {
                teachers = new TeacherPackage[Count];
                TeacherNode[] stack = new TeacherNode[Count];
                TeacherNode p = Tree;
                int i = 0, top = -1;
                if (null != Tree)
                {
                    do
                    {
                        while (null != p)
                        {
                            stack[++top] = p;
                            p = p.lChild;
                        }
                        p = stack[top--];
                        teachers[i++] = new TeacherPackage
                        {
                            ID = p.ID,
                            Name = p.Name,
                        };
                        p = p.rChild;
                    } while (-1 != top || null != p);
                }
            }
            return teachers;
        }
        /// <summary>
        /// 通过索引器读取或修改指定教师的姓名
        /// </summary>
        /// <param name="id">教师编号</param>
        /// <returns>返沪教师姓名</returns>
        public string this[string id]
        {
            get { return Search(id); }
            set { Edit(id, value, true); }
        }
    }
}

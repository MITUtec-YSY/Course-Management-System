using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManageSystem.Students
{
    /// <summary>
    /// 学生课程数据包
    /// </summary>
    public struct StudentClassPackage
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Class;
        /// <summary>
        /// 老师工号
        /// </summary>
        public string Teacher;
        /// <summary>
        /// 课程得分
        /// </summary>
        public float Score;
    }
    /// <summary>
    /// 学生数据包
    /// </summary>
    public struct StudentPackage
    {
        /// <summary>
        /// 学生学号
        /// </summary>
        public string ID;
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name;
        /// <summary>
        /// 学生年级
        /// </summary>
        public int Grade;
        /// <summary>
        /// 学生专业
        /// </summary>
        public string Major;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int College;
        /// <summary>
        /// 学生课程组
        /// </summary>
        public StudentClassPackage[] Classes;
    }
    /// <summary>
    /// 课程表节点
    /// </summary>
    public class TimeTableNode
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Class { get; internal set; }
        /// <summary>
        /// 教师工号
        /// </summary>
        public string Teacher { get; internal set; }
        /// <summary>
        /// 课程分数
        /// </summary>
        public float Score { get; internal set; }
        /// <summary>
        /// 下一个课程
        /// </summary>
        public TimeTableNode Next;

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
        public static bool operator <(TimeTableNode left, TimeTableNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.Class.CompareTo(right.Class) < 0)
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
        public static bool operator >(TimeTableNode left, TimeTableNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.Class.CompareTo(right.Class) > 0)
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
        public static bool operator <=(TimeTableNode left, TimeTableNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 确定左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(TimeTableNode left, TimeTableNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 确定左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(TimeTableNode left, TimeTableNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 确定左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(TimeTableNode left, TimeTableNode right)
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
                    flag = (this == (TimeTableNode)obj);
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
    /// 学生二叉树节点
    /// </summary>
    public class StudentNode
    {
        /// <summary>
        /// 学生学号
        /// </summary>
        public string ID { get; internal set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// 学生年级
        /// </summary>
        public int Grade { get; internal set; }
        /// <summary>
        /// 学生专业
        /// </summary>
        public string Major { get; internal set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        public int College { get; internal set; }
        /// <summary>
        /// 学生课程数
        /// </summary>
        public int ClassNum { get; private set; }
        /// <summary>
        /// 学生二叉树左孩子
        /// </summary>
        public StudentNode lChild;
        /// <summary>
        /// 学生二叉树右孩子
        /// </summary>
        public StudentNode rChild;
        private TimeTableNode Schedule;   //学生课程表

        /// <summary>
        /// 学生二叉树节点构造函数
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="name">学生姓名</param>
        /// <param name="grade">学生年级</param>
        /// <param name="major">学生专业</param>
        /// <param name="college">学院编号</param>
        public StudentNode(string id, string name, int grade, string major, int college)
        {
            ID = id;
            Name = name;
            Grade = grade;
            Major = major;
            College = college;
            ClassNum = 0;
            Schedule = new TimeTableNode
            {
                Class = null,
                Teacher = null,
                Score = 0,
                Next = null,
            };
        }
        
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="classID">课程编号</param>
        /// <param name="teacher">教师工号</param>
        /// <returns>返回添加结果</returns>
        public string AddClass(string classID, string teacher)
        {
            TimeTableNode node = new TimeTableNode
            {
                Class = classID,
                Teacher = teacher,
                Score = 0,
                Next = null,
            };
            TimeTableNode p = Schedule;
            while (null != p.Next)
            {
                if (p.Next > node)
                    break;
                else if (p.Next == node)
                    return "课程已经添加";
                p = p.Next;
            }
            node.Next = p.Next;
            p.Next = node;
            ClassNum++;
            return "课程添加成功";
        }
        /// <summary>
        /// 删除指定课程
        /// </summary>
        /// <param name="classID">课程编号</param>
        public void DelClass(string classID)
        {
            TimeTableNode p = Schedule;
            while (null != p.Next)
            {
                if (p.Next.Class == classID)
                {
                    TimeTableNode pp = p.Next;
                    p.Next = p.Next.Next;
                    pp.Destroy();
                    ClassNum--;
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 修改课程成绩
        /// </summary>
        /// <param name="classID">指定课程编号</param>
        /// <param name="score">课程成绩</param>
        public void Edit(string classID, float score)
        {
            TimeTableNode p = Schedule;
            while (null != p.Next)
            {
                if (p.Next.Class == classID)
                {
                    p.Next.Score = score;
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 查询指定课程数据
        /// </summary>
        /// <param name="classID">指定的课程编号</param>
        /// <returns>返回课程数据包</returns>
        public StudentClassPackage SeachClass(string classID)
        {
            StudentClassPackage package = new StudentClassPackage
            {
                Class = null,
                Teacher = null,
                Score = 0,
            };
            TimeTableNode p = Schedule;
            while (null != p.Next)
            {
                if (p.Next.Class == classID)
                {
                    package.Class = p.Next.Class;
                    package.Teacher = p.Next.Teacher;
                    package.Score = p.Next.Score;
                    break;
                }
                p = p.Next;
            }
            return package;
        }

        /// <summary>
        /// 获取学生的所有课程
        /// </summary>
        /// <returns>返回课程组</returns>
        public StudentClassPackage[] GetClasses()
        {
            StudentClassPackage[] packages = null;
            if (0 < ClassNum)
            {
                packages = new StudentClassPackage[ClassNum];
                TimeTableNode p = Schedule;
                int i = 0;
                while (null != p.Next)
                {
                    packages[i++] = new StudentClassPackage
                    {
                        Class = p.Next.Class,
                        Teacher = p.Next.Teacher,
                        Score = p.Next.Score,
                    };
                    p = p.Next;
                }
            }
            return packages;
        }

        /// <summary>
        /// 从内存中销毁
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
        public static bool operator <(StudentNode left, StudentNode right)
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
        public static bool operator >(StudentNode left, StudentNode right)
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
        public static bool operator <=(StudentNode left, StudentNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 确定左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(StudentNode left, StudentNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 确定左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(StudentNode left, StudentNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 确定左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(StudentNode left, StudentNode right)
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
                    flag = (this == (StudentNode)obj);
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
    /// 学生二叉树
    /// </summary>
    public class StudentTree
    {
        /// <summary>
        /// 学生数目
        /// </summary>
        public int Count { get; private set; }
        private StudentNode Tree;   //学生二叉树

        /// <summary>
        /// 学生二叉树构造函数
        /// </summary>
        public StudentTree()
        {
            Count = 0;
            Tree = null;
        }

        /// <summary>
        /// 向二叉树中添加一个节点
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="name">学生姓名</param>
        /// <param name="grade">学生年级</param>
        /// <param name="major">学生专业</param>
        /// <param name="college">学院编号</param>
        public void Add(string id, string name, int grade, string major, int college)
        {
            bool Equals = false;
            if (null == Tree)
            {
                Tree = new StudentNode(id, name, grade, major, college)
                {
                    lChild = null,
                    rChild = null,
                };
                Count++;
            }
            else
            {
                StudentNode newNode = new StudentNode(id, name, grade, major, college)
                {
                    lChild = null,
                    rChild = null,
                };
                StudentNode p = Tree, s = Tree;
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
        /// <param name="id">删除节点的学生学号</param>
        public void Del(string id)
        {
            if (null != Tree)
            {
                bool Find = false;
                StudentNode p = Tree, s = null;
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
        /// 查询指定学生
        /// </summary>
        /// <param name="id">查询的学生学号</param>
        /// <returns>返回学生数据包</returns>
        public StudentPackage Search(string id)
        {
            StudentPackage package = new StudentPackage
            {
                ID = null,
                Name = null,
                Grade = -1,
                Major = null,
                Classes = null,
            };
            StudentNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    package.ID = p.ID;
                    package.Name = p.Name;
                    package.Grade = p.Grade;
                    package.Major = p.Major;
                    package.College = p.College;
                    package.Classes = p.GetClasses();
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return package;
        }
        /// <summary>
        /// 修改指定学生姓名
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="name">学生姓名</param>
        public void Edit(string id, string name)
        {
            StudentNode p = Tree;
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
        /// 修改指定学生年级
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="grade">学生年级</param>
        public void Edit(string id, int grade)
        {
            StudentNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    p.Grade = grade;
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改指定学生专业
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="major">学生专业</param>
        /// <param name="college">学院编号</param>
        public void Edit(string id, string major, int college)
        {
            StudentNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    p.Major = major;
                    p.College = college;
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }

        /// <summary>
        /// 向指定学生添加课程
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="classID">课程编号</param>
        /// <param name="teacher">教师工号</param>
        /// <returns>返回添加状态</returns>
        public string AddClass(string id, string classID, string teacher)
        {
            StudentNode p = Tree;
            string result = "没有学生记录";
            while (null != p)
            {
                if (id == p.ID)
                {
                    result = p.AddClass(classID, teacher);
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return result;
        }
        /// <summary>
        /// 删除指定学生的指定课程
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="classID">课程编号</param>
        public void DelClass(string id, string classID)
        {
            StudentNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    p.DelClass(classID);
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改指定学生成绩
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <param name="classID">课程编号</param>
        /// <param name="score">成绩分数</param>
        public void Edit(string id, string classID, float score)
        {
            StudentNode p = Tree;
            while (null != p)
            {
                if (id == p.ID)
                {
                    p.Edit(classID, score);
                    break;
                }
                else if (id.CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 批量化修改学生成绩
        /// </summary>
        /// <param name="id">学生学号数组</param>
        /// <param name="classID">课程编号</param>
        /// <param name="score">学生成绩数组</param>
        public void Edit(string[] id, string classID, float[] score)
        {
            StudentNode p = Tree;
            StudentNode[] nodes = new StudentNode[Count];
            int Num = 0, i = 0;
            while (null != p)
            {
                if (id[i] == p.ID)
                {
                    nodes[Num++] = p;
                    i++;
                }
                else if (id[i].CompareTo(p.ID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
                if (id.Length <= i)
                    break;
            }
            for (i = 0; i < Num; i++)
                nodes[i].Edit(classID, score[i]);
        }

        /// <summary>
        /// 获取所有学生的数据
        /// </summary>
        /// <returns>返回学生数据组</returns>
        public StudentPackage[] GetStudents()
        {
            StudentPackage[] students = null;
            if (0 < Count)
            {
                students = new StudentPackage[Count];
                StudentNode[] stack = new StudentNode[Count];
                StudentNode p = Tree;
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
                        students[i++] = new StudentPackage
                        {
                            ID = p.ID,
                            Name = p.Name,
                            Grade = p.Grade,
                            Major = p.Major,
                            College = p.College,
                            Classes = p.GetClasses(),
                        };
                        p = p.rChild;
                    } while (-1 != top || null != p);
                }
            }
            return students;
        }
        /// <summary>
        /// 通过所引起获取指定学生的数据
        /// </summary>
        /// <param name="id">学生学号</param>
        /// <returns>学生数据包</returns>
        public StudentPackage this[string id]
        {
            get { return Search(id); }
        }
    }
}

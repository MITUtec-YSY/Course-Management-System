using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRsystem.Collections;

namespace ClassManageSystem.Classes
{
    /// <summary>
    /// 课程基本数据包
    /// </summary>
    public struct ClassPackageBase
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string ClassID;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string ClassName;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string Introduction;
        /// <summary>
        /// 课程年级
        /// </summary>
        public int ClassGrade;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int ClassCollege;
        /// <summary>
        /// 教师工号
        /// </summary>
        public string TeacherID;
        /// <summary>
        /// 教师名字
        /// </summary>
        public string TeacherName;
        /// <summary>
        /// 课程学分
        /// </summary>
        public float Credit;
        /// <summary>
        /// 课程容量
        /// </summary>
        public int ClassMax;
        /// <summary>
        /// 当前容量
        /// </summary>
        public int Selection;
    }
    /// <summary>
    /// 课程数据包
    /// </summary>
    public struct ClassPackage
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string ClassID;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string ClassName;
        /// <summary>
        /// 课程年级
        /// </summary>
        public int ClassGrade;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int ClassCollege;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string Introduction;
        /// <summary>
        /// 课程学分
        /// </summary>
        public float Credit;
        /// <summary>
        /// 课程容量
        /// </summary>
        public int ClassMax;
        /// <summary>
        /// 课程教师数据
        /// </summary>
        public TeachersPackage[] Teachers;
    }
    /// <summary>
    /// 课程教师数据包
    /// </summary>
    public struct TeachersPackage
    {
        /// <summary>
        /// 教师工号
        /// </summary>
        public string TeacherID;
        /// <summary>
        /// 学生学号组
        /// </summary>
        public string[] Students;
    }
    /// <summary>
    /// 广义表学生链
    /// </summary>
    public class StudentsLink
    {
        /// <summary>
        /// 学生学号
        /// </summary>
        public string StudentID;
        /// <summary>
        /// 下一个学生节点
        /// </summary>
        public StudentsLink Next;

        /// <summary>
        /// 从内存中销毁对象
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }
    }
    /// <summary>
    /// 广义表教师链
    /// </summary>
    public class TeachersLink
    {
        /// <summary>
        /// 教师工号
        /// </summary>
        public string TeacherID { get; private set; }
        /// <summary>
        /// 学生数
        /// </summary>
        public int StudentNum { get; private set; }
        /// <summary>
        /// 下一个教师节点
        /// </summary>
        public TeachersLink Next;
        private StudentsLink StudentsLink;   //学生链表

        /// <summary>
        /// 教师广义表链节点构造函数
        /// </summary>
        /// <param name="id">教师工号</param>
        public TeachersLink(string id)
        {
            TeacherID = id;
            StudentNum = 0;
            StudentsLink = new StudentsLink
            {
                StudentID = null,
                Next = null,
            };
        }

        /// <summary>
        /// 添加一个学生
        /// </summary>
        /// <param name="studentID">学生学号</param>
        public string AddStudent(string studentID)
        {
            StudentsLink node = new StudentsLink
            {
                StudentID = studentID,
                Next = null,
            };
            StudentsLink p = StudentsLink;
            while (null != p.Next)
            {
                if (p.Next.StudentID.CompareTo(studentID) > 0)
                    break;
                else if (p.Next.StudentID == studentID)
                    return "添加失败 学生已选此门课";
                p = p.Next;
            }
            node.Next = p.Next;
            p.Next = node;
            StudentNum++;
            return "添加成功";
        }
        /// <summary>
        /// 删除一个学生
        /// </summary>
        /// <param name="studentID">学生学号</param>
        public void DelStudent(string studentID)
        {
            StudentsLink p = StudentsLink;
            while (null != p.Next)
            {
                if (p.Next.StudentID == studentID)
                {
                    StudentsLink pp = p.Next;
                    p.Next = p.Next.Next;
                    pp.Destroy();
                    StudentNum--;
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 获取所有的学生
        /// </summary>
        /// <returns>返回学生学号组</returns>
        public string[] GetStudents()
        {
            string[] vs = null;
            if (0 < StudentNum)
            {
                vs = new string[StudentNum];
                int i = 0;
                StudentsLink p = StudentsLink;
                while (null != p.Next)
                {
                    vs[i++] = p.Next.StudentID;
                    p = p.Next;
                }
            }
            return vs;
        }
        /// <summary>
        /// 查找一个学生是否存在
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <returns>返回查询结果</returns>
        public bool SearchStudent(string studentID)
        {
            StudentsLink p = StudentsLink;
            while (null != p.Next)
            {
                if (p.Next.StudentID.CompareTo(studentID) > 0)
                    break;
                else if (p.Next.StudentID == studentID)
                    return true;
                p = p.Next;
            }
            return false;
        }

        /// <summary>
        /// 从内存中销毁对象
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }
    }
    /// <summary>
    /// 课程二叉树节点
    /// </summary>
    public class ClassNode
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string ClassID { get; internal set; }
        /// <summary>
        /// 课程名字
        /// </summary>
        public string ClassName { get; internal set; }
        /// <summary>
        /// 课程年级
        /// </summary>
        public int ClassGrade { get; internal set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        public int ClassCollege { get; internal set; }
        /// <summary>
        /// 课程简介
        /// </summary>
        public string Introduction { get; internal set; }
        /// <summary>
        /// 课程学分
        /// </summary>
        public float Credit { get; internal set; }
        /// <summary>
        /// 课程授课教师数目
        /// </summary>
        public int TeacherNum { get; internal set; }
        /// <summary>
        /// 单个老师最大支持学生数
        /// </summary>
        public int ClassMax { get; internal set; }
        /// <summary>
        /// 二叉树左孩子
        /// </summary>
        public ClassNode lChild;
        /// <summary>
        /// 二叉树右孩子
        /// </summary>
        public ClassNode rChild;
        private TeachersLink TeachersLink;   //老师链表

        /// <summary>
        /// 课程二叉树节点构造函数
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="name">课程名称</param>
        /// <param name="grade">课程年级</param>
        /// <param name="college">课程编号</param>
        /// <param name="introduct">课程简介</param>
        /// <param name="credit">课程学分</param>
        /// <param name="max">课程最大容量</param>
        public ClassNode(string id, string name, int grade, int college, string introduct, float credit, int max)
        {
            ClassID = id;
            ClassName = name;
            ClassGrade = grade;
            ClassCollege = college;
            Introduction = introduct;
            Credit = credit;
            ClassMax = max;
            TeacherNum = 0;
            TeachersLink = new TeachersLink(null)
            {
                Next = null,
            };
        }

        /// <summary>
        /// 添加一个教师
        /// </summary>
        /// <param name="id">教师工号</param>
        public void AddTeacher(string id)
        {
            TeachersLink node = new TeachersLink(id)
            {
                Next = null,
            };
            TeachersLink p = TeachersLink;
            while (null != p.Next)
            {
                if (p.Next.TeacherID.CompareTo(id) > 0)
                    break;
                else if (p.Next.TeacherID == id)
                    return;
                p = p.Next;
            }
            node.Next = p.Next;
            p.Next = node;
            TeacherNum++;
        }
        /// <summary>
        /// 删除一个教师
        /// </summary>
        /// <param name="id">教师工号</param>
        public void DelTeacher(string id)
        {
            TeachersLink p = TeachersLink;
            while (null != p.Next)
            {
                if (p.Next.TeacherID == id)
                {
                    TeachersLink pp = p.Next;
                    p.Next = p.Next.Next;
                    pp.Destroy();
                    TeacherNum--;
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 获取该课程的所有教师
        /// </summary>
        /// <returns>返回教师组</returns>
        public string[] GetTeachers()
        {
            string[] vs = null;
            if (0 < TeacherNum)
            {
                vs = new string[TeacherNum];
                TeachersLink p = TeachersLink;
                int i = 0;
                while (null != p.Next)
                {
                    vs[i++] = p.Next.TeacherID;
                    p = p.Next;
                }
            }
            return vs;
        }

        /// <summary>
        /// 向指定教师添加学生
        /// </summary>
        /// <param name="teacherID">教师工号</param>
        /// <param name="studentID">学生学号</param>
        public string AddStudent(string teacherID, string studentID)
        {
            string result = "选课成功";
            TeachersLink p = TeachersLink;
            bool Find = false;
            while (null != p.Next && !Find)
            {
                Find = p.Next.SearchStudent(studentID);
                p = p.Next;
            }
            if (!Find)
            {
                p = TeachersLink;
                while (null != p.Next)
                {
                    if (p.Next.TeacherID == teacherID)
                    {
                        if (ClassMax <= p.Next.StudentNum)
                            result = "课程已满 选课失败";
                        else
                            p.Next.AddStudent(studentID);
                        break;
                    }
                    p = p.Next;
                }
            }
            else
                result = "选课失败 学生已选此门课";
            return result;
        }
        /// <summary>
        /// 从指定教师中删除学生
        /// </summary>
        /// <param name="teacherID">教师工号</param>
        /// <param name="studentID">学生学号</param>
        public void DelStudent(string teacherID, string studentID)
        {
            TeachersLink p = TeachersLink;
            while (null != p.Next)
            {
                if (p.Next.TeacherID == teacherID)
                {
                    p.Next.DelStudent(studentID);
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 获取指定教师的全部学生
        /// </summary>
        /// <param name="teacherID">教师工号</param>
        /// <returns>返回学生组</returns>
        public string[] GetStudents(string teacherID)
        {
            string[] vs = null;
            TeachersLink p = TeachersLink;
            while (null != p.Next)
            {
                if (p.Next.TeacherID == teacherID)
                {
                    vs = p.Next.GetStudents();
                    break;
                }
                p = p.Next;
            }
            return vs;
        }

        /// <summary>
        /// 获取该课程的全部教学信息
        /// </summary>
        /// <returns>返回课程教师数据包</returns>
        public TeachersPackage[] GetPackages()
        {
            TeachersPackage[] packages = null;
            if (0 < TeacherNum)
            {
                packages = new TeachersPackage[TeacherNum];
                int i = 0;
                TeachersLink p = TeachersLink;
                while (null != p.Next)
                {
                    packages[i++] = new TeachersPackage
                    {
                        TeacherID = p.Next.TeacherID,
                        Students = p.Next.GetStudents(),
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
        public static bool operator <(ClassNode left, ClassNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.ClassID.CompareTo(right.ClassID) < 0)
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
        public static bool operator >(ClassNode left, ClassNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.ClassID.CompareTo(right.ClassID) > 0)
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
        public static bool operator <=(ClassNode left, ClassNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 确定左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(ClassNode left, ClassNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 确定左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(ClassNode left, ClassNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 确定左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(ClassNode left, ClassNode right)
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
                    flag = (this == (ClassNode)obj);
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
    /// 课程二叉树
    /// </summary>
    public class ClassTree
    {
        /// <summary>
        /// 课程数目
        /// </summary>
        public int Count { get; private set; }
        private ClassNode Tree;   //课程二叉树

        /// <summary>
        /// 课程二叉树构造函数
        /// </summary>
        public ClassTree()
        {
            Count = 0;
            Tree = null;
        }

        /// <summary>
        /// 添加一个课程
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="name">课程名</param>
        /// <param name="grade">课程年级</param>
        /// <param name="college">学院编号</param>
        /// <param name="intrduct">课程简介</param>
        /// <param name="credit">课程学分</param>
        /// <param name="maxnum">课程最大容量</param>
        public void AddClass(string id, string name, int grade, int college, string intrduct, float credit, int maxnum)
        {
            bool Equals = false;
            if (null == Tree)
            {
                Tree = new ClassNode(id, name, grade, college, intrduct, credit, maxnum)
                {
                    lChild = null,
                    rChild = null,
                };
                Count++;
            }
            else
            {
                ClassNode newNode = new ClassNode(id, name, grade, college, intrduct, credit, maxnum)
                {
                    lChild = null,
                    rChild = null,
                };
                ClassNode p = Tree, s = Tree;
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
        /// <param name="id">删除节点的课程编号</param>
        public void Del(string id)
        {
            if (null != Tree)
            {
                bool Find = false;
                ClassNode p = Tree, s = null;
                s = p;
                if (id == Tree.ClassID)
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
                        if (id == p.ClassID)
                        {
                            Find = true;
                            break;
                        }
                        else
                        {
                            s = p;
                            if (id.CompareTo(p.ClassID) > 0)
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
        /// 修改课程名称
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="name">课程简介</param>
        /// <param name="flag">区分标识</param>
        public void EditClass(string id, string name, bool flag)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    p.ClassName = name;
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改课程简介
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="intr">课程简介</param>
        public void EditClass(string id, string intr)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    p.Introduction = intr;
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改课程最大容量
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="max">课程最大容量</param>
        public void EditClass(string id, int max)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    p.ClassMax = max;
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改课程学分
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="credit">课程学分</param>
        public void EditClass(string id, float credit)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    p.Credit = credit;
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 修改课程年级
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="grade">课程年级</param>
        /// <param name="college">学院编号</param>
        public void EditClass(string id, int grade, int college)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    p.ClassGrade = grade;
                    p.ClassCollege = college;
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 获取指定课程的课程数据
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程数据包</returns>
        public ClassPackage GetClass(string id)
        {
            ClassPackage package = new ClassPackage
            {
                ClassID = null,
                ClassName = null,
                Introduction = null,
                ClassMax = 0,
                Credit = 0,
                Teachers = null,
            };
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    package.ClassID = id;
                    package.ClassName = p.ClassName;
                    package.ClassGrade = p.ClassGrade;
                    package.ClassCollege = p.ClassCollege;
                    package.Introduction = p.Introduction;
                    package.Credit = p.Credit;
                    package.ClassMax = p.ClassMax;
                    package.Teachers = p.GetPackages();
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return package;
        }
        /// <summary>
        /// 获取指定课程的课程名称
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程名称</returns>
        public string GetClassName(string id)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                    return p.ClassName;
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return null;
        }
        /// <summary>
        /// 获取指定课程的课程学分
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程学分</returns>
        public float GetClassCredit(string id)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                    return p.Credit;
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return 0;
        }
        /// <summary>
        /// 获取指定课程的年级
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程年级</returns>
        public int GetClassGrade(string id)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                    return p.ClassGrade;
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return 0;
        }
        /// <summary>
        /// 获取指定课程的所属学院
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程年级</returns>
        public int GetClassCollege(string id)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                    return p.ClassCollege;
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return 0;
        }
        /// <summary>
        /// 获取指定课程的课程简介
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程简介</returns>
        public string GetClassIntroduct(string id)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                    return p.Introduction;
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return null;
        }
        /// <summary>
        /// 获取所有课程数据
        /// </summary>
        /// <returns>返回课程数据组</returns>
        public ClassPackage[] GetClasses()
        {
            ClassPackage[] packages = null;
            if (0 < Count)
            {
                packages = new ClassPackage[Count];
                ClassNode[] stack = new ClassNode[Count];
                ClassNode p = Tree;
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
                        packages[i++] = new ClassPackage
                        {
                            ClassID = p.ClassID,
                            ClassName = p.ClassName,
                            ClassGrade = p.ClassGrade,
                            ClassCollege = p.ClassCollege,
                            Introduction = p.Introduction,
                            Credit = p.Credit,
                            ClassMax = p.ClassMax,
                            Teachers = p.GetPackages(),
                        };
                        p = p.rChild;
                    } while (-1 != top || null != p);
                }
            }
            return packages;
        }
        /// <summary>
        /// 获取指定课程指定教师的所有学生
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="teacher">教师工号</param>
        /// <returns>返回学生学号组</returns>
        public string[] GetStudents(string id, string teacher)
        {
            string[] vs = null;
            ClassNode p = Tree;
            while (null != p)
            {
                if (id == p.ClassID)
                {
                    vs = p.GetStudents(teacher);
                    break;
                }
                else if (id.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return vs;
        }

        /// <summary>
        /// 向指定课程中添加教师
        /// </summary>
        /// <param name="classID">课程编号</param>
        /// <param name="teacherID">教师工号</param>
        public void AddTeacher(string classID, string teacherID)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (classID == p.ClassID)
                {
                    p.AddTeacher(teacherID);
                    break;
                }
                else if (classID.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
        /// <summary>
        /// 从指定课程中删除教师
        /// </summary>
        /// <param name="classID">课程编号</param>
        /// <param name="teacherID">教师工号</param>
        public void DelTeacher(string classID, string teacherID)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (classID == p.ClassID)
                {
                    p.DelTeacher(teacherID);
                    break;
                }
                else if (classID.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }

        /// <summary>
        /// 向指定课程的指定教师中添加学生
        /// </summary>
        /// <param name="classID">课程编号</param>
        /// <param name="teacherID">教师工号</param>
        /// <param name="studentID">学生学号</param>
        /// <returns>返回添加结果</returns>
        public string AddStudent(string classID, string teacherID, string studentID)
        {
            ClassNode p = Tree;
            string result = "添加失败";
            while (null != p)
            {
                if (classID == p.ClassID)
                {
                    result = p.AddStudent(teacherID, studentID);
                    break;
                }
                else if (classID.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
            return result;
        }
        /// <summary>
        /// 从指定课程的指定教师中删除学生
        /// </summary>
        /// <param name="classID">课程编号</param>
        /// <param name="teacherID">教师工号</param>
        /// <param name="studentID">学生学号</param>
        public void DelStudent(string classID, string teacherID, string studentID)
        {
            ClassNode p = Tree;
            while (null != p)
            {
                if (classID == p.ClassID)
                {
                    p.DelStudent(teacherID, studentID);
                    break;
                }
                else if (classID.CompareTo(p.ClassID) < 0)
                    p = p.lChild;
                else
                    p = p.rChild;
            }
        }
    }
}

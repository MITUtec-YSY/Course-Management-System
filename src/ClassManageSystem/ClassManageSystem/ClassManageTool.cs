using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRsystem.Collections;
using ClassManageSystem.Classes;
using ClassManageSystem.Students;
using ClassManageSystem.Teachers;
using MRsystem.Collections.MRX;
using MRsystem.Collections.MRI;

namespace ClassManageSystem
{
    /// <summary>
    /// 教师课程数据包
    /// </summary>
    public struct TeacherClassPackage
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string classID;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string className;
        /// <summary>
        /// 课程年级
        /// </summary>
        public int classGrade;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int classCollege;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string classIntroduct;
        /// <summary>
        /// 课程最大容量
        /// </summary>
        public int classMax;
        /// <summary>
        /// 课程学分
        /// </summary>
        public float classCredit;
    }
    /// <summary>
    /// 教师学生数据包
    /// </summary>
    public struct TeacherStudentPackage
    {
        /// <summary>
        /// 学生学号
        /// </summary>
        public string studentID;
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string studentName;
        /// <summary>
        /// 学生专业
        /// </summary>
        public string studentMajor;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int studentCollege;
        /// <summary>
        /// 学生年级
        /// </summary>
        public int Grade;
        /// <summary>
        /// 学生分数
        /// </summary>
        public float Score;
    }
    /// <summary>
    /// 学生课程数据包
    /// </summary>
    public struct StudentClassPackage
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string classID;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string className;
        /// <summary>
        /// 课程年级
        /// </summary>
        public int classGrade;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int classCollege;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string classIntroduct;
        /// <summary>
        /// 课程学分
        /// </summary>
        public float classCredit;
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string teacherName;
        /// <summary>
        /// 教师工号
        /// </summary>
        public string teacherID;
        /// <summary>
        /// 学生分数
        /// </summary>
        public float Score;
    }
    /// <summary>
    /// 学生课程选择数据包
    /// </summary>
    public struct StudentClassSelect
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public string classID;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string className;
        /// <summary>
        /// 课程年级
        /// </summary>
        public int classGrade;
        /// <summary>
        /// 学院编号
        /// </summary>
        public int classCollege;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string classIntroduct;
        /// <summary>
        /// 课程最大容量
        /// </summary>
        public int classMax;
        /// <summary>
        /// 课程学分
        /// </summary>
        public float classCredit;
        /// <summary>
        /// 课程教师工号
        /// </summary>
        public string[] TeacherIDs;
        /// <summary>
        /// 课程教师名字
        /// </summary>
        public string[] TeacherNames;
    }

    /// <summary>
    /// 课程管理系统系统组件
    /// </summary>
    public class ClassManageTool
    {
        private ClassTree ClassTable;    //课程表
        private TeacherTree TeacherTable;     //教师表
        private StudentTree StudentTable;    //学生表
        private KeyPackage[] CollegeTable;    //学院数据表
        private string PathX;
        private string PathI;
        private MRX MRX;    //MRX文件记录表
        private MRI MRI;    //MRI文件记录表

        /// <summary>
        /// 课程管理系统系统组件构造函数
        /// </summary>
        public ClassManageTool(string pathx = @"C:\Users\ysydt\Desktop\ClassManage.mrx", string pathi = @"C:\Users\ysydt\Desktop\PersonManage.mri")
        {
            ClassTable = new ClassTree();
            TeacherTable = new TeacherTree();
            StudentTable = new StudentTree();
            CollegeTable = null;
            MRX = null;
            MRI = null;
            PathX = pathx;
            PathI = pathi;
            Open();
        }
        
        /*系统默认功能区*/
        /// <summary>
        /// 用户登陆方法
        /// </summary>
        /// <param name="user_name">登陆用户名</param>
        /// <param name="user_pw">登陆用户密码</param>
        /// <param name="pathi">默认启动路径</param>
        /// <returns>返回登陆结果</returns>
        public static LAND_REQUEST Landing(string user_name, string user_pw, string pathi = @"C:\Users\ysydt\Desktop\PersonManage.mri")
        {
            MRI mri = new MRI(pathi, FILE_OPEN.BOTH);
            LAND_REQUEST _REQUEST = LAND_REQUEST.UR_FAIL;
            string PW = null;
            string CL = null;
            PW = mri.Search("E" + user_name, "PassWord");
            if (null != PW)
            {
                if (PW == user_pw)
                {
                    CL = mri.Search("E" + user_name, "Classify");
                    switch (CL.ToLower())
                    {
                        case "control":
                            _REQUEST = LAND_REQUEST.ON_CONTROL;
                            break;
                        case "teacher":
                            _REQUEST = LAND_REQUEST.ON_TEACHER;
                            break;
                        case "student":
                            _REQUEST = LAND_REQUEST.ON_STUDENT;
                            break;
                        default:
                            break;
                    }
                }
                else
                    _REQUEST = LAND_REQUEST.PW_FAIL;
            }
            mri.Destroy();
            mri = null;
            return _REQUEST;
        }
        /// <summary>
        /// 将数据保存至文件
        /// </summary>
        public void Save()
        {
            MRX = new MRX(PathX, FILE_OPEN.BOTH);
            WriteToFile();
            MRX.Flush();
            MRX.Close();
            MRX.Destroy();
            MRX = null;
        }
        /// <summary>
        /// 从文件中读取数据
        /// </summary>
        public void Open()
        {
            MRX = new MRX(PathX, FILE_OPEN.READ_ONLY);
            MRX.Open("", FILE_OPEN.READ_ONLY);
            ReadFromFile();
            MRX.Close();
            MRX.Destroy();
            MRX = null;
        }
        /*系统默认功能区*/

        /*教师功能区*/
        /// <summary>
        /// 获取教师姓名方法
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        /// <returns>返回教师名字</returns>
        public string GetTeacherName(string teacher_code)
        {
            return TeacherTable.Search(teacher_code);
        }
        /// <summary>
        /// 获取指定课程的指定教师学生
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="class_code">课程编号</param>
        /// <returns>返回学生组</returns>
        public string[] GetTeacherStudent(string teacher_code, string class_code)
        {
            return ClassTable.GetStudents(class_code, teacher_code);
        }
        /// <summary>
        /// 获取指定教师所教授的所有课程
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        /// <returns>返回课程信息组</returns>
        public TeacherClassPackage[] GetClassesT(string teacher_code)
        {
            ClassPackage[] classes = ClassTable.GetClasses();
            TeacherClassPackage[] teacherClasses = null;
            if (null != classes)
            {
                StringStack classStack = new StringStack();
                StringStack cnameStack = new StringStack();
                StringStack cintrStack = new StringStack();
                int[] maxStack = new int[classes.Length];
                int[] gradeStack = new int[classes.Length];
                int[] collegeStack = new int[classes.Length];
                float[] cStack = new float[classes.Length];
                int top = 0;
                for (int i = 0; i < classes.Length; i++)
                {
                    if (null != classes[i].Teachers)
                        for (int j = 0; j < classes[i].Teachers.Length && classes[i].Teachers[j].TeacherID.CompareTo(teacher_code) <= 0; j++)
                            if (teacher_code == classes[i].Teachers[j].TeacherID)
                            {
                                classStack.Push(classes[i].ClassID);
                                cnameStack.Push(classes[i].ClassName);
                                cintrStack.Push(classes[i].Introduction);
                                maxStack[top] = classes[i].ClassMax;
                                cStack[top] = classes[i].Credit;
                                collegeStack[top] = classes[i].ClassCollege;
                                gradeStack[top] = classes[i].ClassGrade;
                                top++;
                                break;
                            }
                }
                if (0 < top)
                {
                    teacherClasses = new TeacherClassPackage[top];
                    for(int i = 0; i < top; i++)
                    {
                        teacherClasses[i].classID = classStack.Pop();
                        teacherClasses[i].className = cnameStack.Pop();
                        teacherClasses[i].classGrade = gradeStack[top - i - 1];
                        teacherClasses[i].classCollege = collegeStack[top - i - 1];
                        teacherClasses[i].classIntroduct = cintrStack.Pop();
                        teacherClasses[i].classCredit = cStack[top - i - 1];
                        teacherClasses[i].classMax = maxStack[top - i - 1];
                    }
                }
            }
            return teacherClasses;
        }
        /// <summary>
        /// 获取指定教师指定课程中的所有学生信息
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="teacher_code">教师工号</param>
        /// <returns>返回学生数据包组</returns>
        public TeacherStudentPackage[] GetStudentsT(string class_code, string teacher_code)
        {
            TeacherStudentPackage[] teacherStudents = null;
            string[] vs = ClassTable.GetStudents(class_code, teacher_code);
            if (null != vs)
            {
                teacherStudents = new TeacherStudentPackage[vs.Length];
                for(int i = 0; i < vs.Length; i++)
                {
                    StudentPackage package = StudentTable[vs[i]];
                    teacherStudents[i].studentID = vs[i];
                    teacherStudents[i].studentName = package.Name;
                    teacherStudents[i].studentMajor = package.Major;
                    teacherStudents[i].studentCollege = package.College;
                    teacherStudents[i].Grade = package.Grade;
                    if (null != package.Classes)
                        for (int j = 0; j < package.Classes.Length; j++)
                            if (class_code == package.Classes[j].Class)
                            {
                                teacherStudents[i].Score = package.Classes[j].Score;
                                break;
                            }
                }
            }
            return teacherStudents;
        }
        /// <summary>
        /// 修改一个指定的学生成绩
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="student_code">学生学号</param>
        /// <param name="score">学生成绩</param>
        public void EditScoreT(string class_code, string student_code, float score)
        {
            StudentTable.Edit(student_code, class_code, score);
        }
        /// <summary>
        /// 批量修改学生成绩
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="student_codes">学生学号组</param>
        /// <param name="scores">学生成绩组</param>
        public void EditScoreT(string class_code, string[] student_codes, float[] scores)
        {
            StudentTable.Edit(student_codes, class_code, scores);
        }
        /*教师功能区*/

        /*学生功能区*/
        /// <summary>
        /// 获取指定学生的所有课程数据
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <returns>返回课程数据组</returns>
        public StudentClassPackage[] GetClassS(string student_code)
        {
            StudentClassPackage[] studentClasses = null;
            StudentPackage package = StudentTable[student_code];
            if (null != package.ID)
                if (null != package.Classes)
                {
                    studentClasses = new StudentClassPackage[package.Classes.Length];
                    for (int i = 0; i < package.Classes.Length; i++)
                    {
                        ClassPackage packages = ClassTable.GetClass(package.Classes[i].Class);
                        studentClasses[i].classID = package.Classes[i].Class;
                        studentClasses[i].className = packages.ClassName;
                        studentClasses[i].classGrade = packages.ClassGrade;
                        studentClasses[i].classCollege = packages.ClassCollege;
                        studentClasses[i].classCredit = packages.Credit;
                        studentClasses[i].classIntroduct = packages.Introduction;
                        studentClasses[i].teacherName = TeacherTable.Search(package.Classes[i].Teacher);
                        studentClasses[i].teacherID = package.Classes[i].Teacher;
                        studentClasses[i].Score = package.Classes[i].Score;
                    }
                }
            return studentClasses;
        }
        /// <summary>
        /// 退选指定学生的指定课程
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="class_code">课程编号</param>
        public void DropClass(string student_code, string teacher_code, string class_code)
        {
            ClassTable.DelStudent(class_code, teacher_code, student_code);
            StudentTable.DelClass(student_code, class_code);
        }
        /// <summary>
        /// 获取所有课程数据
        /// </summary>
        /// <returns>返回所有课程组</returns>
        public StudentClassSelect[] GetClassS()
        {
            StudentClassSelect[] classSelects = null;
            ClassPackage[] classes = ClassTable.GetClasses();
            if (null != classes)
            {
                classSelects = new StudentClassSelect[classes.Length];
                for(int i = 0; i < classes.Length; i++)
                {
                    classSelects[i].classID = classes[i].ClassID;
                    classSelects[i].className = classes[i].ClassName;
                    classSelects[i].classGrade = classes[i].ClassGrade;
                    classSelects[i].classCollege = classes[i].ClassCollege;
                    classSelects[i].classIntroduct = classes[i].Introduction;
                    classSelects[i].classCredit = classes[i].Credit;
                    classSelects[i].classMax = classes[i].ClassMax;
                    classSelects[i].TeacherIDs = null;
                    classSelects[i].TeacherNames = null;
                    if (null != classes[i].Teachers)
                    {
                        classSelects[i].TeacherIDs = new string[classes[i].Teachers.Length];
                        classSelects[i].TeacherNames = new string[classes[i].Teachers.Length];
                        for(int j = 0; j < classes[i].Teachers.Length; j++)
                        {
                            classSelects[i].TeacherIDs[j] = classes[i].Teachers[j].TeacherID;
                            classSelects[i].TeacherNames[j] = TeacherTable.Search(classes[i].Teachers[j].TeacherID);
                        }
                    }
                }
            }
            return classSelects;
        }
        /// <summary>
        /// 为指定学生选择指定课程和指定老师
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="class_code">课程编号</param>
        public string SelectClass(string student_code, string teacher_code, string class_code)
        {
            string str = ClassTable.AddStudent(class_code, teacher_code, student_code);
            if ("选课成功" == str)
                StudentTable.AddClass(student_code, class_code, teacher_code);
            else
                return str;
            return "选课成功";
        }
        /// <summary>
        /// 获取指定学生的姓名
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <returns>返回学生姓名</returns>
        public string GetStudentName(string student_code)
        {
            return StudentTable.Search(student_code).Name;
        }
        /// <summary>
        /// 获取指定学生的详细数据
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <returns>返回学生数据包</returns>
        public StudentPackage GetStudentData(string student_code)
        {
            return StudentTable.Search(student_code);   
        }
        /// <summary>
        /// 获取指定课程的所有数据
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="flag">区分标志</param>
        /// <returns>返回课程数据包</returns>
        public ClassPackage GetClassS(string class_code, bool flag)
        {
            return ClassTable.GetClass(class_code);
        }
        /// <summary>
        /// 从学院编号获取学院名
        /// </summary>
        /// <param name="college">学院编号</param>
        /// <returns>返回学院名</returns>
        public string GetCollege(int college)
        {
            string str = college.ToString();
            if (null != CollegeTable)
                for (int i = 0; i < CollegeTable.Length; i++)
                    if (college.ToString() == CollegeTable[i].Name)
                    {
                        str = CollegeTable[i].Data;
                        break;
                    }
            return str;
        }
        /*学生功能区*/

        /*教务功能区*/
        /// <summary>
        /// 添加学院方法
        /// </summary>
        /// <param name="college_code">学院编号</param>
        /// <param name="college_name">学院名称</param>
        public void AddCollege(string college_code, string college_name)
        {
            if (null != CollegeTable)
            {
                KeyPackage[] newKey = new KeyPackage[CollegeTable.Length + 1];
                int i;
                for (i = 0; i < CollegeTable.Length; i++)
                {
                    newKey[i].Type = CollegeTable[i].Type;
                    newKey[i].Name = CollegeTable[i].Name;
                    newKey[i].Data = CollegeTable[i].Data;
                }
                newKey[i].Type = SUBKEY_TYPE.STRING;
                newKey[i].Name = college_code;
                newKey[i].Data = college_name;
                CollegeTable = newKey;
            }
            else
            {
                CollegeTable = new KeyPackage[1];
                CollegeTable[0].Name = college_code;
                CollegeTable[0].Data = college_name;
                CollegeTable[0].Type = SUBKEY_TYPE.STRING;
            }
        }
        /// <summary>
        /// 删除学院方法
        /// </summary>
        /// <param name="college_name">学院名称</param>
        public bool DelCollege(string college_name)
        {
            bool result = false;
            if (null != college_name)
            {
                bool find = false;
                for (int i = 0; i < CollegeTable.Length; i++)
                    if (college_name == CollegeTable[i].Data)
                    {
                        find = true;
                        break;
                    }
                if (find)
                {
                    int index = 0;
                    KeyPackage[] packages = new KeyPackage[CollegeTable.Length - 1];
                    for(int i = 0; i < CollegeTable.Length; i++)
                        if (college_name != CollegeTable[i].Data)
                        {
                            packages[index].Data = CollegeTable[i].Data;
                            packages[index].Name = CollegeTable[i].Name;
                            packages[index].Type = CollegeTable[i].Type;
                            index++;
                        }
                    CollegeTable = packages;
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 增加一个课程
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="class_name">课程名称</param>
        /// <param name="class_grade">课程年级</param>
        /// <param name="class_college">学院编号</param>
        /// <param name="class_intro">课程简介</param>
        /// <param name="class_credit">课程学分</param>
        /// <param name="class_cap">课程容量</param>
        public void AddClass(string class_code, string class_name, int class_grade, int class_college, string class_intro, float class_credit,int class_cap)
        {
            ClassTable.AddClass(class_code, class_name, class_grade, class_college, class_intro, class_credit, class_cap);
        }
        /// <summary>
        /// 向课程中添加一个教师
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="teacher_code">教师编号</param>
        public void AddClassTeacher(string class_code, string teacher_code)
        {
            ClassTable.AddTeacher(class_code, teacher_code);
        }
        /// <summary>
        /// 删除一个课程
        /// </summary>
        /// <param name="class_code">课程编号</param>
        public void DelClass(string class_code)
        {
            ClassPackage package = ClassTable.GetClass(class_code);
            if (null != package.ClassID)
                if (null != package.Teachers)
                    for (int i = 0; i < package.Teachers.Length; i++)
                        if (null != package.Teachers[i].Students)
                            for (int j = 0; j < package.Teachers[i].Students.Length; j++)
                                StudentTable.DelClass(package.Teachers[i].Students[j], class_code);
            ClassTable.Del(class_code);
        }
        /// <summary>
        /// 删除一个课程中的一个老师
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="teacher_code">教师工号</param>
        public void DelClassTeacher(string class_code, string teacher_code)
        {
            string[] vs = ClassTable.GetStudents(class_code, teacher_code);
            if (null != vs)
                for (int i = 0; i < vs.Length; i++)
                    StudentTable.DelClass(vs[i], class_code);
            ClassTable.DelTeacher(class_code, teacher_code);
        }
        /// <summary>
        /// 删除一个课程中的一个学生
        /// </summary>
        /// <param name="class_code">课程编号</param>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="student_code">学生学号</param>
        public void DelClassStudent(string class_code, string teacher_code, string student_code)
        {
            ClassTable.DelStudent(class_code, teacher_code, student_code);
            StudentTable.DelClass(student_code, class_code);
        }
        /// <summary>
        /// 添加一个教师
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="teacher_name">教师姓名</param>
        public void AddTeacher(string teacher_code, string teacher_name)
        {
            TeacherTable.Add(teacher_code, teacher_name);
            MRI = new MRI(PathI, FILE_OPEN.BOTH);
            MRI.Add("E" + teacher_code, null, NoteType.No_Note);
            MRI.Add("E" + teacher_code, "PassWord", "000000", null, NoteType.No_Note);
            MRI.Add("E" + teacher_code, "Classify", "Teacher", null, NoteType.No_Note);
            MRI.Flush();
            MRI.Close();
            MRI.Destroy();
            MRI = null;
        }
        /// <summary>
        /// 删除一个教师
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        public void DelTeacher(string teacher_code)
        {
            ClassPackage[] classes = ClassTable.GetClasses();
            if (null != classes)
                for (int i = 0; i < classes.Length; i++)
                    if (null != classes[i].Teachers)
                        for (int j = 0; j < classes[i].Teachers.Length; j++)
                            if (teacher_code == classes[i].Teachers[j].TeacherID)
                            {
                                string[] vs = ClassTable.GetStudents(classes[i].ClassID, teacher_code);
                                if (null != vs)
                                    for (int k = 0; k < vs.Length; k++)
                                        StudentTable.DelClass(vs[k], classes[i].ClassID);
                                ClassTable.DelTeacher(classes[i].ClassID, teacher_code);
                                break;
                            }
                            else if (teacher_code.CompareTo(classes[i].Teachers[j].TeacherID) < 0)
                                break;
            TeacherTable.Del(teacher_code);
            MRI mri = new MRI(@"C:\Users\ysydt\Desktop\PersonManage.mri", FILE_OPEN.BOTH);
            mri.Del("E" + teacher_code);
            mri.Flush();
            mri.Close();
        }
        /// <summary>
        /// 添加一个学生
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="student_name">学生姓名</param>
        /// <param name="student_major">学生专业</param>
        /// <param name="grade">学生年级</param>
        /// <param name="college">学院编号</param>
        public void AddStudent(string student_code, string student_name, string student_major, int grade, int college)
        {
            StudentTable.Add(student_code, student_name, grade, student_major, college);
            MRI = new MRI(PathI, FILE_OPEN.BOTH);
            MRI.Add("E" + student_code, null, NoteType.No_Note);
            MRI.Add("E" + student_code, "PassWord", "000000", null, NoteType.No_Note);
            MRI.Add("E" + student_code, "Classify", "Student", null, NoteType.No_Note);
            MRI.Flush();
            MRI.Close();
            MRI.Destroy();
            MRI = null;
        }
        /// <summary>
        /// 删除一个学生
        /// </summary>
        /// <param name="student_code">学生学号</param>
        public void DelStudent(string student_code)
        {
            StudentPackage package = StudentTable[student_code];
            if (null != package.Classes)
                for (int i = 0; i < package.Classes.Length; i++)
                    ClassTable.DelStudent(package.Classes[i].Class, package.Classes[i].Teacher, student_code);
            StudentTable.Del(student_code);
            MRI mri = new MRI(@"C:\Users\ysydt\Desktop\PersonManage.mri", FILE_OPEN.BOTH);
            mri.Del("E" + student_code);
            mri.Flush();
            mri.Close();
        }
        /// <summary>
        /// 修改课程简介
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="intr">课程简介</param>
        public void EditClass(string id, string intr)
        {
            ClassTable.EditClass(id, intr);
        }
        /// <summary>
        /// 修改课程名称
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="name">课程名称</param>
        /// <param name="flag">区分标识</param>
        public void EditClass(string id, string name, bool flag)
        {
            ClassTable.EditClass(id, name, flag);
        }
        /// <summary>
        /// 修改课程最大容量
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="max">课程最大容量</param>
        public void EditClass(string id, int max)
        {
            ClassTable.EditClass(id, max);
        }
        /// <summary>
        /// 修改课程学分
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="credit">课程学分</param>
        public void EditClass(string id, float credit)
        {
            ClassTable.EditClass(id, credit);
        }
        /// <summary>
        /// 修改课程年级
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <param name="grade">课程年级</param>
        /// <param name="college">学院编号</param>
        public void EditClass(string id, int grade, int college)
        {
            ClassTable.EditClass(id, grade, college);
        }
        /// <summary>
        /// 修改指定学生姓名
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="student_name">学生姓名</param>
        public void EditStudentName(string student_code,string student_name)
        {
            StudentTable.Edit(student_code, student_name);
        }
        /// <summary>
        /// 修改指定学生专业
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="student_major">学生专业</param>
        /// <param name="college">学院编号</param>
        public void EditStudentMajor(string student_code,string student_major, int college)
        {
            StudentTable.Edit(student_code, student_major, college);
        }
        /// <summary>
        /// 修改指定学生年级
        /// </summary>
        /// <param name="student_code">学生学号</param>
        /// <param name="student_grade">学生年级</param>
        public void EditStudentGrade(string student_code, int student_grade)
        {
            StudentTable.Edit(student_code, student_grade);
        }
        /// <summary>
        /// 修改指定教师的姓名
        /// </summary>
        /// <param name="teacher_code">教师工号</param>
        /// <param name="teacher_name">教师名字</param>
        public void EditTeacherName(string teacher_code, string teacher_name)
        {
            TeacherTable.Edit(teacher_code, teacher_name, true);
        }
        /// <summary>
        /// 获取指定课程的课程数据
        /// </summary>
        /// <param name="id">课程编号</param>
        /// <returns>返回课程数据包</returns>
        public ClassPackage GetClass(string id)
        {
            return ClassTable.GetClass(id);
        }
        /// <summary>
        /// 获取所有课程数据
        /// </summary>
        /// <returns>返回课程数据组</returns>
        public ClassPackage[] GetClasses()
        {
            return ClassTable.GetClasses();
        }
        /// <summary>
        /// 获取所有学生的数据
        /// </summary>
        /// <returns>返回学生数据组</returns>
        public StudentPackage[] GetStudents()
        {
            return StudentTable.GetStudents();
        }
        /// <summary>
        /// 获取所有老师数据
        /// </summary>
        /// <returns>老师组</returns>
        public TeacherPackage[] GetTeachers()
        {
            return TeacherTable.GetTeachers();
        }
        /// <summary>
        /// 获取某一分数段的绩点
        /// </summary>
        /// <param name="score">分数</param>
        /// <returns>返回绩点</returns>
        public float GetGPA(float score)
        {
            if (95 <= score)
                return (float)4.5;
            else if (90 <= score)
                return (float)4.0;
            else if (85 <= score)
                return (float)3.5;
            else if (80 <= score)
                return (float)3.0;
            else if (75 <= score)
                return (float)2.5;
            else if (70 <= score)
                return (float)2.0;
            else if (65 <= score)
                return (float)1.5;
            else if (60 <= score)
                return (float)1.0;
            else
                return (float)0;
        }
        /*教务功能区*/

        /*测试功能区*/
        /// <summary>
        /// 获取课程数据方法（Test调试）
        /// </summary>
        /// <param name="flag">区分标识</param>
        public void GetClasses(bool flag)
        {
            Console.WriteLine("Classes");
            ClassPackage[] classes = ClassTable.GetClasses();
            if (null != classes)
            {
                for (int i = 0; i < classes.Length; i++)
                {
                    Console.WriteLine(classes[i].ClassID + " " + classes[i].ClassName + " " + classes[i].Credit + " " + classes[i].ClassMax);
                    Console.WriteLine(classes[i].Introduction);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("No Data");
        }
        /// <summary>
        /// 获取教师数据方法（Test调试）
        /// </summary>
        public void GetTeacher()
        {
            Console.WriteLine("Teachers");
            TeacherPackage[] teachers = TeacherTable.GetTeachers();
            if (null != teachers)
            {
                for (int i = 0; i < teachers.Length; i++)
                {
                    Console.WriteLine(teachers[i].ID + " " + teachers[i].Name);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("No Data");
        }
        /// <summary>
        /// 获取学生数据方法（Test调试）
        /// </summary>
        public void GetStudent()
        {
            Console.WriteLine("Students");
            StudentPackage[] students = StudentTable.GetStudents();
            if (null != students)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    Console.WriteLine(students[i].ID + " " + students[i].Name + " " + students[i].Grade + " " + students[i].Major);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("No Data");
        }
        /*测试功能区*/

        private void ReadFromFile()
        {
            ReadTeachers();
            ReadStudents();
            ReadClasses();
            ReadCollege();
        }
        private void ReadTeachers()
        {
            string[] vs = { "TEACHER" };
            KeyPackage[] keys = MRX.GetAllKeys(vs);
            if (null != keys)
            {
                for(int i = 0; i < keys.Length; i++)
                    TeacherTable.Add(keys[i].Name, keys[i].Data);
            }
        }
        private void ReadStudents()
        {
            StringStack stringStack = new StringStack();
            stringStack.Push("STUDENT");
            string[] StudentsIDs = MRX.GetEntrys(stringStack.Read());
            if (null != StudentsIDs)
            {
                for(int i = 0; i < StudentsIDs.Length; i++)
                {
                    stringStack.Push(StudentsIDs[i]);
                    KeyPackage[] keys = MRX.GetAllKeys(stringStack.Read());
                    if (null != keys)
                    {
                        string name = "";
                        string grade = "";
                        string major = "";
                        string college = "";
                        for (int j = 0; j < keys.Length; j++)
                            switch (keys[j].Name.ToLower())
                            {
                                case "name":
                                    name = keys[j].Data;
                                    break;
                                case "grade":
                                    grade = keys[j].Data;
                                    break;
                                case "major":
                                    major = keys[j].Data;
                                    break;
                                case "college":
                                    college = keys[j].Data;
                                    break;
                                default:
                                    break;
                            }
                        int g = 0;
                        if (!int.TryParse(grade, out g))
                            g = 0;
                        int c = 0;
                        if (!int.TryParse(college, out c))
                            c = 0;
                        StudentTable.Add(StudentsIDs[i], name, g, major, c);
                        string[] classes = MRX.GetEntrys(stringStack.Read());
                        if (null != classes)
                        {
                            for(int j = 0; j < classes.Length; j++)
                            {
                                stringStack.Push(classes[j]);
                                string teacher = "";
                                string score = "";
                                keys = MRX.GetAllKeys(stringStack.Read());
                                if (null != keys)
                                {
                                    for(int k=0;k<keys.Length;k++)
                                        switch (keys[k].Name.ToLower())
                                        {
                                            case "teacher":
                                                teacher = keys[k].Data;
                                                break;
                                            case "score":
                                                score = keys[k].Data;
                                                break;
                                            default:
                                                break;
                                        }
                                    StudentTable.AddClass(StudentsIDs[i], classes[j], teacher);
                                    float s = 0;
                                    if (!float.TryParse(score, out s))
                                        s = 0;
                                     StudentTable.Edit(StudentsIDs[i], classes[j], s);
                                }
                                stringStack.Pop();
                            }
                        }
                    }
                    stringStack.Pop();
                }
            }
        }
        private void ReadClasses()
        {
            StringStack stringStack = new StringStack();
            stringStack.Push("CLASS");
            string[] classes = MRX.GetEntrys(stringStack.Read());
            if (null != classes)
            {
                string name = "";
                string credit = "";
                string introduct = "";
                string cap = "";
                string grade = "";
                string college = "";
                int class_grade = 0;
                float creditf = 0;
                int capi = 0;
                int colli = 0;
                for (int i = 0; i < classes.Length; i++)
                {
                    stringStack.Push(classes[i]);
                    KeyPackage[] keys = MRX.GetAllKeys(stringStack.Read());
                    if (null != keys)
                    {
                        for (int j = 0; j < keys.Length; j++)
                            switch (keys[j].Name.ToLower())
                            {
                                case "name":
                                    name = keys[j].Data;
                                    break;
                                case "credit":
                                    credit = keys[j].Data;
                                    break;
                                case "introduction":
                                    introduct = keys[j].Data;
                                    break;
                                case "maxcapacity":
                                    cap = keys[j].Data;
                                    break;
                                case "grade":
                                    grade = keys[j].Data;
                                    break;
                                case "college":
                                    college = keys[j].Data;
                                    break;
                                default:
                                    break;
                            }
                        
                        bool error = float.TryParse(credit, out creditf);
                        if (!error)
                            creditf = 0;
                        error = int.TryParse(cap, out capi);
                        if (!error)
                            capi = 0;
                        error = int.TryParse(grade, out class_grade);
                        if (!error)
                            class_grade = 0;
                        error = int.TryParse(college, out colli);
                        if (!error)
                            colli = 0;
                        ClassTable.AddClass(classes[i], name, class_grade, colli, introduct, creditf, capi);
                        string[] teachers = MRX.GetEntrys(stringStack.Read());
                        if (null != teachers)
                            for (int j = 0; j < teachers.Length; j++)
                            {
                                stringStack.Push(teachers[j]);
                                ClassTable.AddTeacher(classes[i], teachers[j]);
                                keys = MRX.GetAllKeys(stringStack.Read());
                                if (null != keys)
                                    for (int k = 0; k < keys.Length; k++)
                                        if (SUBKEY_TYPE.STRING == keys[k].Type)
                                            ClassTable.AddStudent(classes[i], teachers[j], keys[k].Name);
                                stringStack.Pop();
                            }
                    }
                    name = "";
                    credit = "";
                    introduct = "";
                    grade = "";
                    cap = "";
                    college = "";
                    creditf = 0;
                    capi = 0;
                    colli = 0;
                    stringStack.Pop();
                }
            }
        }
        private void ReadCollege()
        {
            string[] vs = { "COLLEGE" };
            CollegeTable = MRX.GetAllKeys(vs);
        }
        private void WriteToFile()
        {
            WriteTeachers();
            WriteStudents();
            WriteClasses();
            WriteCollege();
        }
        private void WriteTeachers()
        {
            TeacherPackage[] teachers = TeacherTable.GetTeachers();
            string[] vs = { "TEACHER" };
            if (null != teachers)
                for (int i = 0; i < teachers.Length; i++)
                    MRX.AddKey(vs, teachers[i].ID, teachers[i].Name);
        }
        private void WriteStudents()
        {
            StudentPackage[] students = StudentTable.GetStudents();
            StringStack stringStack = new StringStack();
            stringStack.Push("STUDENT");
            if (null != students)
                for (int i = 0; i < students.Length; i++)
                {
                    stringStack.Push(students[i].ID);
                    MRX.AddKey(stringStack.Read(), "Name", students[i].Name);
                    MRX.AddKey(stringStack.Read(), "Grade", students[i].Grade.ToString(), SUBKEY_TYPE.INT);
                    MRX.AddKey(stringStack.Read(), "College", students[i].College.ToString(), SUBKEY_TYPE.INT);
                    MRX.AddKey(stringStack.Read(), "Major", students[i].Major);
                    if (null != students[i].Classes)
                        for (int j = 0; j < students[i].Classes.Length; j++)
                        {
                            stringStack.Push(students[i].Classes[j].Class);
                            MRX.AddKey(stringStack.Read(), "Teacher", students[i].Classes[j].Teacher);
                            MRX.AddKey(stringStack.Read(), "Score", students[i].Classes[j].Score.ToString(), SUBKEY_TYPE.INT);
                            stringStack.Pop();
                        }
                    stringStack.Pop();
                }
        }
        private void WriteClasses()
        {
            StringStack stringStack = new StringStack();
            stringStack.Push("CLASS");
            ClassPackage[] classes = ClassTable.GetClasses();
            if (null != classes)
                for (int i = 0; i < classes.Length; i++)
                {
                    stringStack.Push(classes[i].ClassID);
                    MRX.AddKey(stringStack.Read(), "Name", classes[i].ClassName);
                    MRX.AddKey(stringStack.Read(), "Credit", classes[i].Credit.ToString(), SUBKEY_TYPE.INT);
                    MRX.AddKey(stringStack.Read(), "Introduction", classes[i].Introduction);
                    MRX.AddKey(stringStack.Read(), "MaxCapacity", classes[i].ClassMax.ToString(), SUBKEY_TYPE.INT);
                    MRX.AddKey(stringStack.Read(), "Grade", classes[i].ClassGrade.ToString(), SUBKEY_TYPE.INT);
                    MRX.AddKey(stringStack.Read(), "College", classes[i].ClassCollege.ToString(), SUBKEY_TYPE.INT);
                    if (null != classes[i].Teachers)
                        for (int j = 0; j < classes[i].Teachers.Length; j++)
                        {
                            stringStack.Push(classes[i].Teachers[j].TeacherID);
                            if (null != classes[i].Teachers[j].Students)
                                for (int k = 0; k < classes[i].Teachers[j].Students.Length; k++)
                                    MRX.AddKey(stringStack.Read(), classes[i].Teachers[j].Students[k], "");
                            MRX.AddKey(stringStack.Read(), "Name", "", SUBKEY_TYPE.INT);
                            stringStack.Pop();
                        }
                    stringStack.Pop();
                }
        }
        private void WriteCollege()
        {
            string[] vs = { "COLLEGE" };
            if (null != CollegeTable)
                for (int i = 0; i < CollegeTable.Length; i++)
                    MRX.AddKey(vs, CollegeTable[i].Name, CollegeTable[i].Data, SUBKEY_TYPE.INT);
        }

        /// <summary>
        /// 索引器（用于索引静态数据）
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>返回静态数据包</returns>
        public KeyPackage this[int index]
        {
            get { return CollegeTable[index]; }
        }
        /// <summary>
        /// 获取静态数据长度
        /// </summary>
        public int Length => CollegeTable.Length;
        /// <summary>
        /// 获取静态数据可用性
        /// </summary>
        public bool IsNull => null == CollegeTable ? true : false;
        /// <summary>
        /// 获取静态数据可用性
        /// </summary>
        public bool IsnNull => null == CollegeTable ? false : true;
    }
}

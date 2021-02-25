using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManageSystem
{
    /// <summary>
    /// 课程管理系统登陆结果
    /// </summary>
    public enum LAND_REQUEST
    {
        /// <summary>
        /// 登陆成功-管理模式
        /// </summary>
        ON_CONTROL,
        /// <summary>
        /// 登陆成功-教师模式
        /// </summary>
        ON_TEACHER,
        /// <summary>
        /// 登陆成功-学生模式
        /// </summary>
        ON_STUDENT,
        /// <summary>
        /// 密码错误
        /// </summary>
        PW_FAIL,
        /// <summary>
        /// 用户不存在或用户名错误
        /// </summary>
        UR_FAIL,
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem
{
    namespace Collections
    {
        /// <summary>
        /// 通用混合表单
        /// </summary>
        /// <typeparam name="T">类型名（必须为值类型）</typeparam>
        /// <typeparam name="U">类型名（必须含有无参数的构造函数）</typeparam>
        public class Dictionary<T,U> where T : struct
                                where U : new()
        {

        }
        /// <summary>
        /// 通用混合表单节点
        /// </summary>
        /// <typeparam name="T">类型名（必须为值类型）</typeparam>
        /// <typeparam name="U">类型名（必须含有无参数的构造函数）</typeparam>
        class DictionaryNode<T,U> where T : struct
                             where U : new()
        {

        }
    }
}

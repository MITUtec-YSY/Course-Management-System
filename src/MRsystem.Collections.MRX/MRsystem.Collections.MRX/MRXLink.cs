using System;


namespace MRsystem.Collections.MRX
{
    /// <summary>
    /// 键值数据包
    /// </summary>
    public struct KeyPackage
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string Name;
        /// <summary>
        /// 键类型
        /// </summary>
        public SUBKEY_TYPE Type;
        /// <summary>
        /// 键值
        /// </summary>
        public string Data;
    }
    /// <summary>
    /// 键节点
    /// </summary>
    public class KeyNode
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string _NAME { get; private set; }
        /// <summary>
        /// 键值类型
        /// </summary>
        public SUBKEY_TYPE _TYPE { get; private set; }
        /// <summary>
        /// 键值
        /// </summary>
        public string _DATA { get; private set; }
        /// <summary>
        /// 下一个键
        /// </summary>
        public KeyNode Next;

        /// <summary>
        /// 键节点构造函数
        /// </summary>
        /// <param name="name">键名</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public KeyNode(string name, string data, SUBKEY_TYPE type)
        {
            _NAME = name;
            _TYPE = type;
            _DATA = data;
        }

        /// <summary>
        /// 修改键名
        /// </summary>
        /// <param name="name">新的键名</param>
        public void Edit(string name)
        {
            _NAME = name;
        }
        /// <summary>
        /// 修改键值类型
        /// </summary>
        /// <param name="type">键值类型</param>
        public void Edit(SUBKEY_TYPE type)
        {
            switch (type)
            {
                case SUBKEY_TYPE.BINARY:
                    _DATA = "00";
                    break;
                case SUBKEY_TYPE.INT:
                    _DATA = "0";
                    break;
                case SUBKEY_TYPE.STRING:
                    _DATA = "";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 修改键值
        /// </summary>
        /// <param name="data">新的键值</param>
        /// <param name="flag">区分标识</param>
        public void Edit(string data, bool flag)
        {
            _DATA = data;
        }
        /// <summary>
        /// 修改键值类型与键值
        /// </summary>
        /// <param name="data">键值</param>
        /// <param name="type">键值类型</param>
        public void Edit(string data, SUBKEY_TYPE type)
        {
            _TYPE = type;
            _DATA = data;
        }

        /// <summary>
        /// 从内存中销毁对象
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }

        /// <summary>
        /// 判断左值是否小于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator <(KeyNode left, KeyNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left._TYPE < right._TYPE)
                        flag = true;
                    else if (left._TYPE == right._TYPE)
                    {
                        if (left._NAME.CompareTo(right._NAME) < 0)
                            flag = true;
                        else
                            flag = false;
                    }
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
        /// 判断左值是否大于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >(KeyNode left, KeyNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left._TYPE > right._TYPE)
                        flag = true;
                    else if (left._TYPE == right._TYPE)
                    {
                        if (left._NAME.CompareTo(right._NAME) > 0)
                            flag = true;
                        else
                            flag = false;
                    }
                    else
                        flag = false;
                }
                else
                    flag = true ;
            }
            else
                flag = false;
            return flag;
        }
        /// <summary>
        /// 判断左值是否小于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator <=(KeyNode left, KeyNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 判断左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(KeyNode left, KeyNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 判断左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(KeyNode left, KeyNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 判断左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(KeyNode left, KeyNode right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 将键节点输出为字符串（已重写）
        /// </summary>
        /// <returns>返回字符串</returns>
        public override string ToString()
        {
            if (SUBKEY_TYPE.STRING == _TYPE)
                return "<Key name = \"" + _NAME + "\">" + _DATA + "</Key>";
            return "<Key name = \"" + _NAME + "\" type = \"" + _TYPE.ToString() + "\">" + _DATA + "</Key>";
        }
        /// <summary>
        /// 比较指定节点与当前节点是否相等（已重写）
        /// </summary>
        /// <param name="obj">指定节点</param>
        /// <returns>返回比较结果</returns>
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (null != obj)
            {
                if (GetType() == obj.GetType())
                    flag = this == (KeyNode)obj;
                else
                    flag = false;
            }
            else
                flag = false;
            return flag;
        }
        /// <summary>
        /// 用于获取哈希值的函数（已重写）
        /// </summary>
        /// <returns>返回哈希值</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// 段节点
    /// </summary>
    public class EntryNode
    {
        /// <summary>
        /// 段落名
        /// </summary>
        public string EntryName { get; private set; }
        /// <summary>
        /// 段落左孩子
        /// </summary>
        public EntryNode lChild;
        /// <summary>
        /// 段落右孩子
        /// </summary>
        public EntryNode rChild;
        /// <summary>
        /// 段落键数目
        /// </summary>
        public int KeyNum { get; private set; }
        private KeyNode KeyLink;   //段落键头节点
        private int HeadNum;   //段落头节点中的段落数目
        private EntryNode Head;    //段落头节点

        /// <summary>
        /// 段落节点构造函数
        /// </summary>
        /// <param name="name">段落名</param>
        public EntryNode(string name)
        {
            EntryName = name;
            KeyLink = new KeyNode(null, null, SUBKEY_TYPE.STRING)
            {
                Next = null,
            };
            KeyNum = 0;
            HeadNum = 0;
            Head = null;
        }

        /// <summary>
        /// 添加新的段落
        /// </summary>
        /// <param name="path">段落路径</param>
        /// <param name="name">段落名</param>
        public void Add(string[] path, string name)
        {
            if (null == path)
                Add(name);
            else
            {
                if (null == Head)
                {
                    Head = new EntryNode(path[0])
                    {
                        lChild = null,
                        rChild = null,
                    };
                    if (1 < path.Length)
                        Head.Add(null, name);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        Head.Add(vs, name);
                    }
                }
                else
                {
                    EntryNode p = Head;
                    while (null != p)
                    {
                        if (path[0].CompareTo(p.EntryName) > 0)
                            p = p.rChild;
                        else if (path[0].CompareTo(p.EntryName) < 0)
                            p = p.lChild;
                        else
                            break;
                    }
                    if (null != p)
                    {
                        if (1 >= path.Length)
                            p.Add(null, name);
                        else
                        {
                            string[] vs = new string[path.Length - 1];
                            for (int i = 0; i < vs.Length; i++)
                                vs[i] = path[i + 1];
                            p.Add(vs, name);
                        }
                    }
                    else
                    {
                        Add(path[0]);
                        Add(path, name);
                    }
                } 
            }
        }
        /// <summary>
        /// 删除指定段落
        /// </summary>
        /// <param name="path">段落路径</param>
        /// <param name="name">段落名</param>
        public void Del(string[] path, string name)
        {
            if (null == path)
                Del(name);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.Del(null, name);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.Del(vs, name);
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定段落的段落名
        /// </summary>
        /// <param name="path">段落路径</param>
        /// <param name="name_o">原始段落名</param>
        /// <param name="name_n">新的段落名</param>
        public void Edit(string[] path, string name_o, string name_n)
        {
            if (null == path)
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (name_o.CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (name_o.CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                    p.Edit(name_n);
            }
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.Edit(null, name_o, name_n);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.Edit(vs, name_o, name_n);
                    }
                }
            }
        }

        /// <summary>
        /// 在指定段落中添加键
        /// </summary>
        /// <param name="path">添加路径</param>
        /// <param name="key">键名</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public void AddKey(string[] path, string key, string data, SUBKEY_TYPE type)
        {
            if (null == path)
                AddKey(key, data, type);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.AddKey(null, key, data, type);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.AddKey(vs, key, data, type);
                    }
                }
                else
                {
                    Add(path[0]);
                    AddKey(path, key, data, type);
                }
            }
        }
        /// <summary>
        /// 在指定段落中删除指定键
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">键名</param>
        public void DelKey(string[] path, string key)
        {
            if (null == path)
                DelKey(key);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.DelKey(null, key);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.DelKey(vs, key);
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定键的键名
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key_o">老的键名</param>
        /// <param name="key_n">新的键名</param>
        public void EditKey(string[] path, string key_o, string key_n)
        {
            if (null == path)
                EditKey(key_o, key_n);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.EditKey(null, key_o, key_n);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.EditKey(vs, key_o, key_n);
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定键的键类型
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">指定的键名</param>
        /// <param name="type">键类型</param>
        public void EditKey(string[] path, string key, SUBKEY_TYPE type)
        {
            if (null == path)
                EditKey(key, type);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.EditKey((string[])null, key, type);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.EditKey(vs, key, type);
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定键的键值
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">指定的键名</param>
        /// <param name="data">键值</param>
        /// <param name="flag">区分标识</param>
        public void EditKey(string[] path, string key, string data, bool flag)
        {
            if (null == path)
                EditKey(key, data, flag);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.EditKey(null, key, data, flag);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.EditKey(vs, key, data, flag);
                    }
                }
            }
        }
        /// <summary>
        /// 修改指定键的键值和键类型
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">指定的键</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public void EditKey(string[] path, string key, string data, SUBKEY_TYPE type)
        {
            if (null == path)
                EditKey(key, data, type);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        p.EditKey(null, key, data, type);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        p.EditKey(vs, key, data, type);
                    }
                }
            }
        }
        /// <summary>
        /// 获取指定段落中的所有次级段落
        /// </summary>
        /// <param name="path">段落路径</param>
        /// <returns>返回段落组</returns>
        public string[] GetEntrys(string[] path)
        {
            string[] result = null;
            if (null == path)
                result = GetEntrys();
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        result = p.GetEntrys(null);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        result = p.GetEntrys(vs);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取指定键的键数据
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">指定键名</param>
        /// <returns>返回键值数据包</returns>
        public KeyPackage GetKey(string[] path, string key)
        {
            KeyPackage result = new KeyPackage
            {
                Name = null,
                Type = SUBKEY_TYPE.STRING,
                Data = null,
            };
            if (null == path)
                result = GetKey(key);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        result = p.GetKey(null, key);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        result = p.GetKey(vs, key);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 将指定键转换为字符串
        /// </summary>
        /// <param name="path">键路径</param>
        /// <param name="key">指定键名</param>
        /// <returns>返回字符串</returns>
        public string KeyToString(string[] path, string key)
        {
            string result = null;
            if (null == path)
                result = KeyToString(key);
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        result = p.KeyToString(null, key);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        result = p.KeyToString(vs, key);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取所有键的键数据
        /// </summary>
        /// <returns>返回键值数据包组</returns>
        public KeyPackage[] GetKeys(string[] path)
        {
            KeyPackage[] packages = null;
            if (null == path)
                packages = GetKeys();
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        packages = p.GetKeys(null);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        packages = p.GetKeys(vs);
                    }
                }
            }
            return packages;
        }
        /// <summary>
        /// 将所有键值转换为字符串
        /// </summary>
        /// <returns>返回字符串组</returns>
        public string[] GetKeyStrs(string[] path)
        {
            string[] result = null;
            if (null == path)
                result = GetKeyStrs();
            else
            {
                EntryNode p = Head;
                while (null != p)
                {
                    if (path[0].CompareTo(p.EntryName) > 0)
                        p = p.rChild;
                    else if (path[0].CompareTo(p.EntryName) < 0)
                        p = p.lChild;
                    else
                        break;
                }
                if (null != p)
                {
                    if (1 >= path.Length)
                        result = p.GetKeyStrs(null);
                    else
                    {
                        string[] vs = new string[path.Length - 1];
                        for (int i = 0; i < vs.Length; i++)
                            vs[i] = path[i + 1];
                        result = p.GetKeyStrs(vs);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 格式化获取所有数据
        /// </summary>
        /// <returns>返回格式化字符串</returns>
        public string[] GetAllStrs(int desk = 0)
        {
            EntryNode node = Head;
            StringLink stringLink = new StringLink();
            string EntryIndent = "", KeyIndent = "";
            for (int i = 0; i < desk; i++)
            {
                EntryIndent += "\t";
                KeyIndent += "\t\t";
            }
            stringLink.Add(EntryIndent + ToString());
            if (null != node)
            {
                EntryNode[] stack = new EntryNode[HeadNum];
                EntryNode p = Head;
                int top = -1;
                do
                {
                    while (null != p)
                    {
                        stack[++top] = p;
                        p = p.lChild;
                    }
                    p = stack[top--];
                    stringLink.Append(p.GetAllStrs(desk + 1));
                    p = p.rChild;
                } while (-1 != top || null != p);
            }
            if (0 < KeyNum)
            {
                KeyNode p = KeyLink;
                while (null != p.Next)
                {
                    stringLink.Add(KeyIndent + p.Next.ToString());
                    p = p.Next;
                }
            }
            stringLink.Add(EntryIndent + GetEnd());
            return stringLink.Read();
        }

        /// <summary>
        /// 在本段落中添加新的子段落
        /// </summary>
        /// <param name="name">子段落名</param>
        public void Add(string name)
        {
            if (null == Head)
            {
                Head = new EntryNode(name)
                {
                    lChild = null,
                    rChild = null,
                };
                HeadNum++;
            }
            else
            {
                EntryNode node = new EntryNode(name)
                {
                    lChild = null,
                    rChild = null,
                };
                EntryNode p = Head, s;
                s = p;
                while (null != p)
                {
                    s = p;
                    if (p > node)
                        p = p.lChild;
                    else if (p < node)
                        p = p.rChild;
                    else
                        break;
                }
                if (p != node)
                {
                    if (s > node)
                        s.lChild = node;
                    else
                        s.rChild = node;
                    HeadNum++;
                }
            }
        }
        /// <summary>
        /// 从本段落的子段落中删除段落
        /// </summary>
        /// <param name="name">段落名</param>
        public void Del(string name)
        {
            if (null != Head)
            {
                bool Find = false;
                EntryNode p = Head, s = null;
                s = p;
                if (name == Head.EntryName)
                {
                    if (null == Head.lChild && null == Head.rChild)
                    {
                        Head.Destroy();
                        Head = null;
                    }
                    else if (null == Head.lChild)
                    {
                        Head = Head.rChild;
                        p.Destroy();
                    }
                    else if(null == Head.rChild)
                    {
                        Head = Head.lChild;
                        p.Destroy();
                    }
                    else
                    {
                        Head = Head.lChild;
                        s = Head;
                        while (null != s.rChild)
                            s = s.rChild;
                        s.rChild = p.rChild;
                        p.Destroy();
                    }
                    HeadNum--;
                }
                else
                {
                    while (null != p)
                    {
                        if (name == p.EntryName)
                        {
                            Find = true;
                            break;
                        }
                        else
                        {
                            s = p;
                            if (name.CompareTo(p.EntryName) > 0)
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
                        HeadNum--;
                    }
                }
            }
        }
        /// <summary>
        /// 修改本段落中的指定段落的段落名
        /// </summary>
        /// <param name="name">新的名字</param>
        public void Edit(string name)
        {
            EntryName = name;
        }

        /// <summary>
        /// 在本段落中添加一个键
        /// </summary>
        /// <param name="name">键名</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public void AddKey(string name, string data, SUBKEY_TYPE type)
        {
            KeyNode node = new KeyNode(name, data, type)
            {
                Next = null,
            };
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next > node)
                    break;
                else if (p.Next == node)
                    return;
                p = p.Next;
            }
            node.Next = p.Next;
            p.Next = node;
            KeyNum++;
        }
        /// <summary>
        /// 从本段落中删除一个键
        /// </summary>
        /// <param name="name">键名</param>
        public void DelKey(string name)
        {
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    KeyNode pp = p.Next;
                    p.Next = p.Next.Next;
                    pp.Destroy();
                    KeyNum--;
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 在本段落中修改指定键的键名
        /// </summary>
        /// <param name="name_o">老的键名</param>
        /// <param name="name_n">新的键名</param>
        public void EditKey(string name_o, string name_n)
        {
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name_o)
                {
                    p.Next.Edit(name_n);
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 在本段落中修改指定键的键类型
        /// </summary>
        /// <param name="name">指定的键名</param>
        /// <param name="type">键类型</param>
        public void EditKey(string name, SUBKEY_TYPE type)
        {
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    p.Next.Edit(name, type);
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 在本段落中修改指定键的键值
        /// </summary>
        /// <param name="name">指定的键名</param>
        /// <param name="data">键值</param>
        /// <param name="flag">区分标识</param>
        public void EditKey(string name, string data, bool flag)
        {
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    p.Next.Edit(data, flag);
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 在本段落中修改指定键的键值和键类型
        /// </summary>
        /// <param name="name">指定的键</param>
        /// <param name="data">键值</param>
        /// <param name="type">键类型</param>
        public void EditKey(string name, string data, SUBKEY_TYPE type)
        {
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    p.Next.Edit(data, type);
                    break;
                }
                p = p.Next;
            }
        }
        /// <summary>
        /// 获取本段落下的所有次级子段落名
        /// </summary>
        /// <returns>返回段落名字组</returns>
        public string[] GetEntrys()
        {
            string[] vs = null;
            if (0 < HeadNum)
            {
                vs = new string[HeadNum];
                EntryNode[] stack = new EntryNode[HeadNum];
                EntryNode p = Head;
                int top = -1, i = 0;
                do
                {
                    while (null != p)
                    {
                        stack[++top] = p;
                        p = p.lChild;
                    }
                    p = stack[top--];
                    vs[i++] = p.EntryName;
                    p = p.rChild;
                } while (-1 != top || null != p);
            }
            return vs;
        }
        /// <summary>
        /// 获取在本段落中指定键的键数据
        /// </summary>
        /// <param name="name">指定键名</param>
        /// <returns>返回键值数据包</returns>
        public KeyPackage GetKey(string name)
        {
            KeyPackage result = new KeyPackage
            {
                Name = null,
                Type = SUBKEY_TYPE.STRING,
                Data = null,
            };
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    result.Name = p.Next._NAME;
                    result.Type = p.Next._TYPE;
                    result.Data = p.Next._DATA;
                    break;
                }
                p = p.Next;
            }
            return result;
        }
        /// <summary>
        /// 将在本段落中指定键转换为字符串
        /// </summary>
        /// <param name="name">指定键名</param>
        /// <returns>返回字符串</returns>
        public string KeyToString(string name)
        {
            string result = null;
            KeyNode p = KeyLink;
            while (null != p.Next)
            {
                if (p.Next._NAME == name)
                {
                    result = p.Next.ToString();
                    break;
                }
                p = p.Next;
            }
            return result;
        }
        /// <summary>
        /// 获取在本段落中所有键的键数据
        /// </summary>
        /// <returns>返回键值数据包组</returns>
        public KeyPackage[] GetKeys()
        {
            KeyPackage[] packages = null;
            if (0 < KeyNum)
            {
                packages = new KeyPackage[KeyNum];
                KeyNode p = KeyLink;
                int i = 0;
                while (null != p.Next)
                {
                    packages[i++] = new KeyPackage
                    {
                        Name = p.Next._NAME,
                        Type = p.Next._TYPE,
                        Data = p.Next._DATA,
                    };
                    p = p.Next;
                }
            }
            return packages;
        }
        /// <summary>
        /// 将在本段落中所有键值转换为字符串
        /// </summary>
        /// <returns>返回字符串组</returns>
        public string[] GetKeyStrs()
        {
            string[] result = null;
            if (0 < KeyNum)
            {
                result = new string[KeyNum];
                KeyNode p = KeyLink;
                int i = 0;
                while (null != p.Next)
                {
                    result[i++] = p.Next.ToString();
                    p = p.Next;
                }
            }
            return result;
        }

        /// <summary>
        /// 从内存中销毁对象
        /// </summary>
        public void Destroy()
        {
            GC.Collect();
        }

        /// <summary>
        /// 判断左值是否小于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator <(EntryNode left, EntryNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.EntryName.CompareTo(right.EntryName) < 0)
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
        /// 判断左值是否大于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >(EntryNode left, EntryNode right)
        {
            bool flag = false;
            if (null != (object)left)
            {
                if (null != (object)right)
                {
                    if (left.EntryName.CompareTo(right.EntryName) > 0)
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
        /// 判断左值是否小于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator <=(EntryNode left, EntryNode right)
        {
            return !(left > right);
        }
        /// <summary>
        /// 判断左值是否大于等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator >=(EntryNode left, EntryNode right)
        {
            return !(left < right);
        }
        /// <summary>
        /// 判断左值是否等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator ==(EntryNode left, EntryNode right)
        {
            return !((left < right) || (left > right));
        }
        /// <summary>
        /// 判断左值是否不等于右值
        /// </summary>
        /// <param name="left">左值</param>
        /// <param name="right">右值</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(EntryNode left, EntryNode right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 将段落节点输出为字符串（已重写）
        /// </summary>
        /// <returns>返回字符串</returns>
        public override string ToString()
        {
            if ("MRX" == EntryName)
                return "<MRX>";
            return "<Entry name = \"" + EntryName + "\">";
        }
        /// <summary>
        /// 比较指定节点与当前节点是否相等（已重写）
        /// </summary>
        /// <param name="obj">指定节点</param>
        /// <returns>返回比较结果</returns>
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (null != obj)
            {
                if (GetType() == obj.GetType())
                    flag = this == (EntryNode)obj;
                else
                    flag = false;
            }
            else
                flag = false;
            return flag;
        }
        /// <summary>
        /// 用于获取哈希值的函数（已重写）
        /// </summary>
        /// <returns>返回哈希值</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// 获取段落节点结束字符串
        /// </summary>
        /// <returns>返回字符串</returns>
        public string GetEnd()
        {
            if ("MRX" == EntryName)
                return "</MRX>";
            return "</Entry>";
        }
    }
}
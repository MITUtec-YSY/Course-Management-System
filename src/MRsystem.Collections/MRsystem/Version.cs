using System;
using System.Collections.Generic;
using System.Text;

namespace MRsystem.Collections
{
    /// <summary>
    /// MR版本信息存储器（对象可序列化）
    /// </summary>
    [Serializable]
    public class Version
    {
        private byte Main;  //主要版本号
        private byte Second;   //第二版本号
        private byte Third;   //第三版本号
        private byte SubVer;    //子版本号
        private byte Max;    //版本号上限值

        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        public Version()
        {
            Main = 0x01;
            Second = 0x00;
            Third = 0x00;
            SubVer = 0x01;
            Max = 0x10;
        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(byte[] vs, byte max = 0x0A)
        {
            Max = max;
            switch (vs.Length)
            {
                case 4:
                    SubVer = vs[3];
                    Third = vs[2];
                    Second = vs[1];
                    Main = vs[0];
                    break;
                case 3:
                    SubVer = 0x00;
                    Third = vs[2];
                    Second = vs[1];
                    Main = vs[0];
                    break;
                case 2:
                    Third = SubVer = 0x00;
                    Second = vs[1];
                    Main = vs[0];
                    break;
                case 1:
                    Second = Third = SubVer = 0x00;
                    Main = vs[0];
                    break;
                default:
                    if (4 < vs.Length)
                    {
                        SubVer = vs[3];
                        Third = vs[2];
                        Second = vs[1];
                        Main = vs[0];
                    }
                    else
                    {
                        Second = Third = SubVer = 0x00;
                        Main = 0x01;
                    }
                    break;
            }
        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(byte[] vs, int max = 10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(byte[] vs, char max = (char)10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(int[] vs, byte max = 0x0A)
        {
            Max = max;
            switch (vs.Length)
            {
                case 4:
                    SubVer = (byte)vs[3];
                    Third = (byte)vs[2];
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 3:
                    SubVer = 0x00;
                    Third = (byte)vs[2];
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 2:
                    Third = SubVer = 0x00;
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 1:
                    Second = Third = SubVer = 0x00;
                    Main = (byte)vs[0];
                    break;
                default:
                    if (4 < vs.Length)
                    {
                        SubVer = (byte)vs[3];
                        Third = (byte)vs[2];
                        Second = (byte)vs[1];
                        Main = (byte)vs[0];
                    }
                    else
                    {
                        Second = Third = SubVer = 0x00;
                        Main = 0x01;
                    }
                    break;
            }
        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(int[] vs, int max = 10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(int[] vs, char max = (char)10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(char[] vs, byte max = 0x0A)
        {
            Max = max;
            switch (vs.Length)
            {
                case 4:
                    SubVer = (byte)vs[3];
                    Third = (byte)vs[2];
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 3:
                    SubVer = 0x00;
                    Third = (byte)vs[2];
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 2:
                    Third = SubVer = 0x00;
                    Second = (byte)vs[1];
                    Main = (byte)vs[0];
                    break;
                case 1:
                    Second = Third = SubVer = 0x00;
                    Main = (byte)vs[0];
                    break;
                default:
                    if (4 < vs.Length)
                    {
                        SubVer = (byte)vs[3];
                        Third = (byte)vs[2];
                        Second = (byte)vs[1];
                        Main = (byte)vs[0];
                    }
                    else
                    {
                        Second = Third = SubVer = 0x00;
                        Main = 0x01;
                    }
                    break;
            }
        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(char[] vs, int max = 10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器构造函数
        /// </summary>
        /// <param name="vs">版本号字节数组</param>
        /// <param name="max">版本号上限</param>
        public Version(char[] vs, char max = (char)10) : this(vs, (byte)max)
        {

        }
        /// <summary>
        /// MR版本信息存储器复制构造函数
        /// </summary>
        /// <param name="_copy">拷贝源</param>
        public Version(Version _copy)
        {
            Main = _copy.Main;
            Second = _copy.Second;
            Third = _copy.Third;
            SubVer = _copy.SubVer;
            Max = _copy.Max;
        }

        /// <summary>
        /// 将子版本号提升一个版本
        /// </summary>
        public void Add()
        {
            if (SubVer + 0x01 > Max)
            {
                SubVer = (byte)(SubVer + 0x01 - Max);
                if (Third + 0x01 > Max)
                {
                    Third = (byte)(Third + 0x01 - Max);
                    if (Second + 0x01 > Max)
                    {
                        Second = (byte)(Second + 0x01 - Max);
                        if (Main + 0x01 > Max)
                            Main = Max;
                        else
                            Main += 0x01;
                    }
                    Second += 0x01;
                }
                else
                    Third += 0x01;
            }
            else
                SubVer += 0x01;
        }
        /// <summary>
        /// 将子版本号提升一个指定版本数
        /// </summary>
        /// <param name="vs">提升的版本数</param>
        public void Add(byte vs)
        {
            if (SubVer + vs > Max)
            {
                SubVer = (byte)(SubVer + vs - Max);
                if (Third + 0x01 > Max)
                {
                    Third = (byte)(Third + 0x01 - Max);
                    if (Second + 0x01 > Max)
                    {
                        Second = (byte)(Second + 0x01 - Max);
                        if (Main + 0x01 > Max)
                            Main = Max;
                        else
                            Main += 0x01;
                    }
                    Second += 0x01;
                }
                else
                    Third += 0x01;
            }
            else
                SubVer += vs;
        }
        /// <summary>
        /// 将各个版本号提升指定版本数
        /// </summary>
        /// <param name="vs">版本号提升组</param>
        /// <example>
        /// <c>Main=vs[3]</c>
        /// <c>Second=vs[2]</c>
        /// <c>Third=vs[1]</c>
        /// <c>SubVer=vs[0]</c>
        /// </example>
        public void Add(byte[] vs)
        {
            if (null != vs)
            {
                switch (vs.Length)
                {
                    case 4:
                        if (SubVer + vs[3] > Max)
                        {
                            SubVer = (byte)(SubVer + vs[3] - Max);
                            if (Third + vs[2] + 0x01 > Max)
                            {
                                Third = (byte)(Third + 0x01 + vs[2] - Max);
                                if (Second + vs[1] + 0x01 > Max)
                                {
                                    Second = (byte)(Second + 0x01 + vs[1] - Max);
                                    if (Main + vs[0] + 0x01 > Max)
                                        Main = Max;
                                    else
                                        Main += (byte)(vs[0] + 0x01);
                                }
                                Second += (byte)(vs[1] + 0x01);
                            }
                            else
                                Third += (byte)(vs[2] + 0x01);
                        }
                        else
                            SubVer += vs[3];
                        break;
                    case 3:
                        if (SubVer + vs[2] > Max)
                        {
                            SubVer = (byte)(SubVer + vs[1] - Max);
                            if (Third + vs[1] + 0x01 > Max)
                            {
                                Third = (byte)(Third + 0x01 + vs[0] - Max);
                                if (Second + vs[0] + 0x01 > Max)
                                {
                                    Second = (byte)(Second + 0x01 - Max);
                                    if (Main + 0x01 > Max)
                                        Main = Max;
                                    else
                                        Main += 0x01;
                                }
                                Second += (byte)(vs[0] + 0x01);
                            }
                            else
                                Third += (byte)(vs[1] + 0x01);
                        }
                        else
                            SubVer += vs[2];
                        break;
                    case 2:
                        if (SubVer + vs[1] > Max)
                        {
                            SubVer = (byte)(SubVer + vs[0] - Max);
                            if (Third + vs[0] + 0x01 > Max)
                            {
                                Third = (byte)(Third + 0x01 - Max);
                                if (Second + 0x01 > Max)
                                {
                                    Second = (byte)(Second + 0x01 - Max);
                                    if (Main + 0x01 > Max)
                                        Main = Max;
                                    else
                                        Main += 0x01;
                                }
                                Second += 0x01;
                            }
                            else
                                Third += (byte)(vs[0] + 0x01);
                        }
                        else
                            SubVer += vs[1];
                        break;
                    case 1:
                        if (SubVer + vs[0] > Max)
                        {
                            SubVer = (byte)(SubVer + vs[0] - Max);
                            if (Third + 0x01 > Max)
                            {
                                Third = (byte)(Third + 0x01 - Max);
                                if (Second + 0x01 > Max)
                                {
                                    Second = (byte)(Second + 0x01 - Max);
                                    if (Main + 0x01 > Max)
                                        Main = Max;
                                    else
                                        Main += 0x01;
                                }
                                Second += 0x01;
                            }
                            else
                                Third += 0x01;
                        }
                        else
                            SubVer += vs[0];
                        break;
                    default:
                        if (4 < vs.Length)
                        {
                            if (SubVer + vs[3] > Max)
                            {
                                SubVer = (byte)(SubVer + vs[3] - Max);
                                if (Third + vs[2] + 0x01 > Max)
                                {
                                    Third = (byte)(Third + 0x01 + vs[2] - Max);
                                    if (Second + vs[1] + 0x01 > Max)
                                    {
                                        Second = (byte)(Second + 0x01 + vs[1] - Max);
                                        if (Main + vs[0] + 0x01 > Max)
                                            Main = Max;
                                        else
                                            Main += (byte)(vs[0] + 0x01);
                                    }
                                    Second += (byte)(vs[1] + 0x01);
                                }
                                else
                                    Third += (byte)(vs[2] + 0x01);
                            }
                            else
                                SubVer += vs[3];
                        }
                        else
                        {
                            if (SubVer + 0x01 > Max)
                            {
                                SubVer = (byte)(SubVer + 0x01 - Max);
                                if (Third + 0x01 > Max)
                                {
                                    Third = (byte)(Third + 0x01 - Max);
                                    if (Second + 0x01 > Max)
                                    {
                                        Second = (byte)(Second + 0x01 - Max);
                                        if (Main + 0x01 > Max)
                                            Main = Max;
                                        else
                                            Main += 0x01;
                                    }
                                    Second += 0x01;
                                }
                                else
                                    Third += 0x01;
                            }
                            else
                                SubVer += 0x01;
                        }
                        break;
                }
            }
            else
                Add();
        }
        /// <summary>
        /// 将本版本号提升一个指定的版本号
        /// </summary>
        /// <param name="version">指定的版本号</param>
        public void Add(Version version)
        {
            byte[] vs = new byte[4];
            vs[0]= version.SubVer;
            vs[1] = version.Third;
            vs[2] = version.Second;
            vs[3] = version.Main;
            Add(vs);
        }
        /// <summary>
        /// 将子版本号降低一个版本
        /// </summary>
        public void Sub()
        {
            SubVer -= 0x01;
            if (0x00 > SubVer)
            {
                SubVer = 0x00;
                Third -= 0x01;
                if (0x00 > Third)
                {
                    Third = 0x00;
                    Second -= 0x01;
                    if (0x00 > Second)
                    {
                        Second = 0x00;
                        Main -= 0x01;
                        if (0x00 > Main)
                            Main = 0x01;
                    }
                }
            }
        }
        /// <summary>
        /// 将子版本号降低一个指定版本数
        /// </summary>
        /// <param name="vs">降低的版本数</param>
        public void Sub(byte vs)
        {
            SubVer -= vs;
            if (0x00 > SubVer)
            {
                SubVer = 0x00;
                Third -= 0x01;
                if (0x00 > Third)
                {
                    Third = 0x00;
                    Second -= 0x01;
                    if (0x00 > Second)
                    {
                        Second = 0x00;
                        Main -= 0x01;
                        if (0x00 > Main)
                            Main = 0x01;
                    }
                }
            }
        }
        /// <summary>
        /// 将各个版本号降低指定版本数
        /// </summary>
        /// <param name="vs">版本号降低组</param>
        /// <example>
        /// <c>Main=vs[3]</c>
        /// <c>Second=vs[2]</c>
        /// <c>Third=vs[1]</c>
        /// <c>SubVer=vs[0]</c>
        /// </example>
        public void Sub(byte[] vs)
        {
            if (null != vs)
            {
                switch (vs.Length)
                {
                    case 4:
                        SubVer -= vs[3];
                        if (0x00 > SubVer)
                        {
                            SubVer = 0x00;
                            Third -= (byte)(0x01 + vs[2]);
                            if (0x00 > Third)
                            {
                                Third = 0x00;
                                Second -= (byte)(0x01 + vs[1]);
                                if (0x00 > Second)
                                {
                                    Second = 0x00;
                                    Main -= (byte)(0x01 + vs[0]);
                                    if (0x00 > Main)
                                        Main = 0x01;
                                }
                            }
                        }
                        break;
                    case 3:
                        SubVer -= vs[2];
                        if (0x00 > SubVer)
                        {
                            SubVer = 0x00;
                            Third -= (byte)(0x01 + vs[1]);
                            if (0x00 > Third)
                            {
                                Third = 0x00;
                                Second -= (byte)(0x01 + vs[0]);
                                if (0x00 > Second)
                                {
                                    Second = 0x00;
                                    Main -= 0x01;
                                    if (0x00 > Main)
                                        Main = 0x01;
                                }
                            }
                        }
                        break;
                    case 2:
                        SubVer -= vs[1];
                        if (0x00 > SubVer)
                        {
                            SubVer = 0x00;
                            Third -= (byte)(0x01 + vs[0]);
                            if (0x00 > Third)
                            {
                                Third = 0x00;
                                Second -= 0x01;
                                if (0x00 > Second)
                                {
                                    Second = 0x00;
                                    Main -= 0x01;
                                    if (0x00 > Main)
                                        Main = 0x01;
                                }
                            }
                        }
                        break;
                    case 1:
                        SubVer -= vs[0];
                        if (0x00 > SubVer)
                        {
                            SubVer = 0x00;
                            Third -= 0x01;
                            if (0x00 > Third)
                            {
                                Third = 0x00;
                                Second -= 0x01;
                                if (0x00 > Second)
                                {
                                    Second = 0x00;
                                    Main -= 0x01;
                                    if (0x00 > Main)
                                        Main = 0x01;
                                }
                            }
                        }
                        break;
                    default:
                        if (4 < vs.Length)
                        {
                            SubVer -= vs[3];
                            if (0x00 > SubVer)
                            {
                                SubVer = 0x00;
                                Third -= (byte)(0x01 + vs[2]);
                                if (0x00 > Third)
                                {
                                    Third = 0x00;
                                    Second -= (byte)(0x01 + vs[1]);
                                    if (0x00 > Second)
                                    {
                                        Second = 0x00;
                                        Main -= (byte)(0x01 + vs[0]);
                                        if (0x00 > Main)
                                            Main = 0x01;
                                    }
                                }
                            }
                        }
                        else
                            Sub();
                        break;
                }
            }
            else
                Sub();
        }
        /// <summary>
        /// 将本版本号降低一个指定的版本号
        /// </summary>
        /// <param name="version">降低的版本号</param>
        public void Sub(Version version)
        {
            byte[] vs = new byte[4];
            vs[0] = version.SubVer;
            vs[1] = version.Third;
            vs[2] = version.Second;
            vs[3] = version.Main;
            Sub(vs);
        }

        /// <summary>
        /// 格式化的版本号输出
        /// </summary>
        /// <param name="spilt">格式化串</param>
        /// <returns>返回格式化字符串</returns>
        public string FormatText(string spilt)
        {
            if (null != spilt)
            {
                if (string.Empty != spilt)
                {
                    int[] vs = new int[4];
                    vs[0] = Main;
                    vs[1] = Second;
                    vs[2] = Third;
                    vs[3] = SubVer;
                    return vs[0] + spilt + vs[1] + spilt + vs[2] + spilt + vs[3];
                }
            }
            return Text;
        }
        /// <summary>
        /// 获取默认格式化串
        /// </summary>
        public string Text
        {
            get
            {
                int[] vs = new int[4];
                vs[0] = Main;
                vs[1] = Second;
                vs[2] = Third;
                vs[3] = SubVer;
                return vs[0] + "." + vs[1] + "." + vs[2] + "." + vs[3];
            }
        }

        /// <summary>
        /// 将子版本号提升一个版本
        /// </summary>
        /// <param name="version">自增源</param>
        /// <returns>返回增加后的对象</returns>
        public static Version operator ++(Version version)
        {
            Version ver = new Version(version);
            ver.Add();
            return ver;
        }
        /// <summary>
        /// 将子版本号提升一个指定版本数
        /// </summary>
        /// <param name="version">增加源</param>
        /// <param name="vs">提升的版本数</param>
        /// <returns>返回增加后的对象</returns>
        public static Version operator +(Version version, byte vs)
        {
            version.Add(vs);
            return new Version(version);
        }
        /// <summary>
        /// 将版本号提升一个指定版本数
        /// </summary>
        /// <param name="version">增加源</param>
        /// <param name="vs">提升的版本数</param>
        /// <returns>返回增加后的对象</returns>
        /// <example>
        /// <c>Main=vs[3]</c>
        /// <c>Second=vs[2]</c>
        /// <c>Third=vs[1]</c>
        /// <c>SubVer=vs[0]</c>
        /// </example>
        public static Version operator +(Version version, byte[] vs)
        {
            version.Add(vs);
            return new Version(version);
        }
        /// <summary>
        /// 将两个版本号相加
        /// </summary>
        /// <param name="version_left">左值</param>
        /// <param name="version_right">右值</param>
        /// <returns>返回相加后的对象</returns>
        public static Version operator +(Version version_left, Version version_right)
        {
            version_left.Add(version_right);
            return new Version(version_left);
        }
        /// <summary>
        /// 将子版本号降低一个版本
        /// </summary>
        /// <param name="version">降低源</param>
        /// <returns>返回降低后的对象</returns>
        public static Version operator --(Version version)
        {
            Version ver = new Version(version);
            ver.Sub();
            return ver;
        }
        /// <summary>
        /// 将子版本号降低一个指定版本数
        /// </summary>
        /// <param name="version">降低源</param>
        /// <param name="vs">降低的版本数</param>
        /// <returns>返回降低后的对象</returns>
        public static Version operator -(Version version, byte vs)
        {
            version.Sub(vs);
            return new Version(version);
        }
        /// <summary>
        /// 将版本号降低一个指定版本数
        /// </summary>
        /// <param name="version">增加源</param>
        /// <param name="vs">降低的版本数</param>
        /// <returns>返回减少后的对象</returns>
        /// <example>
        /// <c>Main=vs[3]</c>
        /// <c>Second=vs[2]</c>
        /// <c>Third=vs[1]</c>
        /// <c>SubVer=vs[0]</c>
        /// </example>
        public static Version operator -(Version version, byte[] vs)
        {
            version.Sub(vs);
            return new Version(version);
        }
        /// <summary>
        /// 将两个版本号相减
        /// </summary>
        /// <param name="version_left">左值</param>
        /// <param name="version_right">右值</param>
        /// <returns>返回相减后的对象</returns>
        public static Version operator -(Version version_left, Version version_right)
        {
            version_left.Sub(version_right);
            return new Version(version_left);
        }
    }
}

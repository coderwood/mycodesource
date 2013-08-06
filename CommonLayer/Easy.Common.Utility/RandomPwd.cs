using System;
using System.Collections.Generic;
using System.Text;

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 随机生成密码
    /// </summary>
    public class RandomPwd
    {
        Random m_rnd = new Random();
        /// <summary>
        /// 转换为字符
        /// </summary>
        /// <returns></returns>
        public char GetRandomChar()
        {
            int ret = m_rnd.Next(1,122);
            while (ret < 48 || (ret > 57 && ret < 65) || (ret > 90 && ret < 97))
            {
                if (ret != 48 && ret != 111 && ret != 79&&ret!=0)
                {
                    ret = m_rnd.Next(1,122);
                }
            }
            return (char)ret;
        }
        /// <summary>
        /// 根据长度获取随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public string GetRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(GetRandomChar());
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HtlInv.Common.Utility
{
    public class StringHelper
    {
        /// <summary>
        /// 字符串拼接
        /// </summary>
        /// <param name="stringList">字符串列表</param>
        /// <param name="symbol">拼接的字符</param>
        /// <returns>拼接好的字符串</returns>
        public static string MergeString(List<string> stringList,string symbol)
        {
            string result = string.Empty;

            foreach (string str in stringList)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += symbol + str;
                }
                else
                {
                    result +=  str;
                }
            }

            return result;
        }

        /// <summary>
        /// 截取字符串长度(按字节算)
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取条件</param>
        /// <param name="subPlace">截取的字符长度</param>
        /// <param name="flag">true:加"..." false:不加"..."</param>
        /// <returns>返回原字符串截取后的字符串Or截取后的字符串加“...”</returns>
        public static string Sub_StrLength(string str, int length, int subPlace,bool flag)
        {
            int len = 0;//原字符串字符长度
            byte[] b;
            string strCont = string.Empty;//返回值
            for (int i = 0; i < str.Length; i++)
            {
                b = Encoding.Default.GetBytes(str.Substring(i, 1));
                if (b.Length > 1)
                    len += 2;
                else
                    len++;
            }
            if (len <= length)//小于等于截取条件则不作处理
                strCont = str;
            else if (len > length)//否则 返回subPlace个字符+英文“...”
            {
                len = 0;
                strCont = string.Empty;
                for (int i = 0; i < str.Length; i++)
                {
                    b = Encoding.Default.GetBytes(str.Substring(i, 1));
                    if (b.Length > 1)
                    {
                        len += 2;
                    }
                    else
                    {
                        len++;
                    }
                    if (len <= subPlace)
                    {
                        strCont += str[i];
                    }
                }
                if (flag)
                strCont += "...";
            }
            return strCont;
        }
    }
}

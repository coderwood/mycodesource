using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyUtility
{
    public static class StringUtility
    {
        #region 字符串验证
        /// <summary>
        /// 验证是否是手机号码
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否是手机号码</returns>
        public static bool IsMobilePhone(string input)
        {
            return Regex.IsMatch(input, @"^1[3458]\\d{9}$");
        }

        /// <summary>
        /// 验证字符串是否都是数字
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否是数字</returns>
        public static bool IsAllNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
        #endregion

        #region 字符串反转
        /// <summary>
        /// 字符串数组实现字符反转
        /// 使用类库方法
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <returns>反转后的字符串</returns>
        public static string ReverseStringByArray(string original)
        {
            char[] o = original.ToCharArray();
            Array.Reverse(o);
            return new string(o);
        }

        /// <summary>
        /// 字符串缓存实现字符反转
        /// 效率最高，推荐使用
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <returns>反转后的字符串</returns>
        public static string ReverseStringByCharBuffer(string original)
        {
            int length = original.Length;
            char[] r = original.ToCharArray();

            for (int i = 0; i < length / 2; i++)
            {
                r[i] = original[length - i - 1];
                r[length - i - 1] = original[i];
            }

            return new string(r);
        }

        /// <summary>
        /// 字符串缓存实现字符反转
        /// 使用栈结构
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <returns>反转后的字符串</returns>
        public static string ReverseStringByStack(string original)
        {
            Stack<char> s = new Stack<char>();
            foreach (char item in original)
            {
                s.Push(item);
            }

            char[] r = new char[original.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = s.Pop();
            }

            return new string(r);
        }
        #endregion

        #region 字符串分组
        /// <summary>
        /// 字符串分组
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="count"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static List<string> SubGroup(string resource, int count, char character)
        {
            List<string> stringList = new List<string>();

            string[] allHotels = resource.Split(character);
            for (int i = 0; i < ((allHotels.Length - 1) / count + 1); i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < count && (i * count + j) < allHotels.Length; j++)
                {
                    sb.Append(allHotels[i * count + j] + ",");
                }
                stringList.Add(sb.ToString().TrimEnd(','));
            }

            return stringList;
        }
        #endregion
    }
}

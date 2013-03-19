using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyCommon
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
    }
}

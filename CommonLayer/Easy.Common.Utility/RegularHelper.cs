using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 正则表达式验证
    /// </summary>
    public class RegularHelper
    {
        /// <summary>
        /// 字符串是否包含数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHaveNumber(string str)
        {
            string pattern = GetPatern(2);
            bool result = Regex.IsMatch(str, pattern);
            return result;
        }
        /// <summary>
        /// 获取表达式类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetPatern(int type)
        {
            string result = "";
            switch (type)
            {
                case 1:
                    result = @"^-?\d+$"; //是否是整数
                    break;
                case 2:
                    result = @"[0-9]*[1-9][0-9]";  //是否包含数字
                    break;
                case 3:
                    result = @"^\d+(\.\d+)?$"; //非负浮点数（正浮点数 + 0） 
                    break;
                case 4:
                    result = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";//正浮点数 
                    break;
                case 5:
                    result = @"^(-?\d+)(\.\d+)?$";//浮点数 
                    break;
                case 6:
                    result = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";//负浮点数 
                    break;
                case 7:
                    result = @"^[A-Za-z]+$"; //由26个英文字母组成的字符串 
                    break;
                case 8:
                    result = @"^[A-Z]+$";  //由26个英文字母的大写组成的字符串 
                    break;
                case 9:
                    result = @"^[A-Za-z0-9]+$"; //由数字和26个英文字母组成的字符串
                    break;
                case 10:
                    result = @"^\w+$"; //由数字、26个英文字母或者下划线组成的字符串 
                    break;
                case 11:
                    result = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"; //email地址
                    break;
                case 12:
                    result = @"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"; //url 
                    break;
                case 13:
                    result = @"/^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$";// 年-月-日 
                    break;
                case 14:
                    result = @"(d+-)?(d{4}-?d{7}|d{3}-?d{8}|^d{7,8})(-d+)?"; //电话号码 
                    break;
                case 15:
                    result = @"^(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5])$";//ip地址
                    break;
                case 16:
                    result = @"[\u4e00-\u9fa5]";//汉字
                    break;
                case 17:
                    result = @"^\s*)|(\s*$";//首尾空格
                    break;
                
                default: break;
            }
            return result;
        }

        /// <summary>
        /// 获取关键字
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <returns></returns>
        public static string GetKeyWords(string url)
        {
            string key="";
            Regex reg = null;
            //k1
            reg = new Regex(@"keyword=([^&/]*)", RegexOptions.IgnoreCase);
            Match m = null;
            if (reg.IsMatch(url))
            {
                m = reg.Match(url);
                key = m.Groups[1].Value;
            }
            return key;
        }

        /// <summary>
        /// 获取点评类型
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <returns></returns>
        public static string GetCommentType(string url)
        {
            string key = "";
            Regex reg = null;
            //k1
            reg = new Regex(@"comType=([^&/]*)", RegexOptions.IgnoreCase);
            Match m = null;
            if (reg.IsMatch(url))
            {
                m = reg.Match(url);
                key = m.Groups[1].Value;
            }
            return key;
        }
    }
}

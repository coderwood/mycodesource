using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace HtlInv.Common.Utility
{
    public static class ExpandHelper
    {
        #region 字符串操作
        /// <summary>
        /// 自定义扩展方法,将字符串转换成值类型
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <returns></returns>
        public static T ToValue<T>(this string input)
        {
            T result = default(T);
            Type resultType = typeof(T);
            if (resultType.IsValueType)
            {
                MethodInfo tryParse = resultType.GetMethod("TryParse", new Type[] { typeof(String), typeof(T).MakeByRefType() });
                object[] paramArray = new object[] { input, result };
                if (tryParse != null)
                {
                    bool flag = (bool)tryParse.Invoke(null, paramArray);
                    if (flag)
                        result = (T)paramArray[1];
                }
            }
            return result;
        }

        /// <summary>
        /// 自定义扩展方法,将字符串转换成自定义枚举类型
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="input">输入的字符串</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string input)
        {
            T result = default(T);
            Type resultType = typeof(T);
            if (resultType.IsEnum)
            {
                MethodInfo tryParse = null;
                MethodInfo[] methodList = typeof(Enum).GetMethods();
                IEnumerator ide = methodList.GetEnumerator();
                while (ide.MoveNext())
                {
                    MethodInfo tmpInfo = (MethodInfo)ide.Current;
                    if (tmpInfo.Name.Equals("TryParse") && tmpInfo.IsGenericMethod && tmpInfo.GetParameters().Length == 2)
                    {
                        tryParse = tmpInfo;
                        break;
                    }
                }
                if (tryParse != null)
                {
                    tryParse = tryParse.MakeGenericMethod(typeof(T));
                    object[] paramArray = new object[] { input, result };
                    bool flag = (bool)tryParse.Invoke(null, paramArray);
                    if (flag)
                        result = (T)paramArray[1];
                }
            }
            return result;
        }

        /// <summary>
        /// 取整数，可转换带小数点的字符串
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns></returns>
        public static int ToInteger(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            return input.ToValue<double>().ToString("F0").ToValue<int>();
        }

        /// <summary>
        /// 将字符串转换成带小数的值类型
        /// </summary>
        /// <typeparam name="T">输入的类型</typeparam>
        /// <param name="input">要去除小数点的值</param>
        /// <param name="bit">要带几位小数</param>
        /// <returns></returns>
        public static T StrToDecimal<T>(this string input, int bit)
        {
            if (string.IsNullOrEmpty(input))
                return default(T);
            if (bit < 0)
                bit = 0;
            string param = string.Concat("F", bit);
            return input.ToValue<double>().ToString(param).ToValue<T>();
        }

        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="input">当前字符串</param>
        /// <param name="formartStr">要拼接的字符串</param>
        /// <returns>拼接后的字符串</returns>
        public static string FormatStr(this string input, params string[] formartStr)
        {
            if (formartStr == null || formartStr.Length == 0)
                return input;
            List<string> strList = new List<string>();
            strList.Add(input);
            strList.AddRange(formartStr);
            return string.Concat<string>(formartStr);
        }

        /// <summary>
        /// 自定义扩展方法,将字符串转换成数组
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <param name="spilt">分隔符</param>
        /// <returns></returns>
        public static List<T> StrToList<T>(this string input,char spilt)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            string[] tmpList = input.Split(new char[] { spilt });
            List<T> result = new List<T>();
            if (tmpList != null && tmpList.Length > 0)
            {
                foreach (string item in tmpList)
                {
                    result.Add(item.ToValue<T>());
                }
            }
            return result;
        }
        #endregion

        #region 数组操作
        /// <summary>
        /// 自定义扩展方法,将list按指定分隔符转换成string
        /// </summary>
        /// <param name="input">待转换的值类型数组</param>
        /// <param name="splitStr">分隔符</param>
        /// <returns></returns>
        public static string ToCustomString(this ICollection input, char splitStr)
        {
            if (input == null)
                return string.Empty;
            IEnumerator ie = input.GetEnumerator();
            List<string> strList = new List<string>();
            while (ie.MoveNext())
            {
                strList.Add(ie.Current.ToString());
                strList.Add(splitStr.ToString());
            }
            strList.RemoveAt(strList.Count - 1);
            return string.Concat<string>(strList);
        }

        /// <summary>
        /// 用来获取属性值的委托
        /// </summary>
        /// <typeparam name="T">实体的类型</typeparam>
        /// <typeparam name="V">属性的返回值类型</typeparam>
        /// <param name="entity">包含值的实体</param>
        /// <returns></returns>
        delegate V deleGetProterty<T, V>(T entity);
        /// <summary>
        /// 自定义扩展方法,将list的指定属性的值按自定义分隔符拼接成string
        /// </summary>
        /// <typeparam name="T">实体的类型</typeparam>
        /// <typeparam name="V">属性的返回值类型</typeparam>
        /// <param name="input">待转换的类数组</param>
        /// <param name="proterty">要拼接的属性</param>
        /// <param name="splitStr">分隔符</param>
        /// <returns></returns>
        public static string ToCustomString<T, V>(this ICollection<T> input, string proterty, char splitStr) where T : class
        {
            if (input == null)
                return string.Empty;
            if (string.IsNullOrEmpty(proterty))
                return string.Empty;
            IEnumerator ie = input.GetEnumerator();
            List<string> strList = new List<string>();
            while (ie.MoveNext())
            {
                T entity = (T)ie.Current;
                if (entity != null)
                {
                    PropertyInfo protertyInfo = typeof(T).GetProperty(proterty);
                    if (protertyInfo != null)
                    {
                        deleGetProterty<T, V> deleMethod = (deleGetProterty<T, V>)Delegate.CreateDelegate(typeof(deleGetProterty<,>), protertyInfo.GetGetMethod());
                        V protertyVal = deleMethod.Invoke(entity);
                        if (protertyVal != null)
                        {
                            strList.Add(protertyVal.ToString());
                            strList.Add(splitStr.ToString());
                        }
                    }
                }
            }
            strList.RemoveAt(strList.Count - 1);
            return string.Concat<string>(strList);
        }
        #endregion

        #region 值类型操作
        /// <summary>
        /// 判断是否是奇数还是偶数,(-1:不是奇数也不是偶数，0x0：奇数，0x1：偶数)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>-1:不是奇数也不是偶数，0x0：奇数，0x1：偶数</returns>
        public static int IsOddOrEven(this int input)
        {
            if (input < 0)
                return -1;
            if ((input & 1) == 0)
                return 0x1;
            else
                return 0x0;
        }

        /// <summary>
        /// 取整数
        /// </summary>
        /// <typeparam name="T">输入的类型</typeparam>
        /// <param name="input">要去除小数点的值</param>
        /// <returns></returns>
        public static int ToInteger<T>(this T input)
        {
            string tmpStr = input.ToString();
            return tmpStr.ToValue<double>().ToString("F0").ToValue<int>();
        }

        /// <summary>
        /// 将值类型转换成带小数或不带小数的值类型
        /// </summary>
        /// <typeparam name="T">输入的类型</typeparam>
        /// <param name="input">要去除小数点的值</param>
        /// <param name="bit">要带几位小数</param>
        /// <returns></returns>
        public static V ValueToDecimal<T,V>(this T input, int bit)
        {
            if (bit < 0)
                bit = 0;
            string param = string.Concat("F", bit);
            string tmpStr = input.ToString();
            return tmpStr.ToValue<double>().ToString(param).ToValue<V>();
        }
        #endregion
    }
}

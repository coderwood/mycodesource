using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;
using Castle.Components.Binder;
using System.Reflection;
using System.Collections;

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 页面通用函数
    /// </summary>
    /// <history>
    ///  <date>2010-02-02</date>
    ///  <programmer>赵阳</programmer>
    /// <document></document>
    /// </history>
    public class WebPageUtil
    {
        
        #region        
        /// <summary>
        /// string To int型
        /// </summary>
        public static int StringChangeToInt(string str) 
        {
            int rval = 0;
            if (!string.IsNullOrEmpty(str))
            {
                if (Int32.TryParse(str, out rval))
                {
                    rval = Convert.ToInt32(str);
                }
            }
            return rval;
        
        }
        
        /// <summary>
        /// string To decimal型
        /// </summary>
        public static decimal StringChangeToDecimal(string str)
        {
            decimal rval = 0;
            if (!string.IsNullOrEmpty(str))
            {
                if (decimal.TryParse(str, out rval))
                {
                    rval = Convert.ToDecimal(str);
                }
            }

            return rval;

        }
       
        /// <summary>
        /// string To double型
        /// </summary>
        public static double StringChangeToDouble(string str)
        {
            double rval = 0;
            if (!string.IsNullOrEmpty(str))
            {
                if (double.TryParse(str, out rval))
                {
                    rval = Convert.ToDouble(str);
                }
            }

            return rval;

        }
        

        
        /// <summary>
        /// string To float型
        /// </summary>
        public static float StringChangeToSingle(string str)
        {
            float rval =0;
            if (!string.IsNullOrEmpty(str))
            {
                if (float.TryParse(str, out rval)) 
                {
                    rval = Convert.ToSingle(str);
                }                
            }

            return rval;

        }
       
        ///<summary>
        /// string to DateTime 型
        ///</summary>
        public static DateTime StringChangeToDateTime(string str) 
        {
            DateTime rval=DateTime.Now;
            if (!string.IsNullOrEmpty(str)) 
            {
                if (DateTime.TryParse(str, out rval))
                {
                    rval = Convert.ToDateTime(str);
                }
            }

            return rval;
        }

        /// <summary>
        /// 响应用户请求  add xlzhang 20120401
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method">"POST" or "GET"</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static StringBuilder GetResponse(string url, string method, string data)
        {
            StringBuilder builder = new StringBuilder(256);
            switch (method)
            {
                case "post":
                    builder.AppendFormat("<html><body><form id='submitdata' method='post' action='{0}'>", url);
                    string[] arg1 = data.Split('&');
                    for (int i = 0; i < arg1.Length; i++)
                    {
                        string[] arg2 = arg1[i].Split('=');
                        builder.AppendFormat("<input type='hidden' name='{0}' value={1} id='{2}'><br/>", arg2[0], arg2[1], arg2[0]);
                    }
                    builder.Append("</form><script language='javascript'> document.getElementById('submitdata').submit();</script></body></html>");
                    return builder;
                case "get":
                    builder.AppendFormat("{0}?", url);
                    builder.Append(data);
                    return builder;
            }
            return builder;
        }
        #endregion

        #region 获取用户Form提交字段值
        /// <summary>
        /// 获取post和get提交值
        /// </summary>
        /// <param name="inputName">字段名</param>
        /// <param name="method">post和get</param>
        /// <param name="MaxLen">最大允许字符长度 0为不限制</param>
        /// <param name="MinLen">最小字符长度 0为不限制</param>
        /// <param name="dataType">字段数值类型 int 和str和dat不限为为空</param>
        /// <returns></returns>
       [Obsolete("该方法已过期，请使用带泛型参数的Sink方法")]
        public static object Sink(string inputName, MethodType method, DataType dataType)
        {
            HttpContext rq = HttpContext.Current;
            string tempValue =string.Empty;

            #region 获取提交字段数据 TempValue
            //if (rq.Request.Form[inputName] == null || rq.Request.Form[inputName].ToString()=="")
            //{
            //    EventMessage.MessageBox(2, "获取数据失败", string.Format("{0}字段不能获取值!", inputName), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //}
            if (method == MethodType.Post)
            {
                if (rq.Request.Form[inputName] != null)
                {
                    tempValue = rq.Request.Form[inputName].ToString();
                }

            }
            else if (method == MethodType.Get)
            {
                if (rq.Request.QueryString[inputName] != null)
                {
                    tempValue = rq.Request.QueryString[inputName].ToString();
                }
            }
            else if (method == MethodType.All)
            {
                if (rq.Request.QueryString[inputName] != null)
                {
                    tempValue = rq.Request.QueryString[inputName].ToString();
                }

                if (String.IsNullOrEmpty(tempValue))
                {
                    if (rq.Request.Form[inputName] != null)
                    {
                        tempValue = rq.Request.Form[inputName].ToString();
                    }
                }
            }
            //else
            //{
            //    MessBox("提交数据方式不是post和get!", "?", rq);
            //    EventMessage.MessageBox(2, "获取数据失败", string.Format("{0}字段提交数据方式不是post和get!", inputName), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //}
            #endregion

            #region 检测最大允许长度，已注释
            //if (MaxLen != 0)
            //{
            //    if (TempValue.Length > MaxLen)
            //    {
            //        EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}超过系统允许长度{2}!", inputName, TempValue, MaxLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //    }
            //}
            #endregion

            #region 检测最小允许长度 ，已注释
            //if (MinLen != 0)
            //{
            //    if (TempValue.Length < MinLen)
            //    {
            //        EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}低于系统允许长度{2}!", inputName, TempValue, MinLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //    }
            //}
            #endregion

            #region 检测数据类型
            if (!string.IsNullOrEmpty(tempValue))
            {
                switch (dataType)
                {
                    case DataType.Int:
                        int IntTempValue = 0;
                        int.TryParse(tempValue, out IntTempValue);
                        //if (!int.TryParse(TempValue, out IntTempValue))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Int型!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return IntTempValue;
                    case DataType.Dat:
                        DateTime DateTempValue = DateTime.MinValue;
                        DateTime.TryParse(tempValue, out DateTempValue);
                        //if (!DateTime.TryParse(TempValue, out DateTempValue))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为日期型!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DateTempValue;
                    case DataType.Long:
                        long LongTempValue = long.MinValue;
                        long.TryParse(tempValue, out LongTempValue);
                        //if (!long.TryParse(TempValue, out LongTempValue))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Log型!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return LongTempValue;
                    case DataType.Double:
                        double DoubleTempValue = double.MinValue;
                        double.TryParse(tempValue, out DoubleTempValue);
                        //if (!double.TryParse(TempValue, out DoubleTempValue))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为Double型!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DoubleTempValue;
                    case DataType.CharAndNum:
                        CheckRegEx(tempValue, "^[A-Za-z0-9]+$");
                        //if (!CheckRegEx(TempValue, "^[A-Za-z0-9]+$"))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为英文或数字!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return tempValue;
                    case DataType.CharAndNumAndChinese:
                        CheckRegEx(tempValue, "^[A-Za-z0-9\u00A1-\u2999\u3001-\uFFFD]+$");
                        //if (!CheckRegEx(TempValue, "^[A-Za-z0-9\u00A1-\u2999\u3001-\uFFFD]+$"))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为英文或数字或中文!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return tempValue;
                    case DataType.Email:
                        CheckRegEx(tempValue, "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                        //if (!CheckRegEx(TempValue, "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
                        //    EventMessage.MessageBox(2, "输入数据格式验证失败", string.Format("{0}字段值：{1}数据类型必需为邮件地址!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return tempValue;
                    default:
                        return tempValue;
                }

            }
            else
            {
                switch (dataType)
                {
                    case DataType.Int:
                        return 0;
                    case DataType.Dat:
                        return DateTime.MinValue;
                    case DataType.Long:
                        return long.MinValue;
                    case DataType.Double:
                        return 0.0f;
                    default:
                        return tempValue;
                }
            }

            #endregion
        }

        /// <summary>
        /// 获取post和get提交值
        /// </summary>
        /// <param name="inputName">key</param>
        /// <param name="method">获取方式 get, pot ,all</param>
        /// <returns>结果，默认为空</returns>
        [Obsolete("该方法已过期，请使用带泛型参数的Sink方法")]
        public static string Sink(string inputName, MethodType method)
        {
            string val = "";
            if (method == MethodType.Get)
            {
                if (HttpContext.Current.Request.QueryString[inputName] == null)
                {
                    val = "";
                }
                else
                {
                    val = HttpContext.Current.Request.QueryString[inputName].ToString();
                }
            }
            else if (method == MethodType.Post)
            {
                if (HttpContext.Current.Request.Form[inputName] == null)
                {
                    val = "";
                }
                else
                {
                    val = HttpContext.Current.Request.Form[inputName].ToString();
                }
            }
            else if (method == MethodType.All)
            {
                val = Sink(inputName, MethodType.Get);
                if (String.IsNullOrEmpty(val))
                {
                    val = Sink(inputName, MethodType.Post);
                }
            }
            if (inputName.Equals("star") && !val.Equals("") && val.IndexOf(',').Equals(-1)) //URL重写将星级数值重新拼写，如：234->2,3,4    add xlzhang 120509
            {
                val = GetStarValue(val);
            }
            return val;
        }
        /// <summary>
        /// 获取星级数值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetStarValue(string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;
            if (val.Length == 1)
                return val;
            string star = string.Empty;
            
            for (int i = 0; i < val.Length; i++)
            {
                star += val.Substring(i, 1) + ",";
            }
            star = star.Substring(0, star.Length - 1);
            return star;
        }
        #endregion

        #region 界面数据绑定对象
        /// <summary>
        /// 获取web界面数据对象。
        /// web界面，控件以pre.Name等方式命名（name）
        /// 当界面提交时，通过改方法可直接获得对象。
        /// </summary>
        /// <typeparam name="T">返回对象类</typeparam>
        /// <param name="preg">界面用前缀。界面控件name名</param>
        /// <returns>返回对象</returns>
        public static T BindObjectByForm<T>(string preg)
        {
            // 界面数据绑定
            TreeBuilder treeBuilder = new TreeBuilder();
            CompositeNode formCompositeNode = 
                treeBuilder.BuildSourceNode(HttpContext.Current.Request.Form);
            treeBuilder.PopulateTree(formCompositeNode, HttpContext.Current.Request.Files);

            DataBinder bind = new DataBinder();
            T entity = (T)bind.BindObject(typeof(T), preg, formCompositeNode);
            return entity;
        }

        public static void BindObjectInstanceByForm<T>(object inst, string preg)
        {
            // 界面数据绑定
            Castle.Components.Binder.TreeBuilder treeBuilder = new Castle.Components.Binder.TreeBuilder();
            Castle.Components.Binder.CompositeNode formCompositeNode =
                treeBuilder.BuildSourceNode(HttpContext.Current.Request.Form);
            treeBuilder.PopulateTree(formCompositeNode, HttpContext.Current.Request.Files);

            Castle.Components.Binder.DataBinder bind = new Castle.Components.Binder.DataBinder();
            bind.BindObjectInstance(inst, preg, formCompositeNode);
        }
        #endregion
        
        #region 正式表达式验证 Help Functions
        /// <summary>
        /// 正式表达式验证
        /// </summary>
        /// <param name="C_Value">验证字符</param>
        /// <param name="C_Str">正式表达式</param>
        /// <returns>符合true不符合false</returns>
        private static bool CheckRegEx(string C_Value, string C_Str)
        {
            Regex objAlphaPatt;
            objAlphaPatt = new Regex(C_Str, RegexOptions.Compiled);


            return objAlphaPatt.Match(C_Value).Success;
        }
        #endregion

        #region 获取用户Form提交的字段值
        /// <summary>
        /// 获取post和get提交值
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="inputName">字段名</param>
        /// <param name="method">post和get</param>
        /// <param name="isDecode">是否需要解码</param>
        /// <param name="isSecurity">是否要经过安全过滤</param>
        /// <returns></returns>
        public static T Sink<T>(string inputName, MethodType method,bool isSecurity,bool isDecode=false)
        {
            string tempValue = GetPostOrRequestValue(inputName, method, isSecurity, isDecode);
            T result = ChangeTypeValue<T>(tempValue);
            return result;
        }

        /// <summary>
        /// 转换类型的值
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="inputValue">输入的字符串</param>
        /// <returns></returns>
        public static T ChangeTypeValue<T>(string inputValue)
        {
            T result = default(T);
            Type resultType = typeof(T);
            if (resultType.IsValueType)
            {
                MethodInfo tryParse = null;
                if (resultType.IsEnum)
                {
                    MethodInfo[] methodList = typeof(Enum).GetMethods();
                    if (methodList != null)
                    {
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
                    }
                    tryParse = tryParse.MakeGenericMethod(typeof(T));
                }
                else
                {
                    tryParse = resultType.GetMethod("TryParse", new Type[] { typeof(String), typeof(T).MakeByRefType() });
                }
                object[] paramArray = new object[] { inputValue, result };
                if (tryParse != null)
                {
                    bool flag = (bool)tryParse.Invoke(null, paramArray);
                    if (flag)
                        result = (T)paramArray[1];
                }
            }
            else
            {
                result = (T)Convert.ChangeType(inputValue, typeof(T));
            }
            return result;
        }

        /// <summary>
        /// 获取post或get的值
        /// </summary>
        /// <param name="inputName">参数</param>
        /// <param name="method">提交类型</param>
        /// <returns></returns>
        private static string GetPostOrRequestValue(string inputName, MethodType method,bool isSecurity,bool isDecode)
        {
            HttpContext context = HttpContext.Current;
            string tempValue = string.Empty;
            #region 获取提交字段数据 TempValue
            if (method == MethodType.Post)
            {
                if (context.Request.Form[inputName] != null)
                {
                    tempValue = context.Request.Form[inputName].ToString();
                }
            }
            else if (method == MethodType.Get)
            {
                if (context.Request.QueryString[inputName] != null)
                {
                    tempValue = context.Request.QueryString[inputName].ToString();
                }
            }
            else if (method == MethodType.All)
            {
                if (context.Request.QueryString[inputName] != null)
                {
                    tempValue = context.Request.QueryString[inputName].ToString();
                }

                if (String.IsNullOrEmpty(tempValue))
                {
                    if (context.Request.Form[inputName] != null)
                    {
                        tempValue = context.Request.Form[inputName].ToString();
                    }
                }
            }
            #endregion
            return FilterResult(isSecurity, isDecode, tempValue);
        }

        /// <summary>
        /// 过滤结果
        /// </summary>
        /// <param name="isSecurity">是否需要安全过滤</param>
        /// <param name="isEncode">是否需要解码</param>
        /// <param name="requestValue">参数值</param>
        /// <returns></returns>
        private static string FilterResult(bool isSecurity, bool isEncode, string requestValue)
        {
            if (isEncode)
                requestValue = HttpUtility.UrlDecode(requestValue);
            //if (isSecurity)
            //    return SecurityUtil.SecurityFilter(requestValue);
            //else
                return requestValue;
        }
        #endregion
    }
    /// <summary>
    /// 获取请求数据方式
    /// </summary>
    public enum MethodType
    {
        All = 0,
        /// <summary>
        /// Post方式
        /// </summary>
        Post = 1,
        /// <summary>
        /// Get方式
        /// </summary>
        Get = 2
    }
    
    /// <summary>
    /// 获取数据类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 字符
        /// </summary>
        Str = 1,
        /// <summary>
        /// 日期
        /// </summary>
        Dat = 2,
        /// <summary>
        /// 整型
        /// </summary>
        Int = 3,
        /// <summary>
        /// 长整型
        /// </summary>
        Long = 4,
        /// <summary>
        /// 双精度小数
        /// </summary>
        Double = 5,
        /// <summary>
        /// 只限字符和数字
        /// </summary>
        CharAndNum = 6,
        /// <summary>
        /// 只限邮件地址
        /// </summary>
        Email = 7,
        /// <summary>
        /// 只限字符和数字和中文
        /// </summary>
        CharAndNumAndChinese = 8
    }

    
}

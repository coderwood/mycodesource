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
    /// ҳ��ͨ�ú���
    /// </summary>
    /// <history>
    ///  <date>2010-02-02</date>
    ///  <programmer>����</programmer>
    /// <document></document>
    /// </history>
    public class WebPageUtil
    {
        
        #region        
        /// <summary>
        /// string To int��
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
        /// string To decimal��
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
        /// string To double��
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
        /// string To float��
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
        /// string to DateTime ��
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
        /// ��Ӧ�û�����  add xlzhang 20120401
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

        #region ��ȡ�û�Form�ύ�ֶ�ֵ
        /// <summary>
        /// ��ȡpost��get�ύֵ
        /// </summary>
        /// <param name="inputName">�ֶ���</param>
        /// <param name="method">post��get</param>
        /// <param name="MaxLen">��������ַ����� 0Ϊ������</param>
        /// <param name="MinLen">��С�ַ����� 0Ϊ������</param>
        /// <param name="dataType">�ֶ���ֵ���� int ��str��dat����ΪΪ��</param>
        /// <returns></returns>
       [Obsolete("�÷����ѹ��ڣ���ʹ�ô����Ͳ�����Sink����")]
        public static object Sink(string inputName, MethodType method, DataType dataType)
        {
            HttpContext rq = HttpContext.Current;
            string tempValue =string.Empty;

            #region ��ȡ�ύ�ֶ����� TempValue
            //if (rq.Request.Form[inputName] == null || rq.Request.Form[inputName].ToString()=="")
            //{
            //    EventMessage.MessageBox(2, "��ȡ����ʧ��", string.Format("{0}�ֶβ��ܻ�ȡֵ!", inputName), Icon_Type.Error, "history.back();", UrlType.JavaScript);
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
            //    MessBox("�ύ���ݷ�ʽ����post��get!", "?", rq);
            //    EventMessage.MessageBox(2, "��ȡ����ʧ��", string.Format("{0}�ֶ��ύ���ݷ�ʽ����post��get!", inputName), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //}
            #endregion

            #region �����������ȣ���ע��
            //if (MaxLen != 0)
            //{
            //    if (TempValue.Length > MaxLen)
            //    {
            //        EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}����ϵͳ������{2}!", inputName, TempValue, MaxLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //    }
            //}
            #endregion

            #region �����С������ ����ע��
            //if (MinLen != 0)
            //{
            //    if (TempValue.Length < MinLen)
            //    {
            //        EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}����ϵͳ������{2}!", inputName, TempValue, MinLen), Icon_Type.Error, "history.back();", UrlType.JavaScript);
            //    }
            //}
            #endregion

            #region �����������
            if (!string.IsNullOrEmpty(tempValue))
            {
                switch (dataType)
                {
                    case DataType.Int:
                        int IntTempValue = 0;
                        int.TryParse(tempValue, out IntTempValue);
                        //if (!int.TryParse(TempValue, out IntTempValue))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���ΪInt��!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return IntTempValue;
                    case DataType.Dat:
                        DateTime DateTempValue = DateTime.MinValue;
                        DateTime.TryParse(tempValue, out DateTempValue);
                        //if (!DateTime.TryParse(TempValue, out DateTempValue))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���Ϊ������!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DateTempValue;
                    case DataType.Long:
                        long LongTempValue = long.MinValue;
                        long.TryParse(tempValue, out LongTempValue);
                        //if (!long.TryParse(TempValue, out LongTempValue))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���ΪLog��!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return LongTempValue;
                    case DataType.Double:
                        double DoubleTempValue = double.MinValue;
                        double.TryParse(tempValue, out DoubleTempValue);
                        //if (!double.TryParse(TempValue, out DoubleTempValue))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���ΪDouble��!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return DoubleTempValue;
                    case DataType.CharAndNum:
                        CheckRegEx(tempValue, "^[A-Za-z0-9]+$");
                        //if (!CheckRegEx(TempValue, "^[A-Za-z0-9]+$"))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���ΪӢ�Ļ�����!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return tempValue;
                    case DataType.CharAndNumAndChinese:
                        CheckRegEx(tempValue, "^[A-Za-z0-9\u00A1-\u2999\u3001-\uFFFD]+$");
                        //if (!CheckRegEx(TempValue, "^[A-Za-z0-9\u00A1-\u2999\u3001-\uFFFD]+$"))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���ΪӢ�Ļ����ֻ�����!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
                        return tempValue;
                    case DataType.Email:
                        CheckRegEx(tempValue, "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                        //if (!CheckRegEx(TempValue, "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
                        //    EventMessage.MessageBox(2, "�������ݸ�ʽ��֤ʧ��", string.Format("{0}�ֶ�ֵ��{1}�������ͱ���Ϊ�ʼ���ַ!", inputName, TempValue), Icon_Type.Error, "history.back();", UrlType.JavaScript);
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
        /// ��ȡpost��get�ύֵ
        /// </summary>
        /// <param name="inputName">key</param>
        /// <param name="method">��ȡ��ʽ get, pot ,all</param>
        /// <returns>�����Ĭ��Ϊ��</returns>
        [Obsolete("�÷����ѹ��ڣ���ʹ�ô����Ͳ�����Sink����")]
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
            if (inputName.Equals("star") && !val.Equals("") && val.IndexOf(',').Equals(-1)) //URL��д���Ǽ���ֵ����ƴд���磺234->2,3,4    add xlzhang 120509
            {
                val = GetStarValue(val);
            }
            return val;
        }
        /// <summary>
        /// ��ȡ�Ǽ���ֵ
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

        #region �������ݰ󶨶���
        /// <summary>
        /// ��ȡweb�������ݶ���
        /// web���棬�ؼ���pre.Name�ȷ�ʽ������name��
        /// �������ύʱ��ͨ���ķ�����ֱ�ӻ�ö���
        /// </summary>
        /// <typeparam name="T">���ض�����</typeparam>
        /// <param name="preg">������ǰ׺������ؼ�name��</param>
        /// <returns>���ض���</returns>
        public static T BindObjectByForm<T>(string preg)
        {
            // �������ݰ�
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
            // �������ݰ�
            Castle.Components.Binder.TreeBuilder treeBuilder = new Castle.Components.Binder.TreeBuilder();
            Castle.Components.Binder.CompositeNode formCompositeNode =
                treeBuilder.BuildSourceNode(HttpContext.Current.Request.Form);
            treeBuilder.PopulateTree(formCompositeNode, HttpContext.Current.Request.Files);

            Castle.Components.Binder.DataBinder bind = new Castle.Components.Binder.DataBinder();
            bind.BindObjectInstance(inst, preg, formCompositeNode);
        }
        #endregion
        
        #region ��ʽ���ʽ��֤ Help Functions
        /// <summary>
        /// ��ʽ���ʽ��֤
        /// </summary>
        /// <param name="C_Value">��֤�ַ�</param>
        /// <param name="C_Str">��ʽ���ʽ</param>
        /// <returns>����true������false</returns>
        private static bool CheckRegEx(string C_Value, string C_Str)
        {
            Regex objAlphaPatt;
            objAlphaPatt = new Regex(C_Str, RegexOptions.Compiled);


            return objAlphaPatt.Match(C_Value).Success;
        }
        #endregion

        #region ��ȡ�û�Form�ύ���ֶ�ֵ
        /// <summary>
        /// ��ȡpost��get�ύֵ
        /// </summary>
        /// <typeparam name="T">Ҫת��������</typeparam>
        /// <param name="inputName">�ֶ���</param>
        /// <param name="method">post��get</param>
        /// <param name="isDecode">�Ƿ���Ҫ����</param>
        /// <param name="isSecurity">�Ƿ�Ҫ������ȫ����</param>
        /// <returns></returns>
        public static T Sink<T>(string inputName, MethodType method,bool isSecurity,bool isDecode=false)
        {
            string tempValue = GetPostOrRequestValue(inputName, method, isSecurity, isDecode);
            T result = ChangeTypeValue<T>(tempValue);
            return result;
        }

        /// <summary>
        /// ת�����͵�ֵ
        /// </summary>
        /// <typeparam name="T">Ҫת��������</typeparam>
        /// <param name="inputValue">������ַ���</param>
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
        /// ��ȡpost��get��ֵ
        /// </summary>
        /// <param name="inputName">����</param>
        /// <param name="method">�ύ����</param>
        /// <returns></returns>
        private static string GetPostOrRequestValue(string inputName, MethodType method,bool isSecurity,bool isDecode)
        {
            HttpContext context = HttpContext.Current;
            string tempValue = string.Empty;
            #region ��ȡ�ύ�ֶ����� TempValue
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
        /// ���˽��
        /// </summary>
        /// <param name="isSecurity">�Ƿ���Ҫ��ȫ����</param>
        /// <param name="isEncode">�Ƿ���Ҫ����</param>
        /// <param name="requestValue">����ֵ</param>
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
    /// ��ȡ�������ݷ�ʽ
    /// </summary>
    public enum MethodType
    {
        All = 0,
        /// <summary>
        /// Post��ʽ
        /// </summary>
        Post = 1,
        /// <summary>
        /// Get��ʽ
        /// </summary>
        Get = 2
    }
    
    /// <summary>
    /// ��ȡ��������
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// �ַ�
        /// </summary>
        Str = 1,
        /// <summary>
        /// ����
        /// </summary>
        Dat = 2,
        /// <summary>
        /// ����
        /// </summary>
        Int = 3,
        /// <summary>
        /// ������
        /// </summary>
        Long = 4,
        /// <summary>
        /// ˫����С��
        /// </summary>
        Double = 5,
        /// <summary>
        /// ֻ���ַ�������
        /// </summary>
        CharAndNum = 6,
        /// <summary>
        /// ֻ���ʼ���ַ
        /// </summary>
        Email = 7,
        /// <summary>
        /// ֻ���ַ������ֺ�����
        /// </summary>
        CharAndNumAndChinese = 8
    }

    
}

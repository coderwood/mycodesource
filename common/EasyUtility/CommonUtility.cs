using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace EasyCommon
{
    /// <summary>
    /// 公用的静态方法
    /// </summary>
    public class CommonUtility
    {
        #region "3des加密字符串"
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptString(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        #endregion

        #region "3des解密字符串"
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptString(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion

        #region "MD5加密"
        /// <summary>
        /// 取得MD5加密串
        /// </summary>
        /// <param name="input">源明文字符串</param>
        /// <returns>密文字符串</returns>
        public static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
        #endregion

        #region 获取参数的值
        /// <summary>
        /// 从配置文件中获取值
        /// </summary>
        /// <param name="key">key名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromConfig(string key)
        {
            string value = string.Empty;
            if (null != ConfigurationManager.AppSettings[key])
            {
                value = ConfigurationManager.AppSettings[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 从隐藏域中获取值
        /// </summary>
        /// <param name="key">隐藏域名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromForm(string key)
        {
            string value = string.Empty;
            if (null != HttpContext.Current.Request.Form[key])
            {
                value = HttpContext.Current.Request.Form[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 从url参数中获取值
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromQueryString(string key)
        {
            string value = string.Empty;
            if (null != HttpContext.Current.Request.QueryString[key])
            {
                value = HttpContext.Current.Request.QueryString[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 从隐藏域或url参数中获取值
        /// </summary>
        /// <param name="key">隐藏域或者参数名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromParameters(string key)
        {
            string value = string.Empty;
            if (null != HttpContext.Current.Request[key])
            {
                value = HttpContext.Current.Request[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 从上下文中获取值
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromContext(string key)
        {
            string value = string.Empty;
            if (null != HttpContext.Current.Items[key])
            {
                value = HttpContext.Current.Items[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 从session中获取值
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns>获取的值</returns>
        public static string GetValueFromSession(string key)
        {
            string value = string.Empty;
            if (null != HttpContext.Current.Session[key])
            {
                value = HttpContext.Current.Session[key].ToString();
            }
            return value;
        }

        /// <summary>
        /// 读取cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <returns>cookie值</returns>
        public static string GetCookies(string cookieName)
        {
            string retValue = string.Empty;

            HttpCookie hc = HttpContext.Current.Request.Cookies[cookieName];
            if (null != hc)
            {
                retValue = hc.Value;
            }

            return retValue;
        }
        #endregion

        #region asp.net获取当前环境参数
        /// <summary>
        /// 得到当前环境的域名
        /// </summary>
        /// <returns>域名</returns>
        public static string GetCurrentDomain
        {
            get
            {
                string sDomain = string.Empty;
                if (HttpContext.Current.Session["sDomain"] == null)
                {
                    sDomain = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
                    HttpContext.Current.Session["sDomain"] = sDomain;
                }
                else
                {
                    sDomain = HttpContext.Current.Session["sDomain"].ToString();
                }
                return sDomain;
            }
        }

        /// <summary>
        /// 得到当前url
        /// </summary>
        /// <returns>url地址</returns>
        public static string GetCurrentUrl()
        {
            string url = "http://" + GetCurrentDomain + HttpContext.Current.Request.Url.PathAndQuery;
            return url;
        }

        /// <summary>
        /// 获取虚拟目录名称
        /// </summary>
        public static string GetVPath
        {
            get
            {
                string vpath = "";
                if (HttpContext.Current.Session["vpath"] == null)
                {
                    vpath = HttpRuntime.AppDomainAppVirtualPath;
                    vpath = vpath.Substring(1, vpath.Length - 1);
                    if (vpath.LastIndexOf('/') > 0)
                    {
                        vpath = vpath.Substring(vpath.LastIndexOf('/') + 1, vpath.Length - vpath.LastIndexOf('/') - 1);
                    }

                    HttpContext.Current.Session["vpath"] = vpath;
                }
                else
                {
                    vpath = HttpContext.Current.Session["vpath"].ToString();
                }
                return vpath;
            }
        }
        #endregion

        #region "获取用户IP地址"
        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {

            string user_IP = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }
        #endregion

        #region 获取guid
        /// <summary>
        /// 获取guid
        /// </summary>
        /// <returns>guid值</returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        #endregion

        #region 字符串处理
        /// <summary>
        /// 首字母转为大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToBigCase(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                result = input.Substring(0, 1).ToUpper() + (input.Length > 1 ? input.Substring(1) : "");
            }
            return result;
        }
        public static string ToLittleCase(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                result = input.Substring(0, 1).ToLower() + (input.Length > 1 ? input.Substring(1) : "");
            }
            return result;
        }
        #endregion
    }
}

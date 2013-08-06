using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions; // 正则

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 对接收的html字符串替换
    /// </summary>
    public class HtmlReplace
    {
        /// <summary>
        /// 替换字符串中的一些特殊字符标签  
        /// </summary>
        /// <param name="Htmlstring">字符串</param>
        /// <returns>返回字符串</returns>
        public string NoHTML(string Htmlstring)  
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
         //   删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 替换字符串中<h>的一些标签
        /// </summary>
        /// <param name="Htmlstring">字符串</param>
        /// <returns>返回字符串</returns>
        public string RepH(string Htmlstring) 
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<h5>", "<div>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</h5>", "</div>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<h2>", "<div class='fontsize1'>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</h2>", "</div>", RegexOptions.IgnoreCase);

            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 邮箱Email验证
        /// </summary>
        /// <param name="Htmlstring">字符串</param>
        /// <returns></returns>
        public bool Email(string Htmlstring) 
        {            
            bool st = false;
            string Reg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (Regex.IsMatch(Htmlstring, Reg)) 
            {
                st = true;
            }
            return st;
        }

        /// <summary>
        /// 替换特殊符号 如 =,' 等字符
        /// </summary>
        /// <param name="Htmlstring">字符串</param>
        /// <returns>返回没有=和'的字符串</returns>
        public string ReplaceEmail(string Htmlstring) 
        {          
            Htmlstring = Regex.Replace(Htmlstring, @"=", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"'", "", RegexOptions.IgnoreCase);
            return Htmlstring;
        }

        /// <summary>
        /// 替换javaScript
        /// </summary>
        /// <param name="Htmlstring">字符串</param>
        /// <returns></returns>
        public string ReplaceScript(string Htmlstring) 
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);          
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);          
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            return Htmlstring;
        }

        /// <summary>
        /// 去除HTML标签(如,<br> )   
        /// </summary>
        /// <param name="Htmlstring">输入原字符串</param>
        /// <returns>处理后字符串</returns>
        public string RepHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<br>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<br/>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<div>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</div>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<span>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</span>", "", RegexOptions.IgnoreCase);

            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }
    }
}

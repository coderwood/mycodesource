using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 封装的js类
    /// </summary>
    /// 
   public class JudgJavaScript
    {
        /// <summary>
        /// 更改标签id
        /// </summary>
        /// <param name="message"></param> 
       public static string  ShowFontColor(string colornum) 
       {
           string js = @"<Script language='JavaScript'> document.getElementById('color" + colornum + "').id='colorname';  </Script>";
        //   HttpContext.Current.Response.Write(js);         
          return js;
       }
       /// <summary>
       /// 弹出消息并关闭当前页
       /// </summary>
       /// <param name="message"></param>
       public static void AlertClose(string message)
       {
           string js = @"<script language='javascript'>alert('" + message + "');window.opener=null;window.open('','_self');window.close();</" + "script>";
           HttpContext.Current.Response.Write(js);

       }
       /// <summary>
       /// 弹出消息并返回上一页
       /// </summary>
       /// <param name="message">消息</param>
        public void Alert(string message)
        {
            //  message = StringUtil.DeleteUnVisibleChar(message);
            string js = @"<Script language='JavaScript'> alert('" + message + "'); history.back();</Script>";
            HttpContext.Current.Response.Write(js);

        }
       /// <summary>
       /// (仅)弹出消息
       /// </summary>
       /// <param name="message">消息</param>
       public void AlertMessage(string message)
       {
           string js = @"<Script language='JavaScript'> alert('" + message + "');</Script>";
           HttpContext.Current.Response.Write(js);
       }

       /// <summary>
       ///  弹出消息，并且页面跳转(执行后有后退、前进)
       /// </summary>
       /// <param name="message">消息</param>
       /// <param name="url">页面Url</param>
        public  void login_username(string message,string url)
        {
            //  message = StringUtil.DeleteUnVisibleChar(message);
            string js = @"<Script language='JavaScript'> alert('" + message + "'); location.href='"+url+"';</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 弹出消息，并且页面跳转(执行后无后退、前进)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="url">页面Url</param>
        public void JavaScriptToHref(string message, string url)
        {
            string js = @"<Script language='JavaScript'>
                    alert(" + message + "); window.location.replace('"+url+"');       </Script>";
           
            HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// 改变字体颜色
        /// </summary>
        /// <param name="pid"></param>
        public static void ChangeFontColor(string pid)
        {
            //  string js = @"<Script language='JavaScript'> alert('" + pid + "'); </Script>";
            //   HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 一个含有“确定”、“取消”的警告框
        /// </summary>
        /// <param name="_Msg">警告字串</param>
        /// <param name="URL">“确定”以后要转到预设网址</param>
        /// <returns>警告框JS</returns>
       public void RtnRltMsgbox(string _Msg, string URL)
        {            
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += "var retValue=window.confirm('" + _Msg + "');" + " if(retValue==false){ location.href='" + URL + "';}";
            StrScript += (" </script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }


        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<Script language='JavaScript'> window.close(); </Script>";
            HttpContext.Current.Response.Write(js);

        }
       /// <summary>
       /// 关闭当前窗体不提示  add xlzhang 120426
       /// </summary>
       public static void CloseWindow2()
       {
           string js = @"<script language='javascript'>window.opener=null;window.open('','_self');window.close();</" + "script>";
           HttpContext.Current.Response.Write(js);
       }
        /// <summary>
        /// 重新加载当前页面
        /// </summary>
        public void RefreshParent()
        {
            string js = @"<Script language='JavaScript'> location.reload(); </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// (格式化)字符串替换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'").Replace("\"", "\\\"");
        }

        /// <summary>
        /// 刷新窗口(页面)
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<Script language='JavaScript'>opener.location.reload();</Script>";
            HttpContext.Current.Response.Write(js);
        }

       /// <summary>
        /// 打开页面
       /// </summary>
       /// <param name="url">页面名称</param>
        public static void OpenWebForm(string url)
        {

            string js = @"<Script language='JavaScript'>
   window.open('" + url + @"','','height=768,width=1024,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
   </Script>";

            HttpContext.Current.Response.Write(js);
        }

      /// <summary>
      /// 打开窗口
      /// </summary>
      /// <param name="url">页面名称</param>
      /// <param name="formName">打开方式 (可以新开多次，还是只能打开同名的一个页面)</param>
        public void OpenWebForm(string url, string formName)
        {
            string js = @"<Script language='JavaScript'> 
                        var win = window.open('" + url + @"','" + formName + @"'); 
                        if(win){
                            win.focus();
                        }
                        </Script>";

            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 打開窗口(带限制页面功能参数)
        /// </summary>
        /// <param name="url">页面名称</param>
        /// <param name="formName"> (可以新开多次，还是只能打开同名的一个页面)</param>
      
        public void OpenWebForm1(string url, string formName)
        {
            string js = @"<Script language='JavaScript'>
window.open('" + url + @"','" + formName + @"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
   </Script>";

            HttpContext.Current.Response.Write(js);
        }


        /// <summary>  
        /// 功能描述:Js控制打开页面 
        /// </summary>
        /// <param name="url">文件名称</param>
        /// <param name="isFullScreen">是否全屏幕</param>
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = @"<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js += "var iWidth = 0;";
                js += "var iHeight = 0;";
                js += "iWidth=window.screen.availWidth-10;";
                js += "iHeight=window.screen.availHeight-50;";
                js += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"','',szFeatures);";
            }
            else
            {
                js += "window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js += "</Script>";

            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 跳转到指定的页面
        /// </summary>
        /// <param name="url">页面路径(页面名称)</param>
        public  void JavaScriptLocationHref(string url)
        {
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 指定的框架页面转换
        /// </summary>
        /// <param name="FrameName"></param>
        /// <param name="url"></param>
        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string js = @"<Script language='JavaScript'>
     
                    @obj.location.replace(""{0}"");
                  </Script>";
            js = js.Replace("@obj", FrameName);
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 重置页面
        /// </summary>
        public static void JavaScriptResetPage(string strRows)
        {
            string js = @"<Script language='JavaScript'>
                    window.parent.CenterFrame.rows='" + strRows + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 功能描述: 客户端方法设置cookie
        /// </summary>
        /// <param name="strName">Cookie名</param>
        /// <param name="strValue">Cookie值</param>
        public static void JavaScriptSetCookie(string strName, string strValue)
        {
               string js = @"<script language=Javascript>
               var the_cookie = '" + strName + "=" + strValue + @"'
               var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
               //document.cookie = the_cookie;//寫入Cookie<BR>} <BR>
               document.cookie = the_cookie + '; expires='+dateexpire;   
               </script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>  
        /// 功能描述:返回父窗口 
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>  
        public void GotoParentWindow(string parentWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    this.parent.location.replace('" + parentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>  
        /// 功能描述:替换父窗口
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>
        /// <param name="caption">窗口提示</param>
        /// <param name="future">窗口特征参數</param>
        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string js = "";
            if (future != null && future.Trim() != "")
            {
                js = @"<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');</script>";
            }
            else
            {
                js = @"<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;
       var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);</script>";
            }

            HttpContext.Current.Response.Write(js);
        }


        /// <summary>  
        /// 功能描述:替换当前窗体操作的窗体
        /// </summary>
        /// <param name="openerWindowUrl">当前活动(操作)的窗体</param>  
        public void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.location.replace('" + openerWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>  
        /// 功能描述:替换当前活动窗体的父窗体
        /// </summary>
        /// <param name="frameName">活动窗体的名称(可以自定义)</param>  
        /// <param name="openerWindowUrl">当前活动窗体的父窗口</param>  
        
        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>  
        /// 功能描述:替换当前活动窗体的父窗体
        /// </summary>
        /// <param name="openerWindowUrl">当前活动窗体的父窗口</param>  
        public  void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>  
        /// 功能描述:关闭父窗体
        /// </summary>
        public static void CloseParentWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.parent.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>  
        /// 功能描述: 闭当前打开窗体
        /// </summary>
        public static void CloseOpenerWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 功能描述:返回打开模式窗体的脚本
        /// </summary>
        public static string ShowModalDialogJavascript(string webFormUrl)
        {
            string js = @"<script language=javascript>
                           var iWidth = 0 ;
                           var iHeight = 0 ;
                           iWidth=window.screen.availWidth-10;
                           iHeight=window.screen.availHeight-50;
                           var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';
                           showModalDialog('" + webFormUrl + "','',szFeatures);</script>";
            return js;
        }

        /// <summary>
        /// 功能描述:返回打開模式窗口的腳本 
        /// </summary>
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script language=javascript>       
                           showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }

        /// <summary>
        /// 功能描述:打開模式窗口 
        /// </summary>
        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = ShowModalDialogJavascript(webFormUrl);//
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 功能描述:打開模式窗口 
        /// </summary>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 功能描述:打開模式窗口 
        /// </summary>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
             + ";dialogHeight:" + height.ToString() + "px"
             + ";dialogLeft:" + left.ToString() + "px"
             + ";dialogTop:" + top.ToString() + "px"
             + ";center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }
        /// <summary>
        /// 設定html頁面中指定元素的值
        /// </summary>
        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string js = @"<Script language='JavaScript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>";
            HttpContext.Current.Response.Write(js);
        }       
    }

}
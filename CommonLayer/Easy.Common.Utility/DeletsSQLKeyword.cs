using System;
using System.Collections.Generic;
using System.Text;

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// 替换sql关键字
    /// </summary>
   public class DeletsSQLKeyword
    {
       public string SqlFilter(string sValue)
       {
           sValue = sValue.Replace(";", "");
           sValue = sValue.Replace("--", "");
           sValue = sValue.Replace("xp_", "");
           sValue = sValue.Replace("/*", "");
           sValue = sValue.Replace("*/", "");
           sValue = sValue.Replace("　", "");
           sValue = sValue.Replace("'", "");
           sValue = sValue.Replace("\'", "");
           sValue = sValue.Replace("\\'", "");
           sValue = sValue.Replace(";", "");
           sValue = sValue.Replace("&", "");
           sValue = sValue.Replace("?","");

           return sValue.Trim();
       } 

    }
}

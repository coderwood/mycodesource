using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace EasyWellDataAccess
{
    /// <summary>
    /// 资源类数据库读取
    /// </summary>
    public class ResourceDataAccess
    {
        SQLiteConnection slc = new SQLiteConnection("Data Source="+@"E:\codesource\MyWell\MyWellApp\");
    }
}

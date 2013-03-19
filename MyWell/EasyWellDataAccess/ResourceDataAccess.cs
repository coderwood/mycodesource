using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using MyWellEntity;

namespace MyWellDataAccess
{
    /// <summary>
    /// 资源类数据库读取
    /// </summary>
    public class ResourceDataAccess
    {
        public static List<Resource> GetResourceList()
        {
            try
            {
                List<Resource> rl = new List<Resource>();

                string commandText = "select * from resource";
                DataSet ds = SqliteHelper.ExecuteDataset(commandText, null);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Resource r = new Resource();
                        r.ResourceID = int.Parse(dt.Rows[i]["ResourceID"].ToString());
                        r.Title = dt.Rows[i]["Title"].ToString();
                        r.Content = dt.Rows[i]["Content"].ToString();
                        r.Classfication = dt.Rows[i]["Content"].ToString();
                        rl.Add(r);
                    }
                }
                return rl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

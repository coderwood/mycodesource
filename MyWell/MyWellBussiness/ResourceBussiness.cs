using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWellDataAccess;
using MyWellEntity;

namespace MyWellBussiness
{
    public class ResourceBussiness
    {
        public static List<Resource> GetReourceList()
        {
            List<Resource> rl = new List<Resource>();
            rl = ResourceDataAccess.GetResourceList();
            return rl;
        }
    }
}

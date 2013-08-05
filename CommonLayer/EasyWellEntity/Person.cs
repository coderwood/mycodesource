using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWellEntity
{
    /// <summary>
    /// 人基类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNO { get; set; }

        /// <summary>
        /// 人员类别
        /// </summary>
        public string PersonType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWellEntity
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 入学日期
        /// </summary>
        public DateTime DateOfEntry { get; set; }

    }
}

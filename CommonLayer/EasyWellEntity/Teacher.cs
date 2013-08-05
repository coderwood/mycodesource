using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWellEntity
{
    /// <summary>
    /// 教师
    /// </summary>
  public  class Teacher:Person
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime DateOfEntry { get; set; }

        /// <summary>
        /// 执教年限
        /// </summary>
        public int EntryAge { get; set; }
    }
}

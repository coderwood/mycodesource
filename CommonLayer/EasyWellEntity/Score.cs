using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWellEntity
{
    /// <summary>
    /// 成绩
    /// </summary>
    public class Score
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// 科目成绩
        /// </summary>
        public int CourseScore { get; set; }
    }
}

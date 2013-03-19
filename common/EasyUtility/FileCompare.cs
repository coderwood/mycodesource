using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasyUtility
{
    /// <summary>
    /// 文件对比类
    /// </summary>
    public class FileCompare : IComparer<FileInfo>
    {
        /// <summary>
        /// 文件对比方法
        /// </summary>
        /// <param name="x">文件x</param>
        /// <param name="y">文件y</param>
        /// <returns>文件是否相同</returns>
        public int Compare( FileInfo x, FileInfo y )
        {
            int result = 0;

            DateTime firstDate = DateTime.MinValue;
            DateTime secondDate = DateTime.MinValue;
            firstDate = x.LastWriteTime;
            secondDate = y.LastWriteTime;
            result = firstDate == secondDate ? 0 : (firstDate > secondDate ? -1 : 1);
            return result;
        }
    }
}

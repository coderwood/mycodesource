using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasyUtility
{
    /// <summary>
    /// �ļ��Ա���
    /// </summary>
    public class FileCompare : IComparer<FileInfo>
    {
        /// <summary>
        /// �ļ��Աȷ���
        /// </summary>
        /// <param name="x">�ļ�x</param>
        /// <param name="y">�ļ�y</param>
        /// <returns>�ļ��Ƿ���ͬ</returns>
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

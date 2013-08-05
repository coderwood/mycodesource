using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasyUtility
{
    //文件操作工具类
    public class FileUtility
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void CreateFile( string path )
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                fi.Create();
            }
        }

        /// <summary>
        /// 把内容保存到文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="content">文件内容</content>
        public static void CreateFile( string path, string content )
        {
            CreateDireectory(path);
            using (StreamWriter sw = new StreamWriter(path, false, DefaultEncoding))
            {
                sw.WriteLine(content);
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void CreateDireectory( string path )
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void DeleteFile( string Path )
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        /// <summary>
        /// 根据文件路径取文件夹路径
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件夹路径</returns>
        public static string GetDictionaryFromPath( string path )
        {
            return path.Substring(path.LastIndexOf(@"\") + 1);
        }

        /// <summary>
        /// 根据文件路径获取文件名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string[] GetFilenameFromPath( string path, string searchPattern )
        {
            string[] result = null;
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] fis = di.GetFiles(searchPattern);
                FileCompare fc = new FileCompare();
                Array.Sort(fis, fc);
                if (null != fis)
                {
                    result = new string[fis.Length];
                    for (int i = 0; i < fis.Length; i++)
                    {
                        result[i] = fis[i].Name;
                    }
                }
            }
            return result;
        }
    }
}

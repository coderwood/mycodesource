using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasyUtility
{
    //�ļ�����������
    public class FileUtility
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
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
        /// �����ݱ��浽�ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <param name="content">�ļ�����</content>
        public static void CreateFile( string path, string content )
        {
            CreateDireectory(path);
            using (StreamWriter sw = new StreamWriter(path, false, DefaultEncoding))
            {
                sw.WriteLine(content);
            }
        }

        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="path">�ļ�·��</param>
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
        /// ɾ���ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static void DeleteFile( string Path )
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        /// <summary>
        /// �����ļ�·��ȡ�ļ���·��
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <returns>�ļ���·��</returns>
        public static string GetDictionaryFromPath( string path )
        {
            return path.Substring(path.LastIndexOf(@"\") + 1);
        }

        /// <summary>
        /// �����ļ�·����ȡ�ļ���
        /// </summary>
        /// <param name="path">�ļ�·��</param>
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

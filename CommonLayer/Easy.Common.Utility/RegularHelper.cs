using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HtlInv.Common.Utility
{
    /// <summary>
    /// ������ʽ��֤
    /// </summary>
    public class RegularHelper
    {
        /// <summary>
        /// �ַ����Ƿ��������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHaveNumber(string str)
        {
            string pattern = GetPatern(2);
            bool result = Regex.IsMatch(str, pattern);
            return result;
        }
        /// <summary>
        /// ��ȡ���ʽ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetPatern(int type)
        {
            string result = "";
            switch (type)
            {
                case 1:
                    result = @"^-?\d+$"; //�Ƿ�������
                    break;
                case 2:
                    result = @"[0-9]*[1-9][0-9]";  //�Ƿ��������
                    break;
                case 3:
                    result = @"^\d+(\.\d+)?$"; //�Ǹ����������������� + 0�� 
                    break;
                case 4:
                    result = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";//�������� 
                    break;
                case 5:
                    result = @"^(-?\d+)(\.\d+)?$";//������ 
                    break;
                case 6:
                    result = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";//�������� 
                    break;
                case 7:
                    result = @"^[A-Za-z]+$"; //��26��Ӣ����ĸ��ɵ��ַ��� 
                    break;
                case 8:
                    result = @"^[A-Z]+$";  //��26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
                    break;
                case 9:
                    result = @"^[A-Za-z0-9]+$"; //�����ֺ�26��Ӣ����ĸ��ɵ��ַ���
                    break;
                case 10:
                    result = @"^\w+$"; //�����֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
                    break;
                case 11:
                    result = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"; //email��ַ
                    break;
                case 12:
                    result = @"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"; //url 
                    break;
                case 13:
                    result = @"/^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$";// ��-��-�� 
                    break;
                case 14:
                    result = @"(d+-)?(d{4}-?d{7}|d{3}-?d{8}|^d{7,8})(-d+)?"; //�绰���� 
                    break;
                case 15:
                    result = @"^(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5])$";//ip��ַ
                    break;
                case 16:
                    result = @"[\u4e00-\u9fa5]";//����
                    break;
                case 17:
                    result = @"^\s*)|(\s*$";//��β�ո�
                    break;
                
                default: break;
            }
            return result;
        }

        /// <summary>
        /// ��ȡ�ؼ���
        /// </summary>
        /// <param name="url">�����url</param>
        /// <returns></returns>
        public static string GetKeyWords(string url)
        {
            string key="";
            Regex reg = null;
            //k1
            reg = new Regex(@"keyword=([^&/]*)", RegexOptions.IgnoreCase);
            Match m = null;
            if (reg.IsMatch(url))
            {
                m = reg.Match(url);
                key = m.Groups[1].Value;
            }
            return key;
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="url">�����url</param>
        /// <returns></returns>
        public static string GetCommentType(string url)
        {
            string key = "";
            Regex reg = null;
            //k1
            reg = new Regex(@"comType=([^&/]*)", RegexOptions.IgnoreCase);
            Match m = null;
            if (reg.IsMatch(url))
            {
                m = reg.Match(url);
                key = m.Groups[1].Value;
            }
            return key;
        }
    }
}

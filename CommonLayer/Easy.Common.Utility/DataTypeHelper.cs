using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace HtlInv.Common.Utility
{
    public class DataTypeHelper
    {
        /// <summary>
        /// ת������ΪEnum���ͣ�������ֵ������ʱ���Զ�����Enum�ĵ�һ��
        /// Enum��Ա��ĸ��ȫ����д
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static V ConvertToEnum<T, V>(T source) where V : new()
        {
            Type type = typeof(V);
            V v = new V();
            string sourceString = source.ToString().ToUpper();

            if (type.IsEnum && Enum.IsDefined(type, sourceString))
            {
                return (V)Enum.Parse(type, sourceString);
            }
            return v;
        }

        /// <summary>
        /// ת������Ϊint?��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int? ConvertObjectToInt<T>(T source)
        {
            int result;

            if (source == null)
            {
                return null;
            }
            else if (int.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte ConvertToByte<T>(T source)
        {
            byte result;

            if (source == null)
            {
                return default(byte);
            }
            else if (byte.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return default(byte);
            }
        }

        /// <summary>
        /// ת������Ϊdecimal?��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal? ConvertObjectToDecimal<T>(T source)
        {
            decimal result;

            if (source == null)
            {
                return null;
            }
            else if (decimal.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal ConvertObjectToDecimalSingle<T>(T source)
        {
            decimal? result = ConvertObjectToDecimal(source);

            if (result != null)
            {
                return result.Value;
            }
            else
            {
                return 0M;
            }
        }
        /// <summary>
        /// ת������Ϊint��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int ConvertObjectToInt32<T>(T source)
        {
            int result;

            if (source == null)
            {
                return 0;
            }
            else if (int.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime<T>(T source)
        {
            DateTime result;

            if (source == null)
            {
                return default(DateTime);
            }
            else if (DateTime.TryParse(source.ToString(), out result))
            {
                return result;
            }
            else
            {
                return default(DateTime);
            }
        }



        #region zhaoj

        /// <summary>
        /// �ж������ֵ�Ƿ�������
        /// </summary>
        /// <param name="InputString">�ַ���</param>
        /// <returns></returns>
        public static bool IsInteger(string InputString)
        {
            bool isIntFlog = false;
            int number;

            if (!string.IsNullOrEmpty(InputString))
            {
                if (Regex.IsMatch(InputString, "^((\\+)\\d)?\\d*$"))
                {
                    if (Int32.TryParse(InputString, out number)==true)
                    {
                        isIntFlog = true;
                    }
                }                
            }
            return isIntFlog;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="HasBroadnet"></param>
        /// <param name="BroadnetFee"></param>
        /// <returns></returns>
        public static string getBroadnetString(int HasBroadnet, string BroadnetFee)
        {
            // mod by fush at 20071031 (�����:32489)
            //string getBroadnetString = "";
            string getBroadnetString = "��";
            switch (HasBroadnet)
            {
                case 0://'�޿��
                    //getBroadnetString = "";
                    break;
                case 1://'���ַ����п��
                    if (BroadnetFee == "T")
                    {
                        getBroadnetString = "������<br>�շ�";
                    }
                    else
                    {
                        getBroadnetString = "������<br>���";
                    }
                    break;
                case 2://'ȫ�������п��
                    if (BroadnetFee == "T")
                    {
                        getBroadnetString = "�շ�";
                    }
                    else
                    {
                        getBroadnetString = "���";
                    }
                    break;
            }
            // end mod
            return getBroadnetString;
        }

        /// <summary>
        /// �õ�ʱ���
        /// </summary>
        /// <returns></returns>
        public static Int64 GetTime(DateTime date1, DateTime date2)
        {
            //�õ�ʱ���
            System.TimeSpan diff1 = date2.Subtract(date1);
            Int64 iTime = ((diff1.Days) * 24 * 3600) + (diff1.Hours * 3600) + (diff1.Minutes + 2) * 60;
            return iTime;
        }



        //public static string GetAllianceFontColor2()
        //{
        //    return "#cf6000";
        // }

        /// <summary>
        /// ��ʽ���������ȡ��ʱ��
        /// </summary>
        /// <param name="LastCancelTime">����ȡ��ʱ��</param>
        /// <returns></returns>
        public static string ChangeLastCancelTime(DateTime LastCancelTime)
        {
            string changeLastCancelTime = "";
            int dmtTime = LastCancelTime.Hour;
            if (dmtTime == 0 || dmtTime == 1 || dmtTime == 2 || dmtTime == 3 || dmtTime == 4 || dmtTime == 5)
            {
                changeLastCancelTime = LastCancelTime.ToShortDateString() + "�賿" + dmtTime + ":00";
            }
            if (dmtTime == 6 || dmtTime == 7 || dmtTime == 8 || dmtTime == 9 || dmtTime == 10)
            {
                changeLastCancelTime = LastCancelTime.ToShortDateString() + "����" + dmtTime + ":00";

            }
            if (dmtTime == 11 || dmtTime == 12)
            {
                changeLastCancelTime = LastCancelTime.ToShortDateString() + "����" + dmtTime + ":00";

            }
            if (dmtTime == 13 || dmtTime == 14 || dmtTime == 15 || dmtTime == 16 || dmtTime == 17)
            {
                switch (dmtTime)
                {
                    case 13:
                        dmtTime = 1;
                        break;
                    case 14:
                        dmtTime = 2;
                        break;
                    case 15:
                        dmtTime = 3;
                        break;
                    case 16:
                        dmtTime = 4;
                        break;
                    case 17:
                        dmtTime = 5;
                        break;
                }
                changeLastCancelTime = LastCancelTime.ToShortDateString() + "����" + dmtTime + ":00";
            }
            if (dmtTime == 18 || dmtTime == 19 || dmtTime == 20 || dmtTime == 21 || dmtTime == 22 || dmtTime == 23)
            {
                switch (dmtTime)
                {
                    case 18:
                        dmtTime = 6;
                        break;
                    case 19:
                        dmtTime = 7;
                        break;
                    case 20:
                        dmtTime = 8;
                        break;
                    case 21:
                        dmtTime = 9;
                        break;
                    case 22:
                        dmtTime = 10;
                        break;
                    case 23:
                        dmtTime = 11;
                        break;
                }
                changeLastCancelTime = LastCancelTime.ToShortDateString() + "����" + dmtTime + ":00";
            }



            return changeLastCancelTime;
        }

        public static string JGetBreakfast(int breakfast)
        {
            string getBreakfast = "";
            switch (breakfast)
            {
                case 1:
                    getBreakfast = "����";
                    break;
                case 2:
                    getBreakfast = "˫��";
                    break;
                case 3:
                    getBreakfast = "����";
                    break;
                case 4:
                    getBreakfast = "����";
                    break;
                case 5:
                    getBreakfast = "����";
                    break;
                case 6:
                    getBreakfast = "����";
                    break;
                case 7:
                    getBreakfast = "����";
                    break;
                case 8:
                    getBreakfast = "����";
                    break;
                case 9:
                    getBreakfast = "ÿ��һ��";
                    break;
                case 0:
                    getBreakfast = "����";
                    break;
                case 9999:
                    getBreakfast = "";
                    break;
            }

            return getBreakfast;
        }

        public static string JGetBedType(string kingsize, string twinbed)
        {
            string getBedType = "&nbsp;";
            if (kingsize == "T" && twinbed == "F")
            {
                getBedType = "��";
            }
            if (kingsize == "F" && twinbed == "T")
            {
                getBedType = "˫��";
            }
            if (kingsize == "T" && twinbed == "T")
            {
                getBedType = "��/˫";
            }
            return getBedType;
        }

        /// <summary>
        /// �õ����ڵ������ַ���
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeekDayChinese(DateTime date)
        {
            string weekDayChinese = string.Empty;
            ;
            switch ((int)date.DayOfWeek)
            {
                case 1:
                    weekDayChinese = "��һ,�ܶ�,����,����,����,����,����,";
                    break;
                case 2:
                    weekDayChinese = "�ܶ�,����,����,����,����,����,��һ,";
                    break;
                case 3:
                    weekDayChinese = "����,����,����,����,����,��һ,�ܶ�,";
                    break;
                case 4:
                    weekDayChinese = "����,����,����,����,��һ,�ܶ�,����,";
                    break;
                case 5:
                    weekDayChinese = "����,����,����,��һ,�ܶ�,����,����,";
                    break;
                case 6:
                    weekDayChinese = "����,����,��һ,�ܶ�,����,����,����,";
                    break;
                case 0:
                    weekDayChinese = "����,��һ,�ܶ�,����,����,����,����,";
                    break;
            }
            return weekDayChinese;
        }

        /// <summary>
        /// �õ����ڵ������ַ���
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeekDayChineseNew(DateTime date)
        {
            string weekDayChinese = string.Empty;
            ;
            switch ((int)date.DayOfWeek)
            {
                case 1:
                    weekDayChinese = "��һ|�ܶ�|����|����|����|����|����|";
                    break;
                case 2:
                    weekDayChinese = "�ܶ�|����|����|����|����|����|��һ|";
                    break;
                case 3:
                    weekDayChinese = "����|����|����|����|����|��һ|�ܶ�|";
                    break;
                case 4:
                    weekDayChinese = "����|����|����|����|��һ|�ܶ�|����|";
                    break;
                case 5:
                    weekDayChinese = "����|����|����|��һ|�ܶ�|����|����|";
                    break;
                case 6:
                    weekDayChinese = "����|����|��һ|�ܶ�|����|����|����|";
                    break;
                case 0:
                    weekDayChinese = "����|��һ|�ܶ�|����|����|����|����|";
                    break;
            }
            return weekDayChinese;
        }

        #endregion


        /// <summary>
        /// ת�����ڸ�ʽ
        /// </summary>
        /// <param name="sType">ת������</param>
        /// <param name="sDate">��������</param>
        /// <param name="sdelimiter">�ָ���</param>
        /// <returns></returns>
        public static string ConvertY2K(string sType, DateTime sDate, string sdelimiter)
        {
            string value = string.Empty;

            sType = sType.ToUpper();
            switch (sType)
            {
                case "D":
                case "DATE":
                    value = sDate.ToString("yyyy") + sdelimiter +
                        sDate.ToString("MM") + sdelimiter +
                        sDate.ToString("dd");
                    break;
                case "DT":
                case "DATETIME":
                    value = sDate.ToString("yyyy") + sdelimiter +
                        sDate.ToString("MM") + sdelimiter +
                        sDate.ToString("dd") + " " +
                        sDate.ToString("HH:mm:ss");
                    break;
                case "T":
                case "TIME":
                    value = sDate.ToString("HH:mm:ss");
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}

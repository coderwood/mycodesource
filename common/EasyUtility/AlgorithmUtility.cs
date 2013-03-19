using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyCommon
{
    /// <summary>
    /// 算法相关
    /// </summary>
    public static class AlgorithmUtility
    {
        #region 斐波那契数列
        /// <summary>
        /// 斐波那契数列
        /// </summary>
        /// <param name="num">输入值</param>
        /// <returns>计算结果</returns>
        public static int Foo(int num)
        {
            if (num <= 0)
                return 0;
            else if (num == 1 || num == 2)
                return 1;
            else
                return Foo(num - 2) + Foo(num - 1);
        }
        #endregion

        #region 冒泡排序法
        /// <summary>
        /// 冒泡法排序(正序)
        /// </summary>
        /// <param name="inputArray">输入的数组</param>
        /// <returns>排序后的数组</returns>
        public static int[] BubbleSort(int[] inputArray)
        {
            int len = inputArray.Length;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j <= len - 1; j++)
                {
                    if (inputArray[i] > inputArray[j])
                    {
                        Swap(ref inputArray[i], ref inputArray[j]);
                    }
                }
            }

            return inputArray;
        }

        /// <summary>
        /// 交换两个整数的值
        /// </summary>
        /// <param name="i">第一个数</param>
        /// <param name="j">第二个数</param>
        public static void Swap(ref int i, ref int j)
        {
            int k;
            k = i;
            i = j;
            j = k;
        }
        #endregion
    }
}

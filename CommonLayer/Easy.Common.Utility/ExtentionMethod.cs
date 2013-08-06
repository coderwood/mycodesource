using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyUtility
{
    /// <summary>
    /// 随机数扩展
    /// </summary>
    public static class ExtentionMethod
    {
        /// <summary>
        /// 产生随机的bool值
        /// </summary>
        /// <param name="random">随机值</param>
        /// <returns>布尔值</returns>
        public static bool NextBool(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        /// <summary>
        /// 生成随机的枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static T NextEnum<T>(this Random random) where T : struct
        {
            Type type = typeof(T);
            if (type.IsEnum == false)
                throw new InvalidOperationException();

            var array = Enum.GetValues(type);
            int index = random.Next(array.GetLowerBound(0), array.GetUpperBound(0));
            return (T)array.GetValue(index);
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random,DateTime minValue,DateTime maxValue)
        {
            long ticket = minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * random.NextDouble());
            return new DateTime(ticket);
        }
    }
}

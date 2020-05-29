using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiDemo.Models.ui.locations;

namespace ApiDemo.Utils
{
    public static class Extension
    {
        private const string Space = " ";
        private const string SpaceHtml = "%20";
        private const string cultureInfoEnUs = "en-US";

        #region methods
        private static TextInfo textInfo = new CultureInfo(cultureInfoEnUs, false).TextInfo;

        public static string ToTitleCaseAdvance(this string str)
        {
            str = textInfo.ToTitleCase(str.ToLower()).Trim();
            return str.Length == 0 ? " " : str;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();

            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static string ToUpperAdvance(this string str)
        {
            return str.ToUpper().Trim();
        }

        /// <summary>
        /// string.ToEnum<enum>()
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string str) where TEnum : struct
        {
            Enum.TryParse(str, out TEnum flag);
            return flag;
        }
        public static string ToRemoveSpace(this string str)
        {
            return str.Replace(Space, string.Empty).Replace(SpaceHtml, string.Empty);
        }

        public static byte[] GetBinary(this object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return (byte[])obj;
            }

            return null;
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个int类型返回。
        /// </summary>
        public static int GetIntOrZero(this string value)
        {
            try
            {
                return Convert.ToInt32(value.Trim());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个布尔（bool)类型返回。
        /// </summary>
        public static bool? GetNullOrBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个byte类型返回。
        /// </summary>
        public static byte? GetNullOrByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToByte(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个char类型返回。
        /// </summary>
        public static char? GetNullOrChar(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToChar(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个DateTime类型返回。
        /// </summary>
        public static DateTime? GetNullOrDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个Decimal类型返回。
        /// </summary>
        public static decimal? GetNullOrDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个double类型返回。
        /// </summary>
        public static double? GetNullOrDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToDouble(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个float类型返回。
        /// </summary>
        public static float? GetNullOrFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToSingle(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个Guid类型返回。
        /// </summary>
        public static Guid? GetNullOrGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return new Guid(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个int类型返回。
        /// </summary>
        public static int? GetNullOrInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个long类型返回。
        /// </summary>
        public static long? GetNullOrLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToInt64(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个sbyte类型返回。
        /// </summary>
        public static sbyte? GetNullOrSByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToSByte(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个short类型返回。
        /// </summary>
        public static short? GetNullOrShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToInt16(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，Trim()后返回该字符串。
        /// </summary>
        public static string GetNullOrString(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return value;
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个uint类型返回。
        /// </summary>
        public static uint? GetNullOrUInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToUInt32(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个ulong类型返回。
        /// </summary>
        public static ulong? GetNullOrULong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToUInt64(value);
        }

        /// <summary>
        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个ushort类型返回。
        /// </summary>
        public static ushort? GetNullOrUShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            value = value.Trim();

            return Convert.ToUInt16(value);
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的布尔（bool)类型。
        /// </summary>
        public static bool IsBool(this string value)
        {
            try
            {
                Convert.ToBoolean(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsByte(this string value)
        {
            try
            {
                Convert.ToByte(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的Char类型。
        /// </summary>
        public static bool IsChar(this string value)
        {
            try
            {
                Convert.ToChar(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的日期。
        /// </summary>
        public static bool IsDateTime(this string value)
        {
            try
            {
                Convert.ToDateTime(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsDecimal(this string value)
        {
            try
            {
                Convert.ToDecimal(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsDouble(this string value)
        {
            try
            {
                Convert.ToDouble(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsFloat(this string value)
        {
            try
            {
                Convert.ToSingle(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的Guid。
        /// </summary>
        public static bool IsGuid(this string value)
        {
            try
            {
                var guid = new Guid(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsInt(this string value)
        {
            try
            {
                Convert.ToInt32(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsLong(this string value)
        {
            try
            {
                Convert.ToInt64(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个对象是否为空，如传入对象为string类型，
        /// 该方法会判断所传入的string是否包含内容。
        /// </summary>
        public static bool IsNull(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (obj is string)
            {
                var tmpStr = (string)obj;

                return string.IsNullOrEmpty(tmpStr.Trim());
            }

            return false;
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的布尔（bool)类型。
        /// </summary>
        public static bool IsNullOrBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToBoolean(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsNullOrByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToByte(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的Char类型。
        /// </summary>
        public static bool IsNullOrChar(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToChar(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的日期。
        /// </summary>
        public static bool IsNullOrDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDateTime(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsNullOrDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDecimal(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsNullOrDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDouble(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        /// </summary>
        public static bool IsNullOrFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToSingle(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的Guid。
        /// </summary>
        public static bool IsNullOrGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                var guid = new Guid(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsNullOrInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt32(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsNullOrLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt64(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsNullOrSByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToSByte(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsNullOrShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt16(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsNullOrUInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt32(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsNullOrULong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt64(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsNullOrUShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt16(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断所传入字符串的长度，是否超过指定长度。
        /// 如果字符串为空或null，返回false。
        /// </summary>
        public static bool IsOutLength(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (value.Length > maxLength)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsSByte(this string value)
        {
            try
            {
                Convert.ToSByte(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的整数。
        /// </summary>
        public static bool IsShort(this string value)
        {
            try
            {
                Convert.ToInt16(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsUInt(this string value)
        {
            try
            {
                Convert.ToUInt32(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsULong(this string value)
        {
            try
            {
                Convert.ToUInt64(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断一个字符串是否是一个有效的正整数。
        /// </summary>
        public static bool IsUShort(this string value)
        {
            try
            {
                Convert.ToUInt16(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public static List<Format> NewSort(this List<Format> formats)
        {
            //formats.Sort(new Format.FormatCompare());
            var sorted = formats.OrderByDescending(x => x.IsDefault)
                                .ThenBy(x => x.ImprintGroup)
                                .ThenBy(x => x.ImprintRule)
                                .ThenBy(x => x.Sequence);
            return sorted.ToList();
        }

    }
}

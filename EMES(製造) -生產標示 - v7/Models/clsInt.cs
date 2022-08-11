using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMES.Models
{
    /// <summary>
    /// 跟Int有關的韓式都在此處理.
    /// </summary>
    public static class clsInt
    {
        //原本的轉換是沒有保護,新增一個有加保護的轉換式.
        public static int Parse(string Str)
        {
            try
            {
                if (string.IsNullOrEmpty(Str)) return 0;
                if (string.IsNullOrWhiteSpace(Str)) return 0;
                
                if (Str.Length > 10) return 0; //150713 .cbc+ 避免字串太長解不出來
                if (Str.Length == 0) return 0;
                if (Str == null) return 0;
                if (Str[0] == 0) return 0;
                return int.Parse(Str);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }   
        }

        //原本的轉換是沒有保護,新增一個有加保護的轉換式.
        public static uint ParseUnsignedInt(string Str)
        {
            try
            {
                if (Str.Length > 10) return 0; //150713 .cbc+ 避免字串太長解不出來
                if (Str.Length == 0) return 0;
                if (Str == null) return 0;
                if (Str[0] == 0) return 0;
                return uint.Parse(Str);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }
        }

        //原本的轉換是沒有保護,新增一個有加保護的轉換式.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="iMode"></param>
        /// <returns></returns>
        public static int ParseHex(string Str)
        {
            try
            {
                if (Str.Length > 10) return 0; //150713 .cbc+ 避免字串太長解不出來
                if (Str.Length == 0) return 0;
                if (Str == null) return 0;
                if (Str[0] == 0) return 0;
                return int.Parse(Str,System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }
        }
   
    

        /// <summary>
        /// 抓取SubArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
   
    }
}

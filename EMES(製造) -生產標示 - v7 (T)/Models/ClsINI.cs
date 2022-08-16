using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace EMES.Models
{
    /// <summary>
    /// ClsINI
    /// 這是讀寫INI檔類別
    /// 
    /// 修改记录
    ///		2017.12.31 版本：1.0 ben  新增Dictionary檢索、刪除Section功能。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2017.12.31</date>
    /// </author>
    /// </summary>
    public class ClsINI
    {
        private string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString
            (string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString
            (string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileSectionNames
            (byte[] lpszReturnBuffer, int nSize, string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection
            (string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        /// <summary>構造方法</summary>  
        /// <param name="INIPath">文件路徑</param> 
        public ClsINI(string INIPath)
        {
            inipath = INIPath;
        }

        /// <summary>寫入INI文件</summary>  
        /// <param name="Section">項目名稱(如 [TypeName] )</param> 
        /// <param name="Key">鍵</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value,  inipath);
        }

        /// <summary>寫入INI文件 By int </summary>  
        /// <param name="Section">項目名稱(如 [TypeName] )</param> 
        /// <param name="Key">鍵</param> 
        /// <param name="Value">值</param> 
        public void IniWriteIntValue(string Section, string Key, int Value)
        {
            string kk = Value.ToString();
            WritePrivateProfileString(Section, Key, kk, inipath);
        }

        /// <summary>讀出INI文件</summary>  
        /// <param name="Section">項目名稱(如 [TypeName] )</param> 
        /// <param name="Key">鍵</param> 
        /// <returns>字串</returns> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }

        //171202 .ben+
        public string IniReadValue(string Section, string Key,string DefaultValue)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            if (temp.ToString() == "")
            {
                return DefaultValue;
            }
            return temp.ToString();
        }
        /// <summary>讀出INI文件</summary>  
        /// <param name="Section">項目名稱(如 [TypeName] )</param> 
        /// <param name="Key">鍵</param> 
        /// <returns>字串</returns> 
        public int IniReadIntValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return clsInt.Parse(temp.ToString());
        }

        /// <summary>
        /// 多一個預設值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public int IniReadIntValue(string Section, string Key,int DefaultValue)  //171202 .ben+ 
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            if (temp.ToString() == "")
            {
                return DefaultValue;
            }
            return clsInt.Parse(temp.ToString());
        }
      

        /// <summary>驗證文件是否存在///</summary>   
        /// <returns>布林值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }

       /// <summary>
       /// 刪除所有Section .ben+
       /// </summary>
        public void DeleteAll()
        {      
            byte[] buffer = new byte[1024];
            GetPrivateProfileSectionNames(buffer, buffer.Length, this.inipath);
            string allSections = System.Text.Encoding.Default.GetString(buffer);
            string[] sectionNames = allSections.Split('\0');
            string[] result = sectionNames.Where(val => val != "").ToArray(); //linq語法
            /*foreach (string sectionName in sectionNames)
            {
                if (sectionName != string.Empty)
                    aaa.Add(sectionName, sectionName);
            }*/
            for (int i = 0; i < result.Length; i++)
            {
                IniWriteValue(result[i], null, null); //key給null 就會把該section全砍掉
            }
        }

        /// <summary>
        /// 刪除單一Section
        /// </summary>
        /// <param name="stSectionName"></param>
        public void DeleteSection(string stSectionName)
        {
            IniWriteValue(stSectionName, null, null); 
        }

        /// <summary>
        /// 取得該Section下所有Key和Value的Dictionary物件
        /// </summary>
        /// <param name="stSectionName"></param>
        /// <returns></returns>
        public Dictionary<string,string> GetSectionValueDic(string stSectionName)
        {

            byte[] buffer = new byte[2048];

            GetPrivateProfileSection(stSectionName, buffer, 2048, inipath);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');

            Dictionary<string, string> Dic = new Dictionary<string, string>();
           // List<string> result = new List<string>();

            foreach (String entry in tmp)
            {
                string[] split = entry.Split('=');
                Dic.Add(split[0], split[1]);
               // result.Add(entry.Substring(0, entry.IndexOf("=")));
            }
            return Dic;
        }
    }
}

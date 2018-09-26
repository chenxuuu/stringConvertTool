using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stringConvert
{
    class ConvertTool
    {
        public static string String2Hex(string str,bool space)
        {
            if(space)
                return BitConverter.ToString(Encoding.Default.GetBytes(str)).Replace("-", " ");
            else
                return BitConverter.ToString(Encoding.Default.GetBytes(str)).Replace("-", "");
        }

        public static string Hex2String(string mHex)
        {
            mHex = Regex.Replace(mHex, "[^0-9A-Fa-f]", "");
            if (mHex.Length % 2 != 0)
                mHex = mHex.Remove(mHex.Length - 1, 1);
            if (mHex.Length <= 0) return "";
            byte[] vBytes = new byte[mHex.Length / 2];
            for (int i = 0; i < mHex.Length; i += 2)
                if (!byte.TryParse(mHex.Substring(i, 2), NumberStyles.HexNumber, null, out vBytes[i / 2]))
                    vBytes[i / 2] = 0;
            return Encoding.Default.GetString(vBytes);
        }

        /// <summary>
        /// Base64加密，解密方法
        /// </summary>
        /// <paramname="s">输入字符串</param>
        /// <paramname="c">true-加密,false-解密</param>
        public static string base64(string s, bool c)
        {
            if (c)
            {
                return Convert.ToBase64String(Encoding.Default.GetBytes(s));
            }
            else
            {
                try
                {
                    return Encoding.Default.GetString(Convert.FromBase64String(s));
                }
                catch (Exception exp)
                {
                    return exp.Message;
                }
            }
        }

        public static string ChangeEncode(string text, string row, string to)
        {
            byte[] bs = Encoding.GetEncoding(row).GetBytes(text);
            return Encoding.GetEncoding(to).GetString(bs);
        }

        /// <summary>
        /// 用MD5加密字符串
        /// </summary>
        /// <param name="password">待加密的字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            return tmp.ToString();
        }

        public static string sha1(string enstr)
        {
            var strRes = Encoding.Default.GetBytes(enstr);
            HashAlgorithm iSha = new SHA1CryptoServiceProvider();
            strRes = iSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (byte iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }

        public static string sha256(string enstr)
        {
            var strRes = Encoding.Default.GetBytes(enstr);
            HashAlgorithm iSha = new SHA256CryptoServiceProvider();
            strRes = iSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (byte iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }

        public static string sha512(string enstr)
        {
            var strRes = Encoding.Default.GetBytes(enstr);
            HashAlgorithm iSha = new SHA512CryptoServiceProvider();
            strRes = iSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (byte iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }

        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        internal static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">经过Unicode编码的字符串</param>
        /// <returns>正常字符串</returns>
        internal static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(source, x => Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)).ToString());
        }
    }
}

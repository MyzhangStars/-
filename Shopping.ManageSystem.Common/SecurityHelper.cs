using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ManageSystem.Common
{
  public  class SecurityHelper
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Md5Security(string text)
        {
            //构建MD5对象
            using (MD5 md5 = MD5.Create())
            {

                //把字符串变成字节数组
                byte[] tempBuffer = Encoding.Default.GetBytes(text);

                byte[] hashBytes=md5.ComputeHash(tempBuffer);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

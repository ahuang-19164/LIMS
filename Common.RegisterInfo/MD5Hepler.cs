using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.RegisterInfo
{
    public class MD5Hepler
    {
        //public void aaaa()
        //{
        //    string source = "Hello World!";
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        string hash = GetMd5Hash(md5Hash, source);

        //        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

        //        Console.WriteLine("正在验证哈希。。。");

        //        if (VerifyMd5Hash(md5Hash, source, hash))
        //        {
        //            Console.WriteLine("哈希值是一样的.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("哈希值不一样。");
        //        }
        //    }
        //}
        public static string GetMd5String(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, input);
                return hash;
            }
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {


            // 将输入字符串转换为字节数组并计算哈希。
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //创建一个新的Stringbuilder来收集字节              
            //然后创建一个字符串。
            StringBuilder sBuilder = new StringBuilder();

            //循环遍历哈希数据的每个字节              
            //并将每个字符串格式化为十六进制字符串。
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            //返回十六进制字符串。
            return sBuilder.ToString();
        }

        // 根据字符串验证哈希。 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // hash输入。
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // 创建一个StringComparer并比较哈希值。
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoExcel
{
    class HttpUtils
    {
        public static string Post(string url, Dictionary<string, string> param)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            //添加参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in param)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string Md5(string str)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));//转化为小写的16进制
            }
            return sBuilder.ToString();
        }

        // unix时间戳
        public static string Timestamp()
        {
            DateTime nowTime = DateTime.Now;
            DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(nowTime.ToUniversalTime() - timeStampStartTime).TotalMilliseconds + "";
        }

        //static void Main()
        //{

        //string signTime = HttpUtils.Timestamp();

        //string content = "石家庄市冀粤生物质能发电有限公司飞灰固化区域封闭项目竞争性竞争性谈判公告4 <div style=\"font-size:30pt\">啊啊啊</div> ";
        ////byte[] content = System.Text.Encoding.Default.GetBytes(content);
        ////content = Convert.ToBase64String(content);
        //content = HttpUtility.UrlEncode(content, System.Text.Encoding.UTF8);
        //    Console.WriteLine(content);

        //    // 拼装请求参数
        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //param.Add("title", "石家庄市冀粤生物质能发电有限公司飞灰固化区域封闭项目竞争性竞争性谈判公告4");
        //    param.Add("content", content);
        //    param.Add("publishDate", "2020-09-18 17:48:00");
        //    param.Add("signTime", signTime);
        //    param.Add("signature", HttpUtils.Md5(signTime + "8h6wWSEv0NT4BvBC"));
        //    // 发送post请求
        //    Console.WriteLine(HttpUtils.Post("http://www.hbzbjt.cn/hbzbjt/zbgg", param));
        //}
    }
}

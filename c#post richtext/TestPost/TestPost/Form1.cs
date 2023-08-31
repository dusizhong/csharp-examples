using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TestPost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            string signTime = Timestamp();
            //string content = "石家庄市冀粤生物质能发电有限公司飞灰固化区域封闭项目竞争性竞争性谈判公告4% <div style=\"font-size:30pt\">啊啊啊</div> ";
            string content = this.textBox3.Text;
            content = HttpUtility.UrlEncode(content, System.Text.Encoding.UTF8);
            byte[] contentByte = System.Text.Encoding.UTF8.GetBytes(content);
            content = Convert.ToBase64String(contentByte);
            
            Console.WriteLine(content);

            // 拼装请求参数
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("title", this.textBox1.Text);
            param.Add("content", content);
            param.Add("publishDate", this.textBox2.Text);
            param.Add("signTime", signTime);
            param.Add("signature", Md5(signTime + "8h6wWSEv0NT4BvBC"));
            // 发送post请求
            result = Post(this.textBox4.Text, param);
            MessageBox.Show("发送结果：" + result);
        }

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
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
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

        //java接收示例
        //@RequestMapping(value = "/rich")
        //public String richText(@RequestParam String content)
        //    {
        //        String result = "";
        //        content = StringUtils.base64Decode(content);
        //        result = StringUtils.urlDecode((content));
        //        System.out.println(result);
        //        return result;
        //    }
    }
}

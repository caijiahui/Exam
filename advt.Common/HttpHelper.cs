using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace advt.Common
{
    public class HttpHelper
    {
        public static byte[] Get(string url)
        {
            WebHeaderCollection responseHeaders;
            return Get(url, out responseHeaders);
        }

        public static string GetString(string url)
        {
            return Encoding.UTF8.GetString(Get(url));
        }

        public static byte[] Get(string url, out WebHeaderCollection responseHeaders)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    responseHeaders = response.Headers;
                    return ReadBytes(responseStream);
                }
            }
        }

        public static string PostString(string url, object postJsonData, string contentType = "application/x-www-form-urlencoded")
        {
            string postJsonData_str = JsonConvert.SerializeObject(postJsonData);
            return PostString(url, postJsonData_str, contentType);
        }

        public static string PostString(string url, byte[] data, string contentType = "application/x-www-form-urlencoded")
        {
            var result = Post(url, data, contentType);
            return Encoding.UTF8.GetString(result);
        }

        public static byte[] Post(string url, object postJsonData, string contentType = "application/x-www-form-urlencoded")
        {
            return Post(url, JsonConvert.SerializeObject(postJsonData), contentType);
        }

        public static byte[] Post(string url, byte[] postData, string contentType = "application/x-www-form-urlencoded")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = contentType;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        return ReadBytes(responseStream);
                    }
                }
            }
        }

        /// <summary>
        /// 将流读取成字节组。
        /// </summary>
        /// <param name="stream">流。</param>
        /// <returns>字节组。</returns>
        public static byte[] ReadBytes(Stream stream)
        {
            if (stream == null) return new byte[] { };

            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);

            var list = new List<byte>(stream.CanSeek ? (stream.Length > int.MaxValue ? int.MaxValue : (int)stream.Length) : 300);

            int b;

            while ((b = stream.ReadByte()) != -1)
                list.Add((byte)b);

            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);

            return list.ToArray();
        }
        
}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_HttpClient
{
    public class HTTPClient
    {
        public string Server_URL;


        public HTTPClient()
        {

        }

        public HTTPClient(string url)
        {
            Server_URL = url;
        
        }

        public void setServerURL(string url)
        {
            Server_URL = url;
        }

        public string post(string postData)
        {
            GC.Collect();
            HttpWebRequest request;
            try
            {
                 request = (HttpWebRequest)WebRequest.Create(Server_URL);
                 request.Method = "POST";
                 request.ContentType = "application/json";
                 request.Timeout = 20 * 600 * 1000;
                 request.KeepAlive = false;
                 request.ProtocolVersion = HttpVersion.Version10;
            }
            catch
            {
                MessageBox.Show("服务器请求URL解析失败\n");
                return "url error\n";
            }

            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 200;

            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8")); //如果JSON有中文则是UTF-8
            myStreamWriter.Write(postData);
            myStreamWriter.Close(); //请求中止,是因为长度不够,还没写完就关闭了.

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream);//?? throw new InvalidOperationException(), Encoding.GetEncoding("utf-8"));
                string registerResult = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return registerResult;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Data.ToString());
                return "server rec error\n";
            }
        }

    }
}

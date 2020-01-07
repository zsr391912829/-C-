using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_HttpClient;
using MyTCP;

namespace Debug_Form
{
    public partial class Form1 : Form
    {
        HTTPClient myHttpClient;

        MyTcpClient tcpclient;

        string str_temp = "";

        public Form1()
        {
            myHttpClient = new HTTPClient("http://dev.imuyuan.com/api/wlw/noToken/feed/data/add");
            InitializeComponent();
        }


        private void btn_post_Click(object sender, EventArgs e)
        {

            String jsonParam = "[{\"number\":\"Stabilizers1\",\"littleLine\":\"\",\"littleLineLittlePointDistance\":5,\"littleLineLittlePointTemp\":0,\"littleLineMidPointDistance\":45,\"littleLineMidPointTemp\":0,\"littleLineBigPointDistance\":105,\"littleLineBigPointTemp\":0,\"midLine\":\"21\",\"midLineLittlePointDistance\":5,\"midLineLittlePointTemp\":0,\"midLineMidPointDistance\":45,\"midLineMidPointTemp\":0,\"midLineBigPointDistance\":105,\"midLineBigPointTemp\":0,\"bigLine\":\"31\",\"bigLineLittlePointDistance\":5,\"bigLineLittlePointTemp\":0,\"bigLineMidPointDistance\":45,\"bigLineMidPointTemp\":0,\"bigLineBigPointDistance\":105,\"bigLineBigPointTemp\":0,\"modulator\":0,\"fieldId\":\"123\"},{\"number\":\"Stabilizers2\",\"littleLine\":\"11\",\"littleLineLittlePointDistance\":5,\"littleLineLittlePointTemp\":0,\"littleLineMidPointDistance\":45,\"littleLineMidPointTemp\":0,\"littleLineBigPointDistance\":105,\"littleLineBigPointTemp\":0,\"midLine\":\"21\",\"midLineLittlePointDistance\":5,\"midLineLittlePointTemp\":0,\"midLineMidPointDistance\":45,\"midLineMidPointTemp\":0,\"midLineBigPointDistance\":105,\"midLineBigPointTemp\":0,\"bigLine\":\"31\",\"bigLineLittlePointDistance\":5,\"bigLineLittlePointTemp\":0,\"bigLineMidPointDistance\":45,\"bigLineMidPointTemp\":0,\"bigLineBigPointDistance\":105,\"bigLineBigPointTemp\":0,\"modulator\":0,\"fieldId\":\"132\"}]";

           // HttpPostForTimeOut("http://dev.imuyuan.com/api/wlw/noToken/feed/data/add", jsonParam);

            myHttpClient.post("456");

        }

        public void Tcp_recv_handler(byte[] recBuf,int len)
        {

            string str = System.Text.Encoding.Default.GetString(recBuf);
            str_temp = str;
        }

        private void btn_tcp_client_Click(object sender, EventArgs e)
        {
            tcpclient = new MyTcpClient("127.0.0.1", 9999, Tcp_recv_handler);
            tcpclient.connect();
          //  tcpclient.SendData();
            
        }

        private void btn_tcpclient_send_Click(object sender, EventArgs e)
        {
            tcpclient.sendStr("123");
        }

        private void timer_1s(object sender, EventArgs e)
        {
  
           
        }

        private void timer_ui_Tick(object sender, EventArgs e)
        {
            if (str_temp != "")
            {
                tb_log.Text += str_temp;
                str_temp = "";
            }
        }
    }
}

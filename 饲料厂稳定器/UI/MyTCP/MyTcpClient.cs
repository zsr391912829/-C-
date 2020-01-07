using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTCP
{
    public class MyTcpClient
    {
        Socket tcpClient;

        String remote_ip;
        int remote_port;

        bool IsConnected = false;
      

        Thread th_send;

        public delegate void Tcp_recv_handler(byte[] recBuf, int len);

        Tcp_recv_handler tcp_recv_handler;
        public MyTcpClient(String server_ip, int server_port,Tcp_recv_handler rec_handler)
        {
            remote_ip = server_ip;
            remote_port = server_port;
            th_send = new Thread(new ThreadStart(tcpclient_rec));
            tcp_recv_handler = rec_handler;
        }

        public bool connect()
        {
             
             tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //发起建立连接的请求
            //Parse：将一个字符串的ip地址转换成一个IPAddress对象
             IPAddress ipaddress = IPAddress.Parse(remote_ip);
             EndPoint point = new IPEndPoint(ipaddress, remote_port);
             try
             {
                 tcpClient.Connect(point);//通过IP和端口号来定位一个所要连接的服务器端

             }
             catch(Exception ex)
             {
                 MessageBox.Show("连接失败！");
                 return false;
             }

             IsConnected = true;
             th_send.Start();
             return true;
        }

        public void tcpclient_rec()
        {
            while (true)
            {
                if (tcpClient != null)
                {
                    if (IsConnected)
                    {
                        byte[] data = new byte[1024];
                        int length = tcpClient.Receive(data);
                        if (length > 0)
                        {

                            tcp_recv_handler(data, length);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                
                }
            
            }
        }

        public void sendStr(String sendData)
        {
            if (tcpClient != null)
            {
                if (IsConnected)
                { 
                    
            
                    //将字符串转化为字节数组，然后发送到服务器端
                    tcpClient.Send(Encoding.UTF8.GetBytes(sendData));
 
                }
            }

        }

        public void close()
        {
            tcpClient.Close();
        }
    }
 
}

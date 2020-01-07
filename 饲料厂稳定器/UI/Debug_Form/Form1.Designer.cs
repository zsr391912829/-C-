namespace Debug_Form
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_post = new System.Windows.Forms.Button();
            this.btn_tcp_client = new System.Windows.Forms.Button();
            this.btn_tcpclient_send = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.RichTextBox();
            this.timer_ui = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_post
            // 
            this.btn_post.Location = new System.Drawing.Point(31, 33);
            this.btn_post.Name = "btn_post";
            this.btn_post.Size = new System.Drawing.Size(136, 23);
            this.btn_post.TabIndex = 0;
            this.btn_post.Text = "post测试";
            this.btn_post.UseVisualStyleBackColor = true;
            this.btn_post.Click += new System.EventHandler(this.btn_post_Click);
            // 
            // btn_tcp_client
            // 
            this.btn_tcp_client.Location = new System.Drawing.Point(50, 99);
            this.btn_tcp_client.Name = "btn_tcp_client";
            this.btn_tcp_client.Size = new System.Drawing.Size(104, 37);
            this.btn_tcp_client.TabIndex = 1;
            this.btn_tcp_client.Text = "MyTcpClient 连接";
            this.btn_tcp_client.UseVisualStyleBackColor = true;
            this.btn_tcp_client.Click += new System.EventHandler(this.btn_tcp_client_Click);
            // 
            // btn_tcpclient_send
            // 
            this.btn_tcpclient_send.Location = new System.Drawing.Point(189, 106);
            this.btn_tcpclient_send.Name = "btn_tcpclient_send";
            this.btn_tcpclient_send.Size = new System.Drawing.Size(136, 23);
            this.btn_tcpclient_send.TabIndex = 2;
            this.btn_tcpclient_send.Text = "发送";
            this.btn_tcpclient_send.UseVisualStyleBackColor = true;
            this.btn_tcpclient_send.Click += new System.EventHandler(this.btn_tcpclient_send_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(452, 40);
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(242, 317);
            this.tb_log.TabIndex = 3;
            this.tb_log.Text = "";
            // 
            // timer_ui
            // 
            this.timer_ui.Enabled = true;
            this.timer_ui.Interval = 1;
            this.timer_ui.Tick += new System.EventHandler(this.timer_ui_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer_1s);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 400);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.btn_tcpclient_send);
            this.Controls.Add(this.btn_tcp_client);
            this.Controls.Add(this.btn_post);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_post;
        private System.Windows.Forms.Button btn_tcp_client;
        private System.Windows.Forms.Button btn_tcpclient_send;
        private System.Windows.Forms.RichTextBox tb_log;
        private System.Windows.Forms.Timer timer_ui;
        private System.Windows.Forms.Timer timer1;
    }
}


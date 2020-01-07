using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UI
{


    public partial class App_Start : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int GWL_STYLE = -16;
        public const int WS_DISABLED = 0x8000000;

        public static void SetControlEnabled(Control c, bool enabled)
        {
            if (enabled)
            { SetWindowLong(c.Handle, GWL_STYLE, (~WS_DISABLED) & GetWindowLong(c.Handle, GWL_STYLE)); }
            else
            { SetWindowLong(c.Handle, GWL_STYLE, WS_DISABLED + GetWindowLong(c.Handle, GWL_STYLE)); }
        }


        Form fm_baseInf;
        Form fm_setting;

        int show_index = 1;

        public App_Start()
        {
            
            InitializeComponent();
         //   this.Size = this.BackgroundImage.Size;
        
            SetControlEnabled(lb_baseinf,false);
            SetControlEnabled(lb_hwInf, false);
        }

        public Form GenerateForm(string form, object sender, Boolean show)
        {
            //反射生成窗体
            Form fm = (Form)Assembly.GetExecutingAssembly().CreateInstance(form);
            //设置窗体没有边框，加入到选项卡中
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.TopLevel = false;
            fm.Parent = ((TabControl)sender).SelectedTab;
            fm.ControlBox = false;
            fm.Dock = DockStyle.Fill;
            if (show)
            {
                fm.Show();
            }
            else
            {
                fm.Hide();
            }

            return fm;
        }


        private void App_Start_Load(object sender, EventArgs e)
        {
         //   BitmapRegion BitmapRegion = new BitmapRegion();//此为生成不规则窗体和控件的类 
         //   BitmapRegion.CreateControlRegion(this, new Bitmap("33.bmp"));

            fm_baseInf = GenerateForm("UI.Page_BaseInf", tabControl1, true);
            fm_setting = GenerateForm("UI.Page_Setting", tabControl1, false);

        }

        private void panel_baseinf_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_baseinf_Click(object sender, EventArgs e)
        {
            if (show_index == 1)
            {
                fm_baseInf.Show();
                fm_setting.Hide();
                show_index = 0;
            }
            else
            {
                fm_baseInf.Hide();
                fm_setting.Show();
                show_index = 1;
            }
            tabControl1.Update();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

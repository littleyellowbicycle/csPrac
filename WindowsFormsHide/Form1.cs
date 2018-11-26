using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsHide
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            timer1.Tick+= new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            timer3.Tick += new EventHandler(timer3_Tick);
            this.DesktopLocation = new Point(794, 0);   //为当前窗体定位
            label2.Visible = false;                     //设置Label控件为不可见状态
            progressBar1.Minimum = 0;                //设置ProgressBar控件的最小值为0
            progressBar1.Maximum = 10;               //设置ProgressBar控件的最大值为10
            timer1.Start();                       //计时器Counter开始工作
            progressBar1.MarqueeAnimationSpeed = 100; //设置ProgressBar控件的滚动块在进度栏内滚动所用的时间段
            this.MaximizeBox = false;               //设置最大化窗口为不可用状态
        }
        #region 声明本程序中用到的API函数
        //获取当前鼠标下可视化控件的函数
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        //获取指定句柄的父级函数
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        //获取屏幕的大小
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        #endregion

        #region 运行本程序需要声明的变量
        IntPtr CurrentHandle;//记录鼠标当前状态下控件的句柄
        int WindowFlag;//标记是否对窗体进行拉伸操作
        #endregion

        #region 加载时窗体位于屏幕右上侧
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    this.DesktopLocation = new Point(794, 0);   //为当前窗体定位
        //    label2.Visible = false;                     //设置Label控件为不可见状态
        //    progressBar1.Minimum = 0;                //设置ProgressBar控件的最小值为0
        //    progressBar1.Maximum = 10;               //设置ProgressBar控件的最大值为10
        //    timer1.Start();                       //计时器Counter开始工作
        //    progressBar1.MarqueeAnimationSpeed = 100; //设置ProgressBar控件的滚动块在进度栏内滚动所用的时间段
        //    this.MaximizeBox = false;               //设置最大化窗口为不可用状态
        //}
        #endregion

        #region 登陆提示,3秒后登陆成狗，label2可见，计时器2启动
        private void timer1_Tick(object sender,EventArgs e)
        {
            Console.WriteLine("...............timer1 work");
            label1.Visible = false;
            progressBar1.Visible = false;
            label2.Visible = true;
            timer1.Stop();
            timer2.Enabled = true;
        }
        #endregion

        #region 屏幕距窗体边沿3，当鼠标在窗体上显示，否影藏
        private void timer2_Tick(object sender,EventArgs e)
        {
            Console.WriteLine("...............timer2 work");
            //当本窗体距屏幕的上边距小于3px时
            if (this.Top < 3)
            {
                if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))
                {
                    WindowFlag = 1;                //设定当前的窗体状态
                    timer3.Enabled = false;     //设定计时器HideWindow为不可用状态
                    this.Top = 0;                 //设定窗体上边缘与容器工作区上边缘之间的距离
                }               
                else
                {
                    WindowFlag = 1;                //设定当前的窗体状态
                    timer3.Enabled = true;      //启动计时器HideWindow
                }
            }
            //当本窗体在屏幕的最左端或者最右端、最下端时
            else
            {
                if (this.Left < 3 || (this.Left + this.Width) > (GetSystemMetrics(0) - 3)
                    || (this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                {
                    //当窗体的左边缘与容器工作区左边缘之间的距离
                    if (this.Left < 3)
                    {
                        WindowFlag = 2;        //设定当前的窗体状态
                        timer3.Enabled = false;//设定计时器HideWindow为不可用状态
                        this.Left = 0;         //设定窗体的左边缘与容器工作区的左边缘之间的距离
                    }
                    else
                    {
                        WindowFlag = 2;        //设定当前的窗体状态
                        timer3.Enabled = true;//设定计时器HideWindow为可用状态
                    }
                    //当窗体处于屏幕的最右侧时
                    if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y))//当鼠标处于窗体上时
                    {
                        WindowFlag = 3;        //设定当前的窗体状态
                        timer3.Enabled = false; //设定计时器HideWindow为不可用状态
                        this.Left = GetSystemMetrics(0) - this.Width;//设定该窗体与容器工作区左边缘之间的距离
                    }
                    else                          //当鼠标离开窗体时
                    {
                        WindowFlag = 3;            //设定当前的窗体状态
                        timer3.Enabled = true;  //设定计时器HideWindow为可用状态
                    }
                    //当窗体距屏幕最下端的距离小于3px时
                    if ((this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 3))
                    {
                        if (this.Handle == MouseNowPosition(Cursor.Position.X, Cursor.Position.Y)) //当鼠标在该窗体上时
                        {
                            WindowFlag = 4;           //设定当前的窗体状态
                            timer3.Enabled = false;//设定计时器HideWindow为不可用状态
                            this.Top = Screen.AllScreens[0].Bounds.Height - this.Height;//设定该窗体与容器工作区上边缘之间的距离
                        }
                        else
                        {
                            WindowFlag = 4;           //设定当前的窗体状态
                            timer3.Enabled = true; //设定计时器HideWindow为可用状态
                        }
                    }
                }
            }
        }
        #endregion

        #region 在应该隐藏的区域内，窗体自动消失，在消失的地方露出一部分，接触时自动显示
        private void timer3_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("...............timer3 work");
            //判断当前窗体处于那个状态
            switch (Convert.ToInt32(WindowFlag.ToString()))
            {
                case 1:             //当窗体处于最上端时   
                    if (this.Top < 5)   //当窗体与容器工作区的上边缘的距离小于5px时
                        this.Top = -(this.Height - 2);  //设定当前窗体距容器工作区上边缘的值
                    break;
                case 2:              //当窗体处于最左端时
                    if (this.Left < 5)//当窗体与容器工作区的左边缘的距离小于5px时
                        this.Left = -(this.Width - 2); //设定当前窗体据容器工作区左边缘的值
                    break;
                case 3:             //当窗体处于最右端时
                    if ((this.Left + this.Width) > (GetSystemMetrics(0) - 5))  //当窗体与容器工作区的右边缘的距离小于5px时
                        this.Left = GetSystemMetrics(0) - 2;    //设定当前窗体距容器工作区左边缘的值
                    break;
                case 4:             //当窗体处于最低端时
                    if ((this.Top + this.Height) > (Screen.AllScreens[0].Bounds.Height - 5)) //当窗体与容器工作区的下边缘的距离小于5px时
                        this.Top = Screen.AllScreens[0].Bounds.Height - 2;   //设定当前窗体距容器工作区上边缘之间的距离
                    break;
            }
        }
        #endregion

        #region 光标在窗体上移动时
        /// <summary>
        /// 获取鼠标当前状态下控件的句柄
        /// </summary>
        /// <param name="x">当前鼠标的X坐标</param>
        /// <param name="y">当前鼠标的Y坐标</param>
        /// <returns></returns>
        public IntPtr MouseNowPosition(int x, int y)
        {
            IntPtr OriginalHandle;//声明保存原始句柄的变量
            OriginalHandle = ((IntPtr)WindowFromPoint(x, y));//获取原始的句柄
            CurrentHandle = OriginalHandle;//保存原始的句柄
            while (OriginalHandle != ((IntPtr)0))//循环判断鼠标是否移动
            {
                CurrentHandle = OriginalHandle;//记录当前的句柄
                OriginalHandle = GetParent(CurrentHandle);//更新原始句柄
            }
            return CurrentHandle;  //返回当前的句柄
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsoutlook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_load(object sender,EventArgs e)
        {
            listView1.Clear();
            listView1.LargeImageList = imageList1;
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);
            listView1.Items.Add("设置密码", "设置密码", 2);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        

        private void Button2_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            
            button2.Dock = DockStyle.Top;
            button1.SendToBack();
            button1.Dock = DockStyle.Top;
            button3.Dock = DockStyle.Bottom;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("近期工作记录", "近期工作记录", 3);
            listView1.Items.Add("近期工作计划", "近期工作计划", 4);
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button3.SendToBack();
            button3.Dock = DockStyle.Top;
            
            button2.SendToBack();
            button2.Dock = DockStyle.Top;
            button1.SendToBack();
            button1.Dock = DockStyle.Top;
            
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("编辑工作进度报告","编辑工作进度报告",5);
            listView1.Items.Add("编辑项目设计图", "编辑项目设计图", 6);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button1.Dock = DockStyle.Top;
            button2.Dock = DockStyle.Bottom;
            button3.SendToBack();
            button3.Dock = DockStyle.Bottom;
            listView1.BringToFront();
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            //listView1.Show();
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);
            listView1.Items.Add("设置密码", "设置密码", 2);
        }
    }
}

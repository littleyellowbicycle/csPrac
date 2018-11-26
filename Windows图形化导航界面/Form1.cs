using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows图形化导航界面
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            Console.WriteLine("test is start-----------------------------:");
           // MessageBox.Show("test start");
            //button1_Click(null, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = true;
            button4.Visible = true;
            Console.WriteLine("--------------------->click button1");
           // MessageBox.Show("--------------------->click button1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button9.Visible = true;
            button7.Visible = true;
            Console.WriteLine("--------------------->click button2");
           // MessageBox.Show("--------------------->click button2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button11.Visible = true;
            button12.Visible = true;
            button10.Visible = true;
            Console.WriteLine("--------------------->click button3");
           // MessageBox.Show("--------------------->click button3");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }   
}

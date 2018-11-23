using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApptest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void 打开ToolStripMenultem_Click(object sender,EventArgs e)
        {
            openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            StreamWriter s = new StreamWriter(address + "\\Menu.ini",true);
            s.WriteLine(openFileDialog1.FileName);
            s.Flush();
            s.Close();
            ShowWindows(openFileDialog1.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(address + "\\Menu.ini");
            int i = this.文件ToolStripMenuItem.DropDownItems.Count - 2;
            while (sr.Peek() >= 0)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.DropDownItems.Insert(i, menuitem);
                i++;
                menuitem.Click += new EventHandler(menuitem_Click);
            }
            sr.Close();
        }
        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);
            Form f = new Form();
            f.MdiParent = this;
            f.BackgroundImage = p;
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

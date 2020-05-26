using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text =string.Format("{0}{1}",DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random(DateTime.Now.Second);
            string dir = textBox2.Text;
            string pfx = textBox3.Text;
            string ext = textBox4.Text;
DirectoryInfo TheFolder = new DirectoryInfo(dir);
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles("*" + ext))
            {
                string NewFilename =string.Format("{0}\\{1}{2}{3}", dir, pfx, rand.NextDouble().ToString().Substring(2, 10), ext);
                textBox1.Text += string.Format("Old:{0} new:{1}\r\n", NextFile.FullName, NewFilename);
                NextFile.MoveTo(NewFilename);
                
            }
                //this.listBox2.Items.Add(NextFile.Name);
        }
    }
}

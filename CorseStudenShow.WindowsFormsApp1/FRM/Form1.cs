using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorseStudenShow.WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly string strUrl = "Resource1.resx";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var process = new System.Diagnostics.Process();
            int from = Convert.ToInt32(textBox1.Text);
            int to = Convert.ToInt32(textBox2.Text);
            if (to < from)
            {
                MessageBox.Show("error");
                return;
            }

            process.StartInfo.Arguments =
                        strUrl
                        + from + " --new-window"; ;
            process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process.Start();

            for (int i = from + 1; i <= to; i++)
            {
                process.StartInfo.Arguments =
                        strUrl + i;
                process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                System.Threading.Thread.Sleep(200);
                process.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.From;
            textBox2.Text = Properties.Settings.Default.To;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.From = textBox1.Text;
            Properties.Settings.Default.To = textBox2.Text;
            Properties.Settings.Default.Save();
        }
    }
}

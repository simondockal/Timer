using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        int h, m, s;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="Start")
            {
                button1.Text = "Stop";
                t.Start();
                button2.Enabled = true;
            }
            else
            {
                button1.Text = "Start";
                t.Stop();
                button2.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 10;
            t.Elapsed += OnTimerEvent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() => 
            {
                s += 1;
                if(s==60)
                {
                    s = 0;
                    m += 1;
                }

                if(m==60)
                {
                    m = 0;
                    h += 1;
                }
                textBox1.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }
    }
}

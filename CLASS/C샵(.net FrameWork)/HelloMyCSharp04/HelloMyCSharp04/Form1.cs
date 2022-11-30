using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 5;
            int b = 10;
            int c = 0;
            c = a + b;
            c = c - a;
            Console.WriteLine("안녕하세요");


        }

        private void button2_Click(object sender, EventArgs e)//44032 55203
        {
              
            for(int i = '가'; i<'힣';i++)
            {
            Console.Write((char)i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 131);
            this.label1.MaximumSize = new Size(750, 0);
            for (int i = '가'; i < '나'; i++)
            {
                label1.Text += (char)i;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
          


        }
    }
}

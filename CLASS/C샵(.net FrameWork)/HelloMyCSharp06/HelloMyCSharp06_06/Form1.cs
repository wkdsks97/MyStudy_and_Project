using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp06_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int a);
            int.TryParse(textBox2.Text, out int b);
            swapFunction(ref a, ref b);
            textBox3.Text = a.ToString();
            textBox4.Text = b.ToString();
        }

        private void swapFunction(ref int a, ref int b) 
        {
            int temp = a;
            a = b;
            b = temp;

        }



    }
}

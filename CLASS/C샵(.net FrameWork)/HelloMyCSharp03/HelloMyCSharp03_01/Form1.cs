using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_id.Text == "admin" && textBox_pw.Text =="1234")
            {
                MessageBox.Show("관리자 ㅎㅇ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "admin" && textBox_pw.Text == "1234")
            {
                Form2 s = new Form2();
                s.Show();
            }
        }
    }
}

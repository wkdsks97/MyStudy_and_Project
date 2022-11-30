using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpUiAcademy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hide();
            new Form(text1.Text,text2.Text).ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose(); //창 종료
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = text1.Text;
            string pw = text2.Text;

            if (id == "admin" && pw == "1234")
            {
              MessageBox.Show("관리자");
            }

            if(id.Equals("admin") &&pw.Equals("1234"))
            {
                MessageBox.Show("관리자입니다.");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

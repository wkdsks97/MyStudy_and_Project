using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp10_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text ="";
            List<int> list = new List<int>()
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var output = from item in list select item * item;

            foreach (var item in output)
            {
                label1.Text += item + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            List<int> list = new List<int>()
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var output = from item in list where item % 2 == 0 select item;

            
                foreach (var item in output)
                {
                    label2.Text += item + " ";
                }

            int[] a = output.ToArray<int>();
            List<int> b = output.ToList<int>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";

            List<int> list = new List<int>()
            {10,20,30,40,50 };

            var output = from item in list select new { age = item, money = item*100*2};

            foreach (var item in output)
            {
                label3.Text += "나이는 "+ item.age + "이고, 재산은: "+item.money + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { name ="비빔밥", price=5000});
            products.Add(new Product() { name ="라면", price=2500});
            products.Add(new Product() { name ="국밥", price=8000});
            products.Add(new Product() { name ="귤", price=500});

            var output = from item in products 
                         where item.price > 1000 
                         orderby item.price descending 
                         select item ;

            label4.Text = "";
            foreach (var item in output)
            {
                label4.Text += $"{item.name}, {item.price} \n";
            }
        }
    }
}

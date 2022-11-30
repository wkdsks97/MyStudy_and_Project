using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp09_01
{
    public partial class Form1 : Form,ISubject
    {
        public Form1()
        {
            InitializeComponent();

            Form2 frm2 = new Form2(this);
            frm2.TopLevel = false;
            frm2.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm2);
            frm2.Show();

            Form3 frm3 = new Form3(this);
            frm3.TopLevel = false;
            frm3.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(frm3);
            frm3.Show();

            Form4 frm4 = new Form4(this,frm2,frm3);
            frm4.TopLevel = false;
            frm4.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(frm4);
            frm4.Show();


        }

        List<IObserver> observer = new List<IObserver>();

        public void notify(string msg)
        {
            foreach (IObserver o in observer)
            {
                o.update(msg);
            }

        }

        public void register(IObserver o)
        {
            observer.Add(o);
        }
        public void unregister(IObserver o)
        {
            observer.Remove(o);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //둘중에 편한 방식 사용
            //Notifier n = new Notifier();
            ISubject s = new Notifier();

            s.register(new Observer1() { name = "스타1" });
            s.register(new Observer2());

            IObserver o1 = new Observer1();
            (o1 as Observer1).name = "허영무의 옵저버";
            s.register(o1);
            s.notify("스타크래프트");
            s.unregister(o1);
            s.notify(",스2,");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            notify((sender as TextBox).Text);
        }
    }
}

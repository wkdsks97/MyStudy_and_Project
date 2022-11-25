using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyCSharp09_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            studentBindingSource.Add(new Student() { name = textBox1.Text, hakbeon = textBox2.Text, gender = textBox3.Text });


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            for (int i = 0; i < studentBindingSource.Count; i++)
            {
                Student s = studentBindingSource[i] as Student;
                if (s.name == name)
                {
                    s.hakbeon = textBox2.Text;
                    s.gender = textBox3.Text;
                    studentBindingSource[i] = s;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (dataGridView1.Rows[i].Selected == true)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            List<Student> ss = new List<Student>();

            for (int i = 0; i < studentBindingSource.Count; i++)
            {
                Student s = studentBindingSource[i] as Student;
                if (s.name == name)
                {
                    ss.Add(s);
                }
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ss;
        }
    }
}

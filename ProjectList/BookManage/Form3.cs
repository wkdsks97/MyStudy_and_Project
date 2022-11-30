using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloMyLastCSharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            if (DataManager.Users.Count > 0)
                dataGridView1.DataSource = DataManager.Users;

            dataGridView1.CellClick += DataGridView1_CellClick;

            //유저 등록
            button1.Click += (s, e) =>
            {
                if (DataManager.Users.Exists
                (x => x.Id == int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("해당 ID 이미 있음");
                }
                else
                {
                    User user = new User()
                    { Id = int.Parse(textBox1.Text), Name = textBox2.Text };

                    DataManager.Users.Add(user);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                }
            };

            //유저 수정
            button2.Click += delegate (object s, EventArgs e)
            {
                try
                {
                    User user = DataManager.Users.Single
                    (x => x.Id == int.Parse(textBox1.Text));
                    user.Name = textBox2.Text;
                    try
                    {
                        Book book = DataManager.Books.Single
                        (x => x.UserId == int.Parse(textBox1.Text));
                        book.UserName = textBox2.Text;
                    }
                    catch (Exception)
                    {

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("해당 ID 이미 있음");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Users;
                DataManager.Save();
            };

            //유저 삭제
            EventHandler deleteBtn = delegate (object s, EventArgs e)
            {
                try
                {
                    User user = DataManager.Users.Single
                (x => x.Id == int.Parse(textBox1.Text));
                    DataManager.Users.Remove(user);

                    dataGridView1.DataSource = null;
                    if (DataManager.Users.Count > 0)
                        dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                }
                catch (Exception)
                {

                    MessageBox.Show("해당 아이디 사용자 없습니다");
                }


            };
            button3.Click += deleteBtn;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            User u = dataGridView1.CurrentRow.DataBoundItem as User;
            textBox1.Text = u.Id.ToString();
            textBox2.Text = u.Name;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

using PanasonicPlc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MewtocolTest
{
    public partial class Form1 : Form
    {
        DioInterface _dioInterface;
        public Form1()
        {
            InitializeComponent();
            _dioInterface = new DioInterface();
            _dioInterface.CreateDevice("127.0.0.1", 8000);
        }
        private static void Func()
        {
            int i = 1;
            int start = 7;
            int end = 20;

            while (i <= start)
            {

                Console.WriteLine(i);
                i++;
            }
            Console.WriteLine("ON: 입구" );

            while(start <= end)
            {
                Console.WriteLine(start);
                start++;
            }
            Console.WriteLine("ON: 도착");
        }

        private void button_setContactData_Click(object sender, EventArgs e)
        {
            string contactCode = this.textBox_writeContactCode.Text;
            string address = this.textBox_writeContactAddress.Text;
            int value;
            int.TryParse(this.textBox_writeContactValue.Text, out value);


            _dioInterface.SetDioBit(contactCode + address, value == 1 ? KState.ON : KState.OFF);
        }


        private void button_readSingleIo_Click(object sender, EventArgs e)
        {
            int value = _dioInterface.GetDiValue("R03");
            MessageBox.Show(value.ToString());
        }

        private void myThread_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(Func);
            myThread.Start();



        }
    }
}

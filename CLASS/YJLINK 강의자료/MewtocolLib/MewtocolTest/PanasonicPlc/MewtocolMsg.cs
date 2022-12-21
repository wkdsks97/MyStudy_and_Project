using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanasonicPlc
{
    public class MewtocolMsg
    {
        static public string ReadSingleIo(string contactCode, string address)
        {
            string command = String.Format("<01#RCS{0}{1}", contactCode, address.PadLeft(4, '0'));
            string bcc = GetBCC(command);
            return String.Format("{0}{1}{2}", command, bcc, (char)0x0D);
        }

        static public string ReadMultipleIo(string contactCode, int startAddress, int endAddress)
        {
            string command = String.Format("<01#RCC{0}{1:0000}{2:0000}", contactCode, startAddress, endAddress);
            string bcc = GetBCC(command);
            return String.Format("{0}{1}{2}", command, bcc, (char)0x0D);
        }

        static public string WriteIo(string contactCode, string address, int value)
        {
            string command = String.Format("<01#WCS{0}{1}{2}", contactCode, address.PadLeft(4, '0'), value);
            string bcc = GetBCC(command);
            string msg = String.Format("{0}{1}{2}", command, bcc, (char)0x0D);
            return msg;
        }

        static private string GetBCC(string data)
        {
            Byte[] inputStream = new Byte[data.Length];
            inputStream = Encoding.ASCII.GetBytes(data);
            byte bcc = 0;

            if (inputStream != null && inputStream.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    bcc ^= inputStream[i];
                }
            }
            return bcc.ToString("X2");
        }
    }
}

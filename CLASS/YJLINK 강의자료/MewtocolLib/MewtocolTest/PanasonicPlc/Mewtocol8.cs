using System;
using System.Collections.Generic;
using System.Text;

namespace PanasonicPlc
{
    /// <summary>
    /// Mewtocol7 은 Spec 이름이지만 Mewtocol8 은 의미 없음. 그냥 다음 버전을 의미. QJ
    /// </summary>
    public class Mewtocol8
    {
        BoardUdpComm _updComm;

        public Mewtocol8(string ipAddress, int portNumber)
        {
            _updComm = new BoardUdpComm(ipAddress, portNumber);
            _updComm.CreateDevice();
        }

        public bool ReadSingleIo(string contactCode, string address, out int replyData)
        {
            string sendMsg = MewtocolMsg.ReadSingleIo(contactCode, address);

            byte[] byteReply;
            if (SendReceive(sendMsg, out byteReply) == false)
            {
                replyData = 0;
                return false;
            }
            else
            {
                if (int.TryParse(Encoding.ASCII.GetString(new[] { byteReply[6] }), out replyData))
                    return true;
                else
                    return false;
            }
        }


        public bool ReadMultipleIo(int startAddress, int endAddress, string contactCode, ref Dictionary<string, UInt16> ioValue)
        {
            try
            {
                string sendMsg = MewtocolMsg.ReadMultipleIo(contactCode, startAddress, endAddress);

                byte[] byteReply;
                if (SendReceive(sendMsg, out byteReply) == false)
                {
                    return false;
                }
                else
                {
                    int size = endAddress - startAddress + 1;
                    // Word(16bit) 단위로 값을 읽어오는 첫 번째 주소. 연속된 여러 개의 Word 를 읽어올 경우에는 값을 증가시켜야 한다.
                    int wordAddressIndex = startAddress;
                    for (int i = 0; i < size; i++)
                    {
                        int index = i * 4 + 6;
                        byte[] bytes = new byte[] { byteReply[index + 2], byteReply[index + 3], byteReply[index], byteReply[index + 1] };
                        UInt16 intValue = Convert.ToUInt16(Encoding.ASCII.GetString(bytes), 16);
                        ioValue[contactCode + wordAddressIndex.ToString()] = intValue;
                        wordAddressIndex++;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                LogWriter.WriteLogMessage("Mewtocol8::ReadMultipleIo", e.StackTrace);
                return false;
            }
            
        }

        public  bool WriteSingleIo(string contactCode, string address, int value)
        {
            string sendMsg = MewtocolMsg.WriteIo(contactCode, address, value);

            byte[] byteReply;
            return SendReceive(sendMsg, out byteReply);
        }


        /// 장비가 1 대 꺼져 있을 경우에는 0.5초의 Delay 가 발생한다.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendReceive(string msg, out byte[] byteReply)
        {
            string errorMsg;
            byteReply = _updComm.SendReceive(msg);

            if (byteReply == null)
                return false;

            if( CheckErrorReply(byteReply, msg, out errorMsg) == false)
                return false;

            if (CheckBcc(byteReply, msg) == false)
                return false;

            return true;
        }

        private bool CheckErrorReply(byte[] reply, string sendMsg, out string errorMsg)
        {
            if (reply[3] == '!')
            {
                Int16 digit1 = Convert.ToInt16(Encoding.ASCII.GetString(new byte[] {reply[4]}), 16);
                Int16 digit2 = Convert.ToInt16(Encoding.ASCII.GetString(new byte[] { reply[5] }), 16);
                errorMsg = String.Format("Command: {0}, Reply: {1}, Error Code: 0x{2}{3}", sendMsg, Encoding.ASCII.GetString(reply), digit1, digit2);
                return false;
            }
            else if (reply[3] == '$')
            {
                errorMsg = String.Empty;
                return true;
            }
            else
            {
                errorMsg = String.Format("Reply Error = Command: {0}, Reply: {1}", sendMsg, Encoding.ASCII.GetString(reply));
                return false;
            }
        }

        private bool CheckBcc(byte[] reply, string sendMsg)
        {
            string replyBcc = GetBCC(reply);
            if (replyBcc[0] != reply[reply.Length - 3] || replyBcc[1] != reply[reply.Length - 2] )
                return false;
            else
                return true;
        }

        private string GetBCC(string data)
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

        private string GetBCC(byte[] data)
        {
            byte bcc = 0;
            // 마지막 CR 과 checksum 두자리는 제외
            for (int i = 0; i < data.Length - 3; i++)
            {
                bcc ^= data[i];
            }
            return bcc.ToString("X2");
        }


        /// <summary>
        /// int 데이터를 읽어 들이는 RDD 명령
        ///    Mewtocol               byte       ASCII        
        /// 3(0x33)  2(0x32)          0x32         2            
        /// 3(0x33)  3(0x33)          0x33         3            
        /// 3(0x33)  4(0x34)          0x34         4            
        /// </summary>
        public bool ReadData(int startAddress, int size, out int[] result)
        {
            result = new int[size];
            string command = String.Format("<01#RDD{0:00000}{1:00000}", startAddress, startAddress + size - 1);
            string bcc = GetBCC(command);

            string msg = String.Format("{0}{1}{2}", command, bcc, (char)0x0D);

            byte[] byteReply;
            bool isSuccess = SendReceive(msg, out byteReply);

            
            for (int i = 0; i < size; i++)
            {
                int index = i * 4 + 6;
                byte[] bytes = new byte[] { byteReply[index + 2], byteReply[index + 3], byteReply[index], byteReply[index + 1] };
                int resultVal = BitConverter.ToInt16(bytes, 0);
                UInt16 intValue = Convert.ToUInt16(Encoding.ASCII.GetString(bytes), 16);
                result[i] = intValue;
            }

            return isSuccess;
        }

        /// <summary>
        /// int 데이터를 쓰는 WDD 명령
        /// Mewtocol 전송은 ASCII 값을 int 로 변환한 후 다시 ASCII 로 변환한다.
        /// 그래서, 데이터 길이가 2배로 뻥튀기 된다.
        /// ASCII          byte            Mewtocol
        /// 2              0x32            3(0x33)  2(0x32)
        /// 3              0x33            3(0x33)  3(0x33)
        /// 4              0x34            3(0x33)  4(0x34)
        /// 
        /// 제어 코드는 16진수를 사용하고, 데이터는 10진수를 사용한다. PLC 특성상 두 가지를 병행해서 사용한다
        /// </summary>
        public bool WriteData(int startAddress, Int16[] aData, int size, out string errorMsg)
        {
            errorMsg = "";
            if (aData.Length != size)
            {
                errorMsg = String.Format("[aData] length(={0}) and [size](={1}) is different", aData.Length, size);
                return false;
            }

            StringBuilder saData = new StringBuilder(size * 4);
            for (int i = 0; i < size; i++)
            {
                byte[] bytes = BitConverter.GetBytes(aData[i]);
                saData.Append(String.Format("{0:X2}{1:X2}", bytes[0], bytes[1]));
            }

            string command = String.Format("<01#WDD{0:00000}{1:00000}{2}", startAddress, startAddress + size - 1, saData.ToString());
            string bcc = GetBCC(command);
            string msg = String.Format("{0}{1}{2}", command, bcc, (char)0x0D);

            byte[] byteReply;
            bool ret = SendReceive(msg, out byteReply);

            string replyMsg = Encoding.ASCII.GetString(byteReply);

            return ret;

        }

        public bool WriteData(int startAddress, Int16 data, out string errorMsg)
        {
            Int16[] aData = new Int16[1];
            aData[0] = data;
            return WriteData(startAddress, aData, 1, out errorMsg);
        }


        /// 선행하는 번지가 하위 16bit 이다
        public bool WriteDwordData(int startAddress, Int32 aData, out string errorMsg)
        {

            Int16[] aWordData = new Int16[2];

            aWordData[0] = (Int16)(aData & 0xFFFF);
            aWordData[1] = (Int16)((aData >> 16) & 0xFFFF);

            return WriteData(startAddress, aWordData, 2, out errorMsg);
        }

        /// 선행하는 번지가 하위 16bit 이다
        public bool ReadDwordData(int startAddress, out Int32 result)
        {
            result = 0;
            int[] readValue;
            if (ReadData(startAddress, 2, out readValue))
            {
                result = ((Int32)readValue[1] << 16) | readValue[0];
                return true;
            }
            else
                return false;

        }
    }
}

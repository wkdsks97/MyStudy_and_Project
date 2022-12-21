using MewtocolTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PanasonicPlc
{
    public class DeviceScanner
    {
        Thread _scanThread;
        Mewtocol8 _plc;
        Dictionary<string, UInt16> _ioValue;
        List<AddressConfig> _addresses { get; set; }

        public ActionResult CreateDevice(List<AddressConfig> addresses, Mewtocol8 mewtocol)
        {
            _plc = mewtocol;   
            
            _scanThread = new Thread(this.PlcScanThread);
            _scanThread.IsBackground = true;
            _scanThread.Start();

            _ioValue = new Dictionary<string, UInt16>();
            _addresses = addresses;

            return ActionResult.SUCCESS;
        }

        private void PlcScanThread()
        {

            // 시스템이 정지할 때까지 동작한다
            while (true)
            {
                try
                {
                    foreach (AddressConfig item in _addresses)
                    {
                        bool ret1 = _plc.ReadMultipleIo(ParsePlcAddress.GetWxAddress(item.StartAddress), ParsePlcAddress.GetWxAddress(item.EndAddress), ParsePlcAddress.GetContactCode(item.StartAddress), ref _ioValue);
                        if (ret1 == false)
                            LogWriter.WriteLogMessage("DeviceScanner::PlcScanThread", String.Format("Comm Error, Address={0}", item.StartAddress));
                    }
                    
                    Thread.Sleep(100);   // WeCan 모션 보드 스케쥴러 주기는 10ms
                }
                catch (Exception e)
                {
                    LogWriter.WriteLogMessage("DeviceScanner::PlcScanThread", e.Message + e.TargetSite.ToString());
                }
            }
        }
        

        public int GetValue(string address)
        {
            try
            {
                string contactCode = ParsePlcAddress.GetContactCode(address);

                int startAddrNumber = ParsePlcAddress.GetWxAddress(address);

                UInt16 wordValue = _ioValue[String.Format("{0}{1}", contactCode, startAddrNumber)];

                int endDigit = Convert.ToInt32(address.Substring(address.Length - 1), 16);
                int filter = 1 << (endDigit);

                return (wordValue & filter) == 0 ? 0 : 1;
            }
            catch (Exception e)
            {
                LogWriter.WriteLogMessage("DeviceScanner::GetValue", e.StackTrace);
                return -1;
            }
            
        }


    }
}

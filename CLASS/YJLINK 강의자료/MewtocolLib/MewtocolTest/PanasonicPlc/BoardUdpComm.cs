#define _BOARD_INSTALLED

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PanasonicPlc
{
    public class BoardUdpComm
    {
        public string _destIpAddress;
        int _destPortNumber;

        IPEndPoint _endPoint;
        UdpClient _udpClient;
        object _commLockObj;

        public int TotalAxisNumber { get; set; }

        public BoardUdpComm(string destIpAddress, int destPortNumber)
        {
            _destIpAddress = destIpAddress;
            _destPortNumber = destPortNumber;
        }

        public ActionResult CreateDevice()
        {
            _commLockObj = new object();
            IPAddress connectionIp = IPAddress.Parse(_destIpAddress);
            _endPoint = new IPEndPoint(connectionIp, _destPortNumber);

            try
            {
                /// 네트워크에서 remote 접속 주소에 연결할 수 없는 경우에는 IPEndPoint 를 매개변수로 UDPClient 생성 시
                /// WSAEADDRNOTAVAIL (10049) 에러가 발생한다
                /// 네트워크에 연결된 경우에만 IPEndPoint 를 사용할 수 있다
                _udpClient = new UdpClient(_destIpAddress, _destPortNumber);
                _udpClient.Client.ReceiveTimeout = 1000;
            }
            catch (SocketException e)
            {
                LogWriter.WriteLogMessage("UDPComm::CreateDevice", String.Format("Network Errcode = {0} \n", e.ErrorCode ));
                return ActionResult.FAIL;
            }

            return ActionResult.SUCCESS;
        }


        public void CloseDevice()
        {
            if (_udpClient != null)
                _udpClient.Close();
        }


        /// Send 와 Receive 는 항상 쌍으로 동작한다. 하지만 Critical Section 으로 보호할 필요는 없다.
        /// IO/Motion 보드 별로 다른 port 를 통해서 연결하므로 서로 다른 Socket 이 열리게 된다.
        /// 결국 하부 통신 Stack 에서 채널별로 따로 관리 된다. 
        /// ReceiveAsync 를 사용하여  비 동기 통신으로 변경하려고 하였으나 이 경우에는 string[] Return 값을 가질 수 없어서 포기.
        /// (당연하다. 비 동기 통신을 사용하면 컴파일러에서 스레드를 자동 생성하므로 리턴 값을 가질 수 없다)
        /// Receive 데이터의 Parsing 부분을 합칠 경우에는 비 동기 통신이 가능하다. 이 경우에는 IO 와 Motor Class 에 통신을 포함하면 된다.
        /// 한 장비에 보드가 많아질 경우에는 고려해볼 만하다.
        public virtual byte[] SendReceive(string msg)
        {
#if (_BOARD_INSTALLED)
            try
            {
                byte[] sendbuf = Encoding.ASCII.GetBytes(msg);
                Byte[] receiveBytes = null;

                /// m_commLockObj 는 객체마다 다르게 생성되는 object 이다.
                /// 그러므로 각 채널마다 Lock 이 동작한다. port 번호가 다른 경우에는 Lock object 도 다르므로 동작하지 않는다
                /// Status 값을 Read 하는 경우와 Set(Move) 하는 경우의 간섭을 방지하는 용도이다. QJ 2019-12-23
                lock (_commLockObj)
                {
                    /// m_endPoint 는 설정 값은 Client 입장에서는 아무런 의미가 없다. 앞에 선언된 ref 예약어를 보라!!!
                    /// 패킷을 수신하게 되면 송신 측 IP, Port 번호가 설정된 후 반환된다.
                    int reply = _udpClient.Send(sendbuf, sendbuf.Length);
                    receiveBytes = _udpClient.Receive(ref _endPoint);
                }

                return receiveBytes;
            }
            catch (SocketException se)
            {
                /// 통신 오류가 발생하면(Timeout 포함) 모두 catch 로 return 된다. 
                /// 그러므로 통신 에러가 발생한 경우에 try 문 내부에서의 통신 재 시도는 아무런 의미가 없다.
                /// 보드가 많아지면 가끔씩 Timeout 에러가 발생한다. 그 때는 일반적으로 Timeout 후에 수신이 발생하고
                /// 이로 인해서 패킷이 한 번씩 밀려서 송수신이 아니라 수신후 송신으로 패킷이 어긋나는 현상이 발생한다.
                /// 해결책은 버퍼를 Clear 하는 것인데 패킷 통신에는 buffer clear 함수가 없다. 그 대신 Read 하여 clear 해야 한다.
                /// 하지만 수신 데이터가 없을 경우 Read 하면 timeout 에러가 발생한다.
                /// 결국 새로운 객체를 생성하여 새로운 소켓(port)을 형성하는 것으로 buffer 를 clear 한다
                _udpClient = new UdpClient(_destIpAddress, _destPortNumber);
                _udpClient.Client.ReceiveTimeout = 1000;

                string errMsg = String.Format("IP({0}), Port({1}), {2}, Error Code({3})", _destIpAddress, _destPortNumber, se.Message, se.ErrorCode);
                LogWriter.WriteLogMessage("UDPComm::SendReceive", errMsg);
                return null;
            }
#else
            return null;
#endif
        }

        
    }
}

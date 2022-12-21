using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanasonicPlc
{
    public class ParsePlcAddress
    {
        static public string GetContactCode(string address)
        {
            return address.Substring(0, 1);
        }

        /// <summary>
        /// 10진수 값을 반환하지만 PLC 에서는 16진수 해석.
        /// X180 의 경우 WX Read (WORD) 단위 IO 값 읽기를 실행할 경우 Address 에 18을 설정하면 180 ~ 18F 까지 16bit 값 반환
        /// 
        /// 첫자리(접점 코드)와 마지막 자리(16진수)를 제거한 값을 반환한다.
        /// 
        /// 매개변수가 R000 인 경우 R0 을 반환한다.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        static public int GetWxAddress(string address)
        {            
            return int.Parse(address.Substring(1, address.Length - 2));
        }
    }
}

using System.Collections.Generic;

namespace PanasonicPlc
{
    public class DioInterface
    {
        public Mewtocol8 _plc;
        public DeviceScanner _scanner = new DeviceScanner();

        public List<AddressConfig> ContactAddressGroup { get; set; }

        public void CreateDevice(string ipAddress, int portNumber)
        {
            this.ContactAddressGroup = new List<AddressConfig>();
            this.ContactAddressGroup.Add(new AddressConfig("X000", "X00F"));
            this.ContactAddressGroup.Add(new AddressConfig("X180", "X19F"));
            this.ContactAddressGroup.Add(new AddressConfig("Y000", "Y000"));
            this.ContactAddressGroup.Add(new AddressConfig("Y180", "Y18F"));
            this.ContactAddressGroup.Add(new AddressConfig("R000", "R01F"));
            this.ContactAddressGroup.Add(new AddressConfig("R100", "R11F"));

            //_plc = new Mewtocol8("192.168.1.5", 8000);
            _plc = new Mewtocol8(ipAddress, portNumber);

            _scanner.CreateDevice(this.ContactAddressGroup, _plc);
        }

        public int GetDiValue(string address)
        {
            return _scanner.GetValue(address);
        }

        public ActionResult SetDioBit(string address, KState value)
        {
            string contactCode = ParsePlcAddress.GetContactCode(address);
            string contactCodeRemovedAddress = address.Substring(1, address.Length - 1);
            int intValue = (value == KState.ON) ? 1 : 0;
            return _plc.WriteSingleIo(contactCode, contactCodeRemovedAddress, intValue) ? ActionResult.SUCCESS : ActionResult.FAIL;
        }

    }
}

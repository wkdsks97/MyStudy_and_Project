
namespace PanasonicPlc
{
    public class AddressConfig
    {
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }

        public AddressConfig(string startAddr, string endAddr)
        {
            this.StartAddress = startAddr;
            this.EndAddress = endAddr;
        }
    }
}

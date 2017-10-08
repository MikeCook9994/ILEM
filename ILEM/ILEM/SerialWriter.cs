using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace ILEM
{
    class SerialWriter : ISerialWriter
    {
        private I2cDevice Device;

        public async Task InitializeConnection(int busAddress, string deviceSelector)
        {
            var settings = new I2cConnectionSettings(busAddress);
            string aqs = I2cDevice.GetDeviceSelector(deviceSelector);
            var dis = await DeviceInformation.FindAllAsync(aqs);
            this.Device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
        }

        public void Write(string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            this.Device.Write(bytes);
        }

        public void Write(byte[] bytes)
        {
            this.Device.Write(bytes);
        }
    }
}

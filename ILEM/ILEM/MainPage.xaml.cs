using Windows.UI.Xaml.Controls;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using System.Diagnostics;
using System.Threading;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ILEM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private I2cDevice Device;
        private Timer periodicTimer;
        public MainPage()
        {
            this.InitializeComponent();
            initcommunication();
        }

        private async void initcommunication()
        {
            var settings = new I2cConnectionSettings(0x40); // Arduino address
            settings.BusSpeed = I2cBusSpeed.StandardMode;
            string aqs = I2cDevice.GetDeviceSelector("I2C1");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            Device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
            periodicTimer = new Timer(this.TimerCallback, null, 0, 100); // Create a timmer
        }

        private void TimerCallback(object state)
        {
            byte[] RegAddrBuf = new byte[] { 0x40 };
            byte[] ReadBuf = new byte[5];

            try
            {
                Device.Read(ReadBuf); // read the data
            }
            catch (Exception f)
            {
                Debug.WriteLine(f.Message);
            }
        }
    }
}

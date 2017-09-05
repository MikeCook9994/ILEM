using Windows.UI.Xaml.Controls;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using System;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ILEM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private I2cDevice arduino;

        public MainPage()
        {
            this.InitializeComponent();
            InitializeSerialCommunication();
        }

        private async void InitializeSerialCommunication()
        {
            var settings = new I2cConnectionSettings(0x40); // Arduino address

            string aqs = I2cDevice.GetDeviceSelector("I2C1");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            arduino = await I2cDevice.FromIdAsync(dis[0].Id, settings);

            Messages.Text += arduino.ConnectionSettings.BusSpeed;
            Messages.Text += arduino.ConnectionSettings.SharingMode;
            Messages.Text += arduino.ConnectionSettings.SlaveAddress;
            Messages.Text += arduino.DeviceId;
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            this.HelloMessage.Text = "Hello, Windows 10 IoT Core!";
            this.arduino.Write(System.Text.Encoding.ASCII.GetBytes("Hello Arduino"));
        }
    }
}

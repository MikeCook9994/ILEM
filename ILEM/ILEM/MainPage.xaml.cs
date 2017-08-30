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
        private DispatcherTimer timer;

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

            Messages.Text += $"{dis.Count} --- ";
            for(int i = 0; i < dis.Count; i++)
            {
                Messages.Text += $"{dis[i].Name} --- ";
            }

            Messages.Text += arduino.DeviceId;
            if (arduino == null)
            {
                Messages.Text = string.Format(
                    "Slave address {0} on I2C Controller {1} is currently in use by " +
                    "another application. Please ensure that no other applications are using I2C.",
                    settings.SlaveAddress,
                    dis[0].Id);
            }

            this.timer = new DispatcherTimer();
            timer.Tick += Timer_Tick; // We will create an event handler 
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // Timer_Tick is executed every 500 milli second
            timer.Start();
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            this.HelloMessage.Text = "Hello, Windows 10 IoT Core!";
            this.arduino.Write(System.Text.Encoding.ASCII.GetBytes("Hello Arduino"));
        }

        private void Timer_Tick(object sender, object e)
        {

            byte[] response = new byte[2];
            //arduino.Read(response); // this funtion will read data from Arduino 
            Messages.Text += response[0].ToString();
        }
    }
}

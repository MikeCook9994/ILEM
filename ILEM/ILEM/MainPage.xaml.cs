using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ILEM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IColorPicker ColorPicker;

        private ISerialWriter ArduinoSerialWriter;

        public MainPage()
        {
            this.InitializeComponent();

            this.ColorPicker = new ColorPicker(this.RedSlider, this.GreenSlider, this.BlueSlider, this.ColorPalette);

            this.ArduinoSerialWriter = new SerialWriter();
            Task initTask = Task.Run(() => this.ArduinoSerialWriter.InitializeConnection(0x40, "I2C1"));

            while(!initTask.IsCompleted)
            {
                // spin until the task completes
            }

            SendUpdatedColor();
        }

        private void ColorSliderChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            this.ColorPicker.UpdatePaletteColor();

            string sliderName = (sender as Slider).Name;
            if (sliderName.Contains("Red"))
            {
                this.RedTextBox.Text = (sender as Slider).Value.ToString();
            }
            else if (sliderName.Contains("Green"))
            {
                this.GreenTextBox.Text = (sender as Slider).Value.ToString();
            }
            else
            {
                this.BlueTextBox.Text = (sender as Slider).Value.ToString();
            }

            SendUpdatedColor();
        }

        private void ColorTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            string textBoxName = (sender as TextBox).Name;
            if(textBoxName.Contains("Red"))
            {
                double tmpValue;
                double.TryParse((sender as TextBox).Text, out tmpValue);
                this.RedSlider.Value = tmpValue;
            }
            else if(textBoxName.Contains("Green"))
            {
                double tmpValue;
                double.TryParse((sender as TextBox).Text, out tmpValue);
                this.GreenSlider.Value = tmpValue;
            }
            else
            {
                double tmpValue;
                double.TryParse((sender as TextBox).Text, out tmpValue);
                this.BlueSlider.Value = tmpValue;
            }

            SendUpdatedColor();
        }

        private void SendUpdatedColor()
        {
            byte[] colorAsBytes = new byte[3];
            colorAsBytes[0] = (byte)this.RedSlider.Value;
            colorAsBytes[1] = (byte)this.GreenSlider.Value;
            colorAsBytes[2] = (byte)this.BlueSlider.Value;
            this.ArduinoSerialWriter.Write(colorAsBytes);
        }
    }
}

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

namespace ILEM
{
    class ColorPicker : IColorPicker
    {
        private Slider RedSlider;

        private Slider GreenSlider;

        private Slider BlueSlider;

        private Rectangle ColorPalette;

        public ColorPicker(Slider redSlider, Slider greenSlider, Slider blueSlider, Rectangle colorPalette)
        {
            this.RedSlider = redSlider;
            this.GreenSlider = greenSlider;
            this.BlueSlider = blueSlider;
            this.ColorPalette = colorPalette;
        }

        public void UpdatePaletteColor()
        {
            Color color = new Color();
            color.R = (byte)this.RedSlider.Value;
            color.G = (byte)this.GreenSlider.Value;
            color.B = (byte)this.BlueSlider.Value;
            color.A = (byte)255;
            this.ColorPalette.Fill = new SolidColorBrush(color);
        }
    }
}

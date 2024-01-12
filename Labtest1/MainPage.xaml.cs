using Microsoft.Maui.Controls;

namespace Labtest1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = sender as Slider;
            var value = e.NewValue;

            label1.Text = $"{value:0}";

            if (value < 40)
            {
                label2.Text = "Failed";
                label2.TextColor = Colors.Red;
                if (slider != null) slider.MinimumTrackColor = Colors.Red;
            }
            else if (value < 80)
            {
                label2.Text = "Passed";
                label2.TextColor = Colors.Black;
                if (slider != null) slider.MinimumTrackColor = Colors.Black;
            }
            else
            {
                label2.Text = "Excellent";
                label2.TextColor = Colors.Green;
                if (slider != null) slider.MinimumTrackColor = Colors.Green;
            }
        }
    }
}

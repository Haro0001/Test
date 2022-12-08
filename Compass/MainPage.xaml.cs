using System.Numerics;

namespace Compass02;

public partial class MainPage : ContentPage
{
    IAccelerometer accelerometer = Accelerometer.Default;

    public MainPage()
    {
        InitializeComponent();
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        if (accelerometer.IsSupported)
        {
            if (!accelerometer.IsMonitoring)
            {
                accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                accelerometer.Start(SensorSpeed.UI);
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
        }
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        myCanvas.AddData(e.Reading.Acceleration);
        myCanvas.Invalidate();
        AccelLabel.TextColor = Colors.Green;
        Vector3 acc = e.Reading.Acceleration;
        AccelLabel.Text = $"Accel: X:{acc.X:N2}, Y:{acc.Y:N2}, Z:{acc.Z:N2}";
    }

    private void StopButton_Clicked(object sender, EventArgs e)
    {
        if (accelerometer.IsSupported)
        {
            if (accelerometer.IsMonitoring)
            {
                accelerometer.Stop();
                accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            }
        }
    }

}

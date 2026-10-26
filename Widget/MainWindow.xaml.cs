using Microsoft.UI.Xaml;
using System;

namespace Widget
{
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer clockTimer;
        private bool showColon = true;
        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true; ///extends the canvas into title bar

            clockTimer = new DispatcherTimer();
            clockTimer.Interval = TimeSpan.FromMilliseconds(500);
            clockTimer.Tick += ClockTimer_Tick;

            UpdateClock();
            clockTimer.Start();
            DateText.Text = GetDate();
        }

        private void GetRamUsage()
        {
            int ramUsage = SystemMonitor.GetRamUsage();
            if (ramUsage >= 0)
            {
                RamUsage.Text = $"RAM: {ramUsage}%";
            }
            else
            {
                RamUsage.Text = "RAM: --";
            }
        }

        private string GetGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12)
            {
                return "Good morning, Amrik";
            }
            else if (hour < 17)
            {
                return "Good afternoon, Amrik";
            }
            else
            {
                return "Good evening, Amrik";
            }
        }

        private string GetTime()
        {
            string time = DateTime.Now.ToString("HH:mm");
            if (showColon)
            {
                return time;
            }
            else
            {
                return DateTime.Now.ToString("HH mm");
            }
        }

        private string GetDate()
        {
            string date = DateTime.Now.ToString("dd MMM, yyyy");
            return date;
        }

        private void UpdateClock()
        {
            GreetingText.Text = GetGreeting();
            ClockText.Text = GetTime();
            GetRamUsage();
        }

        private void ClockTimer_Tick(object? sender, object e)
        {
            showColon = !showColon;
            UpdateClock();

        }
    }
}
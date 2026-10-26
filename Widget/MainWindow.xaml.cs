using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Widget
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer clockTimer;
        private bool showColon = true;
        public MainWindow()
        {
            InitializeComponent();

            clockTimer = new DispatcherTimer();
            clockTimer.Interval = TimeSpan.FromMilliseconds(500);
            clockTimer.Tick += ClockTimer_Tick;

            UpdateClock();
            clockTimer.Start();

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
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (showColon)
            {
                return time;
            }
            else
            {
                return DateTime.Now.ToString("HH mm ss");
            }
        }

        private void UpdateClock()
        {
            GreetingText.Text = GetGreeting();
            ClockText.Text = GetTime();
        }

        private void ClockTimer_Tick(object sender, object e)
        {
            showColon = !showColon;
            UpdateClock();

        }
    }
}
using System;
using System.Windows;
using System.Timers;
namespace TomatoAlarm
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private CAlarm alarm;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Rect bounds = Properties.Settings.Default.WindowPosition;
                this.Top=bounds.Top;
                this.Left=bounds.Left;
            }
            catch
            {
                MessageBox.Show("No setting stored.");
            }

            alarm = new CAlarm {TimeLimit = new TimeSpan(0,1,0)};

            this.DataContext = alarm;
            alarm.Start();

            alarm.TimeOut += Alarm_TimeOut;
        }

        private void Alarm_TimeOut(object sender, EventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Red;
        }

        private void onclosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.WindowPosition = this.RestoreBounds;
            Properties.Settings.Default.Save();
        }
    }
}

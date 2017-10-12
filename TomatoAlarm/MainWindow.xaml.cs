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

        public MainWindow(CAlarm alm)
        {
            InitializeComponent();

            this.DataContext = this.alarm = alm;


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

            //TODO: 界面完善,拖动功能，透明功能、设置功能、退出、停止功能
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

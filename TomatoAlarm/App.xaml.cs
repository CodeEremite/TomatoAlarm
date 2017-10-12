using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TomatoAlarm
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            MainWindow win = new MainWindow(new CAlarm {TimeLimit = new TimeSpan(0,0,1)});
            this.MainWindow = win;
            win.Show();
        }
    }
}

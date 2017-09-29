using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace TomatoAlarm
{
    public delegate void TimeOutEventHandler(object sender, EventArgs e);
    public class CAlarm:INotifyPropertyChanged
    {

        private DispatcherTimer timer;

        private TimeSpan timeleft;
        private TimeSpan timelimit;

        public event PropertyChangedEventHandler PropertyChanged;
        public event TimeOutEventHandler TimeOut;

        public CAlarm()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += RefreshTimeLeft;
        }

        private void RefreshTimeLeft(object sender, EventArgs e)
        {
            TimeLeft = TimeLeft.Subtract(new TimeSpan(0,0,1));
        }

        public TimeSpan TimeLimit
        {   get
            {
                return timelimit;
            }
            set
            {
                timelimit = value;
                TimeLeft  = value;
            }
        }
        
        public TimeSpan TimeLeft
        {
            get
            {
                return timeleft;
            }
            private set
            {
                timeleft = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeLeft"));
                
                if(timeleft.TotalSeconds <= 0)
                {
                    timer.Stop();
                    TimeOut?.Invoke(this,new EventArgs());
                }
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }
    }
}

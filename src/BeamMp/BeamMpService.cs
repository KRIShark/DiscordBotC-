using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static DcBeamMpBot.Modules.ExampleModule;

namespace Example.BeamMp
{
    public static class BeamMpService 
    {
        static Timer timer;
        public static void ON(int sec, System.Timers.ElapsedEventHandler elapsedEventHandler) 
        {
            if (timer != null)
            {
                timer.Stop();
            }
            timer = new Timer(sec * 1000);
            timer.Elapsed += elapsedEventHandler;
            timer.Start();
        }
        public static void OFF(int sec)
        {
            if (timer == null)
            {
                timer = new Timer(sec * 1000);
            }
            timer.Stop();
        }

        //protected void OnStart()
        //{
        //    var _timer = new Timer(40 * 1000); // every 40 seconds
        //    _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        //    _timer.Start(); // <- important
        //}

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) 
        {
            //ReplyAsync("", false, builder.Build());
        }
    }
}

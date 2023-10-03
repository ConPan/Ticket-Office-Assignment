using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office_Assignment
{
    public class ArenaEvent
    {
        public  EventActivity Activity { get; set; } 
        public double Duration { get; set; }
        public DateTime StartTime { get; set; }

        public ArenaEvent()
        { 
        }

        public ArenaEvent(EventActivity activity, double duration, DateTime startTime)
        {
            Activity = activity;
            Duration = duration;
            StartTime = startTime;
        }

        public DateTime EndTime () 
        { 
        return StartTime + TimeSpan.FromSeconds(Duration);
        }
    }
}

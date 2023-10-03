using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office_Assignment
{
    public class App
    {
        public static ArenaEvent CreateArenaEvent()
        { 
        ArenaEvent actualEvent = new ArenaEvent();

        actualEvent.Activity = EventActivity.Concert;
        actualEvent.Duration = 2.45;
        actualEvent.StartTime = new DateTime(2023, 11, 05);
        
        return actualEvent;
        }
    }
}

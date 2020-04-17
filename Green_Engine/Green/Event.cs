using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Green_Engine.Green
{
    public class EventArgs
    {
        public readonly DateTime EventTime;
        public EventArgs()
        {
            EventTime = DateTime.Now;
        }
    }
}
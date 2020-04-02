using Green_Engine.Green;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Engine
{
    public class Green_Application
    {
        public Green_Application(string[] args)
        {
            Logger.Init();
            Logger.Info_int("George! Are you here sir!?");
        }


        public void Run()
        {
            while (true) ;
        }

    }
}

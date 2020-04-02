using Green_Engine.Green;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Program : Green_Engine.Green_Application
    {
        public Program(string[] args) : base(args)
        {
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            Logger.Warn("Yes Sir Carl, I am here.  You don't need to shout.");
            program.Run();

            

        }
    }
}

using Green_Engine.Green;
using Raylib_cs;
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

        bool Underscore = false;
        float timeElapsed;

        public Program(string[] args) : base(args)
        {
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            Logger.Warn("Yes Sir Carl, I am here.  You don't need to shout.");
            program.Run();

            

        }

        protected override void Init()
        {
            BGColor = Color.BLACK;
        }

        protected override void Update(float DeltaTime)
        {
            timeElapsed += DeltaTime;
            if(timeElapsed > 0.5f)
            {
                Underscore = !Underscore;
                timeElapsed = 0.0f;
            }
        }

        protected override void Draw(float DeltaTime)
        {
            if (Underscore)
            {
                Raylib.DrawText("Booting...\n_", 5, 5, 18, Color.GRAY);
            }
            else
            {
                Raylib.DrawText("Booting...", 5, 5, 18, Color.GRAY);
            }
        }
    }
}

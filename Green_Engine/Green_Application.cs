using Green_Engine.Green;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.IO;
using System.Reflection;

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
            Logger.Info_int($"Loading from:{Path.GetDirectoryName(Assembly.GetAssembly(typeof(Green_Application)).CodeBase)}");
            Raylib.InitWindow(1280, 720, "Green Engine");
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.DrawText("Hello world!", 12, 12, 20, Color.BLACK);

                Raylib.EndDrawing();
            }
        }

    }
}

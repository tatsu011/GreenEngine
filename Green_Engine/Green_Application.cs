using Green_Engine.Green;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.IO;
using System.Reflection;
using System.Net.Sockets;

namespace Green_Engine
{
    public abstract class Green_Application
    {
        protected Color BGColor = Color.WHITE;

        public Green_Application(string[] args)
        {
            Logger.Init();
            Logger.Info_int("George! Are you here sir!?");
        }


        public void Run(string Title = "Green Engine", int GameFPS = 60)
        {
            Logger.Info_int($"Loading from:{Path.GetDirectoryName(Assembly.GetAssembly(typeof(Green_Application)).CodeBase)}");
            Raylib.InitWindow(1280, 720, Title);
            Raylib.SetTargetFPS(GameFPS);

            Init();

            while(!Raylib.WindowShouldClose()) //I feel like this should be setup differently... o.o...
            {
                float deltaTime = Raylib.GetFrameTime();

                Update(deltaTime);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(BGColor);

                Draw(deltaTime);

                Raylib.EndDrawing();

                LateUpdate(deltaTime);
            }

            Shutdown();
            
        }

        protected virtual void Init() { }

        protected virtual void Update(float DeltaTime) { }
        protected virtual void Draw(float DeltaTime) { }
        protected virtual void LateUpdate(float DeltaTime) { }

        protected virtual void Shutdown() { }
    }
}

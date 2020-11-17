using Green_Engine.Green;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Green_Engine
{
    public class Green_Application
    {
        List<RegistryObject> gameObjects;

        public Green_Application(string[] args)
        {
            Logger.Init();
            Logger.Info_int("George! Are you here sir!?");
            gameObjects = new List<RegistryObject>();
            Logger.Info_int("I have a large payload to run!");
        }


        public void Run()
        {
            OnPreInit();

            InitWindow(1280, 720, "Green Engine");

            //Image logo = LoadImage("Engine/GreenLgo.png");
            OnInit();
            //Texture2D texture = LoadTextureFromImage(logo);
            //UnloadImage(logo); //Logo is now empty.

            while(!WindowShouldClose())
            {
                OnUpdate();
                BeginDrawing();
                ClearBackground(Color.WHITE);

                OnDraw();

                DrawText("Hello world!", 12, 12, 20, Color.BLACK);
                DrawText("We are running with Raylib 3.0.", 12, 34, 20, Color.BLACK);
                DrawText("With Green Engine version 0.1", 12, 58, 20, Color.BLACK);

                //DrawTexture(texture, GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, Color.WHITE);

                EndDrawing();

                OnLateUpdate();
            }
            //UnloadTexture(texture); //clean up the GPU.
            OnShutdown();
        }

        #region "Events"

        void OnPreInit()
        {
            foreach(RegistryObject ro in gameObjects)
            {
                ro.PreInit();
            }
        }

        void OnInit()
        {
            foreach (RegistryObject ro in gameObjects)
            {
                ro.Init();
            }
        }

        void OnUpdate()
        {
            foreach (RegistryObject ro in gameObjects)
            {
                ro.Update();
            }
        }

        void OnDraw()
        {
            foreach (RegistryObject ro in gameObjects)
            {
                ro.Draw();
            }
        }

        void OnLateUpdate()
        {
            foreach (RegistryObject ro in gameObjects)
            {
                ro.LateUpdate();
            }
        }

        void OnShutdown()
        {
            foreach (RegistryObject ro in gameObjects)
            {
                ro.Shutdown();
            }
        }

        #endregion

        public bool RegisterObject(RegistryObject obj)
        {
            if(!gameObjects.Contains(obj))
            {
                gameObjects.Add(obj);
                return true;
            }
            return false;
        }

    }
}

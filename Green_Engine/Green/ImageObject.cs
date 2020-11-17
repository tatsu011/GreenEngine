using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Green_Engine.Green
{
    public class ImageObject : RegistryObject
    {
        public string Filepath
        {
            get;
            private set;
        }

        Image image;
        Texture2D texture;
        public Vector2 Location;



        public ImageObject(string path, int posX, int posY)
        {
            Filepath = path;
            Location = new Vector2(posX, posY);
        }


        public override void Init()
        {
            image = LoadImage(Filepath); //Loaded into memory
            texture = LoadTextureFromImage(image); //Loaded into GPU
        }

        public override void Draw()
        {
            DrawTexture(texture, (int)Location.x, (int)Location.y, Color.WHITE);
        }

        public override void Shutdown()
        {
            UnloadImage(image);
            UnloadTexture(texture);
        }

    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace SEGORATA
{
    public class Nation
    {
        rGame g;                    //This allows to refer back to the rGame class. Used to draw things with spriteBatch and the like.
        int x, y;                   //The position of the top left corner of the texture
        Texture2D tex;              //The texture of the nation
        public Color Colour;        //The colour of the nation
        public String[] neighbors;  //The names of neighbouring nations
        public String name;         //The name of the nation
        public int continent;       //The continent this nation belongs to
        public Nation(rGame game, int X, int Y, Texture2D texture, int Continent, Color Ownership, String[] Neighbors, String Name)
        {
            g = game;               
            x = X;                  
            y = Y;
            tex = texture;
            Colour = Ownership;
            neighbors = Neighbors;
            continent = Continent;
            name = Name;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            g.g.spriteBatch.Draw(tex, g.tDraw(new Rectangle(x, y, tex.Width, tex.Height)), Colour);
        }
    }
}

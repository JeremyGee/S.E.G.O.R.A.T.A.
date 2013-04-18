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
    public class Player
    {
        rGame g;
        public String name;
        public Boolean ai;
        public Color colour;
        
        public Player(rGame G, String Name, Boolean isAI, Color Colour)
        {
            g = G;
            name = Name;
            ai = isAI;
            colour = Colour;
        }
    }
}

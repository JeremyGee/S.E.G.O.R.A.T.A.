using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace SEGORATA
{
    public class rGame
    {
        public Game1 g;         //The main class

        public int sMoveX = 0;  //The amount of X that the screen is panned
        public int sMoveY = 0;  //The amount of Y that the screen is panned
        public double sZoom = 1;   //The amount of zoom

        List<Player> pls;      //True is the player is human, false if it is an AI

        Boolean offline;        //This flag holds the value of whether or not the game is offline

        List<Nation> Nations = new List<Nation>();

        String[] continents;    //The continents and their worths; stored like this: "name,A|D|S|T"

        public rGame(Game1 game, List<Player> players, Boolean isOffline, String mapName)
        {
            g = game;

            pls = players;

            offline = isOffline;

            String[] mPosA = File.ReadAllLines("maps\\" + mapName + "\\map.txt");
            String[] mPos = mPosA[0].Split(' ');
            continents = mPosA[1].Split(' ');

            foreach (String pos in mPos)
            {
                String[] nNs = pos.Split(',')[4].Split(':');
                Nation[] nN = new Nation[nNs.Length];
                int i = 0;

                //Get all neighbouring nation objects
                foreach (Nation n in Nations)
                {
                    if(Array.IndexOf(nNs, n.name)>-1)
                    {
                        nN[i]=n;
                        i++;
                    }
                }

                //Add the actual nation. Huge function, I know.
                Nations.Add(new Nation(this,                                        //Reference to rGame(this class)
                    int.Parse(pos.Split(',')[1]), int.Parse(pos.Split(',')[2]),     //Position
                    g.gT("maps\\" + mapName + "\\" + pos.Split(',')[0] + ".png"),   //Texture
                    int.Parse(pos.Split(',')[3]),                                   //Continent ID
                    new Player(this, "none", false, Color.White),                   //Colour
                    nN,                                                             //Neighbouring nations
                    pos.Split(',')[0]));                                            //Nation name
            }

            for (int i = 0; i < pls.Count; i++)
            {
                int rNation = g.r.Next(0, mPos.Length);
                while (Nations[rNation].Owner.colour!=Color.White)
                    rNation = g.r.Next(0, mPos.Length);
                Nations[rNation].Owner = players[i];
            }
        }

        int pmx = 0;
        int pmy = 0;
        int pms = 0;

        public void Update()
        {
            #region Offline Game
            if (offline)
            {

            }
            #endregion

            #region Online Game
            if (!offline)
            {

            }
            #endregion

            //General code; code that goes for either online and offline
                //Zooming and Panning
            MouseState ms = Mouse.GetState();
            if (ms.ScrollWheelValue > pms) sZoom += 0.25;
            if (ms.ScrollWheelValue < pms) sZoom -= 0.25;
            if (sZoom < 0.25) sZoom = 0.25;
            if (sZoom > 2) sZoom = 2;
            pms = ms.ScrollWheelValue;
            if (ms.RightButton == ButtonState.Pressed)
            {
                sMoveX += ms.X - pmx;
                sMoveY += ms.Y - pmy;
            }
            pmx = ms.X;
            pmy = ms.Y;

                //Updating
            for (int i = 0; i < Nations.Count; i++) Nations[i].Update();
        }

        public void Draw()
        {
            #region Offline Game
            if (offline)
            {

            }
            #endregion

            #region Online Game
            if (!offline)
            {

            }
            #endregion

            //General code; code that goes for either online and offline
                //Drawing
            for (int i = 0; i < Nations.Count; i++) Nations[i].Draw();
        }

        public Rectangle tDraw(Rectangle rect)
        {
            rect.Width = (int)(rect.Width*sZoom);
            rect.Height = (int)(rect.Height * sZoom);
            rect.X = (int)(rect.X * sZoom);
            rect.Y = (int)(rect.Y * sZoom);
            rect.X += sMoveX;
            rect.Y += sMoveY;
            return rect;
        }
    }
}

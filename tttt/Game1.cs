using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace tttt
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public rGame Game;

        public Random r = new Random();

        public List<Color> Colours = new List<Color>();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // Initialization code
        protected override void Initialize()
        {
            //Define the 8 colours that players can have.
            Colours.Add(Color.FromNonPremultiplied(240, 40, 40, 255));      //red
            Colours.Add(Color.FromNonPremultiplied(140, 230, 50, 255));     //green
            Colours.Add(Color.FromNonPremultiplied(110, 160, 210, 255));    //blue
            Colours.Add(Color.FromNonPremultiplied(250, 230, 80, 255));     //yellow
            Colours.Add(Color.FromNonPremultiplied(170, 100, 170, 255));    //purple
            Colours.Add(Color.FromNonPremultiplied(135, 135, 135, 255));    //gray
            Colours.Add(Color.FromNonPremultiplied(250, 175, 60, 255));     //orange
            Colours.Add(Color.FromNonPremultiplied(140, 90, 0, 255));       //brown

            

            Boolean[] hs = new Boolean[6];
            hs[0] = true;
            hs[1] = true;
            hs[2] = true;
            hs[3] = true;
            hs[4] = true;
            hs[5] = true;

            String[] ns = new String[6];
            ns[0] = "Reetbau1";
            ns[1] = "Reetbau2";
            ns[2] = "Reetbau3";
            ns[3] = "Reetbau4";
            ns[4] = "Reetbau5";
            ns[5] = "Reetbau6";
            Game = new rGame(this, hs, ns, true, "default");    //Create a new offlineGame instance. This is to be called whenever someone creates a new game.

            base.Initialize();
        }

        // Content loading.
        // Example:
        // Tx_Yourmom = Content.Load<Texture2D>("yourmom");
        // This loads the resource 'yourmom' into the Texture2D variable 'Tx_Yourmom'. And crashes your computer.
        protected override void LoadContent()
        {
            // Create SpriteBatch.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        // The below is probably not going to be necessary. But who knows!
        protected override void UnloadContent()
        {
        }

        // This is the code which runs every frame.
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Game.Update();

            base.Update(gameTime);
        }

        //This code also runs every frame, but should be used to draw graphics. It is run after Update()
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //This Begin() is subject to change depending on the art style we choose.
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);


            //Inbetween Begin() and End() goes all drawing.
            Game.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Texture2D gT(String url)
        {
            return Texture2D.FromStream(GraphicsDevice, new StreamReader(url).BaseStream);
        }
    }
}

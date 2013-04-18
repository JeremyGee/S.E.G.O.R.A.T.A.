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

            //Make the list of players and start a game (Temporary code)
            List<Player> ps = new List<Player>();
            ps.Add(new Player(Game, "reetbau1", false, Colours[0]));
            ps.Add(new Player(Game, "reetbau2", false, Colours[1]));
            ps.Add(new Player(Game, "reetbau3", false, Colours[2]));
            ps.Add(new Player(Game, "reetbau4", false, Colours[3]));
            ps.Add(new Player(Game, "REETBAU5", false, Colours[4]));
            ps.Add(new Player(Game, "reetbau6", false, Colours[5]));
            Game = new rGame(this, ps, true, "default");    //Create a new offlineGame instance. This is to be called whenever someone creates a new game.

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

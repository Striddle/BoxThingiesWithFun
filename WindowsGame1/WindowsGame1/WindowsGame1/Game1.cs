  using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Rectangle[] CrazyTile = new Rectangle[100];
       // Rectangle CheckerBoard = new Rectangle(0, 0, 15, 15);
       // Rectangle CheckerBoardBlack = new Rectangle(15, 0, 15, 15);
        int CurrentScreen = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                CrazyTile[i] = new Rectangle(random.Next(0, 800), random.Next(0, 600), random.Next(15, 100), random.Next(15, 100));
            }
                base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            square = Content.Load<Texture2D>("square");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.D1))
            {
                CurrentScreen = 1;
            }
            else if (kb.IsKeyDown(Keys.D2))
            {
                CurrentScreen = 2;
            }
            else if (kb.IsKeyDown(Keys.D3))
            {
                CurrentScreen = 3;
            }
            else if (kb.IsKeyDown(Keys.D4))
            {
                CurrentScreen = 4;
            }

            base.Update(gameTime);
        }

        public void DrawCheckerBoard()
        {
            int X = 0;
            int Y = 0;
            for (int i = 0; i < 10000; i++)
            {
                Rectangle CheckerBoard = new Rectangle(X, Y, 15, 15);
                spriteBatch.Begin();

                if (i % 2 == 0)
                {
                    spriteBatch.Draw(square, CheckerBoard, Color.White);
                }
                else
                    spriteBatch.Draw(square, CheckerBoard, Color.Black);
                X += 15;
                if (i % 53 == 52)
                {
                    Y += 15;
                    X = 0;
                }
                spriteBatch.End();

            }
        }

            public void DrawCrazySquares()
        {
            Random random = new Random();
            spriteBatch.Begin();
            

        
        for (int i = 0; i < 100; i++)
        {
            spriteBatch.Draw(square, CrazyTile[i], Color.Firebrick);

            if(i % 2 == 0)
                spriteBatch.Draw(square, CrazyTile[i], Color.OrangeRed);
        }
        spriteBatch.End();
        }


            public void DrawRainbow()
            {


            }

            public void DrawBlankScreen()
            {


            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            switch (CurrentScreen)
            {

                case 1: DrawCheckerBoard(); break;
                case 2: DrawCrazySquares(); break;
                case 3: DrawRainbow(); break;
                case 4: DrawBlankScreen(); break; 
            }

            base.Draw(gameTime);
        }
    }
}

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace ClockworkSkies
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Test plane
        //Plane testPlane;
        Menu gameMenu;
        //Player testPlayer;
        Enemy[] testEnemy = new Enemy[3];


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1360;
            graphics.PreferredBackBufferHeight = 768;

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

            base.Initialize();
            IsMouseVisible = true;
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
            GameVariables.PlayerImage = Content.Load<Texture2D>("temp");
            GameVariables.BulletImage = Content.Load<Texture2D>("bullet");
            GameVariables.ButtonImage = Content.Load<Texture2D>("button");
            GameVariables.BaseImage = Content.Load<Texture2D>("base");
            GameVariables.TextFont = Content.Load<SpriteFont>("mainFont");
            //testPlane = new Plane(GameVariables.PlayerImage, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 50), 32, 32, 0, 3 * (float)(Math.PI / 180), 150);
            //testPlayer = new Player(GameVariables.PlayerImage, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 50), 32, 32, 0, 3 * (float)(Math.PI / 180), 150);

            //testEnemy[0] = new Enemy(GameVariables.PlayerImage, new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height - 50), 32,
            //                        32, 0, 3 * (float)(Math.PI / 180), 150, testPlayer);
            //testEnemy[1] = new Enemy(GameVariables.PlayerImage, new Vector2(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height - 50), 32,
            //                        32, 0, 3 * (float)(Math.PI / 180), 150, testPlayer);
            //testEnemy[2] = new Enemy(GameVariables.PlayerImage, new Vector2(GraphicsDevice.Viewport.Width / 5, GraphicsDevice.Viewport.Height - 50), 32,
            //                        32, 0, 3 * (float)(Math.PI / 180), 150, testPlayer);

           // button1 = new Button(new Rectangle(50, 50, 200, 100), "Button");
            gameMenu = new Menu(MenuState.Title, this);
            

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            MouseState mState = Mouse.GetState();

            //KeyboardState kState = Keyboard.GetState();
            GamePadState gState = GamePad.GetState(0);

            //testPlayer.kState = Keyboard.GetState();
            if (gameMenu.levels.currentLevel != null)
            {
                gameMenu.levels.currentLevel.p1.kState = Keyboard.GetState();
            }

            //testPlayer.Update();

            for (int i = 0; i < GameVariables.pieces.Count; i++)
            {
                GameVariables.pieces[i].Update();
            }
            gameMenu.Update(mState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            
            foreach(Piece piece in GameVariables.pieces)
            {
                piece.Draw(spriteBatch);
            }

            //spriteBatch.DrawString(font, "Direction: " + testPlane.direction, new Vector2(50, 50), Color.White);
            //spriteBatch.DrawString(font, "Speed: " + testPlane.speed, new Vector2(50, 100), Color.White);

            //spriteBatch.DrawString(font, "Piece List Length: " + GameVariables.pieces.Count, new Vector2(50, 150), Color.White);

            //button1.Draw(spriteBatch, button, font);
            gameMenu.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

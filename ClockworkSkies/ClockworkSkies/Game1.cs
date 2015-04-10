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

        Menu gameMenu;



        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = GameVariables.WindowWidth;
            graphics.PreferredBackBufferHeight = GameVariables.WindowHeight;
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
            GameVariables.SmokeImage = Content.Load<Texture2D>("smoke");

            GameVariables.MainGame = this;

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

            // TODO: Add your update logic here
            MouseState mState = Mouse.GetState();

            GamePadState gState = GamePad.GetState(0);

            if (gameMenu.levels.currentLevel != null)
            {
                gameMenu.levels.currentLevel.p1.kState = Keyboard.GetState();
            }

            for (int i = 0; i < GameVariables.pieces.Count; i++)
            {
                GameVariables.pieces[i].Update();
            }

            for (int i = 0; i < GameVariables.smokeList.Count; i++)
            {
                GameVariables.smokeList[i].Update();
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

            GameVariables.pieces.Reverse();

            for (int i = 0; i < GameVariables.pieces.Count; i++)
            {
                if (GameVariables.pieces[i].ShouldDraw)
                {
                    GameVariables.pieces[i].Draw(spriteBatch);
                }
            }

            for (int i = 0; i < GameVariables.smokeList.Count; i++)
            {
                GameVariables.smokeList[i].Draw(spriteBatch);
            }

            GameVariables.pieces.Reverse();

            gameMenu.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

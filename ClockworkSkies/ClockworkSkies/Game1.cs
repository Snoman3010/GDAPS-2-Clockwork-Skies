#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
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

        public Menu gameMenu;



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
            GameVariables.GameTitle = Content.Load<Texture2D>("title2");

            GameVariables.PlayerImage = Content.Load<Texture2D>("player_plane");
            GameVariables.AllyImage = Content.Load<Texture2D>("ally_plane");
            GameVariables.AllyEscortImage = Content.Load<Texture2D>("ally_escort");
            GameVariables.EnemyImage = Content.Load<Texture2D>("enemy_plane");
            GameVariables.EnemyEscortImage = Content.Load<Texture2D>("enemy_escort");
            GameVariables.BulletImage = Content.Load<Texture2D>("player_bullet");
            GameVariables.EnemyBulletImage = Content.Load<Texture2D>("enemy_bullet");
            GameVariables.ButtonImage = Content.Load<Texture2D>("button");
            GameVariables.BaseImage = Content.Load<Texture2D>("base_ally");
            GameVariables.EnemyBaseImage = Content.Load<Texture2D>("base_enemy");
            GameVariables.TextFont = Content.Load<SpriteFont>("mainFont");
            GameVariables.SmokeImage = Content.Load<Texture2D>("smoke");
            GameVariables.SelectorImage = Content.Load<Texture2D>("selector");

            GameVariables.MainMenu = Content.Load<Texture2D>("main_menu");
            GameVariables.BarrenRiverBackground = Content.Load<Texture2D>("level1");
            GameVariables.CoastalTroubleBackground = Content.Load<Texture2D>("level2");

            GameVariables.MainGame = this;

            GameVariables.BGM = Content.Load<SoundEffect>("pianoMusic");
            GameVariables.BulletSound = Content.Load<SoundEffect>("gunshot");
            GameVariables.ExplosionSound = Content.Load<SoundEffect>("explosion");

            gameMenu = new Menu(MenuState.Title, this);
            
            //requires openAL
            try
            {
                SoundEffectInstance instance = GameVariables.BGM.CreateInstance();
                instance.IsLooped = true;
                instance.Play();
            }
            catch(System.DllNotFoundException)
            {
                Console.WriteLine("OpenAL not found, no sound will play.");
            }
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

            if (GameVariables.GameUnpaused)
            {
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

            DrawBackground(gameMenu.State);

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

        private void DrawBackground(MenuState state)
        {
            Rectangle screen = new Rectangle(0, 0, GameVariables.WindowWidth, GameVariables.WindowHeight);
            
            switch (state)
            {
                case MenuState.Title:
                    {
                        spriteBatch.Draw(GameVariables.MainMenu, screen, Color.White);
                        break;
                    }
                case MenuState.Main:
                    {
                        spriteBatch.Draw(GameVariables.MainMenu, screen, Color.White);
                        break;
                    }
                case MenuState.Play:
                    {
                        spriteBatch.Draw(GameVariables.BarrenRiverBackground, screen, Color.White);
                        break;
                    }
                case MenuState.GameOver:
                    {
                        spriteBatch.Draw(GameVariables.MainMenu, screen, Color.White);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}

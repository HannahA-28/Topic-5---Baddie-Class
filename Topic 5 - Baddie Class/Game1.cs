using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Topic_5___Baddie_Class
{

    enum Screen
    {
        Title,
        House,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Screen screen;
        Rectangle window;
        List<Texture2D> ghostTextures;
        Texture2D titleTexture;
        Texture2D houseTexture;
        Texture2D endTexture;
        Texture2D marioTexture;
        MouseState mouseState;
        Random random;
        Ghost ghost1;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ghostTextures = new List<Texture2D>();
            random = new Random();
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;

            screen = Screen.House;

            base.Initialize();

            ghost1 = new Ghost(ghostTextures, new Rectangle(150, 250, 40, 40));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            titleTexture = Content.Load<Texture2D>("haunted-title");
            houseTexture = Content.Load<Texture2D>("haunted-background");
            endTexture = Content.Load<Texture2D>("haunted-end-screen");
            marioTexture = Content.Load<Texture2D>("mario");

            ghostTextures.Add(Content.Load<Texture2D>("boo-stopped"));

            for (int i = 1; i <= 8; i++)
            {
                ghostTextures.Add(Content.Load<Texture2D>("boo-move-" + i));
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();
            ghost1.Update(mouseState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(houseTexture, window, Color.White);
            ghost1.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Texture2D> pTextures;
        Texture2D HazUTexture;
        Texture2D HazDTexture;
        Texture2D HazLTexture;
        Texture2D HazRTexture;
        Texture2D HazSTexture;
        Texture2D HazTexture;
        Texture2D HazNETexture;
        Texture2D HazSETexture;
        Texture2D HazSWTexture;
        Texture2D HazNWTexture;
        Player player;
        MouseState mouseState;
        KeyboardState keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            pTextures = new List<Texture2D>();
            base.Initialize();
            player = new Player(pTextures, 10, 10);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            HazDTexture = Content.Load<Texture2D>("HazmatDown");
            HazUTexture = Content.Load<Texture2D>("HazmatUp");
            HazLTexture = Content.Load<Texture2D>("HazmatLeft");
            HazRTexture = Content.Load<Texture2D>("HazmatRight");
            HazSTexture = Content.Load<Texture2D>("HazmatStand");
            HazNETexture = Content.Load<Texture2D>("HazmatNorthE");
            HazSETexture = Content.Load<Texture2D>("HazmatSouthE");
            HazSWTexture = Content.Load<Texture2D>("HazmatSouthW");
            HazNWTexture = Content.Load<Texture2D>("HazmatNorthW");


            HazTexture = HazSTexture;
            pTextures.Add(HazSTexture);
            pTextures.Add(HazUTexture);
            pTextures.Add(HazDTexture);
            pTextures.Add(HazLTexture);
            pTextures.Add(HazRTexture);
            pTextures.Add(HazNETexture);
            pTextures.Add(HazSETexture);
            pTextures.Add(HazSWTexture);
            pTextures.Add(HazNWTexture);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
           
            
           



                player.Update(keyboardState);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
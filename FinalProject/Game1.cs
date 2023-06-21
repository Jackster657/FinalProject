using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Texture2D> pTextures;
        List<Rectangle> CollisionTextures;
        Texture2D borderTexture;
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
        Texture2D HazSHUTexture;
        Texture2D HazSHDTexture;
        Texture2D HazSHLTexture;
        Texture2D HazSHRTexture;
        Texture2D HazSHNETexture;
        Texture2D HazSHNWTexture;
        Texture2D HazSHSETexture;
        Texture2D HazSHSWTexture;
        Texture2D BackgroudTexture;
        Texture2D enemieTexture;
        Rectangle BackgroundRect;
        Player player;
        Projectile bullet;
        Enemies enemies;
        MouseState mouseState;
        KeyboardState keyboardState;
        MouseState prevMouseState;
        Texture2D bulletTexture;
        List<Projectile> projectileList;
        List<Enemies> enemiesList;
        SoundEffect shoot;
        SoundEffect ricochet;
        Song intro;
        Song song;
        float seconds;
        float startTime;
        float secondsUp;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            pTextures = new List<Texture2D>();
            CollisionTextures = new List<Rectangle>();
            projectileList = new List<Projectile>();
            enemiesList= new List<Enemies>();
            
            base.Initialize();
            player = new Player(pTextures, 50, 50);
            
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
            HazSHUTexture = Content.Load<Texture2D>("HazmatShootU");
            HazSHDTexture = Content.Load<Texture2D>("HazmatShootD");
            HazSHLTexture = Content.Load<Texture2D>("HazmatShootL");
            HazSHRTexture = Content.Load<Texture2D>("HazmatShootR");
            HazSHNETexture = Content.Load<Texture2D>("HazmatShootNE");
            HazSHNWTexture = Content.Load<Texture2D>("HazmatShootNW");
            HazSHSETexture = Content.Load<Texture2D>("HazmatShootSE");
            HazSHSWTexture = Content.Load<Texture2D>("HazmatShootSW");
            BackgroudTexture = Content.Load<Texture2D>("400Danimated");
            borderTexture = Content.Load<Texture2D>("Solid_red");
            bulletTexture = Content.Load<Texture2D>("Bullet2");
            shoot = Content.Load<SoundEffect>("Realistic Gunshot Sound Effect");
            ricochet = Content.Load<SoundEffect>("Bullet ricochet sound effect 2");
            enemieTexture = Content.Load<Texture2D>("blueCreature");


            HazTexture = HazSTexture; 
            pTextures.Add(HazSTexture);//0
            pTextures.Add(HazUTexture);//1
            pTextures.Add(HazDTexture);//2
            pTextures.Add(HazLTexture);//3
            pTextures.Add(HazRTexture);//4
            pTextures.Add(HazNETexture);//5
            pTextures.Add(HazSETexture);//6
            pTextures.Add(HazSWTexture);//7
            pTextures.Add(HazNWTexture);//8
            pTextures.Add(HazSHUTexture);//9
            pTextures.Add(HazSHDTexture);//10
            pTextures.Add(HazSHLTexture);//11
            pTextures.Add(HazSHRTexture);//12
            pTextures.Add(HazSHNETexture);//13
            pTextures.Add(HazSHNWTexture);//14
            pTextures.Add(HazSHSETexture);//15
            pTextures.Add(HazSHSWTexture);//16
            pTextures.Add(bulletTexture); //17


            CollisionTextures.Add(new Rectangle(0, 0, 450, 15));
            CollisionTextures.Add(new Rectangle(320, 465, 500, 15));
            CollisionTextures.Add(new Rectangle(425, 0, 400, 200));
            CollisionTextures.Add(new Rectangle(0, 350, 320, 200));
            //objects
           
            CollisionTextures.Add(new Rectangle(0, 175, 30, 1));
            CollisionTextures.Add(new Rectangle(0, 290, 30, 1));
            CollisionTextures.Add(new Rectangle(330, 155, 1, 1));
            CollisionTextures.Add(new Rectangle(270, 220, 1, 1));
            CollisionTextures.Add(new Rectangle(480, 275, 100, 1));
            CollisionTextures.Add(new Rectangle(480, 370, 100, 1));
            CollisionTextures.Add(new Rectangle(360, 405, 70, 1));
            CollisionTextures.Add(new Rectangle(680, 275, 100, 1));
            CollisionTextures.Add(new Rectangle(680, 370, 100, 1));
            CollisionTextures.Add(new Rectangle(105, 235, 75, 1));
            CollisionTextures.Add(new Rectangle(105, 120, 75, 1));



            BackgroundRect = new Rectangle(0, 0, 800, 480);
            enemiesList.Add(new Enemies(enemieTexture, new Vector2(340, 340)));


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            keyboardState = Keyboard.GetState();
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
           
            if (seconds > 2) // Takes a timestamp every 10 seconds.
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;


            System.Diagnostics.Debug.WriteLine(seconds.ToString());

            foreach (Enemies enemy in enemiesList)
            {
                enemy.Update(new Vector2(player.Bounds.X, player.Bounds.Y), CollisionTextures);

            }

            player.Update(keyboardState, prevMouseState, mouseState, projectileList, CollisionTextures,shoot,ricochet);

            foreach (Projectile projectile in projectileList)
            {
                projectile.Kill(enemiesList);
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackgroudTexture, BackgroundRect, Color.White);
            player.Draw(_spriteBatch);
            foreach (Enemies enemies in enemiesList)
            {
                enemies.Draw(_spriteBatch);

            }
            foreach (Projectile bullet in projectileList)
            {
                bullet.Draw(_spriteBatch);
            }
            //foreach (Rectangle borders in CollisionTextures)
            //{
            //    _spriteBatch.Draw(borderTexture, borders, Color.White);
            //}
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
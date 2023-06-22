using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinalProject
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            platform1,
            platform2,
            platform3
        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Texture2D> pTextures;
        List<Rectangle> CollisionTextures;
        List<Rectangle> CollisionTextures2;
        List<Rectangle> CollisionTextures3;
        List<Texture2D> enemyTextures;
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
        Texture2D BackgroundTexture2;
        Texture2D BackgroundTexture3;
        Texture2D enemyTexture;
        Texture2D enemyLTexture;
        Texture2D enemyRunRTexture;
        Texture2D enemyRunLTexture;
        Texture2D enemyRTexture;
        Texture2D buttonUpTexture;
        Rectangle buttonRect;
        Rectangle BackgroundRect;
        Player player;
        Projectile bullet;
        Enemies enemies;
        MouseState mouseState;
        KeyboardState keyboardState;
        MouseState prevMouseState;
        Texture2D bulletTexture;
        Texture2D buttonClick;
        Texture2D buttonTexture;
        List<Projectile> projectileList;
        List<Enemies> enemiesList;
        SoundEffect shoot;
        SoundEffect ricochet;
        SoundEffect empty;
        SoundEffect button;
        Song intro;
        Song song;
        float spawnInterval;
        float startTime;
        float seconds;
        float spawnTimer;
        Screen screen;
        int screenOn;
        Random generator;
        int enemyKills  = 0;
        bool delay;
        bool looped = false;
        float delayDuration = 1.0f; 
        float delayTimer = 0.0f;

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
            enemyTextures= new List<Texture2D>();
            screen = Screen.Intro;
            screenOn = 1;
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
            player = new Player(pTextures, 50, 50);
            generator = new Random();
            buttonRect = new Rectangle(547, 250, 105, 80);
            buttonTexture = buttonUpTexture;

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
            BackgroundTexture2 = Content.Load<Texture2D>("400Canimated");
            BackgroundTexture3 = Content.Load<Texture2D>("LabFitting01");
            borderTexture = Content.Load<Texture2D>("Solid_red");
            bulletTexture = Content.Load<Texture2D>("Bullet2");
            buttonUpTexture = Content.Load<Texture2D>("redbutton");
            shoot = Content.Load<SoundEffect>("Realistic Gunshot Sound Effect");
            ricochet = Content.Load<SoundEffect>("Bullet ricochet sound effect 2");
            empty = Content.Load<SoundEffect>("emptyGun");
            button = Content.Load<SoundEffect>("Click");
            enemyRTexture = Content.Load<Texture2D>("blueCreature");
            enemyLTexture = Content.Load<Texture2D>("blueCreatureL");
            enemyRunRTexture = Content.Load<Texture2D>("blueCreaturRunR");
            enemyRunLTexture = Content.Load<Texture2D>("blueCreaturRunL");
            buttonClick = Content.Load<Texture2D>("redButtonPushed");


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
            
            enemyTextures.Add(enemyRTexture);
            enemyTextures.Add(enemyLTexture);
            enemyTextures.Add(enemyRunRTexture);
            enemyTextures.Add(enemyRunLTexture);


            CollisionTextures.Add(new Rectangle(0, 0, 675, 22));
            CollisionTextures.Add(new Rectangle(480, 697, 750, 22));
            CollisionTextures.Add(new Rectangle(637, 0, 600, 300));
            CollisionTextures.Add(new Rectangle(0, 525, 480, 300));
            //objects

            CollisionTextures.Add(new Rectangle(0, 262, 45, 1));
            CollisionTextures.Add(new Rectangle(0, 435, 45, 1));
            CollisionTextures.Add(new Rectangle(495, 232, 1, 5));
            CollisionTextures.Add(new Rectangle(405, 330, 1, 5));
            CollisionTextures.Add(new Rectangle(720, 412, 150, 1));
            CollisionTextures.Add(new Rectangle(720, 555, 150, 1));
            CollisionTextures.Add(new Rectangle(540, 607, 105, 1));
            CollisionTextures.Add(new Rectangle(1020, 412, 150, 1));
            CollisionTextures.Add(new Rectangle(1020, 555, 150, 1));
            CollisionTextures.Add(new Rectangle(157, 352, 112, 1));
            CollisionTextures.Add(new Rectangle(157, 180, 112, 1));//

            CollisionTextures.Add(new Rectangle(0, 0, 250, 100));
            CollisionTextures.Add(new Rectangle(250, 0, 275, 50));
            CollisionTextures.Add(new Rectangle(525, 0, 400, 25));
            CollisionTextures.Add(new Rectangle(865, 0, 400, 50));
            CollisionTextures.Add(new Rectangle(0, 250, 90, 250));
            CollisionTextures.Add(new Rectangle(80, 460, 80, 5));
            CollisionTextures.Add(new Rectangle(320, 460, 80, 5));
            CollisionTextures.Add(new Rectangle(400, 250, 800, 250));
            CollisionTextures.Add(new Rectangle(870, 460, 400, 250));
            CollisionTextures.Add(new Rectangle(250, 650, 400, 200));



            BackgroundRect = new Rectangle(0, 0, 1200, 720);
            
           
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            keyboardState = Keyboard.GetState();
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            


            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {

                if (buttonRect.Contains(mouseState.Position))
                {
                    delay = true;
                    delayTimer = delayDuration;
                    button.Play();
                    buttonTexture = buttonClick;
                    
                }
            }
            if (delay)
            {
                // Decrease the delay timer
                delayTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Check if the delay timer has reached zero or below
                if (delayTimer <= 0)
                {
                    // Perform the screen change
                    screen = Screen.platform1;

                    // Reset the delay
                    delay = false;
                    delayTimer = 0.0f;
                }
            }
            if (screen == Screen.platform1 || screen == Screen.platform2)
            {
                seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
                if (seconds > 5) // Takes a timestamp every 10 seconds.
                    startTime = (float)gameTime.TotalGameTime.TotalSeconds;

                //System.Diagnostics.Debug.WriteLine(seconds.ToString());

                foreach (Enemies enemy in enemiesList)
                {
                    enemy.Update(new Vector2(player.Bounds.X, player.Bounds.Y), CollisionTextures,gameTime, player);

                }

                player.Update(keyboardState, prevMouseState, mouseState, projectileList, CollisionTextures, shoot, ricochet, empty,screenOn );

                foreach (Projectile projectile in projectileList)
                {
                    projectile.Kill(enemiesList);
                    enemyKills += projectile.kills;
                }
                


                spawnInterval = (float)gameTime.TotalGameTime.TotalSeconds - spawnTimer;
                if (spawnInterval > 5) // Takes a timestamp every 10 seconds.
                    spawnTimer = (float)gameTime.TotalGameTime.TotalSeconds;

                if (spawnInterval <= 0.1 )
                {

                    Vector2 spawnLocation = Enemies.GetRandomSpawnLocation(new Rectangle(0, 0, 1200, 720), CollisionTextures, 80, 80);
                    enemiesList.Add(new Enemies(enemyTextures, spawnLocation));

                }
                if (enemyKills > 45 && enemyKills < 50)
                {
                    screen = Screen.platform2;
                    if (!looped)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            CollisionTextures.RemoveAt(0);
                            looped = true;
                        }
                    }
                    
                    screenOn = 2;

                }
                //if (enemyKills > 100)
                //{
                //    screen = Screen.platform2;
                //    if (!looped)
                //    {
                //        for (int i = 0; i < 15; i++)
                //        {
                //            CollisionTextures.RemoveAt(0);
                //            looped = true;
                //        }
                //    }

                //    screenOn = 3;
                //}
                    

                
            }
            
            






            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
               
                _spriteBatch.Draw(buttonTexture, new Rectangle(375, 135, 450, 450), Color.White);
               
                

                

            }
            if (screen == Screen.platform1)
            {
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

            }
            if (screen == Screen.platform2)
            {
                _spriteBatch.Draw(BackgroundTexture2, BackgroundRect, Color.White);
                player.Draw(_spriteBatch);
                foreach (Enemies enemies in enemiesList)
                {
                    enemies.Draw(_spriteBatch);

                }
                foreach (Projectile bullet in projectileList)
                {
                    bullet.Draw(_spriteBatch);
                }
                for (int i = 0;i < CollisionTextures.Count;i++) 
                {
                   _spriteBatch.Draw(borderTexture, CollisionTextures[i], Color.White);
                }
            }
            if (screen == Screen.platform3)
            {
                _spriteBatch.Draw(BackgroundTexture3, BackgroundRect, Color.White);
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
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
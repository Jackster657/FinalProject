using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Player
    {
        private List<Texture2D> _playerTextures;
        private Texture2D _playerSkin;
        private Rectangle _location;
        private Vector2 _speed; // _speed.X is horizontal speed, _speed.Y is vertical speed
        private int diffX = 0;
        private int diffY = 0;
        private Projectile _projectile;
        private Texture2D _bulletTexture;
        private List<Rectangle> _bulletRects;
        private bool looped = false;
        float seconds;
        float startTime;




        public Player(List<Texture2D> textures, int x, int y)
        {
            _playerTextures = textures;
            _location = new Rectangle(x, y, 60, 90);
            _speed = new Vector2();
            _bulletTexture = _playerTextures[_playerTextures.Count - 1];
        }

        public Player(List<Texture2D> textures, Rectangle rectangle)
        {
            _playerTextures = textures;
            _location = rectangle;
            _speed = new Vector2();
        }

        public Rectangle Bounds
        {
            get { return _location; }
            set { _location = value; }
        }
        public float HSpeed
        {
            get { return _speed.Y; }
            set { _speed.Y = value; }
        }
        public float VSpeed
        {

            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public int Width
        {
            get { return _location.Width; }
            set { _location.Width = value; }
        }
        public int height
        {
            get { return _location.Height; }
            set { _location.Height = value; }
        }


        public void Move(KeyboardState keyboardState, List<Rectangle> items, int screen)
        {
            _speed = new Vector2();
            if (keyboardState.IsKeyDown(Keys.D))
            {
                this._speed.X += 3;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                this._speed.X += -3;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                this._speed.Y += -3;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                this._speed.Y += 3;
            }
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
            Debug.Print(screen.ToString());
            if (screen == 1)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (_location.Intersects(items[i]))
                    {
                        UndoMove();

                    }
                    else if (_location.Top < 0 || _location.Bottom > 720 || _location.Left < 0 || _location.Right > 1200)
                    {
                        UndoMove();
                    }

                }
            }
            else if (screen== 2) 
            {
                if (!looped)
                {
                    _location = new Rectangle(200, 200, 22, 36);
                    looped = true;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (_location.Intersects(items[i]))
                    {
                        UndoMove();

                    }
                    else if (_location.Top < 0 || _location.Bottom > 720 || _location.Left < 0 || _location.Right > 1200)
                    {
                        UndoMove();
                    }

                }
            }
            else if (screen == 3)
            {
                _speed = new Vector2();
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    this._speed.X += 1.4f;
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    this._speed.X += -1.4f;
                }
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    this._speed.Y += -1.4f;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    this._speed.Y += 1.4f;
                }
                _location.X += (int)_speed.X;
                _location.Y += (int)_speed.Y;
                if (!looped)
                {
                    _location = new Rectangle(200, 200, 60, 90);
                    looped = true;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (_location.Intersects(items[i]))
                    {
                        UndoMove();

                    }
                    else if (_location.Top < 0 || _location.Bottom > 720 || _location.Left < 0 || _location.Right > 1200)
                    {
                        UndoMove();
                    }

                }
            }
            
                

            
            
        }
        public void PickTexture(MouseState mouseState, MouseState prevMouseState,int Damage)
        {
            
            if (this._speed.X == 0 && this._speed.Y == 0)
                _playerSkin = _playerTextures[0];
            else
            {
                if (this._speed.X > 0 && this._speed.Y > 0)
                    _playerSkin = _playerTextures[6];
                else if (this._speed.X > 0 && this._speed.Y < 0)
                    _playerSkin = _playerTextures[5];
                else if (this._speed.X < 0 && this._speed.Y > 0)
                    _playerSkin = _playerTextures[7];
                else if (this._speed.X < 0 && this._speed.Y < 0)
                    _playerSkin = _playerTextures[8];
                else
                {
                    if (this._speed.X > 0)
                        _playerSkin = _playerTextures[4];
                    else if (this._speed.X < 0)
                        _playerSkin = _playerTextures[3];
                    else if (this._speed.Y > 0)
                        _playerSkin = _playerTextures[2];
                    else if (this._speed.Y < 0)
                        _playerSkin = _playerTextures[1];
                }

            }

            

            if (mouseState.LeftButton == ButtonState.Pressed)
            {

                System.Diagnostics.Debug.WriteLine(seconds.ToString());
                float angle = (float)Math.Atan2(mouseState.Y - (_location.Y + _location.Height / 2), mouseState.X - (_location.X + _location.Width / 2));
                angle = MathHelper.ToDegrees(angle);
                System.Diagnostics.Debug.WriteLine(angle.ToString());

                




                if (angle >= -22.5 && angle <= 22.5)
                {
                    _playerSkin = _playerTextures[12];
                   
                    
                }
                else if (angle >= 22.5 && angle <= 67.5)
                {
                    _playerSkin = _playerTextures[15];
                    
                }
                else if (angle >= 67.5 && angle <= 112.5)
                {
                    _playerSkin = _playerTextures[10];
                   

                }
                else if (angle >= 112.5 && angle <= 157.5)
                {
                    _playerSkin = _playerTextures[16];
                    
                }
                else if (angle >= -157.5 && angle <= -112.5)
                {
                    _playerSkin = _playerTextures[14];
                    
                }
                else if (angle >= -112.5 && angle <= -67.5)
                {
                    _playerSkin = _playerTextures[9];
                    
                }
                else if (angle >= -67.5 && angle <= -22.5)
                {
                    _playerSkin = _playerTextures[13];
                    
                }
                else
                {
                    _playerSkin = _playerTextures[11];
                    
                }
                

            }
            if (Damage >= 3)
            {
                _playerSkin = _playerTextures[17];
            }
        }
    
        public void Bullet(MouseState mouseState, MouseState prevMouseState, List<Projectile> bullets,  SoundEffect shoot,SoundEffect empty)
        {
            
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                
                Vector2 playerCenter = new Vector2(_location.X + _location.Width / 2, (_location.Y + _location.Height / 2) - 20);
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
                Vector2 bulletDirection = mousePosition - playerCenter;
                bulletDirection.Normalize();
                bulletDirection.X *= 6.75f;
                bulletDirection.Y *= 6.75f;

                if (bullets.Count < 3)
                {
                    bullets.Add(new Projectile(_bulletTexture, playerCenter, bulletDirection));
                    shoot.Play();
                }
                else
                {
                    empty.Play();
                }
                
                
                
            }

        }

        public void Update(KeyboardState keyboardState, MouseState prevMouseState, MouseState mouseState, List<Projectile> bullets, List<Rectangle> items, SoundEffect shoot, SoundEffect ricochet,SoundEffect empty, int screen, int damage)
        {

            Move(keyboardState, items, screen);
            PickTexture(mouseState, prevMouseState, damage);
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                if (bullets[i].Collision(items,screen))
                {
                    bullets.RemoveAt(i);
                    ricochet.Play();
                    i--;
                }
                else if (bullets[i].Rect1.Right > 1200)
                {
                    bullets.RemoveAt(i);
                    ricochet.Play();
                    i--;
                }
                else if (bullets[i].Rect1.Right < 0)
                {
                    bullets.RemoveAt(i);
                    ricochet.Play();
                    i--;
                }
            }


            Bullet(mouseState, prevMouseState, bullets, shoot, empty);



        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerSkin, _location, Color.White);

        }
        
        public void UndoMove()
        {
            
            _location.X -= (int)_speed.X;
            _location.Y -= (int)_speed.Y;
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Player
    {
        private List<Texture2D> _playerTextures;
        private Texture2D _playerSkin;
        private Rectangle _location;
        private Vector2 _speed; // _speed.X is horizontal speed, _speed.Y is vertical speed
        private int diffX = 0;
        private int diffY = 0;
        private Projectile _projectile;
        private Texture2D _bulletTexture;



        public Player(List<Texture2D> textures, int x, int y)
        {
            _playerTextures = textures;
            _location = new Rectangle(x, y, 40, 60);
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
            get { return _speed.X; }
            set { _speed.X = value; }
        }
        

        public void Move(KeyboardState keyboardState)
        {
            _speed = new Vector2();
            if (keyboardState.IsKeyDown(Keys.D))
            {
                this._speed.X += 2;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                this._speed.X += -2;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                this._speed.Y += -2;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                this._speed.Y += 2;
            }
           
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
            
        }
        public void PickTexture(MouseState mouseState, MouseState prevMouseState)
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
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
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
        }



    
        public void Bullet(MouseState mouseState, List<Projectile> bullets)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                //Vector2 bulletPosition = new Vector2(_location.Width / 2, _location.Height / 2); // Position the bullet
                Vector2 playerCenter = new Vector2(_location.X + _location.Width / 2, _location.Y + _location.Height / 2);
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
                Vector2 bulletDirection = Vector2.Normalize(mousePosition + playerCenter);
                //Vector2 bulletVelocity = new Vector2(bulletDirection); // Adjust bullet speed as needed

                bullets.Add(new Projectile(_bulletTexture, playerCenter, bulletDirection));
                 //Add the bullet to a list or some other collection for management
                 //ProjectileList.Add(bullet);
            }
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState, List<Projectile> bullets, MouseState prevMouseState)
        {
            Move(keyboardState);
            PickTexture(mouseState, prevMouseState);
            foreach (Projectile bullet in bullets)
            {
                bullet.Update();

            }

            Bullet(mouseState, bullets);



        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerSkin, _location, Color.White);

        }
        //public bool Collide(List<Rectangle> items)
        //{
        //    //for (int i = 0; i <= items.Count; i++)
        //    //    if (_location.Intersects(items[i]))
        //    //        return true;
        //    //return false;
        //}
        public void UndoMove()
        {
            //if(collide)
            //{
            //    _location.X -= (int)_speed.X;
            //    _location.Y -= (int)_speed.Y;
            //}
            
        }
        
    }
}

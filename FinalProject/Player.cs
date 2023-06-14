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
        private Rectangle _shotBox;
        private Vector2 _speed; // _speed.X is horizontal speed, _speed.Y is vertical speed
        private int diffX = 0;
        private int diffY = 0;
        private Projectile _projectile;



        public Player(List<Texture2D> textures, int x, int y)
        {
            _playerTextures = textures;
            _location = new Rectangle(x, y, 40, 60);
            _shotBox = new Rectangle(_location.X / 2, _location.Y / 2, 1600, 960);
            _speed = new Vector2();
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
            _shotBox.X += (int)_speed.X; 
            _shotBox.Y += (int)_speed.Y;
        }
        public void PickTexture(MouseState mouseState)
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
                float angle = (float)Math.Atan2(mouseState.Y - (_location.Y + _location.Height / 2), mouseState.X - (_location.X + _location.Width / 2));
                angle = MathHelper.ToDegrees(angle);
                if(angle >= 20 && angle <= 80)
                    {
                   _playerSkin = _playerTextures[15];
                }
                if (angle >= 70 && angle <= 110)
                {
                    _playerSkin = _playerTextures[10];
                }
                if (angle >= 110 && angle<= 170)
                {
                    _playerSkin = _playerTextures[11];
                }
                if (angle >= 160 && angle <= 200)
                {
                    _playerSkin = _playerTextures[12];
                }
                //if (angle <=20 && angle >= 340)
                //{

                //}

                    else
                    {
                        _playerSkin = _playerTextures[10];
                    }
                
                //diffX = _location.X - mouseState.X;
                //diffY = _location.Y - mouseState.Y;

                //if (diffX <= 134 && diffX >= -134 && diffY <= 53 && diffY >= -53)
                //{
                //    _playerSkin= _playerTextures[0];
                //}
                //else if (mouseState.X < 266 && mouseState.Y < 160)
                //    _playerSkin = _playerTextures[14];
                //else if (mouseState.X < 266 && mouseState.Y > 320)
                //    _playerSkin = _playerTextures[16];
                //else if (mouseState.X > 533 && mouseState.Y < 160)
                //    _playerSkin = _playerTextures[13];
                //else if (mouseState.X > 533 && mouseState.Y > 320)
                //    _playerSkin = _playerTextures[15];
                //else
                //{
                //    if (mouseState.X < 266 && mouseState.Y > 160 && mouseState.Y < 320)
                //        _playerSkin = _playerTextures[11];
                //    if (mouseState.X > 533 && mouseState.Y > 160 && mouseState.Y < 320)
                //        _playerSkin = _playerTextures[12];
                //    if (mouseState.X < 533 && mouseState.X > 266 && mouseState.Y < 320)
                //        _playerSkin = _playerTextures[9];
                //    if (mouseState.X < 533 && mouseState.X > 266 && mouseState.Y > 160)
                //        _playerSkin = _playerTextures[10];
                //    if (mouseState.X < 533 && mouseState.X > 266 && mouseState.Y > 160 && mouseState.Y < 320)
                //        _playerSkin = _playerTextures[9];
                //}
            }
        }



    
        public void Bullet(KeyboardState keyboardState, Projectile _projectile)
        {
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                Vector2 bulletPosition = new Vector2(_location.Width / 2, _location.Height / 2); // Position the bullet
                Vector2 bulletVelocity = new Vector2(0, -5); // Adjust bullet speed as needed

                //_projectile = new Projectile(//add bullet texture bulletPosition, bulletVelocity);
                //// Add the bullet to a list or some other collection for management
                //// ProjectileList.Add(bullet);
            }
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            Move(keyboardState);
            PickTexture(mouseState);
            //Bullet(keyboardState);



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

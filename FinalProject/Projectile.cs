using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{       
    public class Projectile
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private Rectangle _bulletRect;
        private int _enemyKills;

            
        public Projectile(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            _texture = texture;
            _position = position;
            _velocity = velocity;
        }
        public Rectangle Rect1
        {
            get { return _bulletRect; }
            set { _bulletRect = value; }
        }
        public int Width
        {
            get { return _bulletRect.Width; }
            set { _bulletRect.Width = value; }
        }
        public int height
        {
            get { return _bulletRect.Height; }
            set { _bulletRect.Height = value; }
        }
        public void Update()
        {
            _position += _velocity;

            
            
        }
        public bool Collision(List<Rectangle> items, int screen)
        {
            if (screen == 1)
            {
                _bulletRect = (new Rectangle((int)Math.Round(_position.X), (int)Math.Round(_position.Y), 15, 15));
                for (int i = 0; i < 13; i++)
                {
                    if (_bulletRect.Intersects(items[i]))
                    {
                        return true;
                    }

                }
                
            }
            if (screen == 2)
            {
                _bulletRect = (new Rectangle((int)Math.Round(_position.X), (int)Math.Round(_position.Y), 15, 15));
                for (int i = 0; i < items.Count; i++)
                {
                    if (_bulletRect.Intersects(items[i]))
                    {
                        return true;
                    }
                    if (_bulletRect.X > 1200)
                    {
                        return true;
                    }
                    if (_bulletRect.X < 0)
                    {
                        return true;
                    }
                    if (_bulletRect.Y < 0)
                    {
                        return true;
                    }
                    if (_bulletRect.Y > 720)
                    {
                        return true;
                    }

                }

            }
            return false;

        }

        
        
        

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(_texture, new Rectangle((int)Math.Round(_position.X), (int)Math.Round(_position.Y), 22, 22), Color.White);
        }
    }

       
    


}

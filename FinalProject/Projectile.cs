using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Projectile
    {
        private Texture2D _texture;
        private Rectangle _location;
        private Vector2 _speed;
        SoundEffect _launch;

        public Projectile(Texture2D texture, Rectangle rect, Vector2 speed, SoundEffect launch)
        {
            _texture = texture;
            _location = rect;
            _speed = speed;
            _launch = launch;
        }

        public Texture2D Texture
        {
            
            get { return _texture; }
        }

        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Vector2 Speed
        {
            get { return _speed;  }
        }
        //public void Move(GraphicsDeviceManager _graphics)
        //{
        //    _location.Offset(_speed);
        //    if (_location.Left < 0 || _location.Right > _graphics.PreferredBackBufferWidth)
        //    {
                
        //    }
        //    if (_location.Top < 0 || _location.Bottom > _graphics.PreferredBackBufferHeight)
        //    {

        //    }

        //}
        public void PlayLaunch()
        {
            _launch.Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}

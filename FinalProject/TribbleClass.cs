using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame6AnimationAndClasses
{
    internal class TribbleClass
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;
        SoundEffect _coo;
        public TribbleClass(Texture2D texture, Rectangle rect, Vector2 speed, SoundEffect coo)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
            _coo = coo;
        }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }
        public void PlayCoo()
        {
            _coo.Play();
        }
        public void Move(GraphicsDeviceManager _graphics)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Left < 0 || _rectangle.Right > _graphics.PreferredBackBufferWidth)
            {
                _speed.X *= -1;
                
                PlayCoo();
            }
            if (_rectangle.Top < 0 || _rectangle.Bottom > _graphics.PreferredBackBufferHeight)
            {
                _speed.Y *= -1;

                PlayCoo();
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Enemies
    {
        private Texture2D _texture;
        private Rectangle _location;
        private Vector2 _speed; // _speed.X is horizontal speed, _speed.Y is vertical speed

        public Enemies(Texture2D texture, int x, int y)
        {
            _texture = texture;
            _location = new Rectangle(x, y, 30, 30);
            _speed = new Vector2();
        }
        public float HSpeed
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }
        private void Move()
        {
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
        }
        public void Update()
        {
            Move();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
        public bool Collide(Rectangle item)
        {
            return _location.Intersects(item);
        }
        public void UndoMove()
        {
            _location.X -= (int)_speed.X;
            _location.Y -= (int)_speed.Y;
        }
    }
}

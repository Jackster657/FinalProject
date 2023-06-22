using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Enemies
    {

       


        private Texture2D _enemyTexture;
        private Rectangle _location;
        private Vector2 _velocity;
        private List<Texture2D> _textures;
        private float seconds;
        private float startTime;
        private float _speed = 2f;

        public Enemies(List<Texture2D> textures, Vector2 position)
        {
            _textures = textures;
            _enemyTexture = textures[0];
            _location = new Rectangle((int)position.X, (int)position.Y, 80, 80);
        }

        public Rectangle Rect
        {
            get { return _location; }
            set { _location = value; }
        }

        public void Update(Vector2 playerPosition, List<Rectangle> obstacles,GameTime gametime,Player player)
        {
            Vector2 direction = Vector2.Normalize(playerPosition - _location.Center.ToVector2());

            _velocity = direction * _speed;

            seconds = (float)gametime.TotalGameTime.TotalSeconds - startTime;
            if (seconds > 2) // Takes a timestamp every 10 seconds.
                startTime = (float)gametime.TotalGameTime.TotalSeconds;
            if (_velocity.X > 0)
            {
                    if(seconds> 1)
                    {
                        _enemyTexture = _textures[0];
                    }
                    else if ( seconds > 1 )
                    {
                        _enemyTexture = _textures[2];
                    }
                
            }
            else if (_velocity.X < 0)
            {
                    if (seconds >= 1)
                    {
                        _enemyTexture = _textures[1];
                    }
                    else if ( seconds > 1)
                    {
                        _enemyTexture = _textures[3];
                    }
                }
            else
            {
                _enemyTexture = _textures[0];
            }
            _location.X += (int)_velocity.X;
            _location.Y += (int)_velocity.Y;

            foreach (Rectangle obstacle in obstacles)
            {
                if (_location.Intersects(obstacle))
                {
                    Vector2 obstacleCenter = obstacle.Center.ToVector2();
                    Vector2 avoidanceDirection = Vector2.Normalize(_location.Center.ToVector2() - obstacleCenter);
                    _velocity.X *= 0.5f;
                    _velocity.Y *= 0.5f;
                    _velocity += avoidanceDirection * _speed;

                    _location.X += (int)_velocity.X;
                    _location.Y += (int)_velocity.Y;
                } 
            }
            if (_location.Intersects(player.Bounds))
            {
                //add
            }



            
        }

        public static Vector2 GetRandomSpawnLocation(Rectangle playArea, List<Rectangle> obstacles, int enemyWidth, int enemyHeight)
        {
            Random random = new Random();
            Vector2 spawnLocation = Vector2.Zero;

            bool validSpawn = false;
            while (!validSpawn)
            {
                spawnLocation.X = random.Next(playArea.Left, playArea.Right - enemyWidth);
                spawnLocation.Y = random.Next(playArea.Top, playArea.Bottom - enemyHeight);

                Rectangle spawnRect = new Rectangle((int)spawnLocation.X, (int)spawnLocation.Y, enemyWidth, enemyHeight);

                bool collision = false;
                foreach (Rectangle obstacle in obstacles)
                {
                    if (spawnRect.Intersects(obstacle))
                    {
                        collision = true;
                        break;
                    }
                }

                if (!collision)
                    validSpawn = true;
            }

            return spawnLocation;
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_enemyTexture, _location, Color.White);
        }
    }
}


    






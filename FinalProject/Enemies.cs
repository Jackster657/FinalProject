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
        


    
        private Texture2D _enemyTexture;
        private Rectangle _location;
        private Vector2 _velocity;
        private float _speed = 2f;

        public Enemies(Texture2D texture, Vector2 position)
        {
            _enemyTexture = texture;
            _location = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update(Vector2 playerPosition, List<Rectangle> obstacles)
        {
            Vector2 direction = Vector2.Normalize(playerPosition - _location.Center.ToVector2());

            // Update the enemy's velocity based on the direction and speed
            _velocity = direction * _speed;

            _location.X += (int)_velocity.X;
            _location.Y += (int)_velocity.Y;

            foreach (Rectangle obstacle in obstacles)
            {
                if (_location.Intersects(obstacle))
                {
                    Vector2 obstacleCenter = obstacle.Center.ToVector2();
                    Vector2 avoidanceDirection = Vector2.Normalize(_location.Center.ToVector2() - obstacleCenter);

                    // Adjust the enemy's velocity to avoid the obstacle
                    _velocity += avoidanceDirection * _speed;

                    // Move the enemy based on the updated velocity
                    _location.X += (int)_velocity.X;
                    _location.Y += (int)_velocity.Y;
                } 
            }
        } 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_enemyTexture, _location, Color.White); 
        }
    }



}

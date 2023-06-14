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
    
        


    
        
        internal class Projectile
        {
            private Texture2D _texture;
            private Vector2 _position;
            private Vector2 _velocity;

            
            Projectile(Texture2D texture, Vector2 position, Vector2 velocity)
            {
                _texture = texture;
                _position = position;
                _velocity = velocity;
            }

            public void Update(GameTime gameTime)
            {
                
                _position += _velocity;
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(_texture, _position, Color.White);
            }
        }

       
    


}

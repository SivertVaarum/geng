using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Dynamic;

namespace geng
{   
    /// <summary>
    /// Particle obeying gravity.
    /// </summary>
    public class DropParticle : IParticle, IEntity
    {
        private int _xVelocity, _yVelocity = 4;
        public int XVelocity
        {
            get => Math.Sign(_xVelocity);
        }
        public int YVelocity
        {
            get => Math.Sign(_yVelocity);
        }

        public Texture2D Texture
        {
            get => _texture;
        }

        private int _maxVelocity = 8;
        private int _x = 0, _y = 0;
        private int _width, _height;
        private int _framesAlive;
        private Texture2D _texture;
        private Rectangle _rectangle;
        public Rectangle Rectangle
        {
            get => _rectangle;
        }

        public int X
        {
            get => _x;
        }

        public int Y
        {
            get => _y;
        }

        public DropParticle(Texture2D texture, int x, int y, int height, int width)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _texture = texture;
            _rectangle = new Rectangle(_x, _y, _width, _height);
            _framesAlive = 0;
        }
        
        public void IncrementXVelocity(double xIncrement)
        {
            if(_xVelocity <= _maxVelocity)
            {
                _xVelocity += (int)xIncrement;
            }
        }

        public void IncrementYVelocity(double yIncrement)
        {
            if(_yVelocity <= _maxVelocity)
            {
                _yVelocity += (int)yIncrement;
            }
        }
        
        public void Update()
        {
            _framesAlive++;
            
        
            UpdatePosition();
            _rectangle = new Rectangle(_x, _y, _width, _height);
        }
        
        public void Move(double x, double y)
        {
            _x = (int)x;
            _y = (int)y;
        }

        private void UpdatePosition()
        {
            _x += _xVelocity;
            _y += _yVelocity;
        }

        /// <summary>
        /// Resolves collision using given offsets.
        /// </summary>
        /// <param name="offSetX"></param>
        /// <param name="offSetY"></param>
        public void ResolveCollision(int offSetX, int offSetY)
        {
            if (offSetX != 0)
            {
                _xVelocity = 0;
                _x += offSetX;
            }
            if (offSetY != 0)
            {
                _yVelocity = 0;
                _y += offSetY;
            }
        }
    }

}



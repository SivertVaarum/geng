using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace geng
{
    public class DropParticle : IParticle, IEntity
    {
        private int _xVelocity, _yVelocity;
        public int XVelocity
        {
            get => Math.Sign(_xVelocity);
        }
        public int YVelocity
        {
            get => Math.Sign(_yVelocity);
        }
        
        private int _maxVelocityIncrement = 2;
        private int _maxVelocity = 8;
        private int _x, _y;
        private int _width, _height;
        private int _framesAlive;
        private Texture2D _texture;
        private Rectangle _rectangle;

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
            if(_xVelocity <= _maxVelocity && xIncrement <= _maxVelocityIncrement)
            {
                _xVelocity += (int)xIncrement;
            }
        }

        public void IncrementYVelocity(double yIncrement)
        {
            if(_yVelocity <= _maxVelocity && yIncrement <= _maxVelocityIncrement)
            {
                _yVelocity += (int)yIncrement;
            }
        }
        
        public void Update()
        {
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
            ApplyDrag();
        }

        public void ResolveCollision(int offSetX, int offSetY)
        {
            if (offSetX != 0)
            {
                _xVelocity = 0;
                _x += offSetX;
            }
            else if (offSetY != 0)
            {
                _yVelocity = 0;
                _y += offSetY;
            }
        }
        /// <summary>
        /// Drag in the context of this particle is just -x^2 + 10
        /// 
        /// </summary>
        private void ApplyDrag()
        {
            _x = -(int)Math.Pow(_framesAlive, 2);
        }

        public Rectangle GetRectangle()
        {
            return _rectangle;
        }
    }

}



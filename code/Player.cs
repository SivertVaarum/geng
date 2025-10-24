
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace geng
{
    public class Player : IEntity
    {
        private const int _maxVelocityIncrement = 4;
        private float _x, _y;
        /// <summary>
        /// Position on x axis
        /// </summary>
        public float X
        {
            get => _x;
            set => _y = value;
        }
        /// <summary>
        /// Position on y axis
        /// </summary>
        public float Y
        {
            get => _y;
            set => _y = value;
        }

        private int _height, _width;
        public int Height
        {
            get => _height;
        }
        public int Width
        {
            get => _width;
        }
        private float _xVelocity, _yVelocity;
        public float XVelocity
        {
            get => _xVelocity;
            set => _xVelocity = value;
        }
        public float YVelocity
        {
            get => _yVelocity;
            set => _yVelocity = value;
        }
        private float _drag = 0.5f;
        
        private Color _color = Color.White;
        private Rectangle _rectangle;
        private Texture2D _texture;
        private PlayerController _playerController;
        
        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Player(Texture2D texture, int x, int y, int width, int height)
        {
            _playerController = new PlayerController(this);
            _texture = texture;
            _x = x;
            _y = y;
            _height = height;
            _width = width;
            _rectangle = new Rectangle((int)_x, (int)_y, _width, _height);
        }
        
        /// <summary>
        /// Increments player x and y field by supplied arguments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(double x, double y)
        {
             
        }

        public void ResolveCollision(int offSetX, int offSetY)
        {
            if (offSetX != 0)//If entity is given an offset it must have hit a wall and velocity should be set to zero
            {
                _xVelocity = 0;
            }
            if (offSetY != 0)
            {
                _yVelocity = 0;
            }
            _x += offSetX;
            _y += offSetY;
        }

        public void Update()
        {
            UpdatePosition();
            _playerController.CheckInput();
            _rectangle = new Rectangle((int)_x, (int)_y, _width, _height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, _color);
        }
        
        public Rectangle GetRectangle()
        {
            return _rectangle;
        }

        public void IncrementXVelocity(double xIncrement)
        {
            if (xIncrement <= _maxVelocityIncrement)
            {
                _xVelocity += (int)xIncrement;
            }
        }

        public void IncrementYVelocity(double yIncrement)
        {
            if (yIncrement <= _maxVelocityIncrement)
            {
                _yVelocity += (int)yIncrement;
            }
        }

        private void UpdatePosition()
        {
            _x += _xVelocity;
            _y += _yVelocity;
            ApplyDrag();
        }

        private void ApplyDrag()
        {
            
            _xVelocity -= _drag * Math.Sign(_xVelocity);
            _yVelocity -= _drag * Math.Sign(_yVelocity);
            
        }
    }
}
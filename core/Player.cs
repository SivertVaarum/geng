using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;


namespace geng
{
    public class Player : IEntity
    {
        private const int _maxVelocityIncrement = 2;
        private int _maxVelocity = 4;

        private float _x, _y;
        public int X
        {
            get => (int)_x;
        }
        public int Y
        {
            get => (int)_y;
        }

        private int _height, _width;
        private float _xVelocity, _yVelocity;
        /// <summary>
        /// Returns sign of current velocity on x axis.
        /// </summary>
        public int XVelocity
        {
            get => Math.Sign(_xVelocity);
            set => _xVelocity = value;
        }
        /// <summary>
        /// Retuns sign of current velocity on y axis.
        /// </summary>
        public int YVelocity
        {
            get => Math.Sign(_yVelocity);
            set => _yVelocity = value;
        }
        private float _drag = 0.5f;
        private Rectangle _rectangle;
        public Rectangle Rectangle
        {
            get => _rectangle;
        }
        private Texture2D _texture;
        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }
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
        /// Overwrites player x and y field with supplied arguments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Teleport(double x, double y)
        {
            _x = (int)x;
            _y = (int)y;
        }

        /// <summary>
        /// Offset vars should be supplied to let object know how far it has intersects on each axis.
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
            else if(offSetY != 0)
            {
                _yVelocity = 0;
                _y += offSetY;
            }
        }

        public void Update()
        {
            UpdatePosition();
            _playerController.CheckInput();
            _rectangle = new Rectangle((int)_x, (int)_y, _width, _height);
        }

        /// <summary>
        /// Adds sprite to supplied SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }

        /// <summary>
        /// Increment xVelocity be supplied argument.
        /// </summary>
        /// <param name="xIncrement"></param>
        public void IncrementXVelocity(double xIncrement)
        {
            if(Math.Abs(_xVelocity) >= _maxVelocity)
            {
                return;
            }
            if (xIncrement <= _maxVelocityIncrement)
            {
                _xVelocity += (int)xIncrement;
            }
        }
        /// <summary>
        /// Incremnet yVelocity by supplied argument.
        /// </summary>
        /// <param name="yIncrement"></param>
        public void IncrementYVelocity(double yIncrement)
        {
            if(Math.Abs(_yVelocity) >= _maxVelocity)
            {
                return;
            }
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
            if(_xVelocity != 0)_xVelocity -= _drag * Math.Sign(_xVelocity);
            if(_yVelocity != 0)_yVelocity -= _drag * Math.Sign(_yVelocity);
        }
    }
}

using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace geng
{
    public class Player : IEntity
    {   
        private double _x, _y;
        private int _height, _width;
        private Color _color = Color.White;
        private Rectangle _rectangle;
        private Texture2D _texture;
        private Controller _playerController;
        private int xVelocity;
        private int yVelocity;
        
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
            _playerController = new Controller(this);
            _texture = texture;
            _x = x;
            _y = y;
            _height = height;
            _width = width;
            _rectangle = new Rectangle((int)_x, (int)_y, _width, _height);
        }
        /// <summary>
        /// Returns position on x axis
        /// </summary>
        public int getX
        {
            get => (int)_x;
        }
        /// <summary>
        /// Returns position on y axis
        /// </summary>
        public int getY
        {
            get => (int)_y;
        }
        public int getXVelocity
        {
            get => xVelocity;
        }
        public int getYVelocity
        {
            get => yVelocity;
        }
        /// <summary>
        /// Returns player height double
        /// </summary>
        /// <returns>_height</returns>
        public double GetHeight()
        {
            return _height;
        }

        public int GetHeightInt()
        {
            return _height;
        }
        /// <summary>
        /// Returns player width double
        /// </summary>
        /// <returns>_width</returns>
        public double GetWidth()
        {
            return _width;
        }

        public int GetWidthInt()
        {
            return _width;
        }
        /// <summary>
        /// Increments player x and y field by supplied arguments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(double x, double y)
        {
            xVelocity = Math.Sign((int)x);
            yVelocity = Math.Sign((int)y);
            _x += (int)x;
            _y += (int)y;  
        }

        public void ResolveCollision(int offSetX, int offSetY)
        {
            //TODO resolve collision
            
            _x += offSetX;
            _y += offSetY;
        }

        public void Update()
        {
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
        
    }
}
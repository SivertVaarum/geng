
using System.Numerics;

using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;

namespace geng
{
    public class Player : IEntity
    {
        private Texture2D _texture;
        private double _x;
        private double _y;
        private Rectangle _rectangle;
        private int _height = 32;
        private int _width = 32;
        private PlayerController _playerController;
        private Color _color = Color.White;
        
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
        
        public int getX
        {
            get => (int)_x;
        }
        
        public int getY
        {
            get => (int)_y;
        }
       

        public double GetHeight()
        {
            return _height;
        }

        public int GetHeightInt()
        {
            return _height;
        }

        public double GetWidth()
        {
            return _width;
        }

        public int GetWidthInt()
        {
            return _width;
        }

        public void Move(double x, double y)
        {
            _x += (int)x;
            _y += (int)y;
        }

        public void ResolveCollision(int offSetX, int offSetY)
        {
            //TODO resolve collision
            SetColor();
        }

        public void Update()
        {
            _playerController.CheckInput();
            _rectangle = new Rectangle((int)_x, (int)_y, 64, 64);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_texture, _rectangle, _color);
        }
        private void SetColor()
        {
            _color = Color.BlueViolet;
        }
    }
}
using System.Numerics;

namespace geng
{
    public class Player : IEntity
    {

        private Vector2 _position = new Vector2();
        private int _height = 32;
        private int _width = 32;
        public double GetHeight()
        {
            return _height;
        }

        public int GetHeightInt()
        {
            return _height;
        }

        public Vector2 GetPosition()
        {
            return _position;
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
            _position.X += (float)x;
            _position.Y += (float)y;
        }

        public void ResolveCollision(int offSetX, int offSetY)
        {
            _position.X += offSetX;
            _position.Y += offSetY;
        }
    }
}
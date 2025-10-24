namespace geng
{
    public interface IMoveable
    {
        /// <summary>
        /// Move moveable by x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Move(double x, double y);
        void IncrementXVelocity(double xIncrement);
        void IncrementYVelocity(double yIncrement);
    }
}
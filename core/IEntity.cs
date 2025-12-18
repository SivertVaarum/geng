
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng
{
    /// <summary>
    /// Interface for moveable, collidable entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// X and Y offsets to be used to move entity when it has collided with a tile in the map
        /// </summary>
        /// <param name="offSetX"></param>
        /// <param name="offSetY"></param>
        void ResolveCollision(int offSetX, int offSetY);
        
        /// <summary>
        /// Either 1 or -1, responds to if moving left or right
        /// </summary>
        int XVelocity { get; }
        /// <summary>
        /// Either 1 or -1, responds to if moving down or up
        /// </summary>
        int YVelocity { get; }

        /// <summary>
        /// Move moveable by x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Move(double x, double y);
        void IncrementXVelocity(double xIncrement);
        void IncrementYVelocity(double yIncrement);
        Texture2D Texture { get; }
        int X { get; }
        int Y { get; }

        void Update();

        Rectangle Rectangle { get; }

    }
}
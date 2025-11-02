
using Microsoft.Xna.Framework;

namespace geng
{
    /// <summary>
    /// Interface for game moveable, collidable enteties.
    /// </summary>
    public interface IEntity : IMoveable
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

        int X { get; }
        int Y { get; }

        void Update();

        Rectangle Rectangle { get; }

    }
}
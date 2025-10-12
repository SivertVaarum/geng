using System.Drawing;
using Microsoft.Xna.Framework;

namespace geng
{
    //Interface for moveables, collidables
    public interface IEntity : IMoveable
    {   
        
        /// <summary>
        /// X and Y offsets to be used to move entity when it has collided with a tile in the map
        /// </summary>
        /// <param name="offSetX"></param>
        /// <param name="offSetY"></param>
        void ResolveCollision(int offSetX, int offSetY);
        /// <summary>
        /// Returns width
        /// </summary>
        /// <returns></returns>
        int GetWidthInt();
        /// <summary>
        /// Retusn height
        /// </summary>
        /// <returns></returns>
        int GetHeightInt();
        int X { get; }
        int Y { get; }
        /// <summary>
        /// Either 1 or -1, responds to if moving left or right
        /// </summary>
        int XVelocity { get; }
        /// <summary>
        /// Either 1 or -1, responds to if moving down or up
        /// </summary>
        int YVelocity { get; }
        Microsoft.Xna.Framework.Rectangle GetRectangle();
    }
}
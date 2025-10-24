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
        int Width { get; }
        int Height { get; }
        float X { get; set; }
        float Y { get; set; }
        /// <summary>
        /// Either 1 or -1, responds to if moving left or right
        /// </summary>
        float XVelocity { get; }
        /// <summary>
        /// Either 1 or -1, responds to if moving down or up
        /// </summary>
        float YVelocity { get; }
        Microsoft.Xna.Framework.Rectangle GetRectangle();
    }
}
using System.Drawing;
using Microsoft.Xna.Framework;




namespace geng
{
    //Interface for moveables, collidables
    public interface IEntity
    {   
        /// <summary>
        /// Move entity by x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Move(double x, double y);
        /// <summary>
        /// Used to resolve collision
        /// </summary>
        /// <param name="offSetX"></param>
        /// <param name="offSetY"></param>
        void ResolveCollision(int offSetX, int offSetY, Microsoft.Xna.Framework.Color? color);
        int GetWidthInt();
        int GetHeightInt();
        int getX { get; }
        int getY { get; }
        Microsoft.Xna.Framework.Rectangle GetRectangle();
    }
}
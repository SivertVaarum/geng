using System.Numerics;
using Microsoft.Xna.Framework.Input;




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
        void ResolveCollision(int offSetX, int offSetY);
        double GetWidth();
        double GetHeight();
        int GetWidthInt();
        int GetHeightInt();
        Vector2 GetPosition();
    }
}
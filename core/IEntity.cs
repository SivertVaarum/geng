using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace geng;
/// <summary>
/// Interface for moveable, collidable entities.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Resolve collison using x and y offset values.
    /// </summary>
    /// <param name="offSetX"></param>
    /// <param name="offSetY"></param>
    void ResolveCollision(int offSetX, int offSetY, int damage);
    /// <summary>
    /// Teleport to x, y.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void Teleport(double x, double y);
    void IncrementXVelocity(double xIncrement);
    void IncrementYVelocity(double yIncrement);
    void Draw(SpriteBatch spriteBatch, Texture2D texture);
    void Update();
    /// <summary>
    /// Velocity on x axis. Can be negative/positive.
    /// </summary>
    int XVelocity { get; }
    /// <summary>
    /// Velocity on y axis. Can be negative/positive.
    /// </summary>
    int YVelocity { get; }
    Rectangle SourceRectangle { get; }
    Rectangle Rectangle { get; }
    int X { get; }
    int Y { get; }
}

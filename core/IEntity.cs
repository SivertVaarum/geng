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
    /// <summary>
    /// Increment x-velocity by supplied amount.
    /// </summary>
    /// <param name="xIncrement"></param>
    void IncrementXVelocity(double xIncrement);
    /// <summary>
    /// Increment y-velocity by supplied amount.
    /// </summary>
    /// <param name="yIncrement"></param>
    void IncrementYVelocity(double yIncrement);
    /// <summary>
    /// Draw entity to supplied spritebatch.
    /// </summary>
    /// <param name="spriteBatch"></param>
    /// <param name="texture"></param>
    void Draw(SpriteBatch spriteBatch, Texture2D texture);
    /// <summary>
    /// Update Entity state, should be called every tick.
    /// </summary>
    void Update();
    /// <summary>
    /// Velocity on x axis. Can be negative/positive.
    /// </summary>
    int XVelocity { get; }
    /// <summary>
    /// Velocity on y axis. Can be negative/positive.
    /// </summary>
    int YVelocity { get; }
    /// <summary>
    /// Rectangle corresponding to the sprite in the spritesheet.
    /// </summary>
    Rectangle SourceRectangle { get; }
    /// <summary>
    /// Destination rectangle.
    /// </summary>
    Rectangle Rectangle { get; }
    /// <summary>
    /// Position on x axis.
    /// </summary>
    int X { get; }
    /// <summary>
    /// Position on y axis.
    /// </summary>
    int Y { get; }
}

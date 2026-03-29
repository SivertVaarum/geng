using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng;

/// <summary>
/// Generic one pixel particle
/// </summary>
public class Particle : IParticle
{
    /// <summary>
    /// Create particle with direction.
    /// </summary>
    /// <param name="originX"></param>
    /// <param name="originY"></param>
    /// <param name="direction"></param>
    public Particle(int originX, int originY, Vector2 direction, Color color) {
        _x = originX;
        _y = originY; 
        _xVelocity = (int)direction.X;
        _yVelocity = (int)direction.Y;
        _rectangle = new Rectangle(_x, _y, 1, 1);
        _texture = GraphicsHelper.CreateSolid(color);
    }
    /// <summary>
    /// Create particle without direction.
    /// </summary>
    /// <param name="originX"></param>
    /// <param name="originY"></param>
    public Particle(int originX, int originY, Color color) {
        _x = originX;
        _y = originY; 
        _rectangle = new Rectangle(_x, _y, 1, 1);
        _texture = GraphicsHelper.CreateSolid(color);
    }

    public Texture2D Texture {
        get => _texture;
    }
    public int XVelocity {
        get => _xVelocity;
    }
    public int YVelocity {
        get => _yVelocity;
    }
    public int X {
        get => _y;
    }
    public int Y {
        get => _y;
    }

    public Rectangle Rectangle {
        get => _rectangle;
    }

    public void ResolveCollision(int offSetX, int offSetY) {
        throw new System.NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _rectangle, Color.White);
    }

    public void Teleport(double x, double y) {
        _x = (int)x;
        _y = (int)y;
    }

    public void IncrementXVelocity(double xIncrement) {
        _xVelocity += (int)xIncrement;
    }

    public void IncrementYVelocity(double yIncrement) {
        _yVelocity += (int)yIncrement;
    }

    public void Update() {
        _x += _xVelocity;
        _y += _yVelocity;
    }
    private  int _xVelocity, _yVelocity; 
    private int _x, _y;
    private Texture2D _texture;
    private Rectangle _rectangle;
}
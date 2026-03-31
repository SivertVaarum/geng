using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace geng;

/// <summary>
/// Generic one pixel particle
/// </summary>
public class Particle : IParticle
{
    /// <summary>
    /// Create particle with direction using vector.
    /// </summary>
    /// <param name="originX"></param>
    /// <param name="originY"></param>
    /// <param name="direction"></param>
    public Particle(int originX, int originY, Vector2 direction, Rectangle sourceRectangle) {
        _x = originX;
        _y = originY; 
        _xVelocity = (int)direction.X;
        _yVelocity = (int)direction.Y;
        _sourceRectangle = sourceRectangle;
    }
    /// <summary>
    /// Create particle without direction.
    /// </summary>
    /// <param name="originX"></param>
    /// <param name="originY"></param>
    public Particle(int originX, int originY, Rectangle sourceRectangle) {
        _x = originX;
        _y = originY; 
        _sourceRectangle = sourceRectangle;
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
    public Rectangle SourceRectangle
    {
        get => _sourceRectangle;
    }
    public void ResolveCollision(int offSetX, int offSetY, int damage) {
        //¯\_(ツ)_/¯
    }
    public void Draw(SpriteBatch spriteBatch, Texture2D spritesheet) {
        spriteBatch.Draw(spritesheet, _rectangle, _sourceRectangle, Color.White);
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
        _rectangle = new Rectangle(_x, _y, _sourceRectangle.Width*GraphicsHelper.GetPixelRatio(), 
                                _sourceRectangle.Height*GraphicsHelper.GetPixelRatio());
        _timeToLive --;
    }

    public bool isAlive() {
        return _timeToLive > 0;
    }
    private  int _xVelocity, _yVelocity; 
    private int _x, _y;
    private Rectangle _sourceRectangle;
    private Rectangle _rectangle = new Rectangle(0,0,0,0 );
    private int _timeToLive = 256;
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace geng;

public class BouncyBall : IParticle
{
    public int XVelocity => (int)_xVelocity;
    public int YVelocity => (int)_yVelocity;
    public Rectangle SourceRectangle => _sourceRectangle;
    public Rectangle Rectangle => _rectangle;
    public int X => _x;
    public int Y => _y;

    public BouncyBall(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {
        spriteBatch.Draw(texture, _rectangle, _sourceRectangle, Color.White);
    }

    public void IncrementXVelocity(double xIncrement)
    {
        throw new System.NotImplementedException();
    }

    public void IncrementYVelocity(double yIncrement)
    {
        throw new System.NotImplementedException();
    }

    public bool isAlive()
    {
        return true;
    }

    public void ResolveCollision(int offSetX, int offSetY, int damage)
    {
        if (offSetX != 0)
        {
            _xVelocity = 0;
            _x += offSetX;
        }
        else if(offSetY != 0)
        {
            _yVelocity =  -_yVelocity;
            _y += offSetY;
        }
    }

    public void Teleport(double x, double y)
    {
        _x = (int)x;
        _y = (int)y;
    }

    public void Update()
    {
        _x += (int)_xVelocity;
        _y += (int)_yVelocity;
        applyDrag();
        _rectangle = new Rectangle(_x, _y, _sourceRectangle.Width * GraphicsHelper.GetPixelRatio(),
                                    _sourceRectangle.Height * GraphicsHelper.GetPixelRatio());
    } 
    private void applyDrag()
    {
        //if(_xVelocity < 0) _xVelocity--;
    }
    private double _xVelocity;
    private double _yVelocity = 4;
    private int _x, _y;
    private Rectangle _sourceRectangle = new Rectangle(12, 4, 4, 4);//this should really be defined in constructor
    private Rectangle _rectangle;
}
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace geng;

public class Player : IEntity
{
    /// <summary>
    /// Player constructor
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Player(Rectangle sourceRectangle, int x, int y, int width, int height)
    {
        _playerController = new PlayerController(this);
        _sourceRectangle = sourceRectangle;
        _x = x;
        _y = y;
        _height = height;
        _width = width;
        _rectangle = new Rectangle((int)_x, (int)_y, 
            _sourceRectangle.Width * GraphicsHelper.GetPixelRatio(),
            _sourceRectangle.Height * GraphicsHelper.GetPixelRatio());
    }
    public int X
    {
        get => (int)_x;
    }
    public int Y
    {
        get => (int)_y;
    }

    public int XVelocity
    {
        get => (int)_xVelocity;
        set => _xVelocity = value;
    }

    public int YVelocity
    {
        get => (int)_yVelocity;
        set => _yVelocity = value;
    }
    public Rectangle SourceRectangle
    {
        get => _sourceRectangle;
    }
    public Rectangle Rectangle
    {
        get => _rectangle;
    }    

    public void Teleport(double x, double y)
    {
        _x = (int)x;
        _y = (int)y;
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
            _yVelocity = 0;
            _y += offSetY;
        }
    }

    public void Update()
    {
        UpdatePosition();
        _playerController.CheckInput();
        _rectangle = new Rectangle((int)_x, (int)_y, _width, _height);
        if (_xVelocity > 0)
        {
            _currentState = State.right;
            return;
        }
        _currentState = State.left;
    }
     
    int dy = 0;
    public void Draw(SpriteBatch spriteBatch, Texture2D spritesheet) {
        if(_currentState == State.left) dy = 8;
        if(_currentState == State.right) dy = 14;
        
        _sourceRectangle = new Rectangle(0, dy, 5, 6);
        spriteBatch.Draw(spritesheet, _rectangle, _sourceRectangle, Color.White);
    }
    
    public void IncrementXVelocity(double xIncrement) {
        if(Math.Abs(_xVelocity) >= _maxVelocity)
        {
            return;
        }
        if (xIncrement <= _maxVelocityIncrement)
        {
            _xVelocity += (int)xIncrement;
        }
    }
    
    public void IncrementYVelocity(double yIncrement) {
        if(Math.Abs(_yVelocity) >= _maxVelocity)
        {
            return;
        }
        if (yIncrement <= _maxVelocityIncrement)
        {
            _yVelocity += (int)yIncrement;
        }
    }

    private void UpdatePosition() {
        _x += _xVelocity;
        _y += _yVelocity;
        ApplyDrag();
    }

    private void ApplyDrag() {   
        if(_xVelocity != 0)_xVelocity -= _drag * Math.Sign(_xVelocity);
        if(_yVelocity != 0)_yVelocity -= _drag * Math.Sign(_yVelocity);
    }
    private const int _maxVelocityIncrement = 2;
    private int _maxVelocity = 4;
    private float _x, _y;
    private int _height, _width;
    private float _xVelocity, _yVelocity;
    private float _drag = 0.5f;
    private Rectangle _rectangle;
    private Rectangle _sourceRectangle;
    private PlayerController _playerController;
    private enum State
    {
        left, right
    }
    private State _currentState = State.right;
}

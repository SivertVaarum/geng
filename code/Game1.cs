using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace geng;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameLoop _gameLoop = new GameLoop();
    private Texture2D _gengSpritesheet;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gengSpritesheet = Content.Load<Texture2D>("gengStandard");
    }
    protected override void Update(GameTime gameTime)
    {
    
        
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {   
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _gameLoop.Loop( _spriteBatch, _gengSpritesheet); //The drawing of sprites to the spritebatch
                                                         //should be handled inside of the sprites class
                                                         //So this method wont be filled with clutter(for loops)
                                                         //and rectangles from god-knows-where.
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

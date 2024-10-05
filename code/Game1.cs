using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace geng;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private gameLoop _gameLoop = new gameLoop();
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
        //Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        _spriteBatch.Begin();
        _gameLoop.Loop( _spriteBatch, _gengSpritesheet); 
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private gameLoop _gameLoop = new gameLoop();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        Texture2D _gengStandard = new Texture2D()
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
            _gameLoop.Loop();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {   
    
        GraphicsDevice.Clear(Color.CornflowerBlue);
        foreach(var Particle in _gameLoop.explosion._particles )
        {
            _spriteBatch.Draw();
        }
        base.Draw(gameTime);
    }
}

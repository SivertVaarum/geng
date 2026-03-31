using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace geng;

internal class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameLoop _gameLoop;
    private Texture2D _gengSpritesheet;
    private RenderTarget2D _renderTarget;
    private int _nativeWidth = 918;
    private int _nativeHeigth = 515;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = _nativeHeigth;
        _graphics.PreferredBackBufferWidth = _nativeWidth;
        _graphics.ApplyChanges();
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        GraphicsHelper.Initialize(GraphicsDevice);
        GraphicsHelper.SetTileDimension(128);
        GraphicsHelper.SetPixelRatio(32);
        TextureRegister.Spritesheet = _gengSpritesheet;
        _renderTarget = new RenderTarget2D(GraphicsDevice, _nativeWidth, _nativeHeigth);
        _gameLoop = new GameLoop(GraphicsDevice);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gengSpritesheet = Content.Load<Texture2D>("gengStandard");
    }
    protected override void Update(GameTime gameTime)
    {
        _gameLoop.Update();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        Rectangle window = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        //Sets RenderTarget to custom RenderTarget
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _gameLoop.Draw(_spriteBatch); 
        _spriteBatch.End();

        //Sets renderTarger back to backbuffer
        GraphicsDevice.SetRenderTarget(null);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_renderTarget, window, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

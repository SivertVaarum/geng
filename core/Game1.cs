using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng;

public class Game1 : Game
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
        _renderTarget = new RenderTarget2D(GraphicsDevice, _nativeWidth, _nativeHeigth);
        _gameLoop = new GameLoop(GraphicsDevice, _gengSpritesheet);

        Texture2D result = new Texture2D(GraphicsDevice, 1, 1);
        Color[] data = new Color[1 * 1];

        _gengSpritesheet.GetData(0, new Rectangle(2, 0, 1, 1), data, 0, data.Length);
        result.SetData(data);
        ParticleMediator.GetInstance().SetTextures(result);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gengSpritesheet = Content.Load<Texture2D>("gengStandard");
    }
    protected override void Update(GameTime gameTime)
    {
        _gameLoop.Loop();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {

        Rectangle window = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        //Sets RenderTarget to custom RenderTarget
        GraphicsDevice.SetRenderTarget(_renderTarget);
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

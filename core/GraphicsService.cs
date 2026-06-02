using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng;
/// <summary>
/// Helper class for drawing and graphics.
/// </summary>
public class GraphicsService : IService
{
    /// <summary>
    /// Give helper class access to current instance of graphicsdevice.
    /// </summary>
    /// <param name="device"></param>
    public void Initialize(GraphicsDevice device)
    {
        _graphicsDevice = device;
    }
    /// <summary>
    /// Sets width of tiles in onscreen pixels.
    /// Arg must be be at least 1. 
    /// </summary>
    /// <param name="newWidth"></param>
    public void SetTileDimension(int newDimension){
        if(newDimension <= 0) return;
        _tileDimension = newDimension;
    }
    /// <summary>
    /// Get onscreen width/height of tile.
    /// </summary>
    /// <returns></returns>
    public int GetTileDimension()
    {
        return _tileDimension;
    }
    /// <summary>
    /// Get texture to onscreen pixel ratio.
    /// </summary>
    /// <returns></returns>
    public int GetPixelRatio()
    {
        return _pixelRatio;
    }
    /// <summary>
    /// Set texture to onscreen pixel ratio. Method does no calculations on its own, this should be done manually.
    /// </summary>
    /// <param name="onscreen"></param>
    /// <returns></returns>
    public void SetPixelRatio(int onscreen)
    {
        _pixelRatio = onscreen;
    }
    /// <summary>
    /// Sets current spritebatch.
    /// </summary>
    public SpriteBatch SpriteBatch 
    {
        get => _spriteBatch;
        set => _spriteBatch = value;
    }
    private SpriteBatch _spriteBatch;
    private static GraphicsDevice _graphicsDevice;
    private static int _tileDimension; 
    private static int _pixelRatio;
} 
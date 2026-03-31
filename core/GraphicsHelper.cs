using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng;
/// <summary>
/// Helper class for graphics.
/// </summary>
public static class GraphicsHelper
{
    /// <summary>
    /// Give helper class access to current instance of graphicsdevice.
    /// </summary>
    /// <param name="device"></param>
    public static void Initialize(GraphicsDevice device)
    {
        _graphicsDevice = device;
    }
    public static GraphicsDevice GetGraphicsDevice()
    {
        return _graphicsDevice;
    }
    /// <summary>
    /// Returns solid texture of specified color and dimensions.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Texture2D CreateSolid(Color color, int width, int height)
    {
        if(_graphicsDevice == null) throw new System.Exception("bruh");
        Texture2D texture = new Texture2D(_graphicsDevice, width, height);
        texture.SetData([color]);
        return texture;
    }
    /// <summary>
    /// Sets width of tiles in onscreen pixels.
    /// Arg must be be at least 1. 
    /// </summary>
    /// <param name="newWidth"></param>
    public static void SetTileDimension(int newDimension){
        if(newDimension <= 0) return;
        _tileDimension = newDimension;
    }
    /// <summary>
    /// Get onscreen width/height of tile.
    /// </summary>
    /// <returns></returns>
    public static int GetTileDimension()
    {
        return _tileDimension;
    }
    /// <summary>
    /// Get texture to onscreen pixel ratio.
    /// </summary>
    /// <returns></returns>
    public static int GetPixelRatio()
    {
        return _pixelRatio;
    }
    /// <summary>
    /// Set texture to onscreen pixel ratio. Method does no calculations on its own, this should be done manually.
    /// </summary>
    /// <param name="onscreen"></param>
    /// <returns></returns>
    public static void SetPixelRatio(int onscreen)
    {
        _pixelRatio = onscreen;
    }
    private static GraphicsDevice _graphicsDevice;
    private static int _tileDimension; 
    private static int _pixelRatio;
} 
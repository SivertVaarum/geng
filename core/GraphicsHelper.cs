using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng;

public static class GraphicsHelper
{
    private static GraphicsDevice _graphicsDevice;

    public static void Initialize(GraphicsDevice device)
    {
        _graphicsDevice = device;
    }
    /// <summary>
    /// Returns solid texture of specified color.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Texture2D CreateSolid(Color color)
    {
        if(_graphicsDevice == null) throw new System.Exception("bruh");
        Texture2D texture = new Texture2D(_graphicsDevice, 1, 1);
        texture.SetData([color]);
        return texture;
    }
} 
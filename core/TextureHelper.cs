using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
namespace geng;
/// <summary>
/// Object to store textures by name. 
/// </summary>
public static class TextureHelper
{   
    /// <summary>
    /// Gets texture responding to supplied string.
    /// </summary>
    /// <param name="textureName"></param>
    /// <returns></returns>
    public static Texture GetTexture(string textureName)
    {
        return _textures.GetValueOrDefault(textureName);
    }
    /// <summary>
    /// Registers a new texure by supplied name.
    /// </summary>
    /// <param name="textureName"></param>
    /// <param name="newTexture"></param>
    public static void RegisterTexture(String textureName, Texture2D newTexture)
    {
        try
        {
            _textures.Add(textureName, newTexture);
        } catch (ArgumentException e)
        {
            Debug.Print("Texture name already in use");
        }
    }
    /// <summary>
    /// Tries to derive a sub-texture from supplied texture using rectangle.
    /// </summary>
    public static void DeriveTexture(Texture2D spritesheet, Rectangle rectangle, string Name)
    {
        
    }
    private static Dictionary<String ,Texture2D> _textures = new Dictionary<string, Texture2D>();
}
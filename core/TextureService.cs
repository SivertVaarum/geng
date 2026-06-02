using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace geng;
/// <summary>
/// Enables access of a spritesheet from any scope.
/// </summary>
public class TextureService : IService
{
    /// <summary>
    /// Gets main spritesheet.
    /// </summary>
    public Texture2D MainSpritesheet
    {
        get => _spritesheet;
        set => _spritesheet = value;
    }
    /// <summary>
    /// Retrives a spritesheet by name from collection.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Texture2D getSpritesheet(string name)
    {
        return _spritesheets.GetValueOrDefault(name);
    }
    
    private static Texture2D _spritesheet;
    private static Dictionary<string, Texture2D> _spritesheets = new Dictionary<string, Texture2D>();
}
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace geng;
/// <summary>
/// Enables access of a spritesheet from any scope.
/// </summary>
public static class TextureRegister
{
    /// <summary>
    /// Gets main spritesheet.
    /// </summary>
    public static Texture2D MainSpritesheet
    {
        get => _spritesheet;
        set => _spritesheet = value;
    }
    /// <summary>
    /// Retrives a spritesheet by name from collection.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Texture2D getSpritesheet(string name)
    {
        return _spritesheets.GetValueOrDefault(name);
    }
    /// <summary>
    /// Inserts a new spritesheet into collection.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="spritesheet"></param>
    public static void InsertSpritesheet(string name, Texture2D spritesheet)
    {
        _spritesheets.Add(name, spritesheet);
    }
    private static Texture2D _spritesheet;
    private static Dictionary<string, Texture2D> _spritesheets = new Dictionary<string, Texture2D>();
}
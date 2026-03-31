using Microsoft.Xna.Framework.Graphics;

namespace geng;
public static class TextureRegister
{
    public static Texture2D Spritesheet
    {
        get => _spritesheet;
        set => _spritesheet = value;
    }
    private static Texture2D _spritesheet;
}
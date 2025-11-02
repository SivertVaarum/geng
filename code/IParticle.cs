using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng
{
    public interface IParticle : IMoveable, IEntity
    {
        void Update();
        Texture2D Texture { get; }
        Rectangle Rectangle { get; }
    }
}
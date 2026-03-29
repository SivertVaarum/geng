using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace geng
{
    public interface IParticle :  IEntity
    {
        bool isAlive();
    }
}
using System;
using Microsoft.Xna.Framework;
namespace geng;

/// <summary>
/// Particle explosion class.
/// Uses individual particles as opposed to a texture. 
/// </summary>
public class Explosion
{

    /// <summary>
    /// Creates particle explosion at X and Y;
    /// </summary>
    /// <param name="sourceX"></param>
    /// <param name="sourceY"></param>
    public Explosion(int originX, int originY, Color color) {
        for(int i = 0; i < 10 ; i++){
            float angle = (float)(random.NextDouble() * Math.PI * 2);
            Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * (int)(SPEED * random.NextDouble() + 5);       

            particleMediator.AddParticle(new Particle(originX, originY, vector, color));
        }     
    }
    private ParticleMediator particleMediator = ParticleMediator.GetInstance();
    private const int SPEED = 20;
    private Random random = new Random();
}
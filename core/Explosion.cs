using Microsoft.Xna.Framework;
using System;
namespace geng;

/// <summary>
/// Creates an explosion effect. ParticleMediator.Update() and .Draw() has to be called in your main loop.
/// </summary>
public class Explosion
{
    /// <summary>
    /// Creates particle explosion at X and Y, particles evenly spread.
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
    /// <summary>
    /// Creates "directed" particle explosion from x and y in supplied direction.
    /// </summary>
    /// <param name="originX"></param>
    /// <param name="originY"></param>
    /// <param name="direction"></param>
    /// <param name="color"></param>
    public Explosion(int originX, int originY, Vector2 direction, Color color) {
        float angle = (float)Math.Atan2(direction.Y, direction.X);
        float spread = (float)Math.PI / 8;
        float randomOffset = (float)((random.NextDouble() * 2 - 1) * spread);

        for(int i = 0; i < 5 ; i++){
            float finalAngle = angle + randomOffset;
            Vector2 vector = new Vector2((float)Math.Cos(finalAngle), (float)Math.Sin(finalAngle)) * (int)(SPEED * random.NextDouble() + 5);  
            Particle p = new Particle(originX, originY, vector, color);
            particleMediator.AddParticle(p);
        }     
    }
    private ParticleMediator particleMediator = ParticleMediator.GetInstance();
    private const int SPEED = 20;
    private Random random = new Random();
    
}
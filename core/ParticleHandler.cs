using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace geng;

/// <summary>
/// Pipeline for making new particle.
/// Singleton to make it possible to create new particles from any scope.
/// </summary>
public class ParticleHandler//SHOULD THIS BE A SINGLETON????
{
    public List<IParticle> Particles
    {
        get => _particles;
    }
    public enum ParticleType
    {
        Blood,
        Water
    }
    private ParticleHandler() { }
    /// <summary>
    /// Gets instance of the particleMediator
    /// </summary>
    /// <returns>Instance of ParticleMediator</returns>
    public static ParticleHandler GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ParticleHandler();
        }
        return _instance;
    }
    /// <summary>
    /// Adds a new particle of specified type, with specifed location.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public IParticle MakeNewParticle(ParticleType type, int x, int y) {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Adds an existing particle to this class.
    /// </summary>
    /// <param name="particle"></param>
    public void AddParticle(IParticle particle)
    {
        _particles.Add(particle);
    }
    /// <summary>
    /// Updates living particles.
    /// </summary>
    public void Update()
    {
        foreach (IParticle p in _particles)
        {
            p.Update();  
        }
        _particles.RemoveAll( IParticle => !IParticle.isAlive());
    }
    /// <summary>
    /// Draws particles to supplied spritebatch.
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach(IParticle p in _particles)
        {
            p.Draw(spriteBatch, TextureRegister.MainSpritesheet);
        }
    }
    private static ParticleHandler _instance;
    private List<IParticle> _particles = new List<IParticle>();
}

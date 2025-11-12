using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace geng
{  
    /// <summary>
    /// Pipeline for making new particle.
    /// Singleton to make it possible to create new particles from any scope.
    /// </summary>
    public class ParticleMediator//SHOULD THIS BE A SINGLETON????
    {
        private static ParticleMediator _instance;
        private List<IParticle> _particles = new List<IParticle>();
        public List<IParticle> Particles
        {
            get => _particles;
        }
        private List<Texture2D> _textures = new List<Texture2D>();
        public enum ParticleType
        {
            Blood,
            Water
        }

        private ParticleMediator() { }
        /// <summary>
        /// Gets instance of the particleMediator
        /// </summary>
        /// <returns>Instance of ParticleMediator</returns>
        public static ParticleMediator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ParticleMediator();
            }
            return _instance;
        }

        public void GiveTextures(List<Texture2D> textures)
        {
            _textures = textures;
        }

        /// <summary>
        /// Adds a new particle of specified type, with at specifed location.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public IParticle MakeNewParticle(ParticleType type, int x, int y)
        {
            IParticle p = new DropParticle(_textures[0], x, y, 8, 8);
            _particles.Add(p);
            return p;
        }

        /// <summary>
        /// Adds an existing particle to this class.
        /// </summary>
        /// <param name="particle"></param>
        public void AddParticle(IParticle particle)
        {
            _particles.Add(particle);
        }
        public void SetTextures(Texture2D texture)
        {
            _textures.Add(texture);
        }

        public void Update()
        {
            foreach (IParticle p in _particles)
            {
                p.Update();
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IParticle p in _particles)
            {
                spriteBatch.Draw(p.Texture, p.Rectangle, Color.White);
            }
        }
    }
}
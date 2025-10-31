using System.Collections.Generic;
using System.Linq.Expressions;

namespace geng
{  
    /// <summary>
    /// Pipeline for making new particle.
    /// Singleton to make it possible to create new particles from any scope.
    /// </summary>
    public class ParticleMediator
    {
        private static ParticleMediator _instance;
        private List<IParticle> _particles = new List<IParticle>();
        public enum ParticleType
        {
            Blood,
            Water

        }

        private ParticleMediator() {}

        public static ParticleMediator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ParticleMediator();
            }
            return _instance;
        }

        /// <summary>
        /// Adds a new particle of specified type, with at specifed location.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MakeNewParticle(ParticleType type, int x, int y)
        {
            if (type == ParticleType.Water)
            {
                DropParticle p = new DropParticle();
            }
        }

        /// <summary>
        /// Adds an existing particle to this class.
        /// </summary>
        /// <param name="particle"></param>
        public void AddParticle(IParticle particle)
        {
            _particles.Add(particle);
        }

              
        public void Update()
        {
            foreach (IParticle p in _particles)
            {
                p.Update();
            }
        }
        public void Draw()
        {
            
        }






    }
}
namespace geng
{
    public class Explosion
    {
        private float _x;
        private float _y;
        private int localFrame = 0;
        public Particle[] _particles;

        public Explosion(float originX, float originY)
        {
            _x = originX;
            _y = originY;
            for(int i = 0; i>1; i++)
            {
                _particles[i] = new Particle(_x, _y);
            }
        }
        public void Update()
        {
            foreach(var Particle in _particles)
            {
                Particle.Update();
            }
        }






    }
}
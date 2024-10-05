using System;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace geng
{
    public class Particle
    {
        private double _x;
        private double _y;
        private double _magnitude;
        private Random random = new Random();
        public Rectangle _sprite = new Rectangle(0,0,1,1);
        
        public Particle(double originX, double originY)
        {
            _x = originX;
            _y = originY;
            _magnitude = random.NextDouble();
        }
        public void Update()
        {
            _x++;
            _y = -_magnitude*_x*_x;
        }
    }
}
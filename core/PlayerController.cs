using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class PlayerController
    {
        private Player _player;
        private List<Keys> disabledKeys = new List<Keys>();

        public PlayerController(Player p)
        {
            _player = p;
        }

        /// <summary>
        /// Detects input from keyboard for player.
        /// </summary>
        public void CheckInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && !disabledKeys.Contains(Keys.D))
            {
                _player.IncrementXVelocity(1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !disabledKeys.Contains(Keys.A))
            {
                _player.IncrementXVelocity(-1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !disabledKeys.Contains(Keys.S))
            {
                _player.IncrementYVelocity(1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !disabledKeys.Contains(Keys.W))
            {
                _player.IncrementYVelocity(-1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                var p = ParticleMediator.GetInstance().MakeNewParticle(ParticleMediator.ParticleType.Water, _player.X, _player.Y);
                p.IncrementXVelocity(_player.XVelocity);
            }
        }
        public void disableKey(Keys key)
        {
            if (!disabledKeys.Contains(key))
            {
                disabledKeys.Add(key);
            }
        }
        public void enableKey(Keys key)
        {
            if (disabledKeys.Contains(key))
            {
                disabledKeys.Remove(key);
            }
        }
        
    }
}
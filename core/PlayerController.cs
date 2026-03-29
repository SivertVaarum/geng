using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

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
                Explosion explosion = new Explosion(_player.X, _player.Y, new Color(255, 0, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                Explosion explosion = new Explosion(_player.X, _player.Y, new Vector2(_player.XVelocity, _player.YVelocity), new Color(255, 0, 0));
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
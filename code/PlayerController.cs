using System;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class PlayerController
    {
        private Player _player;
        private const int _maxSpeed = 10;//Cannot exceed 31 as this will break collision system.

        public PlayerController(Player p)
        {
            _player = p;
        }
        /// <summary>
        /// Detects input from keyboard for player.
        /// </summary>
        public void CheckInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.IncrementXVelocity(1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _player.IncrementXVelocity(-1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _player.IncrementYVelocity(1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _player.IncrementYVelocity(-1);
            }
        }
        
    }
}
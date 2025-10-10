using System;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class PlayerController
    {
        private Player _player;
        private int _speed = 8;

        public PlayerController(Player p)
        {
            _player = p;
        }

        public void CheckInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _player.Move(0, -_speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _player.Move(0, _speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _player.Move(-_speed, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.Move(_speed, 0);
            }
        }
    }
}
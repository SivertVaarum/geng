using System;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class Controller
    {
        private Player _player;
        private int _speed = 8;//Cannot exceed 31 as this will break collision system.

        public Controller(Player p)
        {
            _player = p;
        }

        public void CheckInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _player.Move(0, -_speed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _player.Move(0, _speed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _player.Move(-_speed, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.Move(_speed, 0);
            }
        }
    }
}
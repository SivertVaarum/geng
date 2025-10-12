using System;
using Microsoft.Xna.Framework.Input;

namespace geng
{
    public class Controller
    {
        private Player _player;
        private int _speed = 8;//Cannot exceed 31 as this will break collision system.
        
        public enum Type
        {
            topDown,
            twoDimensional
        }
        private Type _physicsState;
        public Type PlayerType
        {
            get => _physicsState;
        }
        
        public Controller(Player p, Type ps)
        {
            _player = p;
            _physicsState = ps;
        }

        public void CheckInput()
        {
            if (_physicsState == Type.topDown)
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
            else if (_physicsState == Type.twoDimensional)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    _player.Move(-_speed, 0);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    _player.Move(_speed, 0);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && _player.GravityObject.CurrentState == GravityObject.State.grounded)
                {
                    _player.GravityObject.CurrentState = GravityObject.State.moving;
                    _player.GravityObject.CurrentYVelocity = _player.GravityObject.JumpConstant;
                }
            }
        }
        public void Update()
        {
            _player.GravityObject.Update();
        }
        
    }
}
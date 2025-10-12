using System.Runtime.Serialization;

namespace geng
{   
    /// <summary>
    /// Class to be used by as member by 
    /// objects that should obey gravity.
    /// </summary>
    public class GravityObject
    {
        
        private IEntity _entity;
        private IParticle _particle;
        private const int _terminalVelocity = 30;
        private const int _gravityConstant = 6;
        private int _currentYVelocity = 0;
        public int CurrentYVelocity
        {
            set => _currentYVelocity = value;
        }
        private const int _jumpConstant = -30;
        public int JumpConstant
        {
            get => _jumpConstant;
        }

        public enum State
        {
            grounded,
            moving
        }
        private State _currentState = State.moving;
        public State CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public GravityObject(IEntity e)
        {
            _entity = e;
        }
        public GravityObject(IParticle p)
        {
            _particle = p;
        }

        public void Update()
        {
            if (_currentState == State.moving)
            {
                _entity.Move(0, _currentYVelocity);
                if (_currentYVelocity < _terminalVelocity)
                {
                    _currentYVelocity += _gravityConstant; 
                }
            }
            if (_currentState == State.grounded )
            {
                _currentYVelocity = 0;
            }   
        }
    }
}
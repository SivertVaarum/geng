using System.Runtime.Serialization;

namespace geng
{   
    /// <summary>
    /// Class to be used by as member by 
    /// objects that should obey gravity.
    /// </summary>
    public class GravityObject
    {

        private IMoveable _moveable;
        private const int _terminalVelocity = 30;
        private const int _gravityConstant = 4;
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
        /// <summary>
        /// Makes a new GravityObject tied to supplying argument.
        /// </summary>
        /// <param name="e"></param>
        public GravityObject(IMoveable m)
        {
            _moveable = m;
        }
        /// <summary>
        /// Updates the enteties y position using the _currentVelocity var which is incremented using the a gravitational constant.
        /// </summary>
        public void Update()
        {
            if (_currentState == State.moving)
            {
                _moveable.Move(0, _currentYVelocity);
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
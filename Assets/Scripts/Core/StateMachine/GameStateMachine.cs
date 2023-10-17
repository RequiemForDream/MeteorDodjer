using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, State> _states;
        private State _currentState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, State>();
        }

        public void AddState<TState>(State state)
        {
            var type = typeof(TState);
            _states[type] = state;
        }

        public void ChangeState<TState>() where TState : State
        {
            var type = typeof(TState);
            if (!_states.ContainsKey(type))
            {
                return;
            }

            _currentState?.Exit();
            _currentState = _states[type];
            _currentState.StateMachine = this;
            _states[type].Enter();
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace StarsProject.Misc.StateMachine
{
    public abstract class StateMachine<T, S> where T : Enum where S : State
    {
        public event Action<T> StateChanged; 
        
        protected Dictionary<T, S> states;
        protected S currentState;

        public S CurrentState => currentState;
        
        protected abstract void InitializeStates();
        
        public virtual void ChangeState(T type)
        {
            currentState?.OnExit();

            if (!states.TryGetValue(type, out var state))
            {
                Debug.LogError("State error: " + type);
                return;
            }

            currentState = state;
            currentState.OnEnter();

            RaiseStateChanged(type);
        }
        
        public void Update()
        {
            currentState?.Update();
        }

        public void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        protected void RaiseStateChanged(T type)
        {
            StateChanged?.Invoke(type);
        }
    }
}
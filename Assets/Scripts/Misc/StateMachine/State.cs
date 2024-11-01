namespace StarsProject.Misc.StateMachine
{
    public abstract class State
    {
        public virtual void OnEnter() { }
        
        public virtual void Update() { }
        
        public virtual void FixedUpdate() { }
        
        public virtual void OnExit() { }
    }
}
namespace StateMachine
{
    public abstract class State
    {
        public GameStateMachine StateMachine { get; set; }
        public virtual void Enter() { }
        public virtual void Update(float deltaTime) { }
        public virtual void Exit() { }
    }
}

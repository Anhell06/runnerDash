public interface IGameStateMachine
{
    void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IStateWithPayLoad<TPayLoad>;
    void Enter<TState>() where TState : class, IState;
}
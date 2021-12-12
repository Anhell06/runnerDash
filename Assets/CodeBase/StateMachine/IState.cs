public interface IState : IExitableState
{
    void Enter();
}

public interface IStateWithPayLoad<TPayload> : IExitableState
{
    void Enter(TPayload payload);
}

public interface IExitableState
{
    void Exit();
}
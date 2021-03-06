using Assets.CodeBase.Servises.LevelFactory;
using Assets.CodeBase.StateMachine.State;
using System;
using System.Collections.Generic;

public class GameStateMachine : IGameStateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, ICoroutinRunner coroutinRunner, ServiceLokator service)
    {
        _states = new Dictionary<Type, IExitableState>
        {
            [typeof(BootstrapState)] = new BootstrapState(service, sceneLoader, this),
            [typeof(LoadLevelState)] = new LoadLevelState(service.Single<ILevelFactory>(), sceneLoader, coroutinRunner, this),
            [typeof(GameLoopState)] = new GameLoopState()
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        TState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IStateWithPayLoad<TPayLoad>
    {
        TState state = ChangeState<TState>();
        state.Enter(payLoad);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();

        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState
    {
        return _states[typeof(TState)] as TState;
    }
}

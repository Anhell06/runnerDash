using Assets.CodeBase.Servises.LevelFactory;
using Assets.CodeBase.StateMachine.State;

public class LoadLevelState : IStateWithPayLoad<string>
{
    private ICoroutinRunner _coroutinRunner;
    private SceneLoader _sceneLoader;
    private ServiceLokator _service;
    private ILevelFactory _levelFactory;
    private IGameStateMachine _gameStateMachine;

    public LoadLevelState(ILevelFactory levelFactory, SceneLoader sceneLoader, ICoroutinRunner coroutinRunner, IGameStateMachine gameStateMachine)
    {
        _coroutinRunner = coroutinRunner;
        _sceneLoader = sceneLoader;
        _levelFactory = levelFactory;
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(string sceneName) =>
        _sceneLoader.Load(sceneName, onLoaded: CreateLevel);

    private void CreateLevel()
    {
        _levelFactory.LoadHUD();
        _levelFactory.LoadPlayer();

        _gameStateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
    }
}
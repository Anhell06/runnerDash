public class BootstrapState : IState
{
    private const string initialLevel = "Initial";
    private const string MainLevel = "Main";

    private SceneLoader _sceneLoader;
    private GameStateMachine _stateMachine;
    private ServiceLokator _service;

    public BootstrapState(ServiceLokator service, SceneLoader sceneLoader, GameStateMachine stateMachine)
    {
        _sceneLoader = sceneLoader;
        _stateMachine = stateMachine;
        _service = service;
    }

    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(initialLevel, EnterLoadLevel);
    }

    private void RegisterServices()
    {
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>(MainLevel);
    }


    public void Exit()
    {
    }
}

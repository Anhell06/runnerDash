using UnityEngine.SceneManagement;

public class BootstrapState : IState
{
    private const string initial = "Initial";
    private SceneLoader _sceneLoader;
    private GameStateMachine _stateMachine;

    public BootstrapState(SceneLoader sceneLoader, GameStateMachine stateMachine)
    {
        _sceneLoader = sceneLoader;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(initial, EnterLoadLevel);
        
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>("Main");
    }

    private void RegisterServices()
    {
    }

    public void Exit()
    {
    }
}

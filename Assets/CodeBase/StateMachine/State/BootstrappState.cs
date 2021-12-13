using Assets.CodeBase.InputService;
using Assets.CodeBase.Servises.LevelFactory;
using UnityEngine;

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
        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(initialLevel, EnterLoadLevel);

    }

    private void RegisterServices()
    {
        _service.RegistrateAsSingl<IResourcesProvider>(new ResourcesProvider());
        _service.RegistrateAsSingl<IInputObservableService>(new InputObservableService());

        _service.RegistrateAsSingl<ILevelFactory>(new LevelFactory(
            _service.Single<IResourcesProvider>(),
            _service.Single<IInputObservableService>()
            ));

        Debug.Log(_service.Single<ILevelFactory>());
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>(MainLevel);
    }


    public void Exit()
    {
    }
}

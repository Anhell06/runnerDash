using Assets.CodeBase.Servises.LevelFactory;
using System;

public class LoadLevelState : IStateWithPayLoad<string>
{
    private ICoroutinRunner _coroutinRunner;
    private SceneLoader _sceneLoader;
    private ServiceLokator _service;
    private ILevelFactory _levelFactory;

    public LoadLevelState(ILevelFactory levelFactory, SceneLoader sceneLoader, ICoroutinRunner coroutinRunner)
    {
        _coroutinRunner = coroutinRunner;
        _sceneLoader = sceneLoader;
        _levelFactory = levelFactory;
    }

    public void Enter(string sceneName) => 
        _sceneLoader.Load(sceneName, onLoaded: CreateLevel);

    private void CreateLevel()
    {
        CrateUIRoot();
    }

    private void CrateUIRoot()
    {
        _levelFactory.LoadHUD();
    }

    private void OnLoad()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}
using System;

public class LoadLevelState : IStateWithPayLoad<string>
{
    private ICoroutinRunner _coroutinRunner;
    private SceneLoader _sceneLoader;

    public LoadLevelState(SceneLoader sceneLoader, ICoroutinRunner coroutinRunner)
    {
        _coroutinRunner = coroutinRunner;
        _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName) => _sceneLoader.Load(sceneName);

    private void OnLoad()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}
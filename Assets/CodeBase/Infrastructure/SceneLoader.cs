using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private ICoroutinRunner _coroutinRunner;

    public SceneLoader(ICoroutinRunner coroutinRunner) =>
        _coroutinRunner = coroutinRunner;

    public void Load(string name, Action onLoaded = null) =>
        _coroutinRunner.StartCoroutine(LoadScene(name, onLoaded));

    private IEnumerator LoadScene(string name, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == name)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

        while (waitNextScene.isDone != true)
            yield return null;

        onLoaded?.Invoke();
    }
}

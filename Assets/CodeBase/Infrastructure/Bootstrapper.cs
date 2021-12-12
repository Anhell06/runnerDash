using UnityEngine;

public class Bootstrapper : MonoBehaviour, ICoroutinRunner
{
    private Game _game;

    private void Awake()
    {
        _game = new Game(this);
        _game.StateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad(this);
    }
}

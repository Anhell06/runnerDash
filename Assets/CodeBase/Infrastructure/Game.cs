public class Game
{
    public GameStateMachine StateMachine;

    public Game(ICoroutinRunner coroutinRunner)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutinRunner), coroutinRunner);
    }
}
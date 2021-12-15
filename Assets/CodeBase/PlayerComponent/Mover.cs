using Assets.CodeBase.InputService;
using UnityEngine;

public class Mover : MonoBehaviour, IInputObserver
{
    [SerializeField, Range(0, 10f)]
    private float speed = .5f;

    private Vector3 _direction = Vector3.zero;

    private void Start()
    {
        IInputObservableService _observable = ServiceLokator.Container.Single<IInputObservableService>();
        _observable.AddObserver(this);
    }

    private void FixedUpdate() =>
        MoveForvard(_direction);

    public void InputUpdate(Vector2 direction, SwipeType swipeType)
    {
        if (SwipeTypeIsEndCrossSwipe(swipeType) && SwipeIsLeftOrRight(ref direction))
            _direction = direction;
    }

    private static bool SwipeTypeIsEndCrossSwipe(SwipeType swipeType) =>
        swipeType == SwipeType.EndCrossSwipe;

    private static bool SwipeIsLeftOrRight(ref Vector2 direction) =>
        direction.Equals(Vector2.left) || direction.Equals(Vector2.right);


    private void MoveForvard(Vector3 direction) =>
        transform.position += (Vector3.up + direction) / 2 * speed * Time.deltaTime;

}

using Assets.CodeBase.Constants;
using Assets.CodeBase.InputService;
using UnityEngine;

internal class Mover : MonoBehaviour, IInputObserver
{
    private const float offsetFiled = ConstantOffsetField.offset;
    [SerializeField, Range(0, 10f)]
    private float speed = .5f;

    private Vector3 _direction = Vector3.up;

    internal void Constract(IInputObservableService inputObservable)
    {
        IInputObservableService _observable = ServiceLokator.Container.Single<IInputObservableService>();
        _observable.AddObserver(this);
    }

    private void FixedUpdate() =>
        MoveForvard(_direction);

    public void InputUpdate(Vector2 direction, SwipeType swipeType)
    {
        if (SwipeTypeIsEndCrossSwipe(swipeType)) 
        {
            if (direction.Equals(Vector2.left) || direction.Equals(Vector2.right))
                _direction = new Vector3(direction.x * offsetFiled, 0, 0);
            if (direction.Equals(Vector2.up))
                _direction = Vector3.up;
        }
    }

    private static bool SwipeTypeIsEndCrossSwipe(SwipeType swipeType) =>
        swipeType == SwipeType.EndCrossSwipe;


    private void MoveForvard(Vector3 direction) =>
        transform.position += (Vector3.up + direction) * speed * Time.deltaTime;

}

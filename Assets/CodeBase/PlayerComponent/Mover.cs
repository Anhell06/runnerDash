using System;
using Assets.CodeBase.InputService;
using UnityEngine;

internal class Mover : MonoBehaviour, IInputObserver
{
    [SerializeField, Range(0, 10f)]
    private float speed = .5f;

    private Vector3 _direction = Vector3.zero;
    
    internal void Constract(IInputObservableService inputObservable)
    {
        IInputObservableService _observable = ServiceLokator.Container.Single<IInputObservableService>();
        _observable.AddObserver(this);
    }

    private void FixedUpdate() =>
        MoveForvard(_direction);

    public void InputUpdate(Vector2 direction, SwipeType swipeType)
    {
        if (SwipeTypeIsEndCrossSwipe(swipeType) && !SwipeIsDown(ref direction) && !SwipeIsZero(ref direction))
            _direction = direction;
    }

    private static bool SwipeTypeIsEndCrossSwipe(SwipeType swipeType) =>
        swipeType == SwipeType.EndCrossSwipe;

    private bool SwipeIsZero(ref Vector2 direction) =>
        direction.Equals(Vector2.zero);

    private static bool SwipeIsDown(ref Vector2 direction) =>
        direction.Equals(Vector2.down);


    private void MoveForvard(Vector3 direction) =>
        transform.position += (Vector3.up + direction) / 2 * speed * Time.deltaTime;

}

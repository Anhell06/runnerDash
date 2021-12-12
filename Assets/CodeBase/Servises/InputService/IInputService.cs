using System;
using UnityEngine;

namespace Assets.CodeBase.InputService
{
    public interface IInputService : IService
    {
        event Action<Vector2> EndSwipeDirection;
        event Action<Vector2> EndSwipeInFourDirection;
        event Action<Vector2> StartSwipeDirection;
        event Action<Vector2> StartSwipeInFourDirection;
    }
}
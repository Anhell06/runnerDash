using UnityEngine;

namespace Assets.CodeBase.InputService
{
    public interface IInputObserver
    {
        void InputUpdate(Vector2 direction, SwipeType swipeType);
    }
}

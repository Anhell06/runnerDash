using UnityEngine;

namespace Assets.CodeBase.InputService
{
    public interface IInputObservableService : IService
    {
        void AddObserver(IInputObserver inputObserver);
        void NotifyObservers(Vector2 direction, SwipeType swipeType);
        void RemoveObserver(IInputObserver inputObserver);
    }
}
using Assets.CodeBase.Constants;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.InputService
{
    public partial class InputObservableService : IService, IInputObservableService
    {
        private List<IInputObserver> _inputObservers = new List<IInputObserver>();
        
        public void AddObserver(IInputObserver inputObserver)
        {
            _inputObservers.Add(inputObserver);
        }
        public void RemoveObserver(IInputObserver inputObserver)
        {
            _inputObservers.Remove(inputObserver);
        }
        public void NotifyObservers(Vector2 direction, SwipeType swipeType)
        {
            foreach (var inputObserver in _inputObservers)
            {
                inputObserver.InputUpdate(direction, swipeType);
            }
        }


    }
}

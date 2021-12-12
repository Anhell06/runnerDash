using Assets.CodeBase.Constants;
using System;
using UnityEngine;

namespace Assets.CodeBase.InputService
{
    [Serializable]
    public class InputServiceForMobile : IService, IInputService
    {
        private IResourcesProvider _resources;
        private InputServiceBehaviour _inputSistem;

        public event Action<Vector2> StartSwipeInFourDirection;
        public event Action<Vector2> StartSwipeDirection;

        public event Action<Vector2> EndSwipeInFourDirection;
        public event Action<Vector2> EndSwipeDirection;

        public InputServiceForMobile(IResourcesProvider resources)
        {
            _resources = resources;
            _inputSistem = _resources.InstantiateObject<GameObject>(ConstantResourcesPath.InputSystemPath).GetComponent<InputServiceBehaviour>();
            _inputSistem.Init(StartSwipeInFourDirection, StartSwipeDirection, EndSwipeInFourDirection, EndSwipeDirection);
        }
        
    }
}

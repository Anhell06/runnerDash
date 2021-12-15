using Assets.CodeBase.InputService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    public class PlayerMediator : MonoBehaviour
    {
        IInputObservableService _inputObservable;
        private Mover _mover;

        public void Constract(IInputObservableService inputObservable)
        {
            _inputObservable = inputObservable;
        }

        private void Awake() => CollectModule();
        private void Start() => ConstractModule();
        
        private void CollectModule()
        {
            _mover = gameObject.GetComponent<Mover>();
        }

        private void ConstractModule()
        {
            _mover.Constract(_inputObservable);
        }
    }
}

using Assets.CodeBase.InputService;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    public class PlayerMediator : MonoBehaviour
    {
        private IInputObservableService _inputObservable;
        private Mover _mover;
        private DeathComponent _death;

        private void Awake()
        {
            CollectModule();
            ConstractModule();
        }

        public void Constract(IInputObservableService inputObservable)
        {
            _inputObservable = inputObservable;
        }

        internal void Death() => _mover.enabled = false;

        private void CollectModule()
        {
            _mover = gameObject.GetComponent<Mover>();
            _death = gameObject.GetComponent<DeathComponent>();
        }

        private void ConstractModule()
        {
            _mover.Constract(_inputObservable);
            _death.Constract(this);
        }
    }
}

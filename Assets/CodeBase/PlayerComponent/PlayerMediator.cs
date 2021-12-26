using Assets.CodeBase.InputService;
using Assets.CodeBase.Servises.ProgressService;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    public class PlayerMediator : MonoBehaviour
    {
        private IInputObservableService _inputObservable;
        private IProgressDataServise _progress;
        private Mover _mover;
        private DeathComponent _death;
        private ItemCollectable _colectabel;

        private void Start()
        {
            CollectModule();
            ConstractModule();
        }

        public void Constract(IInputObservableService inputObservable, IProgressDataServise progress)
        {
            _inputObservable = inputObservable;
            _progress = progress;

        }

        private void CollectModule()
        {
            _mover = gameObject.GetComponent<Mover>();
            _death = gameObject.GetComponent<DeathComponent>();
            _colectabel = gameObject.GetComponent<ItemCollectable>();

        }

        private void ConstractModule()
        {
            _mover.Constract(_inputObservable);
            _death.Constract(this);
            _colectabel.Constract(_progress);
        }

        internal void Death() => _mover.enabled = false;
    }
}

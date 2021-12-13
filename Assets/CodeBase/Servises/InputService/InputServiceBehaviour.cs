using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.CodeBase.InputService
{
    internal class InputServiceBehaviour : MonoBehaviour
    {
        [SerializeField, Header("Params")]
        private float _delayTime = .1f;
        [SerializeField, Range(0f, 1f)]
        private float _directionThreshold = .9f;

        private InputController _inputController;
        private Vector2 _currentTouchPosition;
        private Vector2 _startPosition = Vector2.zero;
        private Vector2 _lastDirection = Vector2.zero;
        private Vector2 _lastCrossDirection = Vector2.zero;
        private Vector2[] _crossVectors = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        private bool _isTouch = false;
        private float _timeAfterStartTouch = 0;
        private IInputObservableService _inputObservable;


        public void Constract(IInputObservableService inputObservable)
        {
            _inputObservable = inputObservable;
        }

        private void Awake()
        {
            _inputController = new InputController();
        }

        private void OnEnable()
        {
            _inputController.Enable();
            Debug.Log(SceneManager.GetActiveScene().name);
        }

        private void OnDisable()
        {
            _inputController.Disable();
        }

        private void Start()
        {
            _inputController.ForMobile.StartContact.started += ctx => TouchStarted(ctx);
            _inputController.ForMobile.StartContact.canceled += ctx => TouchEnded(ctx);
        }

        private void Update()
        {
            if (!TouchIsStarted())
                return;

            _timeAfterStartTouch += Time.deltaTime;

            if (_timeAfterStartTouch < _delayTime)
                return;

            TakeStartPosition();
            UpdateSwipeDirection(_currentTouchPosition, _startPosition);
        }
        
        private void UpdateSwipeDirection(Vector2 currentTouchPosition, Vector2 startPosition)
        {
            Vector2 normolizedVector = (currentTouchPosition - startPosition).normalized;
            
            foreach (Vector2 crossVector in _crossVectors)
            {
                if (Vector2.Dot(crossVector, normolizedVector) > _directionThreshold)
                {
                    _lastCrossDirection = crossVector;
                    _inputObservable.NotifyObservers(crossVector, SwipeType.StartCrossSwipe);
                }
            }
        }

        private void TouchStarted(CallbackContext ctx)
        {
            _isTouch = true;
            _startPosition = _inputController.ForMobile.TouchPosition.ReadValue<Vector2>();
        }

        private void TouchEnded(CallbackContext ctx)
        {
            _isTouch = false;
            _timeAfterStartTouch = 0;

            _inputObservable.NotifyObservers(_lastCrossDirection, SwipeType.EndCrossSwipe);

            _lastCrossDirection = Vector2.zero;
        }

        private void TakeStartPosition() => _currentTouchPosition = _inputController.ForMobile.TouchPosition.ReadValue<Vector2>();

        private bool TouchIsStarted() => _isTouch == false;
    }
}

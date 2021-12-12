using System;
using UnityEngine;
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
        private Vector2 _lastInFourDirection = Vector2.zero;
        private bool _isTouch = false;
        private float _timeAfterStartTouch = 0;

        private Action<Vector2> _startSwipeInFourDirection;
        private Action<Vector2> _startSwipeDirection;
        private Action<Vector2> _endSwipeInFourDirection;
        private Action<Vector2> _endSwipeDirection;

        public void Init(Action<Vector2> StartSwipeInFourDirection, Action<Vector2> StartSwipeDirection, Action<Vector2> EndSwipeInFourDirection, Action<Vector2> EndSwipeDirection)
        {
            _startSwipeInFourDirection = StartSwipeInFourDirection;
            _startSwipeDirection = StartSwipeDirection;
            _endSwipeInFourDirection = EndSwipeInFourDirection;
            _endSwipeDirection = EndSwipeDirection;
        }

        private void Awake()
        {
            _inputController = new InputController();
        }

        private void OnEnable()
        {
            _inputController.Enable();
            Debug.Log("");
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

        private void TakeStartPosition()
        {
            _currentTouchPosition = _inputController.ForMobile.TouchPosition.ReadValue<Vector2>();
        }

        private bool TouchIsStarted()
        {
            return _isTouch == false;
        }

        private void UpdateSwipeDirection(Vector2 currentTouchPosition, Vector2 startPosition)
        {

            Vector2 normolizeVector = (currentTouchPosition - startPosition).normalized;

            _startSwipeDirection?.Invoke(normolizeVector);
            _lastDirection = normolizeVector;
            Debug.Log(normolizeVector);

            Vector2[] typeVectors = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

            foreach (Vector2 vector in typeVectors)
            {
                if (Vector2.Dot(vector, normolizeVector) > _directionThreshold)
                {
                    _lastInFourDirection = vector;
                    _startSwipeInFourDirection?.Invoke(vector);
                    Debug.Log(vector);
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

            _endSwipeDirection?.Invoke(_lastDirection);
            _endSwipeInFourDirection?.Invoke(_lastDirection);

            _lastDirection = Vector2.zero;
            _lastInFourDirection = Vector2.zero;
        }

    }
}

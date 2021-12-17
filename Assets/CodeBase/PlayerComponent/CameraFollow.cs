using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _offset;

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            transform.position = _target.position + _offset;
        }

        public void Follow(Transform the, Vector3 withOffset)
        {
            _target = the;
            _offset = withOffset;
        }
    }
}

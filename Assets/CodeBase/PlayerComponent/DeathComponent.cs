using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    internal class DeathComponent : MonoBehaviour
    {
        private const int DeadlyLayer = 11;
        private bool _isTouch = false;
        private PlayerMediator _playerMediator;

        internal void Constract(PlayerMediator playerMediator) =>
            _playerMediator = playerMediator;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isTouch)
            {
                _isTouch = true;

                if (collision.gameObject.layer == DeadlyLayer)
                {
                    _playerMediator.Death();
                    Debug.Log("Player Death");
                    _isTouch = false;
                }
            }
        }

    }
}

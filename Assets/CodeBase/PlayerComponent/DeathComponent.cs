using Assets.CodeBase.Constants;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    internal class DeathComponent : MonoBehaviour
    {
        private const int DeadlyLayer = ConstantLayerNuber.DeadlyLayer;
        private bool _isTouch = false;
        private PlayerMediator _playerMediator;

        internal void Constract(PlayerMediator playerMediator) =>
            _playerMediator = playerMediator;

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (!_isTouch && collision.gameObject.layer == DeadlyLayer)
            {
                _isTouch = true;
                _playerMediator.Death();
                Debug.Log("Player Death");
                _isTouch = false;
            }
        }

    }
}

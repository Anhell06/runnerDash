using Assets.CodeBase.Constants;
using Assets.CodeBase.Servises.StaticDataService;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    internal class ItemCollectable : MonoBehaviour
    {
        private bool _isTouch;
        private const int _itemLayer = ConstantLayerNuber.ItemLayer;
        private IItem _item;
        private IStaticDataService _saveData;

        internal void Constract(PlayerMediator playerMediator, IStaticDataService saveData) => 
            _saveData = saveData;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isTouch && collision.gameObject.layer == _itemLayer)
            {
                _isTouch = true;
                Collect(collision.gameObject);
                _isTouch = false;
            }
        }

        private void Collect(GameObject colision)
        {
            if (colision.TryGetComponent<IItem>(out _item))
            {
                _item.Colect(_saveData);
            }
        }
    }
}

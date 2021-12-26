using Assets.CodeBase.BattelField.Item;
using Assets.CodeBase.Constants;
using Assets.CodeBase.Servises.ProgressService;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    internal class ItemCollectable : MonoBehaviour
    {
        private bool _isTouch;
        private const int _itemLayer = ConstantLayerNuber.ItemLayer;
        private IProgressDataServise _progress;

        public void Constract(IProgressDataServise progress)
        {
            _progress = progress;
        }

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
            if (colision.TryGetComponent<IItem>(out IItem _item))
            {
                SaveItemInData(_item);
                _item.Colect();
            }
        }

        public void SaveItemInData(IItem item)
        {
            _progress.CollectebleItemData.Collect(item);
        }
    }
}

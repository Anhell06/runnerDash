using Assets.CodeBase.BattelField.Item;
using Assets.CodeBase.Constants;
using Assets.CodeBase.Servises.ProgressService;
using UnityEngine;

namespace Assets.CodeBase.PlayerComponent
{
    internal class ItemCollectable : MonoBehaviour, ISaveProgress
    {
        private bool _isTouch;
        private const int _itemLayer = ConstantLayerNuber.ItemLayer;
        private ColLectebleItemData _bag;

        private void Start()
        {
            _bag = new ColLectebleItemData();
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
                _item.Colect();

                switch (_item.Type)
                {
                    case ItemType.Life:
                        _bag.Life++;
                        break;
                    case ItemType.Shield:
                        _bag.Shield++;
                        break;
                    default:
                        break;
                }
            }
        }

        public void LoadProgress(IProgressDataServise progress)
        {
            _bag.Life = progress.CollectebleItemData.Life;
            _bag.Shield = progress.CollectebleItemData.Shield;
        }

        public void SaveProgress(IProgressDataServise progress)
        {
            progress.UpdateCollectebelItem(life: _bag.Life, shield: _bag.Shield);
        }
    }
}

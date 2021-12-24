using Assets.CodeBase.PlayerComponent;
using Assets.CodeBase.Servises.StaticDataService;
using UnityEngine;

namespace Assets.CodeBase.BattelField.Item
{
    public class ExtraLife : MonoBehaviour, IItem
    {
        public ItemType Type { get; } = ItemType.Life;

        public void Colect()
        {
            gameObject.SetActive(false);
        }
    }
}

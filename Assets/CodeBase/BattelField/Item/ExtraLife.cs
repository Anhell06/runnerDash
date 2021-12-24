using Assets.CodeBase.PlayerComponent;
using Assets.CodeBase.Servises.StaticDataService;
using UnityEngine;

namespace Assets.CodeBase.BattelField.Item
{
    internal class ExtraLife : MonoBehaviour, IItem
    {
        public void Colect(IStaticDataService saveData)
        {
            gameObject.SetActive(false);
        }
    }
}

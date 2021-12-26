using System;
using Assets.CodeBase.BattelField.Item;
using UnityEngine;

namespace Assets.CodeBase.Servises.ProgressService
{
    public class CollectebleItemData
    {
        public int Life;
        public int Shield;
        

        public void Collect(IItem item)
        {
            Debug.Log($"Collect {item.Type.ToString()}");
            switch (item.Type)
            {
                case ItemType.Life:
                    Life++;
                    break;
                case ItemType.Shield:
                    Shield++;
                    break;
                default:
                    break;
            }
            Debug.Log($"Live: {Life}, Shield {Shield}");
            SaveProgress();
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString("Item", JsonUtility.ToJson(this));
        }
        
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.BattelField.Item
{
    public class EndLevelTrigger : MonoBehaviour, IItem
    {
        public ItemType Type { get; } = ItemType.EndLevel;

        public void Colect()
        {
            Debug.Log($"Level {SceneManager.GetActiveScene().name} Ended");
        }
    }
}

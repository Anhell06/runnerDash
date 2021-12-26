using UnityEngine;

namespace Assets.CodeBase.Servises.ProgressService
{
    internal class ProgressDataService : IProgressDataServise
    {
        public ProgressDataService()
        {
            LoadProgress();
        }

        public void LoadProgress()
        {
            CollectebleItemData = JsonUtility.FromJson<CollectebleItemData>(PlayerPrefs.GetString("Item")) ?? new CollectebleItemData();
            LevelProgressData = JsonUtility.FromJson<LevelProgressData>(PlayerPrefs.GetString("Level")) ?? new LevelProgressData();
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString("Item", JsonUtility.ToJson(CollectebleItemData));
            PlayerPrefs.SetString("Level", JsonUtility.ToJson(LevelProgressData));
        }

        public CollectebleItemData CollectebleItemData { get; set; }
        public LevelProgressData LevelProgressData { get; set; }

    }
}

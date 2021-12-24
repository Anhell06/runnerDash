namespace Assets.CodeBase.Servises.ProgressService
{
    public interface IProgressDataServise : IService
    {
        void UpdateCollectebelItem(int life, int shield);
        ColLectebleItemData CollectebleItemData { get; set; }
        LevelProgressData LevelProgressData { get; set; }
    }
}
namespace Assets.CodeBase.Servises.ProgressService
{
    public interface IProgressDataServise : IService
    {
        CollectebleItemData CollectebleItemData { get; set; }
        LevelProgressData LevelProgressData { get; set; }

    }
}
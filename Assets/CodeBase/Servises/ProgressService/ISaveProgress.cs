namespace Assets.CodeBase.Servises.ProgressService
{
    public interface ISaveProgress : IWriteProgress
    {
        void SaveProgress(IProgressDataServise progress);
    }
}
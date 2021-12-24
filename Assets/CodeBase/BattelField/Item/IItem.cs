using Assets.CodeBase.Servises.StaticDataService;

namespace Assets.CodeBase.PlayerComponent
{
    internal interface IItem
    {
        void Colect(IStaticDataService saveData);
    }
}

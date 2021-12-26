using Assets.CodeBase.Servises.StaticDataService;

namespace Assets.CodeBase.BattelField.Item
{
    public interface IItem
    {
        void Colect();
        ItemType Type { get; }
    }
}

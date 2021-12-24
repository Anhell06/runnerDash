using Assets.CodeBase.Servises.StaticDataService;

namespace Assets.CodeBase.BattelField.Item
{
    internal interface IItem
    {
        void Colect();
        ItemType Type { get; }
    }
}

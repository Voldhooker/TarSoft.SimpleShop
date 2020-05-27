using TarSoft.SimpleShop.Core.Enums;

namespace TarSoft.SimpleShop.Core.Interfaces
{
    //Using this to indicate the state of the object. Used in the domain (calculations) and converted in persistence layer (EF)
    public interface IStateObject
    {
        EObjectState State { get; }
    }
}

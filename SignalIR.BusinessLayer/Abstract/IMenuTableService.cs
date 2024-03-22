using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericServise<MenuTable>
    {
        int TMenuTableCount();
    }
}

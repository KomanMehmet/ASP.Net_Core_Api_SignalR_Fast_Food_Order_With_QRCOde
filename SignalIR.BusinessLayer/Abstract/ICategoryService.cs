using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericServise<Category>
    {
        int TCategoryCount();

        int TActiveCategoryCount();

        int TPassiveCategoryCount();
    }
}

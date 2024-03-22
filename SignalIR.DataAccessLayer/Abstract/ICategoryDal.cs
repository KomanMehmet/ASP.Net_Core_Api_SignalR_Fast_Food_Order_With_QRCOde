using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int CategoryCount();

        int ActiveCategoryCount();

        int PassiveCategoryCount();
    }
}

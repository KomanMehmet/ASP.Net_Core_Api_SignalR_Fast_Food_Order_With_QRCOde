using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DataAccessLayer.Concrete;
using SignalIR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalIR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalIRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new SignalIRContext();

            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new SignalIRContext();

            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new SignalIRContext();

            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}

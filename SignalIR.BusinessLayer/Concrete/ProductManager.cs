using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class ProductManager : IProductDal
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetListAll()
        {
            return _productDal.GetListAll();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity); 
        }
    }
}

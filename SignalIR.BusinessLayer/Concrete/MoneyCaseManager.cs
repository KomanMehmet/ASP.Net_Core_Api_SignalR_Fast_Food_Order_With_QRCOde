using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalIR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public MoneyCase TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public decimal TtotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            throw new NotImplementedException();
        }
    }
}

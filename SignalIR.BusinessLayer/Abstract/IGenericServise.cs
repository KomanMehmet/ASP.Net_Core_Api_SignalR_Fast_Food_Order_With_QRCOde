namespace SignalIR.BusinessLayer.Abstract
{
    public interface IGenericServise<T> where T : class
    {
        void TAdd(T entity);

        void TDelete(T entity);

        void TUpdate(T entity);

        T TGetById(int id);

        List<T> TGetListAll();
    }
}

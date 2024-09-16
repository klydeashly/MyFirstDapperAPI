namespace MyFirstDapperAPI.Repository
{
    public interface IGenericRepository<T> 
    {
        T GetById(int id);
        bool Add (T entity);
        bool Update (T entity);
        bool Delete (T entity);
    }
}

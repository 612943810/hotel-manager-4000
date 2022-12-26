using Hotel_Manager_4000.Models;
namespace Hotel_Manager_4000.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> findAll();
        T Get (String id);
        void Insert (T Entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();



    }

   
}

using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager_4000.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected HotelContext hotelContext { get; set; }
        private DbSet<T> dbSet { get; set; }
        public Repository(HotelContext hotelContext, DbSet<T> dbSet)
        {
            this.hotelContext = hotelContext;
            this.dbSet = hotelContext.Set<T>(); 
        }

        IEnumerable<T> IRepository<T>.findAll()
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.Get(string id)
        {
            throw new NotImplementedException();
        }

        public virtual void  Insert(T Entity) =>dbSet.Add(Entity);

        public virtual void Update(T entity)=>dbSet.Update(entity); 
        public virtual void Delete(T entity)=>dbSet.Remove(entity); 
 

    public virtual void Save()=>hotelContext.SaveChanges();
    }
        
}

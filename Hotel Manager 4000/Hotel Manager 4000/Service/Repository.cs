using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager_4000.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private HotelContext hotelContext { get; set; }
        private DbSet<T> dbSet { get; set; }
        public Repository(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
            this.dbSet = hotelContext.Set<T>(); 
        }

        public virtual IEnumerable<T> findAll()
        {
            yield return dbSet.Find();
        }

        public virtual T Get(string id)
        {
            return dbSet.Find(id);
        }

        public virtual void InsertAsync(T Entity) =>  dbSet.AddAsync(Entity);

        public virtual void Update(T entity)=>dbSet.Update(entity); 
        public virtual void Delete(T entity)=>dbSet.Remove(entity); 
 

    public virtual async Task SaveAsync()=>await hotelContext.SaveChangesAsync();
    }
        
}

using D6UWHX_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Repository
{
    public  abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MusicLibraryContext MusicLibraryContext;
        //ctor
        public Repository(MusicLibraryContext musicLibraryContext)
        {
            MusicLibraryContext = musicLibraryContext;


        }
        public void Add(T entity)
        {
            MusicLibraryContext.Set<T>().Add(entity);

            MusicLibraryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            MusicLibraryContext.Set<T>().Remove(entity);

            MusicLibraryContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return MusicLibraryContext.Set<T>();
        }
        public abstract T GetOne(int id);

       

        public void Update(T entity)
        {
            MusicLibraryContext.Set<T>().Attach(entity);

            MusicLibraryContext.SaveChanges();
        }
    }
}

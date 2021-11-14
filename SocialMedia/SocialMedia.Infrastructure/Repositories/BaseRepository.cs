using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(SocialMediaContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {           
            await _entities.AddAsync(entity);
        }

        /// <summary>
        /// Para que este
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        /// <summary>
        /// Esta funcioón recibe como parámetro un id válido en la base de datos, para luego eliminarlo.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            //if (entity == null)
            //    throw new Core.Exceptions.BusinessException($"The {typeof(T).Name} with id: {id}, doesn't exist");
            _entities.Remove(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }
}

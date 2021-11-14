using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);        
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        void Remove(T entity);
    }
}

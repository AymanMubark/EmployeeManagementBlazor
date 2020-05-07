using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{

    public interface IGenericRepository<IEntity> where IEntity : class
    {
        public Task<IEnumerable<IEntity>> GetAll();
        public Task<IEntity> GetById(object Id);
        Task Insert(IEntity entity);
        void Update(IEntity entity);
        Task Delete(object Id);
    }
}

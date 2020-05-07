using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<IEntity> : IGenericRepository<IEntity> where IEntity : class
    {
        private readonly DataContext _context;
        public DbSet<IEntity> Entities { get; set; }

        public GenericRepository(DataContext context)
        {
            this._context = context;
            this.Entities = context.Set<IEntity>();
        }

        public async Task Delete(object Id)
        {
            var existEntity =await Entities.FindAsync(Id);
            Entities.Remove(existEntity);
        }


        public async Task<IEntity> GetById(object Id)
        {
            return await Entities.FindAsync(Id);
        }

        public async Task Insert(IEntity entity)
        {
           await Entities.AddAsync(entity);
        }

        public void Update(IEntity entity)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<IEntity>> GetAll()
        {
            return await Entities.ToListAsync();
        }
    }
}

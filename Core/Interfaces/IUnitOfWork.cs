using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWork<IEntity> where IEntity : class
    {
        IGenericRepository<IEntity> Entity { get; }
        void Save();
    }
}

using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityServiceBase<TEntity> where TEntity : class, IEntity, new()
    {
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(int id);
    }
}

using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using MarshallsLLC.Domain.Validation;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity department);
        Task<TEntity> Update(TEntity department);
        Task<TEntity> Delete(TEntity entity);
        ValidationResult ValidateData(TEntity entity, bool selfValidation = false);
    }
}

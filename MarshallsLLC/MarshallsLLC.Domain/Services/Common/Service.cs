using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using MarshallsLLC.Domain.Validation;
using MarshallsLLC.Domain.Interfaces.Validation;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using MarshallsLLC.Domain.Interfaces.Repository.Common;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Constructor
        private readonly IRepository<TEntity> _repository;
        private readonly ValidationResult _validationResult;
        public Service(
            IRepository<TEntity> repository)
        {
            _repository = repository;
            _validationResult = new ValidationResult();
        }
        #endregion
        #region Properties
        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }
        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }
        #endregion
        #region Read Methods
        public virtual Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetAsync(predicate);
        }
        public virtual IEnumerable<TEntity> All()
        {
            return _repository.All();
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }
        #endregion
        #region CRUD Methods
        public virtual ValidationResult ValidateData(TEntity entity, bool selfValidation = false)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (selfValidation)
            {
                var selfValidationEntity = entity as ISelfValidation;
                if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                    return selfValidationEntity.ValidationResult;
            }
            return _validationResult;
        }
        public virtual Task<TEntity> Add(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }
        public virtual async Task<TEntity> Update(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public virtual Task<TEntity> Delete(TEntity entity)
        {
            return _repository.DeleteAsync(entity);
        }
        #endregion
    }
}

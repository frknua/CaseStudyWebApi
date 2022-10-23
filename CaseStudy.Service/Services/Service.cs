using CaseStudy.Core.Repositories;
using CaseStudy.Core.Services;
using CaseStudy.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
            _unitOfWork.Commit();
        }

        public T Update(T entity)
        {
            T updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityTimetable.Shared.Exceptions.DomainExceptions;
using UniversityTimetable.Shared.Interfaces.Data.Models;
using UniversityTimetable.Shared.Interfaces.DataAccess;
using UniversityTimetable.Shared.Interfaces.Domain;

namespace UniversityTimetable.Domain.Services
{
    public class BaseService<TDto, TRepositoryModel> : IBaseService<TDto>
        where TRepositoryModel : class, IModel
        where TDto : class, IDataTransferObject
    {
        private readonly IBaseDataAccessFacade<TRepositoryModel> _dataAccessFacade;
        private readonly ILogger<BaseService<TDto, TRepositoryModel>> _logger;
        private readonly IMapper _mapper;

        public BaseService(IBaseDataAccessFacade<TRepositoryModel> dataAccessFacade, ILogger<BaseService<TDto, TRepositoryModel>> logger,
            IMapper mapper)
        {
            _dataAccessFacade = dataAccessFacade;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<TDto> CreateAsync(TDto entity)
        {
            _logger.LogInformation("Creating object of type {Type}", typeof(TDto));
            var auditory = _mapper.Map<TRepositoryModel>(entity);
            return _mapper.Map<TDto>(await _dataAccessFacade.CreateAsync(auditory));
        }

        public async Task DeleteAsync(int? id)
        {
            _logger.LogInformation("Deleting object of type {Type} with id={Id}", typeof(TDto), id);
            if (id is null)
            {
                throw new NullIdException();
            }
            await _dataAccessFacade.DeleteAsync((int)id);
        }

        public async Task<TDto> GetByIdAsync(int? id)
        {
            _logger.LogInformation("Getting object of type {Type} with id={Id}", typeof(TDto), id);
            if (id is null)
            {
                throw new NullIdException();
            }
            return _mapper.Map<TDto>(await _dataAccessFacade.GetByIdAsync((int)id));
        }

        public async Task<TDto> UpdateAsync(TDto entity)
        {
            _logger.LogInformation("Updating object of type {Type}", typeof(TDto));
            var auditory = _mapper.Map<TRepositoryModel>(entity);
            return _mapper.Map<TDto>(await _dataAccessFacade.UpdateAsync(auditory));
        }
    }
}

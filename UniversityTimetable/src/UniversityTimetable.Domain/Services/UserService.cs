﻿using System.Security.Claims;
using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Exceptions.DomainExceptions;
using UniversityTimetable.Shared.Extensions;
using UniversityTimetable.Shared.Interfaces.Auth;
using UniversityTimetable.Shared.Interfaces.Repositories;
using UniversityTimetable.Shared.Interfaces.Services;
using UniversityTimetable.Shared.Models;
using UniversityTimetable.Shared.Models.RelationModels;

namespace UniversityTimetable.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly IBaseService<UserDto> _baseService;
    private readonly IRelationRepository<User, Auditory, UserAuditory> _userAuditoryRelations;
    private readonly IRelationRepository<User, Group, UserGroup> _userGroupRelations;
    private readonly IRelationRepository<User, Teacher, UserTeacher> _userTeacherRelations;
    private readonly IAuthenticationService _authenticationService;

    public UserService(IUserRepository repository, IMapper mapper, ILogger<UserService> logger,
        IBaseService<UserDto> baseService,
        IRelationRepository<User, Auditory, UserAuditory> userAuditoryRelations,
        IRelationRepository<User, Group, UserGroup> userGroupRelations,
        IRelationRepository<User, Teacher, UserTeacher> userTeacherRelations,
        IAuthenticationService authenticationService)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _baseService = baseService;
        _userAuditoryRelations = userAuditoryRelations;
        _userGroupRelations = userGroupRelations;
        _userTeacherRelations = userTeacherRelations;
        _authenticationService = authenticationService;
    }

    public async Task<UserDto> CreateAsync(UserDto entity)
    {
        var errors = await ValidateAsync(entity);
        if (errors.Any())
        {
            _logger.LogAndThrowException(new ValidationException(typeof(UserDto), errors));
        }

        return await _baseService.CreateAsync(entity);
    }

    public Task DeleteAsync(int? id)
        => _baseService.DeleteAsync(id);

    public async Task<UserDto> GetByIdAsync(int? id)
    {
        if (id is null)
        {
            throw new NullIdException();
        }

        return _mapper.Map<UserDto>(await _repository.GetByIdAsync((int)id));
    }

    public async Task<UserDto> UpdateAsync(UserDto entity)
    {
        var errors = await ValidateAsync(entity);
        if (errors.Any())
        {
            _logger.LogAndThrowException(new ValidationException(typeof(UserDto), errors));
        }

        return await _baseService.UpdateAsync(entity);
    }

    public Task<Dictionary<string, string>> ValidateAsync(UserDto user)
    {
        return _repository.ValidateAsync(_mapper.Map<User>(user));
    }

    public Task SaveAuditory(ClaimsPrincipal user, int auditoryId)
    {
        _authenticationService.VerifyUser(user);
        return _userAuditoryRelations.CreateRelation(user.GetId(), auditoryId);
    }

    public Task RemoveSavedAuditory(ClaimsPrincipal user, int auditoryId)
    {
        _authenticationService.VerifyUser(user);
        return _userAuditoryRelations.DeleteRelation(user.GetId(), auditoryId);
    }

    public Task SaveGroup(ClaimsPrincipal user, int groupId)
    {
        _authenticationService.VerifyUser(user);
        return _userGroupRelations.CreateRelation(user.GetId(), groupId);
    }

    public Task RemoveSavedGroup(ClaimsPrincipal user, int groupId)
    {
        _authenticationService.VerifyUser(user);
        return _userGroupRelations.DeleteRelation(user.GetId(), groupId);
    }

    public Task SaveTeacher(ClaimsPrincipal user, int teacherId)
    {
        _authenticationService.VerifyUser(user);
        return _userTeacherRelations.CreateRelation(user.GetId(), teacherId);
    }

    public Task RemoveSavedTeacher(ClaimsPrincipal user, int teacherId)
    {
        _authenticationService.VerifyUser(user);
        return _userTeacherRelations.DeleteRelation(user.GetId(), teacherId);
    }
}
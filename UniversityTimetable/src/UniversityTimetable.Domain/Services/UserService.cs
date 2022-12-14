using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Exceptions.DomainExceptions;
using UniversityTimetable.Shared.Interfaces.Auth;
using UniversityTimetable.Shared.Interfaces.Domain.Validation;
using UniversityTimetable.Shared.Interfaces.DataAccess;
using UniversityTimetable.Shared.Interfaces.Domain;

namespace UniversityTimetable.Domain.Services;

public class UserService : IUserService
{
    private readonly IBaseService<UserDto> _baseService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserDataAccessFacade _userDataAccessFacade;
    private readonly ICreateValidator<UserDto> _createValidator;
    private readonly IUpdateValidator<UserDto> _updateValidator;
    private readonly IUpdateValidator<PasswordChangeDto> _passwordChangeValidator;

    public UserService(IBaseService<UserDto> baseService,
        IAuthenticationService authenticationService, IUpdateValidator<PasswordChangeDto> passwordChangeValidator,
        IUserDataAccessFacade userDataAccessFacade, IUpdateValidator<UserDto> updateValidator, ICreateValidator<UserDto> createValidator)
    {
        _baseService = baseService;
        _authenticationService = authenticationService;
        _passwordChangeValidator = passwordChangeValidator;
        _userDataAccessFacade = userDataAccessFacade;
        _updateValidator = updateValidator;
        _createValidator = createValidator;
    }

    public Task<UserDto> CreateAsync(UserDto entity)
        => _baseService.CreateAsync(entity);

    public Task DeleteAsync(int? id)
        => _baseService.DeleteAsync(id);

    public Task<UserDto> GetByIdAsync(int? id)
        => _baseService.GetByIdAsync(id);

    public Task<UserDto> UpdateAsync(UserDto entity)
        => _baseService.UpdateAsync(entity);

    public async Task<List<KeyValuePair<string, string>>> ValidateCreateAsync(UserDto user)
    {
        return await _createValidator.ValidateAsync(user);
    }

    public async Task<List<KeyValuePair<string, string>>> ValidateUpdateAsync(UserDto user)
    {
        return await _updateValidator.ValidateAsync(user);
    }

    public async Task<PasswordChangeDto> ChangePassword(PasswordChangeDto passwordChange)
    {
        var errors = await _passwordChangeValidator.ValidateAsync(passwordChange);
        if (errors.Any())
        {
            throw new ValidationException(typeof(PasswordChangeDto), errors);
        }

        await _userDataAccessFacade.ChangePassword(passwordChange);
        return passwordChange;
    }

    public async Task<List<KeyValuePair<string, string>>> ValidatePasswordChange(PasswordChangeDto passwordChange)
    {
        return await _passwordChangeValidator.ValidateAsync(passwordChange);
    }

    public Task SaveAuditory(int userId, int auditoryId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.SaveAuditory(userId, auditoryId);
    }

    public Task RemoveSavedAuditory(int userId, int auditoryId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.RemoveSavedAuditory(userId, auditoryId);
    }

    public Task SaveGroup(int userId, int groupId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.SaveGroup(userId, groupId);
    }

    public Task RemoveSavedGroup(int userId, int groupId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.RemoveSavedGroup(userId, groupId);
    }

    public Task SaveTeacher(int userId, int teacherId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.SaveTeacher(userId, teacherId);
    }

    public Task RemoveSavedTeacher(int userId, int teacherId)
    {
        _authenticationService.VerifyUser(userId);
        return _userDataAccessFacade.RemoveSavedTeacher(userId, teacherId);
    }
}
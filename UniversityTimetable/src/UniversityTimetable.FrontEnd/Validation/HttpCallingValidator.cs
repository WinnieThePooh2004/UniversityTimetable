using FluentValidation;
using FluentValidation.Results;
using UniversityTimetable.FrontEnd.Requests.Interfaces.Validation;

namespace UniversityTimetable.FrontEnd.Validation;

public class HttpCallingValidator<T> : IValidator<T>
{
    private readonly IValidator<T> _baseValidator;
    private readonly IValidationRequests<T> _validationRequests;

    public HttpCallingValidator(IValidator<T> baseValidator, IValidationRequests<T> validationRequests)
    {
        _baseValidator = baseValidator;
        _validationRequests = validationRequests;
    }

    public ValidationResult Validate(IValidationContext context) => _baseValidator.Validate(context);

    public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = new CancellationToken()) 
        => ValidateAsync((T)context.InstanceToValidate, cancellation);

    public IValidatorDescriptor CreateDescriptor()
        => _baseValidator.CreateDescriptor();


    public bool CanValidateInstancesOfType(Type type)
        => _baseValidator.CanValidateInstancesOfType(type);

    public ValidationResult Validate(T instance)
        => _baseValidator.Validate(instance);

    public async Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellation = new CancellationToken())
    {
        var baseResult = await _baseValidator.ValidateAsync(instance, cancellation);
        if (baseResult.Errors.Any())
        {
            return baseResult;
        }

        var serverErrors = await _validationRequests.ValidateAsync(instance);
        baseResult.Errors.AddRange(serverErrors.Select(e => new ValidationFailure(e.Key, e.Value)));
        return baseResult;
    }
}
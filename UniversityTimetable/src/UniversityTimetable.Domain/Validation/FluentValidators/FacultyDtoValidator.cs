using FluentValidation;
using UniversityTimetable.Shared.DataTransferObjects;

namespace UniversityTimetable.Domain.Validation.FluentValidators;

public class FacultyDtoValidator : AbstractValidator<FacultyDto>
{
    public FacultyDtoValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .WithMessage("Please, enter name");
    }
}
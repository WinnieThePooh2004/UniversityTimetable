﻿
using FluentValidation;
using UniversityTimetable.Shared.DataTransferObjects;

namespace UniversityTimetable.Domain.Validation;

public class AuditoryDtoValidator : AbstractValidator<AuditoryDto>
{
    public AuditoryDtoValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .WithMessage("Please, enter name");

        RuleFor(t => t.Building)
            .NotEmpty()
            .WithMessage("Please, enter building`s name");
    }
}
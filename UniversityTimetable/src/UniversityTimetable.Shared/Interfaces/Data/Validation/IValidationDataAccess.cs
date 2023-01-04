﻿using UniversityTimetable.Shared.Interfaces.Data.Models;

namespace UniversityTimetable.Shared.Interfaces.Data.Validation;

public interface IValidationDataAccess<TModel>
    where TModel : class, IModel
{
    Task<TModel> LoadRequiredDataForCreateAsync(TModel model);
    Task<TModel> LoadRequiredDataForUpdateAsync(TModel model);
}
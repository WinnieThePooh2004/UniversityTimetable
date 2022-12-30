﻿using Microsoft.AspNetCore.Components;
using UniversityTimetable.FrontEnd.Requests.Interfaces;

namespace UniversityTimetable.FrontEnd.Components.PageBases;

public abstract class CreatePageBase<TData> : ComponentBase
{
    [Inject] private IBaseRequests<TData> Requests { get; init; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;
    protected abstract string PageAfterSave { get; }

    protected virtual async Task Save(TData model)
    {
        await Requests.CreateAsync(model);
        Navigation.NavigateTo(PageAfterSave);
    }
}
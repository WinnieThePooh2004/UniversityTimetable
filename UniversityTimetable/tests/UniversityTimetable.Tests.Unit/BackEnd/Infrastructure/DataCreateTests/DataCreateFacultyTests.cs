﻿using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Tests.Unit.BackEnd.Infrastructure.DataCreateTests;

public class DataCreateFacultyTests : DataCreateTests<Faculty>
{
    [Fact] protected override Task Create_AddedToContext() => base.Create_AddedToContext();
}
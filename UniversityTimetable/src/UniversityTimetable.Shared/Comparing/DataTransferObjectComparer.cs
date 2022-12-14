using System.Diagnostics.CodeAnalysis;
using UniversityTimetable.Shared.Interfaces.Data.Models;

namespace UniversityTimetable.Shared.Comparing;

public class DataTransferObjectComparer<T> : IEqualityComparer<T>
    where T : class, IDataTransferObject
{
    public bool Equals(T? x, T? y)
    {
        if(x is null || y is null)
        {
            return x == y;
        }
        return x.Id == y.Id;
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        return obj.Id;
    }
}
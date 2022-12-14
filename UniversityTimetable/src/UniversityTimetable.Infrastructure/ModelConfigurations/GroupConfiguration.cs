using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Infrastructure.ModelConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasQueryFilter(g => !g.IsDeleted)
                .HasOne(g => g.Department)
                .WithMany(d => d.Groups)
                .HasForeignKey(g => g.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

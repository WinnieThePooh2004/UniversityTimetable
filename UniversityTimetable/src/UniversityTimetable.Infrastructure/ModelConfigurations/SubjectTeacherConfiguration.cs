﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Infrastructure.ModelConfigurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.HasOne(s => s.Teacher)
                .WithMany(s => s.SubjectIds)
                .HasForeignKey(s => s.TeacherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Subject)
                .WithMany(s => s.TeacherIds)
                .HasForeignKey(s => s.SubjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
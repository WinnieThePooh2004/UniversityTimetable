﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityTimetable.Infrastructure;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221217184332_AddedUsersTable")]
    partial class AddedUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuditoryUser", b =>
                {
                    b.Property<int>("SavedAuditoriesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("SavedAuditoriesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AuditoryUser");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("SavedGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("SavedGroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("TeacherUser", b =>
                {
                    b.Property<int>("SavedTeachersId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("SavedTeachersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TeacherUser");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Auditory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auditories");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditoryId")
                        .HasColumnType("int");

                    b.Property<int>("ClassType")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("WeekDependency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditoryId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacultacyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultacyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.SubjectTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeachers");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserAuditory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuditories");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTeachers");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScienceDegree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuditoryUser", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Auditory", null)
                        .WithMany()
                        .HasForeignKey("SavedAuditoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("SavedGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherUser", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("SavedTeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Class", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Auditory", "Auditory")
                        .WithMany("Classes")
                        .HasForeignKey("AuditoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.Group", "Group")
                        .WithMany("Classes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditory");

                    b.Navigation("Group");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Department", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Faculty", "Facultacy")
                        .WithMany("Departments")
                        .HasForeignKey("FacultacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facultacy");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Group", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.SubjectTeacher", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Subject", "Subject")
                        .WithMany("TeacherIds")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.Teacher", "Teacher")
                        .WithMany("SubjectIds")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserAuditory", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Auditory", "Auditory")
                        .WithMany("UserIds")
                        .HasForeignKey("AuditoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", "User")
                        .WithMany("SavedAuditoriesIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserGroup", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Group", "Group")
                        .WithMany("UserIds")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", "User")
                        .WithMany("SavedGroupIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.RelationModels.UserTeacher", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Teacher", "Teacher")
                        .WithMany("UsersIds")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimetable.Shared.Models.User", "User")
                        .WithMany("SavedTeacherIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Teacher", b =>
                {
                    b.HasOne("UniversityTimetable.Shared.Models.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Auditory", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("UserIds");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Department", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Faculty", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Group", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("UserIds");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Subject", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("TeacherIds");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("SubjectIds");

                    b.Navigation("UsersIds");
                });

            modelBuilder.Entity("UniversityTimetable.Shared.Models.User", b =>
                {
                    b.Navigation("SavedAuditoriesIds");

                    b.Navigation("SavedGroupIds");

                    b.Navigation("SavedTeacherIds");
                });
#pragma warning restore 612, 618
        }
    }
}
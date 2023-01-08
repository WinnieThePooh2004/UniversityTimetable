﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityTimetable.Infrastructure;
using UniversityTimetable.Tests.Integration.TestDatabase;

namespace UniversityTimetable.Tests.Integration.AppFactories;

public class ApplicationFactory : WebApplicationFactory<Program>
{
    public ApplicationDbContext Context { get; }

    public ApplicationFactory()
    {
        Context = TestDatabaseFactory.CreateContext();
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();
        Context.SeedData();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(_ =>
                services.GetType() == typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }
            services.AddSingleton(Context);
        });
    }
}
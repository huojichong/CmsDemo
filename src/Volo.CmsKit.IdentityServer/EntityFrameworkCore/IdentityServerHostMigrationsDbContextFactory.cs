﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Volo.CmsKit.EntityFrameworkCore;

public class IdentityServerHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<IdentityServerHostMigrationsDbContext>
{
    public IdentityServerHostMigrationsDbContext CreateDbContext(string[] args)
    {
        FeatureConfigurer.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<IdentityServerHostMigrationsDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Npg"));

        return new IdentityServerHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

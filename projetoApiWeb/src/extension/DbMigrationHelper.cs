using Database.service;
using Microsoft.EntityFrameworkCore;

namespace projetoApiWeb.src.extension;

public static class DbMigrationHelper
{
    public static void ApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
    }
}
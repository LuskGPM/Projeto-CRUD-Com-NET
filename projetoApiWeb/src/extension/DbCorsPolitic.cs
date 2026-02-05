namespace projetoApiWeb.src.extension;

public static class DbCorsPolitic
{
    public static void ApplyCorsPolitic(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MinhaAppVue", policy =>
            {
                policy.WithOrigins("http://localhost:5173", "https://projeto-crud-com-net.vercel.app")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}
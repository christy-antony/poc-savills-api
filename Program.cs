using poc_savills_api.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var SavillsAllowSpecificOrigins = "_SavillsAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options => {
            options.AddPolicy(name: SavillsAllowSpecificOrigins, policy => {
                policy.WithOrigins("http://localhost:4200");            
            });
        });
        // Add services to the container.
        builder.Services.AddScoped<ITemplateService, TemplateService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(SavillsAllowSpecificOrigins);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
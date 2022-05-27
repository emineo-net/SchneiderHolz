using Microsoft.EntityFrameworkCore;
using SchneiderHolzApi.Authorization;
using SchneiderHolzApi.Helpers;
using SchneiderHolzApi.Services;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    var env = builder.Environment;
 
    if (env.IsProduction())
    {
        services.AddDbContext<DataContext>();
    }
    else
    {
        services.AddDbContext<DataContext>();
       //services.AddDbContext<DataContext, SqliteDataContext>();
    }
    services.AddCors();
    services.AddControllers();
    services.AddSwaggerGen();
    services.AddAutoMapper(typeof(Program));
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
}
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();    
    dataContext.Database.Migrate();
}

{
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseMiddleware<JwtMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.MapControllers();
}
app.Run("http://localhost:4000");
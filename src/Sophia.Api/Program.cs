using Microsoft.EntityFrameworkCore;
using Sophia.Api.DbContext;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContextPool<SophiaContext>(options =>
	 options.UseMySql(
	 	builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
	).UseSnakeCaseNamingConvention()
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

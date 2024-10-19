using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.Middlewares;
using PavelVasilevKT_31_21.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
	builder.Logging.ClearProviders();
	builder.Host.UseNLog();
	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddServices();

	builder.Services.AddDbContext<TeachersDbContext>(options =>
	{
		options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
	});

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseMiddleware<ExceptionHandlerMiddleware>();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch(Exception ex)
{
	logger.Error(ex, "Something went wrong");
}
finally
{
	LogManager.Shutdown();
}

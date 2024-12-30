using MiniPerson.Endpoints.API;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.Services.AddSwaggerGen();

    var app = builder.AddZaminSerilog(c =>
    {
        c.ApplicationName = "MiniBlog";
        c.ServiceName = "MiniBlogService";
        c.ServiceVersion = "1.0";
    }).ConfigureServices().ConfigurePipeline();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.Run();
});

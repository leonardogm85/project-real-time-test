using RealTimeTest.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("Default", configure =>
    {
        configure
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true);
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseCors("Default");

app.MapHub<DateTimeHub>("/DateTimeHub");

app.Run();

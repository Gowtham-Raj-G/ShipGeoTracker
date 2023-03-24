using Microsoft.EntityFrameworkCore;
using ShipGeoTracker.Api;
using ShipGeoTracker.Api.Services;
using ShipGeoTracker.Api.Services.Interfaces;
using ShipGeoTracker.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShipGeoTrackerContext>(o => o.UseSqlServer(Environment.GetEnvironmentVariable("ShipGeoTrackerDatabase") ?? builder.Configuration.GetConnectionString("ShipGeoTrackerDatabase"),
                  x => x.MigrationsAssembly("ShipGeoTracker.Database")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy(Constants.ALLOW_SPECIFIC_ORIGIN, configurePolicy =>
        {
            configurePolicy.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });

//service registration
builder.Services.AddTransient<IShipService, ShipService>();
builder.Services.AddTransient<IPortService, PortService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(Constants.ALLOW_SPECIFIC_ORIGIN);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Seed();
app.Run();

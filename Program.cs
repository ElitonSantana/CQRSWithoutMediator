using CQRSWithoutMediator;
using CQRSWithoutMediator.Infra.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceCollectionExtension.ConfigureServices(builder.Services);
ServiceCollectionExtension.ConfigureRepositorys(builder.Services);
ServiceCollectionExtension.ConfigureHandlers(builder.Services);

//MongoDD Settings Configure
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<IMongoSettings>(serviceProvider =>
        serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);

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
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





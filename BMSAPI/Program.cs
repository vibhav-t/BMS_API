using BMSAPI.Entities;
using BMSAPI.ExceptionMiddleware;
using BMSAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "blog.json");
builder.Services.AddSingleton(new JsonFileService(filePath));
builder.Services.AddApplicationServices();

builder.Services.AddControllers();

//Adding cors policy
builder.Services.AddCors(opt=>{
    opt.AddPolicy("_AllowedOriginPolicy", builder => builder
    .SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200", "*"));
});
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
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("_AllowedOriginPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

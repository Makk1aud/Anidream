using Anidream.API.Extensions;
using Anidream.API.Extensions.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices(builder.Configuration);

builder.Services.AddCors(options => 
    options.AddPolicy(
        "AllowAll",
        p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Инициализация БД
app.EnsureDbCreated();

// Configure the HTTP request pipeline.
//Todo: Убрать свагер с автозагрузки
app.UseSwagger();
app.UseSwaggerUI();
// if (app.Environment.IsDevelopment())
// {
// }
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
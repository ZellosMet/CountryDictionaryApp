using CountryDictionaryApp.Entity;
using CountryDictionaryApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();
//Получаем сервис DBContext 
ApplicationDbContext db = app.Services.GetService<ApplicationDbContext>();
//Выполняем автомиграцию перед запуском приложения
db.Database.Migrate();


//Тест сервера
app.MapGet("/", () => new { Message = "Server is running" });
app.MapGet("/ping", () => new { Message = "pong" });

//Получение списка стран
app.MapGet("/country", async (ApplicationDbContext db) => await db.Countries.ToListAsync());

//Добавление страны
app.MapPost("/country", async (Country country, ApplicationDbContext db) =>
{
    await db.Countries.AddAsync(country);
    await db.SaveChangesAsync();
    return country;
});

//Запрос на получение страны по id
app.MapGet("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Countries.FirstOrDefaultAsync(c => c.Id == id);
});

//Запрос на получение страны по коду
app.MapGet("/api/country/{code:alpha}", async (string code, ApplicationDbContext db) =>
{
    Country country = await db.Countries.FirstOrDefaultAsync(d => d.ISO31661Alpha2Code == code || d.ISO31661Alpha3Code == code || d.ISO31661NumericCode == code );
    return country;
});

app.Run();

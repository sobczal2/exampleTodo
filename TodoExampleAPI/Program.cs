using Microsoft.EntityFrameworkCore;
using TodoExampleAPI;

var builder = WebApplication.CreateBuilder(args);


// konfugurujemy tu serwisy
// głównie konfiguracja Dependency injection

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// konfiguracja bazy danych dla TodoDbContext
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlite("Data Source=todo.db");
});

var app = builder.Build();





// konfiguracja pipelinu -  w tej kolejności wykonują się metody na przychodzących zapytaniach
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
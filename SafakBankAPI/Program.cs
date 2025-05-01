using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Veritaban� ve model olu�turma i�lemi i�in gerekli kodlar
while (true)
{
    Console.WriteLine("Veritaban� ve model olu�turmak istiyor musunuz (y/N)");
    string? test = Console.ReadLine();
    if (test == "y" || test == "Y")
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureDeleted(); // Veritaban�n� siler
            dbContext.Database.EnsureCreated(); // Veritaban� yoksa olu�turur
        }
        break; // Exit the loop if the database is created
    }
    else if (test == "" || test == "n" || test == "N")
    {
        Console.WriteLine("Veritaban� ve model olu�turulmad�.");
        break; // Exit the loop if the user chooses not to create the database
    }
    else
    {
        Console.WriteLine("Ge�ersiz giri�. L�tfen 'y' veya 'n' girin.");
    }
}

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

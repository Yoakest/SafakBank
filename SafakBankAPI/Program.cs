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

// Veritabaný ve model oluþturma iþlemi için gerekli kodlar
while (true)
{
    Console.WriteLine("Veritabaný ve model oluþturmak istiyor musunuz (y/N)");
    string? test = Console.ReadLine();
    if (test == "y" || test == "Y")
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureDeleted(); // Veritabanýný siler
            dbContext.Database.EnsureCreated(); // Veritabaný yoksa oluþturur
        }
        break; // Exit the loop if the database is created
    }
    else if (test == "" || test == "n" || test == "N")
    {
        Console.WriteLine("Veritabaný ve model oluþturulmadý.");
        break; // Exit the loop if the user chooses not to create the database
    }
    else
    {
        Console.WriteLine("Geçersiz giriþ. Lütfen 'y' veya 'n' girin.");
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

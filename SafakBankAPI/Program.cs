using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;
using SafakBankAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS ayarları
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddScoped<GenerateUserCode>(); // GenerateUserCode sınıfını DI konteynerine ekle
builder.Services.AddScoped<EmailChecker>(); // EmailChecker sınıfını DI konteynerine ekle

builder.Services.AddSingleton<JwtHelper>();

var app = builder.Build();

// Veritaban� ve model olu�turma i�lemi i�in gerekli kodlar
while (true)
{
    Console.WriteLine("Veritabanı ve model oluşturmak istiyor musunuz (y/N)");
    string? test = Console.ReadLine();
    if (test == "y" || test == "Y")
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            dbContext.Database.EnsureDeleted(); // Veritabanını siler

            dbContext.Database.EnsureCreated(); // Veritabanı yoksa oluşturur
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

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using RestaurantBill.Application.Interfaces;
using RestaurantBill.Infrastructure.Context;
using RestaurantBill.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RestaurantDbContext>(options => 
options.UseNpgsql(connectionString));
//-----------------------------------
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()   // Her yerden gelene izin ver (Frontend 5173, Postman vs.)
               .AllowAnyMethod()   // GET, POST, PUT hepsine izin ver
               .AllowAnyHeader();  // Tüm başlıklara izin ver
    });
});
/* belli başlı şeylere izin vermek için yapılır
builder.Services.AddCors(options =>
{
    // Politika adını değiştirebilirsin (Örn: "OzelGuvenlik")
    options.AddPolicy("OzelGuvenlik", builder =>
    {
        // 1. KİM GELEBİLİR? (Origins)
        // Sadece senin Frontend projene ve ilerideki canlı siteye izin ver.
        builder.WithOrigins("http://localhost:5173", "https://restoran.com")
        
        // 2. NE YAPABİLİR? (Methods)
        // Sadece veri çeksin (GET) ve veri göndersin (POST).
        // Silme (DELETE) veya Güncelleme (PUT) yapamasın diyorsan onları yazma.
               .WithMethods("GET", "POST")
               
        // 3. HANGİ BAŞLIKLAR? (Headers)
        // Genelde Authorization (Şifre) başlıkları için buna izin verilir.
               .AllowAnyHeader();
    });
});
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();
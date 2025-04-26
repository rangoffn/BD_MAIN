using Microsoft.EntityFrameworkCore;
using BACKENDD.Models;
using BACKENDD.Data; // для DbInitializer

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер
builder.Services.AddScoped<IContactService, ContactService>();  // Регистрируем сервис

// Подключение к базе данных PostgreSQL через Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление сервисов для работы с контроллерами и представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Инициализация базы данных с начальными данными
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(context);  // Инициализация данных
}

// Настройка обработки запросов
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Защищенный HTTP
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Подключаем авторизацию, если требуется
app.UseAuthorization();

app.MapControllerRoute(
    name: "showcontacts",
    pattern: "Contact/ShowContacts",
    defaults: new { controller = "Contact", action = "ShowContacts" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Запуск приложения
app.Run();

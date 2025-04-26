using Microsoft.EntityFrameworkCore;
using BACKENDD.Models;
using BACKENDD.Data; // ��� DbInitializer

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ���������
builder.Services.AddScoped<IContactService, ContactService>();  // ������������ ������

// ����������� � ���� ������ PostgreSQL ����� Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� �������� ��� ������ � ������������� � ���������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������������� ���� ������ � ���������� �������
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(context);  // ������������� ������
}

// ��������� ��������� ��������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // ���������� HTTP
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ���������� �����������, ���� ���������
app.UseAuthorization();

app.MapControllerRoute(
    name: "showcontacts",
    pattern: "Contact/ShowContacts",
    defaults: new { controller = "Contact", action = "ShowContacts" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ������ ����������
app.Run();

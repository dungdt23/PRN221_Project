using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.Business.Mapping;
using PRN221_Project1._0.Business.Repository;
using PRN221_Project1._0.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<ILectureRepository, LectureRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
builder.Services.AddTransient<ISessionRepository, SessionRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
builder.Services.AddTransient<ISlotRepository, SlotRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.Run();

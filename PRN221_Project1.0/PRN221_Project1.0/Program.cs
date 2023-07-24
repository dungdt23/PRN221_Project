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

//lecture
builder.Services.AddTransient<ILectureRepository, LectureRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//session
builder.Services.AddTransient<ISessionRepository, SessionRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//slot
builder.Services.AddTransient<ISlotRepository, SlotRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//group
builder.Services.AddTransient<IGroupRepository, GroupRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//enroll
builder.Services.AddTransient<IEnrollRepository, EnrollRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//student
builder.Services.AddTransient<IStudentRepository, StudentRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//attendance
builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//term
builder.Services.AddTransient<ITermRepository, TermRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//subject
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//campus
builder.Services.AddTransient<ICampusRepository, CampusRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//course
builder.Services.AddTransient<ICourseRepository, CourseRepository>()
    .AddDbContext<Prn221MyAssignmentContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));
//room
builder.Services.AddTransient<IRoomRepository, RoomRepository>()
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");
});

app.Run();

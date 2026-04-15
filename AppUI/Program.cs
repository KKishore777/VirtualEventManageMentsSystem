
using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===============================
//  1. Add MVC Services
// ===============================
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

// ===============================
//  2. Configure Database (EF Core)
// ===============================
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===============================
//  3. Register DAL Services (Dependency Injection)
// ===============================
builder.Services.AddScoped<IUserRepository<UserInfo>, UserServices>();
builder.Services.AddScoped<IEventRepository<EventDetails>, EventServices>();
builder.Services.AddScoped<ISessionRepository<SessionInfo>, SessionServices>();
builder.Services.AddScoped<ISpeakerRepository<SpeakersDetails>, SpeakerServises>();
builder.Services.AddScoped<IParticipantEventRepository, ParticipantEventServices>();

// ===============================
//  4. Add Session (for Login)
// ===============================
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ===============================
//  5. Middleware Pipeline
// ===============================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//  Enable Session Middleware
app.UseSession();

app.UseAuthorization();

// ===============================
// 6. Routing Configuration
// ===============================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Common}/{action=Home}/{id?}");

app.Run();

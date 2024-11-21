using Microsoft.AspNetCore.Authentication.Cookies;
using BLL.UserBLL;
using BLL.TournamentBLL;
using DAL.UserDAL;
using DAL.TournamentDAL;
using BLL.Interfaces;
using DAL.TeamDAL;
using BLL.TeamBLL;
using BLL.PlayerBLL;
using DAL.PlayerDAL;
using BLL.MatchBLL;
using DAL.MatchDAL;
using DAL.LocationDAL;
using BLL.LocationBLL;
using DAL.NationalityDAL;
using BLL.NationalityBLL;
using BLL.TournamentTypeBLL;
using DAL.TournamentTypeDAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/AccessDenied");
    }
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ADMIN", policy => policy.RequireClaim("Role", "ADMIN"));
});

builder.Services.AddRazorPages();
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserDataAccessLayer));
builder.Services.AddScoped(typeof(UserLogicLayer));
builder.Services.AddScoped(typeof(ITournamentRepository), typeof(TournamentDataAccessLayer));
builder.Services.AddScoped(typeof(TournamentLogicLayer));
builder.Services.AddScoped(typeof(ITeamRepository), typeof(TeamDataAccessLayer));
builder.Services.AddScoped(typeof(TeamLogicLayer));
builder.Services.AddScoped(typeof(IPlayerRepository), typeof(PlayerDataAccessLayer));
builder.Services.AddScoped(typeof(PlayerLogicLayer));
builder.Services.AddScoped(typeof(IMatchRepository), typeof(MatchDataAccessLayer));
builder.Services.AddScoped(typeof(MatchLogicLayer));
builder.Services.AddScoped(typeof(ILocationRepository), typeof(LocationDataAccessLayer));
builder.Services.AddScoped(typeof(LocationLogicLayer));
builder.Services.AddScoped(typeof(INationalityRepository), typeof(NationalityDataAccessLayer));
builder.Services.AddScoped(typeof(NationalityLogicLayer));
builder.Services.AddScoped(typeof(ITournamentTypeRepository), typeof(TournamentTypeDataAccessLayer));
builder.Services.AddScoped(typeof(TournamentTypeLogicLayer));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

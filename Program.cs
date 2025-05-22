using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderApp_Advanced.Data;
using ResumeBuilderApp_Advanced.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddScoped<ResumePdfGenerator>();
builder.Services.AddScoped<ResumeDocxExporter>();
builder.Services.AddScoped<ResumeHtmlExporter>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
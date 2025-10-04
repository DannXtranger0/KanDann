using KanDann.Server.Models.Context;
using KanDann.Server.Repositories.User;
using KanDann.Server.Services.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.OpenApi;  

using Scalar.AspNetCore;
using KanDann.Server.Services.User;
using KanDann.Server.Services.Workplace;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Configuration / DB
// ----------------------
var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    // EF logging to console for debugging migrations/queries
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

// ----------------------
// App services
// ----------------------
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Si tienes un TokenService/ITokenService:
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();


builder.Services.AddScoped<IWorkplaceService, WorkplaceService>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();

// ----------------------
// CORS - permitir solo tu frontend dev
// ----------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:56205")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ----------------------
// Authentication (Cookie + OIDC Google)
// ----------------------
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie.Name = ".bff.session";
    options.Cookie.HttpOnly = true;
    // Cuando el frontend est� en otro origen, SameSite=None + Secure=true es necesario
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    // Google OIDC
    options.Authority = "https://accounts.google.com";
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new Exception("Missing Google ClientId");
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("Missing Google ClientSecret");
    options.ResponseType = "code";
    options.UsePkce = true;
    
    // pedir claims
    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

    // Guardar tokens en AuthenticationProperties (server side). �til si luego llamas Google APIs desde el servidor.
    options.SaveTokens = true;

    // No mapear autom�ticamente claims a tipos MS (dejamos los nombres raw como 'sub', 'email', 'name', 'picture')
    options.MapInboundClaims = false;

    // Callback path (debe coincidir con lo registrado en Google)
    options.CallbackPath = "/signin-oidc";

    // Opcional: manejo de errores remotos simple
    options.Events = new OpenIdConnectEvents
    {
        OnRemoteFailure = ctx =>
        {
            ctx.HandleResponse();
            ctx.Response.Redirect("/?error=external_auth_failed");
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddOpenApi();

var app = builder.Build();

// ----------------------
// Middleware pipeline
// ----------------------
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseCors("AllowFrontend");

// HTTPS redirection (debes usar certificados dev)
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

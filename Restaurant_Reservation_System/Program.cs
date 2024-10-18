using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using Restaurant_Reservation_System.Authentication;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.IService;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Service;
using Restaurant_Reservation_System.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantConnection")));



//builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IReviewService,ReviewService>();
builder.Services.AddScoped<IRestaurantServices, RestaurantServices>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IUserServices, UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("RestaurantConnection")));
    builder.Services.AddDbContext<RestaurantDatabaseContext>();
    // For Identity
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<RestaurantDbContext>()
          .AddDefaultTokenProviders();

    builder.Services.AddScoped<IUserServices, UserServices>();
    builder.Services.AddScoped<IReviewService, ReviewService>();
    builder.Services.AddScoped<IRestaurantServices, RestaurantServices>();
    builder.Services.AddScoped<IReservationService, ReservationService>();
    builder.Services.AddScoped<IMenuService, MenuService>();
    builder.Services.AddScoped<IMenuItemService, MenuItemService>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<ITableService, TableService>();
    //builder.Services.AddControllersWithViews();


    // Adding Authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })

    // Adding Jwt Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();


    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "please Enter Token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    //app.UseSession(); // Use session after authentication and authorization

    app.MapControllers();

    app.Run();
}*/
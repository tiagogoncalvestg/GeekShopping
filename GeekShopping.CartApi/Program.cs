using AutoMapper;
using GeekShopping.CartApi.Models.Contexts;
using GeekShopping.CartApi.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using GeekShopping.CartApi.Repositories;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICartRepository, CartRepository>();

builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt =>
{
    opt.Authority = "https://localhost:4435/";
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(
        opt =>
        {
            opt.AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "geek_shopping");
            });
        }
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GeekShopping.CartApi",
        Description = "Api para acesso aos serviços do carrinho de compra de GeekShopping.com.",
        Contact = new OpenApiContact
        {
            Name = "Tiago Gonçalves",
            Url = new Uri("https://github.com/tiagogoncalvestg/GeekShopping")
        },
        Version = "v1"
    });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },

                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string> ()

        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


});

builder.Services.AddDbContext<MyContext>(opt => opt.UseSqlite("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

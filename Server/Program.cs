using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Server.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("CustomCorsPolicy",
		policy =>
		{
			policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
		});
});


builder.Services.AddDbContext<AppDBContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	};
});

// to create automatic  mapping
builder.Services.AddAutoMapper(typeof(DTOMappings));

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
});

// ================================================
// Convert all API Uri to lower case
// ================================================

builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
});

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseSwagger();

app.UseSwaggerUI(swaggerUIOptions =>
{
	swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "AlvaroDev API");
});

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseCors("CustomCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();

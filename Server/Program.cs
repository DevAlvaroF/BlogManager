using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Data;

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

app.UseAuthorization();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();

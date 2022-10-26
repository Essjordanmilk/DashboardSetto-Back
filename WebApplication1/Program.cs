using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .WithMethods("PUT", "DELETE", "GET", "POST")
            .AllowAnyHeader();
        });
});
// Add services to the container.
builder.Services.AddDbContext<WebApplication1.Models.SETTOContext>(options => options.UseSqlServer("Server=DESKTOP-D4K75HQ\\SQLEXPRESS;Database=SETTO;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.DAL.Implementations;
using NPOI.SS.Formula.Functions;
using PaySlipManagement.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDepartmentBALRepo, DepartmentBALRepo>();
builder.Services.AddScoped<IEmployeeBALRepo,EmployeeBALRepo>();
builder.Services.AddScoped<IAccountDetailsBALRepo, AccountDetailsBALRepo>();
builder.Services.AddScoped<ISalaryBALRepo, SalaryBALRepo>();
builder.Services.AddScoped<IUserRoleBALRepo, UserRoleBALRepo>();
builder.Services.AddScoped<IRoleBALRepo, RoleBALRepo>();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

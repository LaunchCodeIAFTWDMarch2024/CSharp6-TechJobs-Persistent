﻿using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;

var builder = WebApplication.CreateBuilder(args);

//db connection
var connectionString = builder.Configuration["techjobsConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JobDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Job}/{action=Index}/{id?}");

app.Run();


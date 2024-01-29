using Microsoft.EntityFrameworkCore;
using TareaRegistroPrioridades.Components;
using TareaRegistroPrioridades.DAL;
using TareaRegistroPrioridades.SERVICES;

namespace TareaRegistroPrioridades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var ConStr = builder.Configuration.GetConnectionString("ConStr");

            builder.Services.AddDbContext<Contexto>(options =>
            options.UseSqlite(ConStr));

            builder.Services.AddScoped<PrioridadSERVICES>();
            builder.Services.AddScoped<ClientesSERVICES>();
            builder.Services.AddScoped<TicketsSERVICES>();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

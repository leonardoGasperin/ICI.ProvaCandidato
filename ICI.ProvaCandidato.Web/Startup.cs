using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.DbContexts;
using ICI.ProvaCandidato.Negocio.Interfaces;
using ICI.ProvaCandidato.Negocio.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ICI.ProvaCandidato.Web
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(opt =>
            {
                opt.DescribeAllParametersInCamelCase();
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ICI Noticias", Version = "v1" });
            });
            services.AddDbContext<SqliteContext>(opt =>
			{
                opt.UseSqlite(Configuration
                   .GetConnectionString("DefaultConnection"))
                   .UseLazyLoadingProxies();
            });
			services.AddTransient<SqliteContext>();
            services.AddScoped<INoticiaRepository, NoticiaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagRuleRepository, TagRuleRepository>();
            services.AddScoped<INoticiaRuleRepository, NoticiaRuleRepository>();
            services.AddScoped<IUsuarioRuleRepository, UsuarioRuleRepository>();
        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ICI Noticias V1");
            });
            app.UseDeveloperExceptionPage();

            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
		}
	}
}

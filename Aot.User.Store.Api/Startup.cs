
using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Repositories;
using Aot.User.Store.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Aot.User.Store.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Aot.User.Store.Api", Version = "1.0" });
            });

            services.AddDbContext<UserStoreDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserGroupRoleRepository, UserGroupRoleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Aot.User.Store.Api V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

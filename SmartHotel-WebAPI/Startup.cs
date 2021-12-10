using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartHotel.Data.Context;
using SmartHotel.IoC;
using SmartHotel.Query.Data.Context;
using SmartHotel.Query.IoC;

namespace SmartHotel_WebAPI
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
            services.AddDbContext<DataContext>(
               x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConn"))
               );

            services.AddDbContext<QueryDataContext>(
               x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConn"))
               );

            services.AddControllers();
            //services.AddScoped<IRepositoryBase,RepositoryBase>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartHotel_WebAPI", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIoC());
            builder.RegisterModule(new QueryModuleIoC());

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SmartHotel.Application.Mapper.DtoToModelMappingGuest());
                cfg.AddProfile(new SmartHotel.Application.Mapper.ModelToDtoMappingGuest());

                cfg.AddProfile(new SmartHotel.Application.Mapper.DtoToModelMappingRoom());
                cfg.AddProfile(new SmartHotel.Application.Mapper.ModelToDtoMappingRoom());

                cfg.AddProfile(new SmartHotel.Application.Mapper.DtoToModelMappingRoomType());
                cfg.AddProfile(new SmartHotel.Application.Mapper.ModelToDtoMappingRoomType());

                cfg.AddProfile(new SmartHotel.Application.Mapper.DtoToModelMappingBooking());
                cfg.AddProfile(new SmartHotel.Application.Mapper.ModelToDtoMappingBooking());

                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.DtoToModelMappingGuest());
                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.ModelToDtoMappingGuest());

                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.DtoToModelMappingRoom());
                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.ModelToDtoMappingRoom());

                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.DtoToModelMappingRoomType());
                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.ModelToDtoMappingRoomType());

                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.DtoToModelMappingBooking());
                cfg.AddProfile(new SmartHotel.Query.Application.Mapper.ModelToDtoMappingBooking());

                cfg.DisableConstructorMapping();
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHotel_WebAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
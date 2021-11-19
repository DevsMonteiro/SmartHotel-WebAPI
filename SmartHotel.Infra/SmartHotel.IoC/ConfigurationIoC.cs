using Autofac;
using AutoMapper;
using SmartHotel.Application;
using SmartHotel.Application.Interface;
using SmartHotel.Application.Mapper;
using SmartHotel.Data.Repositories;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using SmartHotel.Domain.Servicies;

namespace SmartHotel.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IoC

            builder.RegisterType<ApplicationServiceGuest>().As<IApplicationServiceGuest>();
            builder.RegisterType<ApplicationServiceRoom>().As<IApplicationServiceRoom>();
            builder.RegisterType<ApplicationServiceBooking>().As<IApplicationServiceBooking>();

            builder.RegisterType<ServiceGuest>().As<IServiceGuest>();
            builder.RegisterType<ServiceRoom>().As<IServiceRoom>();
            builder.RegisterType<ServiceBooking>().As<IServiceBooking>();

            builder.RegisterType<RepositoryGuest>().As<IRepositoryGuest>();
            builder.RegisterType<RepositoryRoom>().As<IRepositoryRoom>();
            builder.RegisterType<RepositoryRoomType>().As<IRepositoryRoomType>();
            builder.RegisterType<RepositoryBooking>().As<IRepositoryBooking>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingGuest());
                cfg.AddProfile(new ModelToDtoMappingGuest());

                cfg.AddProfile(new DtoToModelMappingRoom());
                cfg.AddProfile(new ModelToDtoMappingRoom());

                cfg.AddProfile(new DtoToModelMappingBooking());
                cfg.AddProfile(new ModelToDtoMappingBooking());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion IoC
        }
    }
}
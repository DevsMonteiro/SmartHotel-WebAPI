using Autofac;
using AutoMapper;
using SmartHotel.Domain.Servicies;
using SmartHotel.Query.Application;
using SmartHotel.Query.Application.Interface;
using SmartHotel.Query.Application.Mapper;
using SmartHotel.Query.Data.Repositories;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Servicies;

namespace SmartHotel.Query.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IoC

            builder.RegisterType<ApplicationServiceQueryGuest>().As<IApplicationServiceQueryGuest>();
            builder.RegisterType<ApplicationServiceQueryRoom>().As<IApplicationServiceQueryRoom>();
            builder.RegisterType<ApplicationServiceQueryBooking>().As<IApplicationServiceQueryBooking>();

            builder.RegisterType<ServiceGuest>().As<IQueryServiceGuest>();
            builder.RegisterType<ServiceRoom>().As<IQueryServiceRoom>();
            builder.RegisterType<ServiceBooking>().As<IQueryServiceBooking>();

            builder.RegisterType<RepositoryGuest>().As<IRepositoryGuest>();
            builder.RegisterType<RepositoryRoom>().As<IRepositoryRoom>();
            builder.RegisterType<RepositoryRoomType>().As<IRepositoryRoomType>();
            builder.RegisterType<RepositoryBooking>().As<IRepositoryBooking>();

            #endregion IoC
        }
    }
}
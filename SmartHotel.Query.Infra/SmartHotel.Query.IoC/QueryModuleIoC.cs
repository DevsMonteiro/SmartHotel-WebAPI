using Autofac;

namespace SmartHotel.Query.IoC
{
    public class QueryModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Extensions
{
    internal static class ModelBuilderExtensions
    {
        internal static void AddAllCnfigurations(this ModelBuilder builder)
        {
            var registrar = Assembly
                               .GetExecutingAssembly()
                               .GetTypes()
                               .Where(_ => _.GetInterfaces()
                                             .Any(_ => _.IsGenericType
                                                    && _.GetGenericTypeDefinition()
                                                    == typeof(IEntityTypeConfiguration<>)))
                               .ToList();

            foreach(var type in registrar)
            {
                dynamic? configInstance = Activator.CreateInstance(type);
                builder.ApplyConfiguration(configInstance);
            }
        }
    }
}

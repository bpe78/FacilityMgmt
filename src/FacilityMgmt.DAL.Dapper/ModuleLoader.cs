using System;
using Autofac;
using FacilityMgmt.DAL.Common.Interfaces;

namespace FacilityMgmt.DAL.Dapper
{
    public static class ModuleLoader
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<DataService>().As<IDataService>().SingleInstance();
            builder.RegisterType<DbContext>().As<IDbContext>();
        }
    }
}

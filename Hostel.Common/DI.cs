using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Common
{
    public static class DI
    {
        public static void AddMyAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}

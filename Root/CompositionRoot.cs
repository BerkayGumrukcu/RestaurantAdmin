using Entities.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using Services;

namespace Root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<ProjectContext>();

            services.AddScoped(typeof(IBillService), typeof(BillService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));

            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(@"Server=DESKTOP-CKPPIUF; Database=Cafe; Trusted_Connection = true", x => x.MigrationsAssembly("UI")));


        }
    }

}
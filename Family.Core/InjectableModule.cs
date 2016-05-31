using Family.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core
{
    public class InjectableModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
            Bind<DbContext>().To<FamilyDbContext>();
        }
    }
}

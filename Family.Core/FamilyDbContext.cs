using Family.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core
{
    public class FamilyDbContext:DbContext
    {
        public FamilyDbContext():base("DefaultConnection")
        {

        }

        
        public DbSet<Man> Men { get; set; }
        public DbSet<Woman> Women { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}

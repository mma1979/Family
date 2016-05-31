using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
    public class Man
    {
        public Man()
        {
            Wifes = new HashSet<Woman>();
            Children = new HashSet<Child>();
        }
        [Key]
        public int ManId { get; set; }
        public string ManName { get; set; }
        public int ManAge { get; set; }
        public bool IsAlive { get; set; }

        public virtual ICollection<Woman> Wifes { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}

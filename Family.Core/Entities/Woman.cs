using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
    public class Woman
    {
        public Woman()
        {
            Children = new HashSet<Child>();
        }
        [Key]
        public int WomanId { get; set; }
        public string WomanName { get; set; }
        public int WomanAge { get; set; }
        public bool IsAlive { get; set; }

        public int ManId { get; set; }
        public virtual Man Hasbund { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}

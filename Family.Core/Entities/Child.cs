using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
   public class Child
    {
       
        [Key]
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public int ChildAge { get; set; }
        public bool IsAlive { get; set; }

        public int ManId { get; set; }
        public int WomanId { get; set; }
        public virtual Woman Mother { get; set; }
        public virtual Man Father { get; set; }
    }
}

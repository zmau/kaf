using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaf.dal {
 
    class Normativ {
        [Key]
        public int id { get; set; }
        public Item sastojak { get; set; }
        public Item artikl { get; set; }
        public float kolicina { get; set; }
    }

}

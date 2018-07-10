using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kaf.dal
{
    public class Role
    {
        public Role()
        {
        }
        public Role(String name)
        {
            this.name = name;
        }
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<User> users { get; set; }

        
        public override string ToString()
        {
            return name;
        }
    }

    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public Role role { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string cardCode { get; set; }
}
   
}

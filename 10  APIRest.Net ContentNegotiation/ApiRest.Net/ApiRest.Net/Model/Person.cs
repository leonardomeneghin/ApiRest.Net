using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Net.Model
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string First_name { get; set; }

        [Column("last_name")]
        public string Last_name { get; set; }

        [Column("address")]
        public string Address{ get; set; }

        [Column("gender")]
        public string Gender{ get; set; }

    }
}

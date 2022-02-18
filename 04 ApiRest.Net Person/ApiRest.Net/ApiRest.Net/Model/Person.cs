using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Net.Model
{
    [Table("Person")]
    public class Person
    {
        [Column("id")]
        public int id { get; set; }
        [Column("first_name")]

        public string first_name { get; set; }
        [Column("last_name")]


        public string last_name { get; set; }
        [Column("address")]

        public string address{ get; set; }
        [Column("gender")]

        public string gender{ get; set; }

    }
}

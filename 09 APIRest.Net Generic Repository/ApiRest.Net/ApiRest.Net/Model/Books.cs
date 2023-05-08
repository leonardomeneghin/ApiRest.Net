using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Model
{
    [Table("tblBooks")]
    public class Books
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("author")]
        public string author { get; set; }

        [Column("launch_date")]
        public DateTime launch_date { get; set; }

        [Column("price")]
        public float price { get; set; }
        [Column("title")]
        public string title { get; set; }
    }
}

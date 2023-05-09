using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Model
{
    [Table("tblBooks")]
    public class Books : BaseEntity //Verificar herança na BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime Launch_date { get; set; }

        [Column("price")]
        public float Price { get; set; }
        [Column("title")]
        public string Title { get; set; }
    }
}

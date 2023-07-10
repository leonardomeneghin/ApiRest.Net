using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Data.Converter.VO
{
    public class BookVO : BaseEntity //Herdar o base entity para que o repository receba a implementação da entidade
    {
        public string Author { get; set; }
        public DateTime Launch_date { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
    }
}

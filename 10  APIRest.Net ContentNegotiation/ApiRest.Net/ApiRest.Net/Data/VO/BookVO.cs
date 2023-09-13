using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Data.Converter.VO
{
    public class BookVO 
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Launch_date { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
    }
}

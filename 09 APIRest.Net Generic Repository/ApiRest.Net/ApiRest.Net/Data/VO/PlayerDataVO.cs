using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Data.Converter.VO
{
    public class PlayerDataVO 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ranking { get; set; }
        public double Score { get; set; }
      
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Net.Model
{
    [Table("tblPlayerData")] //A tabela deve ser devidamente referenciada no model.
    public class PlayerData : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Ranking")]
        public string Ranking { get; set; }
        [Column("Score")]
        public double Score { get; set; }
      
    }
}

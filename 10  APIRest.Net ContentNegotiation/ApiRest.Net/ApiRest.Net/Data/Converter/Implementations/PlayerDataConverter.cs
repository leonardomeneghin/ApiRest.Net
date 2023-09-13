using ApiRest.Net.Data.Converter.Contract;
using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Net.Data.Converter.Implementations
{
    public class PlayerDataConverter : IParse<PlayerDataVO, PlayerData>, IParse<PlayerData, PlayerDataVO>
    {
        public PlayerData Parse(PlayerDataVO item)
        {
            return new PlayerData
            {
                Id = item.Id,
                Nome = item.Nome,
                Ranking = item.Ranking,
                Score = item.Score
            };
        }

        public PlayerDataVO Parse(PlayerData item)
        {
            return new PlayerDataVO
            {
                Id = item.Id,
                Nome = item.Nome,
                Ranking = item.Ranking,
                Score = item.Score
            };
        }

        public List<PlayerData> Parse(List<PlayerDataVO> itens)
        {
            return itens.Select(p => Parse(p)).ToList();
;        }

        public List<PlayerDataVO> Parse(List<PlayerData> itens)
        {
            return itens.Select(p => Parse(p)).ToList();
        }
    }
}

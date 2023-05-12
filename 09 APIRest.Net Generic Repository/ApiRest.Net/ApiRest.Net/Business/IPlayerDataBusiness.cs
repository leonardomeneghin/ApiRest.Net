using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Business
{
    public interface IPlayerDataBusiness
    {
        public PlayerData Create(PlayerData playerData);
        public PlayerData Update(PlayerData playerData);
        public List<PlayerData> FindAll();
        public PlayerData FindById(int id);
        public void Delete(int id);

    }
}

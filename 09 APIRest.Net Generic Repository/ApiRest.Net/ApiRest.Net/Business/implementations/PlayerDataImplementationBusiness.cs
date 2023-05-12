using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;

namespace ApiRest.Net.Business.implementations
{
    public class PlayerDataImplementationBusiness : IPlayerDataBusiness
    {
        //Padrão Repository Implementation
        private IGenericRepository<PlayerData> _repository;
        public PlayerDataImplementationBusiness(IGenericRepository<PlayerData> repository)
        {
            _repository = repository; //Encapsulamento do parâmetro na classe
        }
        public PlayerData Create(PlayerData playerData)
        {
            
            return _repository.Create(playerData);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public List<PlayerData> FindAll()
        {
            return _repository.FindAll();
        }

        public PlayerData FindById(int id)
        {
            return _repository.FindById(id);
        }

        public PlayerData Update(PlayerData playerData)
        {
            return _repository.Update(playerData);
        }
    }
}

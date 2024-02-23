using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;

namespace ApiRest.Net.Business.implementations
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(int person);
        List<PersonVO> FindAll();
        void Delete(long id);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ApiRest.Net.Data.Converter.Contract;
using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;


namespace ApiRest.Net.Data.Converter.Implementations
{
    public class PersonConverter : IParse<Person, PersonVO>, IParse<PersonVO, Person>
    {
        //Recebe um PersonVO, usando o mesmo IPARSE, pode-se criar a conversão para ambos os objetos person.
        //Lembrar que o padrão V.O. sempre precisa de um parse para obter o VO e outro para obter o valor em banco de dados.
        public Person Parse(PersonVO objeto)
        {
            if (objeto == null) return null;
            return new Person
            {
                Id = objeto.Id,
                First_name = objeto.First_name,
                Last_name = objeto.Last_name,
                Address = objeto.Address,
                Gender = objeto.Gender,
            };
        }

        public PersonVO Parse(Person objeto)
        {
            if (objeto == null) return null;
            return new PersonVO
            {
                Id = objeto.Id,
                First_name = objeto.First_name,
                Last_name = objeto.Last_name,
                Address = objeto.Address,
                Gender = objeto.Gender,
            };
        }

        public List<Person> Parse(List<PersonVO> objetos)
        {
            return objetos.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> objetos)
        {
            return objetos.Select(item => Parse(item)).ToList();
        }
    }
}


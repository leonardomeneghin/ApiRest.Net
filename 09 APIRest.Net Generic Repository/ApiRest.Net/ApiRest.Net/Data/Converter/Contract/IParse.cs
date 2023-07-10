using System;
using System.Collections.Generic;

namespace ApiRest.Net.Data.Converter.Contract
{
    public interface IParse<O, D>
    {
        /*Recebe e retorna objeto genérico
         * Importante para modificar o V.O. na forma como quisermos.
         * */
        O Parse(D objeto);
        List<O> Parse(List<D> objetos);
    }
}



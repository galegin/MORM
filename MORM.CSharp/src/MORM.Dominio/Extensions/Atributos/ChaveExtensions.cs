using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORM.Dominio.Extensions.Atributos
{
    public static class ChaveExtensions
    {
        public static bool IsChavePreenchida(this object objeto)
        {
            var campos = objeto.GetCampos();

            return false;
        }
    }
}
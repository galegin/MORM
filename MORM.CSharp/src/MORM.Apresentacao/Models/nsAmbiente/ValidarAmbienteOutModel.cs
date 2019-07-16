using MORM.Dominio.Entidades;

namespace MORM.Apresentacao.Models
{
    public class ValidarAmbienteOutModel
    {
        public string Token { get; set; }
        public Ambiente Ambiente { get; set; }
    }
}
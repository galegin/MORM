﻿using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Models
{
    [URL("Ambiente/Validar")]
    public class ValidarAmbienteInModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
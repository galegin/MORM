using System;

namespace MORM.CrossCutting
{
    public class AbstractEntidade : IAbstractEntidade
    {
    }

    public class AbstractEntidadeId : AbstractEntidade, IAbstractEntidadeId
    {
        [Campo("ID", CampoTipo.Key)]
        public string Id { get; set; }
    }

    public class AbstractEntidadeVersion : AbstractEntidadeId, IAbstractEntidadeVersion
    {
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
    }

    public class AbstractEntidadeUpdate : AbstractEntidadeVersion, IAbstractEntidadeUpdate
    {
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
    }
}
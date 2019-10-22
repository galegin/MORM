using System;
using System.Linq;

namespace MORM.CrossCutting.Datas
{
    public enum FeriadoTipo
    {
        Municipal,
        Estadual,
        Nacional,
    }

    public enum FeriadoEnum
    {
        Carnaval,
        QuartaCinzas,
        SextaSanta,
        CorpusChristi,
        Pascoa,
    }

    public class Feriado
    {
        public FeriadoTipo Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public Feriado(FeriadoTipo tipo, DateTime data, string descricao)
        {
            Tipo = tipo;
            Data = data;
            Descricao = descricao;
        }
    }

    public static class FeriadoExtensions
    {
        #region metodos
        public static bool IsFeriado(this DateTime data)
        {
            return GetFeriados(data.Year)
                .Any(f => f.Data.Equals(data))
                ;
        }

        public static Feriado[] GetFeriados(this int ano)
        {
            return new[]
            {
                new Feriado(FeriadoTipo.Nacional, CalcularPascoa(ano), "Pascoa"),

                new Feriado(FeriadoTipo.Nacional, CalcularFeriado(ano, FeriadoEnum.Carnaval), "Carnaval"),
                new Feriado(FeriadoTipo.Nacional, CalcularFeriado(ano, FeriadoEnum.QuartaCinzas), "Quarta Cinzas"),
                new Feriado(FeriadoTipo.Nacional, CalcularFeriado(ano, FeriadoEnum.SextaSanta), "Sexta Santa"),
                new Feriado(FeriadoTipo.Nacional, CalcularFeriado(ano, FeriadoEnum.CorpusChristi), "Corpus Christi"),

                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 01, 01), "Confraternizacao"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 04, 21), "Tiradentes"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 05, 01), "Dia do trabalho"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 09, 07), "Dia da Independancia d Brasil"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 10, 12), "Nossa Senhora Aparecida"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 11, 02), "Finados"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 11, 15), "Proclamacao da Republica"),
                new Feriado(FeriadoTipo.Nacional, new DateTime(ano, 12, 25), "Natal"),
            };
        }

        public static DateTime CalcularFeriado(int ano, FeriadoEnum feriado)
        {
            DateTime data = CalcularPascoa(ano);

            switch (feriado)
            {
                case FeriadoEnum.Carnaval:
                    return data.AddDays(-47);
                case FeriadoEnum.QuartaCinzas:
                    return data.AddDays(-46);
                case FeriadoEnum.SextaSanta:
                    return data.AddDays(-2);
                case FeriadoEnum.CorpusChristi:
                    return data.AddDays(60);
            }

            return data;
        }

        private static DateTime CalcularPascoa(int ano)
        {
            int r1 = ano % 19;
            int r2 = ano % 4;
            int r3 = ano % 7;
            int r4 = (19 * r1 + 24) % 30;
            int r5 = (6 * r4 + 4 * r3 + 2 * r2 + 5) % 7;
            DateTime dataPascoa = new DateTime(ano, 3, 22).AddDays(r4 + r5);
            int dia = dataPascoa.Day;

            switch (dia)
            {
                case 26:
                    dataPascoa = new DateTime(ano, 4, 19);
                    break;
                case 25:
                    if (r1 > 10)
                        dataPascoa = new DateTime(ano, 4, 18);
                    break;
            }

            return dataPascoa.Date;
        }
        #endregion
    }
}
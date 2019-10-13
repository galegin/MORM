using System;
using System.Linq;

namespace MORM.CrossCutting
{
    public class ValidacaoType
    {
        public ValidacaoType(Type elementType)
        {
            ElementType = elementType;
        }

        public Type ElementType { get; private set; }
        public virtual void Validar(object valor) { }
    }

    public class ValidacaoType<TObject> : ValidacaoType
    {
        protected ValidacaoType(string mensagem) : base(typeof(TObject))
        {
            Mensagem = mensagem;
        }

        public ValidacaoType(string mensagem, TObject inicial, TObject final)
            : this(mensagem)
        {
            Inicial = inicial;
            Final = final;
        }

        public ValidacaoType(string mensagem, TObject[] lista)
            : this(mensagem)
        {
            Lista = lista;
        }

        public string Mensagem { get; }
        public TObject Inicial { get; }
        public TObject Final { get; }
        public TObject[] Lista { get; }

        public override void Validar(object valor)
        {
            if (ElementType == typeof(DateTime))
                ValidarData(Convert.ToDateTime(valor));
            else if (ElementType == typeof(decimal))
                ValidarReal(Convert.ToDouble(valor));
            else if (ElementType == typeof(double))
                ValidarReal(Convert.ToDouble(valor));
            else if (ElementType == typeof(float))
                ValidarReal(Convert.ToDouble(valor));
            else if (ElementType == typeof(long))
                ValidarInt(Convert.ToInt32(valor));
            else if (ElementType == typeof(int))
                ValidarInt(Convert.ToInt32(valor));
            else if (ElementType == typeof(short))
                ValidarInt(Convert.ToInt32(valor));
            else if (ElementType == typeof(string))
                ValidarStr(Convert.ToString(valor));
        }

        //-- intervalo

        protected void ValidarData(DateTime data)
        {
            if (Lista != null)
            {
                var lista = Lista as DateTime[];
                if (!lista.Contains(data))
                    throw new Exception($"{Mensagem} deve estar contido na lista {Lista.ToString()}");
                return;
            }

            var dataInicial = Convert.ToDateTime(Inicial);
            var dataFinal = Convert.ToDateTime(Final);
            if (dataInicial != DateTime.MinValue && data < dataInicial)
                throw new Exception($"{Mensagem} deve ser maior ou igual que {dataInicial}");
            if (dataFinal != DateTime.MinValue && data > dataFinal)
                throw new Exception($"{Mensagem} deve ser menor ou igual que {dataFinal}");
        }

        protected void ValidarReal(double numero)
        {
            if (Lista != null)
            {
                var lista = Lista as double[];
                if (!lista.Contains(numero))
                    throw new Exception($"{Mensagem} deve estar contido na lista {Lista.ToString()}");
                return;
            }

            var numeroInicial = Convert.ToDouble(Inicial);
            var numeroFinal = Convert.ToDouble(Final);
            if (numeroInicial != double.MinValue && numero < numeroInicial)
                throw new Exception($"{Mensagem} deve ser maior ou igual que {numeroInicial}");
            if (numeroFinal != double.MinValue && numero > numeroFinal)
                throw new Exception($"{Mensagem} deve ser menor ou igual que {numeroFinal}");
        }

        protected void ValidarInt(int numero)
        {
            if (Lista != null)
            {
                var lista = Lista as int[];
                if (!lista.Contains(numero))
                    throw new Exception($"{Mensagem} deve estar contido na lista {Lista.ToString()}");
                return;
            }

            var numeroInicial = Convert.ToInt32(Inicial);
            var numeroFinal = Convert.ToInt32(Final);
            if (numeroInicial != int.MinValue && numero < numeroInicial)
                throw new Exception($"{Mensagem} deve ser maior ou igual que {numeroInicial}");
            if (numeroFinal != int.MinValue && numero > numeroFinal)
                throw new Exception($"{Mensagem} deve ser menor ou igual que {numeroFinal}");
        }

        protected void ValidarStr(string str)
        {
            if (Lista != null)
            {
                var lista = Lista as string[];
                if (!lista.Contains(str))
                    throw new Exception($"{Mensagem} deve estar contido na lista {Lista.ToString()}");
                return;
            }

            var strInicial = Convert.ToString(Inicial);
            var strFinal = Convert.ToString(Final);
            if (!string.IsNullOrWhiteSpace(strInicial) && str.CompareTo(strInicial) < 0)
                throw new Exception($"{Mensagem} deve ser maior ou igual que {strInicial}");
            if (!string.IsNullOrWhiteSpace(strFinal) && str.CompareTo(strFinal) > 0)
                throw new Exception($"{Mensagem} deve ser menor ou igual que {strFinal}");
        }
    }

    public class ValidacaoCampo : Attribute
    {
        public ValidacaoCampo(ValidacaoType validacao)
        {
            Validacao = validacao;
        }

        public ValidacaoType Validacao { get; }

        //-- intervalo

        public ValidacaoCampo(string mensagem, DateTime inicial, DateTime final)
            : this(new ValidacaoType<DateTime>(mensagem, inicial, final))
        {
        }

        // numero

        public ValidacaoCampo(string mensagem, decimal inicial, decimal final)
            : this(new ValidacaoType<decimal>(mensagem, inicial, final))
        {
        }

        public ValidacaoCampo(string mensagem, double inicial, double final)
            : this(new ValidacaoType<double>(mensagem, inicial, final))
        {
        }

        public ValidacaoCampo(string mensagem, float inicial, float final)
            : this(new ValidacaoType<float>(mensagem, inicial, final))
        {
        }

        // inteiro

        public ValidacaoCampo(string mensagem, long inicial, long final)
            : this(new ValidacaoType<long>(mensagem, inicial, final))
        {
        }

        public ValidacaoCampo(string mensagem, int inicial, int final)
            : this(new ValidacaoType<int>(mensagem, inicial, final))
        {
        }

        public ValidacaoCampo(string mensagem, short inicial, short final)
            : this(new ValidacaoType<short>(mensagem, inicial, final))
        {
        }

        // texto

        public ValidacaoCampo(string mensagem, string inicial, string final)
            : this(new ValidacaoType<string>(mensagem, inicial, final))
        {
        }

        //-- lista

        public ValidacaoCampo(string mensagem, DateTime[] lista)
            : this(new ValidacaoType<DateTime>(mensagem, lista))
        {
        }

        // numero

        public ValidacaoCampo(string mensagem, decimal[] lista)
            : this(new ValidacaoType<decimal>(mensagem, lista))
        {
        }

        public ValidacaoCampo(string mensagem, double[] lista)
            : this(new ValidacaoType<double>(mensagem, lista))
        {
        }

        public ValidacaoCampo(string mensagem, float[] lista)
            : this(new ValidacaoType<float>(mensagem, lista))
        {
        }

        // inteiro

        public ValidacaoCampo(string mensagem, long[] lista)
            : this(new ValidacaoType<long>(mensagem, lista))
        {
        }

        public ValidacaoCampo(string mensagem, int[] lista)
            : this(new ValidacaoType<int>(mensagem, lista))
        {
        }

        public ValidacaoCampo(string mensagem, short[] lista)
            : this(new ValidacaoType<short>(mensagem, lista))
        {
        }

        // texto

        public ValidacaoCampo(string mensagem, string[] lista)
            : this(new ValidacaoType<string>(mensagem, lista))
        {
        }
    }
}
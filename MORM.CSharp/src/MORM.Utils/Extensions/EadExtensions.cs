using System.Text;

namespace MORM.Utils.Extensions
{
    public static class EadExtensions
    {
        private static string _chave = "aq1SW@de3FR$gt5";

        public static byte[] Hash(this string conteudo, string chave = null)
        {
            byte[] res;

            System.Security.Cryptography.MD5 hash = System.Security.Cryptography.MD5.Create();
            byte[] md5 = hash.ComputeHash(Encoding.Default.GetBytes(conteudo));

            // Depois disso executo o algortimo de RSA com minha chave pública e expoente 3, com um bloco de 128 bytes de acordo com o PAF-ECF.
            using (System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider())
            {
                RSA.FromXmlString(chave ?? _chave);
                res = RSA.Encrypt(md5, false);
            }

            return res;
        }

        /*
        Estou desenvolvendo um módulo de assinatura digital no C#. Gostaria da opinião de vcs se o procedimento está de acordo com o PAF-ECF.

        Estou utilizando a classe MD5 para gerar o Hash:

        MD5 hash = MD5.Create();
        byte[] md5 = hash.ComputeHash(Encoding.Default.GetBytes(conteudo));

        Depois disso executo o algortimo de RSA com minha chave pública e expoente 3, com um bloco de 128 bytes de acordo com o PAF-ECF.

        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(minhaChavePublica);
            meuMd5CriptografadoComRSA = RSA.Encrypt(md5ComBloco128Bytes, false);
        }

        Desta forma ao final tenho 256 bytes em Hexadecimal do MD5 criptografado com o algoritmo RSA.

        Vou dar um exemplo:

        Vamos supor que eu gerei um md5 de um determinado conteudo através da classe MD5:

        177|139|85|78|19|201|134|93|99|215|211|5|98|50|69|193
        
        Conforme layout o MD5 deve ser adicionado em um bloco de 128 bytes:

        16|177|139|85|78|19|201|134|93|99|215|211|5|98|50|69|193|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0
        
        Agora sim, utilizo o RSA com minha chave pública: (o algoritmo gera um array de 128 bytes ai eu converto em hexadecimal, que agora tem 256 bytes)
        
        68b2dea85564e9a877592ab63695ddb6adb32eef47968ce77d72301dc2209a3f5e8223fbfa95df1bd19a7a6516d4d8e831cdebe15f8b901b1b9fa77656f82a56d3ee0798ed83fa4f7908e7f1d13983a3448f29dd32688aa9ab99ebc82666a549158f58d943bd7618722fa415d857a95dda9ef316bdb2f29a0bd47d9437c89c58
        
        É o valor acima que eu coloco no campo EAD.

        Bem, é isso ai. Gostaria de saber se o processo está correto ou se alguém tem alguma opnião diferente.

        Obrigado.

        Fábio.     
        */
    }
}
using Microsoft.Owin.Hosting;
using System;

namespace MORM.RunWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<SelfHostConfig>("http://*:55275/"))
            {
                var opcao = string.Empty;

                while (!"sair".Equals(opcao))
                {
                    Console.WriteLine("Servidor online!");
                    Console.WriteLine("Digite \"sair\" para finalizar.");
                    opcao = Console.ReadLine();
                }
            }
        }
    }
}
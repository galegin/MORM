﻿using MORM.Utils.Classes;
using MORM.Utils.Excecoes;
using System.Collections.Generic;
using System.Windows;

namespace MORM.Apresentacao.Connectors
{
    public abstract class AbstractConnector
    {
        public void ExibirMensagem(string mensagem, bool isGerarLog = false, bool isGerarExcecao = false)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                return;

            if (isGerarLog)
                Logger.InfoMensagem(mensagem);

            if (isGerarExcecao)
                throw new ExceptionInfo(mensagem);

            MessageBox.Show(mensagem, "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public abstract class AbstractConnector<TEntrada> : AbstractConnector
    {
        public abstract void Executar(TEntrada instance);
    }

    public abstract class AbstractConnectorObj : AbstractConnector
    {
        public abstract object Executar(object instance);
    }

    public abstract class AbstractConnectorList<TEntrada, TRetorno> : AbstractConnector
    {
        public abstract List<TRetorno> Executar(TEntrada instance);
    }

    public abstract class AbstractConnectorRet<TEntrada, TRetorno> : AbstractConnector
    {
        public abstract TRetorno Executar(TEntrada instance);
    }
}
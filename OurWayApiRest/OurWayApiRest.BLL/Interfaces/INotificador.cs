using OurWayApiRest.BLL.Noticacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.BLL.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}

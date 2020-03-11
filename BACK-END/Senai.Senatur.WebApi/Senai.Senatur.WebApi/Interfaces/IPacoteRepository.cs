using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacote> ListarPacotes();

        void CadastrarPacote(Pacote novoPacote);

        void AtualizarPacote(int id, Pacote pacoteAtualizado);

        void DeletarPacote(int id);

        Pacote BuscarPacotesPorId(int id);

        List<Pacote> ListarPacotesAtivos();

        List<Pacote> ListarPacotesInativos();

        List<Pacote> ListarPacotesCidades(string cidadeBuscada);

        List<Pacote> ListarPacotesPorPreco(string ordem);
    }
}

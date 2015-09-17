using System.Collections.Generic;
using System.ServiceModel;
using Servicos.Model;

namespace Servicos.Contratos
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        int Salvarcliente(string nome, int codempresa);
        [OperationContract]
        bool Deletetarcliente(int id);
        [OperationContract]
        List<ClienteDto> Listarcliente(int codempresa);
        [OperationContract]
        UsuarioDto Logarusuario(string login, string senha);
        [OperationContract]
        void Usuarioatualizarusuario(int codigo);
        [OperationContract]
        void Bloquearcliente(int id, UsuarioDto usuariologado);
        [OperationContract]
        bool Clientebloqueado(int id);
        [OperationContract]
        void Atualizarcliente(int id, string nome, string obs, int idgrupo);
        [OperationContract]
        string NomeCliente(int id);
        [OperationContract]
        List<GrupclienteDto> Listargrupo(int codempresa);

        [OperationContract]
        void SalvarGrupo(GrupclienteDto entidade);
        [OperationContract]
        bool Deletetargrupo(int id);

    }
}

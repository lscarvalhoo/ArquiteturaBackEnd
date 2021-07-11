using configuracaoArquiteturaBackEnd.api.Business.Entities;

namespace configuracaoArquiteturaBackEnd.api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
    }
}

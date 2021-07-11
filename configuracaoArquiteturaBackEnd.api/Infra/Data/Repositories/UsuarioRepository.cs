using configuracaoArquiteturaBackEnd.api.Business.Entities;
using configuracaoArquiteturaBackEnd.api.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace configuracaoArquiteturaBackEnd.api.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;

        public UsuarioRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Add(usuario); 
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}

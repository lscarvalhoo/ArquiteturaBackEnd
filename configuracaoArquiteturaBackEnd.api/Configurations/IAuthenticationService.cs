using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace configuracaoArquiteturaBackEnd.api.Controllers
{
    public interface IAuthenticationService
    {
        string ObterToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}

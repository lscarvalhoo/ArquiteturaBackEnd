using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace configuracaoArquiteturaBackEnd.api.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Erros { get;  set;}

        public ValidaCampoViewModelOutput(IEnumerable<string> erro)
        {
            Erros = Erros;
        }
    }
}

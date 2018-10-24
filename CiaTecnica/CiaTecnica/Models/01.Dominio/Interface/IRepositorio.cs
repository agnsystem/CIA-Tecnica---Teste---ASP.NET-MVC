using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiaTecnica.Models
{
    interface IRepositorio<T> where T : class
    {
        void salvarDados(T oEntidade);

        void excluirDados(T oEntidade);

        IEnumerable<T> ListarTodos();

        T ListarPorId(string id);
    }
}

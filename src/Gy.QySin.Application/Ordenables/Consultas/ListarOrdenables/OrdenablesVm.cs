using System.Collections.Generic;

namespace Gy.QySin.Application.Consultas.ListarOrdenables
{
    public class OrdenablesVm
    {
        public IList<OrdenableCategoriaDto> Categorias { get; set; }
        public IList<OrdenableDto> Ordenables {get;set;}
    }
}
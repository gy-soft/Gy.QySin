using System.Collections.Generic;

namespace Gy.QySin.Application.Ordenables.Consultas.ListarOrdenables
{
    public class OrdenablesVm
    {
        public IList<OrdenableCategoriaDto> Categorias { get; set; }
        public IList<OrdenableDto> Ordenables {get;set;}
    }
}
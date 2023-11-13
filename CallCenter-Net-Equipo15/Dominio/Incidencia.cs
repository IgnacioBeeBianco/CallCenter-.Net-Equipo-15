using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidencia
    {
        public int Id { get; set; }
        public Usuario Creador { get; set; }
        public Usuario Asignado { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string ComentarioCierre { get; set; }
        public Prioridad Prioridad { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }

    }
}

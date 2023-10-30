using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    public enum EstadoTicket
    {
        [Description("Abierto")]
        Abierto,

        [Description("En Análisis")]
        EnAnalisis,

        [Description("Cerrado")]
        Cerrado,

        [Description("Reabierto")]
        Reabierto,

        [Description("Asignado")]
        Asignado,

        [Description("Resuelto")]
        Resuelto
    }

}

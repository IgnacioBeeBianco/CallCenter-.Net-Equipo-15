using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public bool Estado { get; set; }
    }
}

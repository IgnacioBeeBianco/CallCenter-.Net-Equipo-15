using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Encuesta
    {
        public int Id { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }
    }
}

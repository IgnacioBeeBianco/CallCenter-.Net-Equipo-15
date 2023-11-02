using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Rol> Rol { get; set; }
    }
}

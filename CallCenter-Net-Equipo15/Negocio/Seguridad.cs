using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Seguridad
    {
        public static bool sesionActivaUsuario(object usuario)
        {
            Usuario Usuario = usuario!=null ? (Usuario)usuario : null;
            if(!(Usuario != null && Usuario.Id !=0))
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public static bool sesionActivaCuenta(object cuenta)
        {
            Cuenta Cuenta = cuenta!=null ? (Cuenta)cuenta : null;
            if(!(Cuenta != null && Cuenta.Id !=0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

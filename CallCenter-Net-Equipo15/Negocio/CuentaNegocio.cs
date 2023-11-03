using DAO;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CuentaNegocio
    {
        public bool Login(Cuenta cuenta)
        {
            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                bool logueado = cuentaDAO.Login(cuenta);
                return logueado;
            }catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

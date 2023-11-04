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
        public Usuario Login(Cuenta cuenta)
        {
            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                Usuario userloggued = cuentaDAO.Login(cuenta);
                return userloggued;
            }catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

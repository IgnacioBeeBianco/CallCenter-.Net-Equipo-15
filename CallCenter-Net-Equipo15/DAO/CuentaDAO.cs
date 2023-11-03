using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CuentaDAO
    {
        private AccesoADatos accesoADatos = new AccesoADatos();
        public bool Login(Cuenta cuenta)
        {
            try
            {
                string consulta = "SELECT id_rol FROM Cuenta WHERE email = @email AND password_ = @password";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password", cuenta.Password);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    cuenta.Rol.Id = (int)accesoADatos.Lector["id_rol"];

                }
                if(cuenta.Rol != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }
    }
}

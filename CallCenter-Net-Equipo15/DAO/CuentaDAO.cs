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
                string consulta = "SELECT id_rol FROM Cuenta WHERE email = @email AND password = @password";
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password", cuenta.Password);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {

                }

                return true;

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

using DAO;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        AccesoADatos accesoADatos;
        public void UpdateEstado(int idEstado, long id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Incidencia SET estado_id = @idEstado WHERE id = @Id";

                accesoADatos.AbrirConexion();
                //Setear todos los datos
                accesoADatos.setearParametro("@Id", id);
                accesoADatos.setearParametro("@idEstado", idEstado);
                accesoADatos.consultar(consulta);

                accesoADatos.ejecutarAccion();
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

        private Estado LoadEstado(ref AccesoADatos accesoADatos)
        {
            Estado estado = new Estado();
            estado.Id = (int)accesoADatos.Lector["id"];
            estado.Nombre = accesoADatos.Lector["nombre"].ToString();

            return estado;
        }

        public List<Estado> TraerEstadosMenos(string Estado)
        {
            accesoADatos = new AccesoADatos();
            List<Estado> estado = new List<Estado>();

            try
            {
                string consulta = "SELECT id, nombre FROM Estado WHERE nombre <>  @Estado";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Estado", Estado);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    estado.Add(LoadEstado(ref accesoADatos));
                }

                return estado;
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

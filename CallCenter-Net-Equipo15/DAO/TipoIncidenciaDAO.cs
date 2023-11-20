using Dominio;
//using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TipoIncidenciaDAO
    {
        private List<TipoIncidencia> Tipos;
        private AccesoADatos accesoADatos;

        private TipoIncidencia LoadTipoIncidencia(ref AccesoADatos accesoADatos)
        {
            TipoIncidencia tipoIncidencia = new TipoIncidencia();
            tipoIncidencia.id = (int)accesoADatos.Lector["id"];
            tipoIncidencia.Nombre = accesoADatos.Lector["nombre"].ToString();
            tipoIncidencia.Descripcion = accesoADatos.Lector["descripcion"].ToString();
            tipoIncidencia.Estado = bool.Parse(accesoADatos.Lector["estado"].ToString());

            return tipoIncidencia;
        }

        public TipoIncidencia getTipoIncidencia(int Id)
        {
            accesoADatos = new AccesoADatos();
            TipoIncidencia tipoIncidencia = new TipoIncidencia();

            try
            {
                string consulta = "SELECT id, nombre, descripcion, estado FROM TipoIncidencia WHERE id = @Id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Id", Id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    tipoIncidencia = LoadTipoIncidencia(ref accesoADatos);
                }

                return tipoIncidencia;
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

        public TipoIncidencia getTipoIncidencia(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            TipoIncidencia tipoIncidencia = new TipoIncidencia();

            try
            {
                string consulta = "SELECT id, nombre, descripcion, estado FROM TipoIncidencia WHERE Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    tipoIncidencia = LoadTipoIncidencia(ref accesoADatos);
                }

                return tipoIncidencia;
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

        public List<TipoIncidencia> List()
        {
            accesoADatos = new AccesoADatos();
            Tipos = new List<TipoIncidencia>();

            try
            {
                string consulta = "SELECT id, nombre, descripcion, estado FROM TipoIncidencia";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    Tipos.Add(LoadTipoIncidencia(ref accesoADatos));
                }

                return Tipos;
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

        public void Create(TipoIncidencia tipoIncidencia)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO TipoIncidencia VALUES (@Nombre, @Descripcion, 1)";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", tipoIncidencia.Nombre);
                accesoADatos.setearParametro("@Descripcion", tipoIncidencia.Descripcion);
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

        public void Update(TipoIncidencia newValue, int id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE TipoIncidencia SET nombre = @Nombre, descripcion = @Descripcion WHERE id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", newValue.Nombre);
                accesoADatos.setearParametro("@Descripcion", newValue.Descripcion);
                accesoADatos.setearParametro("@Id", id);
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

        public void Delete(int id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consultar = "UPDATE TipoIncidencia SET Estado = 0 WHERE id = @id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@id", id);
                accesoADatos.consultar(consultar);
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
    }
}

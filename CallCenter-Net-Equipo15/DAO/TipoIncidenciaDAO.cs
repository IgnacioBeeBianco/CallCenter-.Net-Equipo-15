using Dominio;
using Dominio.Enums;
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
            tipoIncidencia.Oid = (long)accesoADatos.Lector["oid"];
            tipoIncidencia.Nombre = accesoADatos.Lector["nombre"].ToString();
            tipoIncidencia.Descripcion = accesoADatos.Lector["descripcion"].ToString();

            return tipoIncidencia;
        }

        public List<TipoIncidencia> List()
        {
            accesoADatos = new AccesoADatos();
            Tipos = new List<TipoIncidencia>(); 

            try
            {
                string consulta = "SELECT oid, nombre, descripcion FROM TiposIncidencia";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while(accesoADatos.Lector.Read())
                {
                    Tipos.Add(LoadTipoIncidencia(ref accesoADatos));
                }

                return Tipos;
            }catch (Exception ex)
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
                string consulta = "INSERT INTO TipoIncidencia(nombre, descripcion) VALUES (@Nombre, @Descripcion)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", tipoIncidencia.Nombre);
                accesoADatos.setearParametro("@Descripcion", tipoIncidencia.Descripcion);
                accesoADatos.ejecutarAccion();

            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void Update(TipoIncidencia tipoIncidencia)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE TipoIncidencia SET nombre = @Nombre, descripcion = @Descripcion WHERE oid = @Oid";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", tipoIncidencia.Nombre);
                accesoADatos.setearParametro("@Descripcion", tipoIncidencia.Descripcion);
                accesoADatos.setearParametro("@Oid", tipoIncidencia.Oid);
                accesoADatos.consultar(consulta);

                accesoADatos.ejecutarAccion();
            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void Delete(long oid)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consultar = "DELETE FROM TipoIncidencia WHERE oid = @Oid";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Oid", oid);
                accesoADatos.consultar(consultar);
                accesoADatos.ejecutarAccion();
            }catch (Exception ex)
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

using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class IncidenciaDAO
    {
        private AccesoADatos accesoADatos;

        private Incidencia LoadIncidencia(ref AccesoADatos accesoADatos)
        {
            Incidencia incidencia = new Incidencia();
            incidencia.Id = (int)accesoADatos.Lector["id"];
            incidencia.Creador.Id = (int)accesoADatos.Lector["idCreador"];
            incidencia.Creador.Nombre = accesoADatos.Lector["creador"].ToString();
            incidencia.Asignado.Id = (int)accesoADatos.Lector["idAsignado"];
            incidencia.Asignado.Nombre = accesoADatos.Lector["asignado"].ToString();
            incidencia.Estado.Id = (int)accesoADatos.Lector["idEstado"];
            incidencia.Estado.Nombre = accesoADatos.Lector["Estado"].ToString();
            incidencia.FechaCreacion = (DateTime)accesoADatos.Lector["fecha_creacion"];
            incidencia.FechaCierre = (DateTime)accesoADatos.Lector["fecha_ultimo_cambio"];
            incidencia.Prioridad.Id = (int)accesoADatos.Lector["idPrioridad"];
            incidencia.Prioridad.Nombre = accesoADatos.Lector["Prioridad"].ToString() ;
            incidencia.TipoIncidencia.id = (int)accesoADatos.Lector["idTipoIncidencia"];
            incidencia.TipoIncidencia.Nombre = accesoADatos.Lector["TipoIncidencia"].ToString();
            incidencia.ComentarioCierre = accesoADatos.Lector["comentario_cierra"].ToString();
            incidencia.problematica = accesoADatos.Lector["problematica"].ToString();


            return incidencia;
        }

        public Incidencia getIncidencia(int Id)
        {
            accesoADatos = new AccesoADatos();
            Incidencia incidencia = new Incidencia();

            try
            {
                string consulta = "SELECT I.id,U.id as idCreador, U.nombre as creador,U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_ultimo_cambio,E.id as idEstado, E.nombre as Estado,P.id as idPrioridad, P.nombre as Prioridad,TI.id as idTipoIncidencia, TI.nombre as TipoIncidencia, I.comentario_cierra, I.problematica " +
                    "FROM Incidencia as I " +
                    "INNER JOIN Usuario as U on I.creador_id = U.id " +
                    "INNER JOIN Usuario as U2 on I.asignado_id = U2.id " +
                    "INNER JOIN Estado as E on I.estado_id = E.id " +
                    "INNER JOIN Prioridad as P on I.prioridad_id = P.id " +
                    "INNER JOIN TipoIncidencia as TI on I.tipo_incidencia_id = TI.id " +
                    "WHERE I.Id = @Id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Id", Id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    incidencia = LoadIncidencia(ref accesoADatos);
                }

                return incidencia;
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

        public Incidencia getIncidencia(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            Incidencia incidencia = new Incidencia();

            try
            {
                string consulta = "SELECT I.id,U.id as idCreador, U.nombre as creador,U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_ultimo_cambio,E.id as idEstado, E.nombre as Estado,P.id as idPrioridad, P.nombre as Prioridad, TI.id as idTipoIncidencia, TI.nombre as TipoIncidencia, I.comentario_cierra, I.problematica " +
                    "FROM Incidencia as I " +
                    "INNER JOIN Usuario as U on I.creador_id = U.id " +
                    "INNER JOIN Usuario as U2 on I.asignado_id = U2.id " +
                    "INNER JOIN Estado as E on I.estado_id = E.id " +
                    "INNER JOIN Prioridad as P on I.prioridad_id = P.id " +
                    "INNER JOIN TipoIncidencia as TI on I.tipo_incidencia_id = TI.id " +
                    "WHERE I.Nombre = @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    incidencia = LoadIncidencia(ref accesoADatos);
                }

                return incidencia;
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

        public List<Incidencia> List()
        {
            accesoADatos = new AccesoADatos();
            List<Incidencia> incidencias = new List<Incidencia>();

            try
            {
                string consulta = "SELECT I.id, U.id as idCreador, U.nombre as creador, U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_ultimo_cambio, "+
                                    "E.id as idEstado, E.nombre as Estado, P.id as idPrioridad, P.nombre as Prioridad, TI.id as idTipoIncidencia, TI.nombre as TipoIncidencia, " +
                                    "I.comentario_cierra, I.problematica FROM Incidencia as I INNER JOIN Usuario as U ON I.creador_id = U.id INNER JOIN Usuario as U2 ON I.asignado_id = U2.id " +
                                    "INNER JOIN Estado as E ON I.estado_id = E.id INNER JOIN Prioridad as P ON I.prioridad_id = P.id INNER JOIN TipoIncidencia as TI ON I.tipo_incidencia_id = TI.id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    incidencias.Add(LoadIncidencia(ref accesoADatos));
                }

                return incidencias;
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

        public List<Incidencia> ListByEstado(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            List<Incidencia> incidencias = new List<Incidencia>();

            try
            {
                string consulta = "SELECT I.id,U.id as idCreador, U.nombre as creador,U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_ultimo_cambio,E.id as idEstado, E.nombre as Estado,P.id as idPrioridad, P.nombre as Prioridad, TI.id as idTipoIncidencia, TI.nombre as TipoIncidencia, I.comentario_cierra, I.problematica " +
                    "FROM Incidencia as I " +
                    "INNER JOIN Usuario as U on I.creador_id = U.cuenta_id " +
                    "INNER JOIN Usuario as U2 on I.asignado_id = U2.cuenta_id " +
                    "INNER JOIN Estado as E on I.estado_id = E.id " +
                    "INNER JOIN Prioridad as P on I.prioridad_id = P.id " +
                    "INNER JOIN TipoIncidencia as TI on I.tipo_incidencia_id = TI.id " +
                    "WHERE E.Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    incidencias.Add(LoadIncidencia(ref accesoADatos));
                }

                return incidencias;
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

        public void Create(Incidencia incidencia)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "";
                accesoADatos.AbrirConexion();
                //setear todos los parametros
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

        public void Update(Incidencia newValue, long id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "setear consulta WHERE I.Id = @Id";

                accesoADatos.AbrirConexion();
                //Setear todos los datos
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

        public void Delete(long id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consultar = "DELETE FROM Incidencia WHERE id = @id";

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

        public List<Incidencia> ListByUsuarioId(int id)
        {
            accesoADatos = new AccesoADatos();
            List<Incidencia> incidencias = new List<Incidencia>();

            try
            {
                string consulta = "SELECT I.id, U.id as idCreador, U.nombre as creador, U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_ultimo_cambio, " +
                                    "E.id as idEstado, E.nombre as Estado, P.id as idPrioridad, P.nombre as Prioridad, TI.id as idTipoIncidencia, TI.nombre as TipoIncidencia, " +
                                    "I.comentario_cierra, I.problematica FROM Incidencia as I INNER JOIN Usuario as U ON I.creador_id = U.id INNER JOIN Usuario as U2 ON I.asignado_id = U2.id " +
                                    "INNER JOIN Estado as E ON I.estado_id = E.id INNER JOIN Prioridad as P ON I.prioridad_id = P.id INNER JOIN TipoIncidencia as TI ON I.tipo_incidencia_id = TI.id " +
                                    "WHERE U.id = @id OR U2.id = @id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    incidencias.Add(LoadIncidencia(ref accesoADatos));
                }

                return incidencias;
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

        public int incidenciasTotales(int id)
        {
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT COUNT(*) FROM Incidencia WHERE asignado_id = @id";

                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);

                int incidencias = Convert.ToInt32(accesoADatos.ejecutarAccionScalar());

                return incidencias;
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

        public int incidenciasUrgente(int id)
        {
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT COUNT(*) FROM Incidencia WHERE asignado_id = @id AND prioridad_id = (SELECT id FROM Prioridad WHERE nombre = 'Urgente')";

                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);

                int incidencias = Convert.ToInt32(accesoADatos.ejecutarAccionScalar());

                return incidencias;
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

        public int incidenciasPendiente(int id)
        {
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT COUNT(*) FROM Incidencia  WHERE asignado_id = @id AND estado_id NOT IN (SELECT id FROM Estado WHERE nombre IN ('Cerrado', 'Resuelto'))";

                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);

                int incidencias = Convert.ToInt32(accesoADatos.ejecutarAccionScalar());

                return incidencias;
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

        public int incidenciasResuelto(int id)
        {
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT COUNT(*) FROM Incidencia  WHERE asignado_id = @id AND estado_id = (SELECT id FROM Estado WHERE nombre = 'Resuelto')";

                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);

                int incidencias = Convert.ToInt32(accesoADatos.ejecutarAccionScalar());

                return incidencias;
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

        public int incidenciasCerrada(int id)
        {
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT COUNT(*) FROM Incidencia  WHERE asignado_id = @id AND estado_id = (SELECT id FROM Estado WHERE nombre = 'Cerrado')";

                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@id", id);

                int incidencias = Convert.ToInt32(accesoADatos.ejecutarAccionScalar());

                return incidencias;
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

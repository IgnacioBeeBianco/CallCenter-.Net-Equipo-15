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
        public void AddSurvey(Encuesta encuesta, long incidenciaId, int usuarioId)
        {
            try
            {
                accesoADatos.AbrirConexion();
                string consulta = "INSERT INTO Encuesta (incidencia_id, usuario_id, calificacion, comentario, estado) VALUES (@incidencia, @usuario, @calificacion, @comentario, @estado)";
                accesoADatos.setearParametro("@incidencia", incidenciaId);
                accesoADatos.setearParametro("@usuario", usuarioId);
                accesoADatos.setearParametro("calificacion", encuesta.Calificacion);
                if(encuesta.Comentario != null)
                {
                    accesoADatos.setearParametro("@comentario", encuesta.Comentario);
                }
                else
                {
                    accesoADatos.setearParametro("@comentario", DBNull.Value);
                }
                accesoADatos.setearParametro("@estado", 1);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }
            catch (Exception ex) 
            {
                throw ex;
            }finally 
            {
                accesoADatos.cerrarConexion();
            }
        }
        public void AddComment(Comentario comentario)
        {
            try
            {
                accesoADatos = new AccesoADatos();
                string consulta = "INSERT INTO ComentarioIncidencia (incidencia_id, usuario_id, fecha, texto, estado) VALUES (@idIncidencia, @usuarioId, @fecha, @texto, @estado)";
                accesoADatos.setearParametro("@idIncidencia", comentario.IncidenciaId);
                accesoADatos.setearParametro("@usuarioId", comentario.Usuario.Id);
                accesoADatos.setearParametro("@fecha", comentario.Fecha);
                accesoADatos.setearParametro("@texto", comentario.Texto);
                accesoADatos.setearParametro("@estado", 1);
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }catch (Exception ex)
            {
                throw ex;
            }finally 
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void ModifyOwner(int usuarioId, long incidenciaId)
        {
            try
            {
                accesoADatos = new AccesoADatos();
                string consulta = "UPDATE Incidencia SET asignado_id = @usuarioId WHERE id = @incidenciaId";
                accesoADatos.setearParametro("@usuarioId", usuarioId);
                accesoADatos.setearParametro("@incidenciaId", incidenciaId);
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
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

        public List<Incidencia> ListByEstado(string Nombre, int idUsuario)
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
                    "WHERE E.Nombre LIKE @Nombre AND U2.id = @idAsignado AND I.estado = 1 " + 
                    "ORDER BY P.nivelPrioridad desc";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.setearParametro("@idAsignado", idUsuario);
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
                    "WHERE E.Nombre LIKE @Nombre AND I.estado = 1 " +
                    "ORDER BY P.nivelPrioridad desc";
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

        public List<Incidencia> ListByEstadoxCliente(string Nombre, int idCuenta, int idUsuario)
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
                    "WHERE E.Nombre LIKE @Nombre AND U.id = @idCuenta AND U2.id = @idAsignado AND I.estado = 1 " +
                    "ORDER BY P.nivelPrioridad desc";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.setearParametro("@idCuenta", idCuenta);
                accesoADatos.setearParametro("@idAsignado", idUsuario);
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

        public List<Incidencia> ListByEstadoxCliente(string Nombre, int idCuenta)
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
                    "WHERE E.Nombre LIKE @Nombre AND U.id = @idCuenta AND I.estado = 1 " +
                    "ORDER BY P.nivelPrioridad desc";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.setearParametro("@idCuenta", idCuenta);
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
                accesoADatos.AbrirConexion();
                string consulta = "INSERT INTO Incidencia (creador_id, asignado_id, fecha_creacion, fecha_ultimo_cambio, estado_id, prioridad_id, tipo_incidencia_id, comentario_cierra, problematica, estado)" +
                    " VALUES (@creador_id, @asignado_id, @fechaCreacion, @fecha_ultimo_cambio, @estado_id, @prioridad_id, @tipo_incidencia_id, @comentario_cierra, @problematica, 1)";
                accesoADatos.setearParametro("@creador_id", incidencia.Creador.Id);
                accesoADatos.setearParametro("@asignado_id", incidencia.Asignado.Id);
                accesoADatos.setearParametro("@fechaCreacion", incidencia.FechaCreacion);
                accesoADatos.setearParametro("@fecha_ultimo_cambio", incidencia.FechaCierre);
                accesoADatos.setearParametro("@estado_id", incidencia.Estado.Id);
                accesoADatos.setearParametro("@prioridad_id", incidencia.Prioridad.Id);
                accesoADatos.setearParametro("@tipo_incidencia_id", incidencia.TipoIncidencia.id);
                accesoADatos.setearParametro("@comentario_cierra ", (object)incidencia.ComentarioCierre ?? DBNull.Value);
                accesoADatos.setearParametro("@problematica", incidencia.problematica);
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

        public void ModifyState(int estadoId, long incidenciaId)
        {
            try
            {
                accesoADatos = new AccesoADatos();
                string consulta = "UPDATE Incidencia SET estado_id = @estado_id WHERE id = @id";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@id", incidenciaId);
                accesoADatos.setearParametro("@estado_id", estadoId);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }catch(Exception ex) {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void Update(Incidencia newValue)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Incidencia SET creador_id = @creador_id, asignado_id = @asignado_id, fecha_creacion = @fecha_creacion, fecha_ultimo_cambio = @fecha_ultimo_cambio, " +
                    "estado_id = @estado_id, prioridad_id = @prioridad_id, tipo_incidencia_id = @tipo_incidencia_id, comentario_cierra = @comentario_cierre, problematica = @problematica, estado = 1 " +
                    " WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                //Setear todos los datos
                accesoADatos.setearParametro("@Id", newValue.Id);
                accesoADatos.setearParametro("@creador_id", newValue.Creador.Id);
                accesoADatos.setearParametro("@asignado_id", newValue.Asignado.Id);
                accesoADatos.setearParametro("@fecha_creacion", newValue.FechaCreacion.ToString());
                accesoADatos.setearParametro("@fecha_ultimo_cambio", newValue.FechaCierre.ToString());
                accesoADatos.setearParametro("@estado_id", newValue.Estado.Id);
                accesoADatos.setearParametro("@prioridad_id", newValue.Prioridad.Id);
                accesoADatos.setearParametro("@tipo_incidencia_id", newValue.TipoIncidencia.id);
                accesoADatos.setearParametro("@comentario_cierre", DBNull.Value);
                accesoADatos.setearParametro("@problematica", newValue.problematica);
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
                                    "WHERE U.id = @id OR U2.id = @id ORDER BY I.fecha_ultimo_cambio DESC";
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
    }
}

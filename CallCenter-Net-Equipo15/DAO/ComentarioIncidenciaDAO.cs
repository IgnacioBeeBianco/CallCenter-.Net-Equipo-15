using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ComentarioIncidenciaDAO
    {
        private AccesoADatos AccesoADatos;
        private List<Comentario> Comentarios = new List<Comentario>();

        private Comentario LoadComments(ref AccesoADatos accesoADatos)
        {
            Comentario comentario = new Comentario();
            comentario.Usuario = new Usuario();
            comentario.Fecha = DateTime.Parse(accesoADatos.Lector["fecha"].ToString());
            comentario.Id = (int)accesoADatos.Lector["id"];
            comentario.Usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
            comentario.Usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
            comentario.IncidenciaId = (int)accesoADatos.Lector["incidencia_id"];
            comentario.Texto = accesoADatos.Lector["texto"].ToString();
            comentario.Estado = bool.Parse(accesoADatos.Lector["estado"].ToString());
            return comentario;
        }
        public List<Comentario> GetComentarios(int incidenciaId)
        {
            try
            {
                AccesoADatos = new AccesoADatos();
                string consulta = "SELECT CI.id, CI.incidencia_id, CI.usuario_id, U.nombre, U.apellido, CI.fecha, CI.estado, CI.texto FROM ComentarioIncidencia CI " +
                    "INNER JOIN Usuario U ON U.id = usuario_id WHERE incidencia_id = @incidenciaId AND CI.estado = 1";
                AccesoADatos.AbrirConexion();
                AccesoADatos.setearParametro("@incidenciaId", incidenciaId);
                AccesoADatos.consultar(consulta);
                AccesoADatos.ejecutarLectura();

                while (AccesoADatos.Lector.Read())
                {
                    Comentario comentario = LoadComments(ref AccesoADatos);
                    if (comentario != null)
                    {
                        Comentarios.Add(comentario);
                    }

                }

                return Comentarios;
            }catch (Exception ex)
            {
                throw ex;
            }finally 
            {
                AccesoADatos.cerrarConexion();
            }
        }
    }
}

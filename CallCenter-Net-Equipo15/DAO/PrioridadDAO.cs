using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PrioridadDAO
    {

        private List<Prioridad> prioridades;
        private AccesoADatos accesoADatos;

        private Prioridad LoadTipoIncidencia(ref AccesoADatos accesoADatos)
        {
            Prioridad prioridad = new Prioridad();
            prioridad.Id = (int)accesoADatos.Lector["id"];
            prioridad.Nombre = accesoADatos.Lector["nombre"].ToString();
            prioridad.nivelPrioridad = (int)accesoADatos.Lector["nivelPrioridad"];
            prioridad.Estado = bool.Parse(accesoADatos.Lector["estado"].ToString());

            return prioridad;
        }

        public Prioridad getPrioridad(int Id)
        {
            accesoADatos = new AccesoADatos();
            Prioridad prioridad = new Prioridad();

            try
            {
                string consulta = "SELECT id, nombre, nivelPrioridad, estado FROM Prioridad WHERE Id = @Id and estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Id", Id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    prioridad = LoadTipoIncidencia(ref accesoADatos);
                }

                return prioridad;
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

        public Prioridad getPrioridad(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            Prioridad prioridad = new Prioridad();

            try
            {
                string consulta = "SELECT id, nombre, nivelPrioridad, estado FROM Prioridad WHERE Nombre LIKE @Nombre and estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    prioridad = LoadTipoIncidencia(ref accesoADatos);
                }

                return prioridad;
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

        public List<Prioridad> List()
        {
            accesoADatos = new AccesoADatos();
            prioridades = new List<Prioridad>();

            try
            {
                string consulta = "SELECT id, nombre, nivelPrioridad, estado FROM Prioridad where estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    prioridades.Add(LoadTipoIncidencia(ref accesoADatos));
                }

                return prioridades;
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

        public List<Prioridad> List(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            prioridades = new List<Prioridad>();

            try
            {
                string consulta = "SELECT id, nombre, nivelPrioridad, estado FROM Prioridad WHERE Nombre LIKE @Nombre and estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", "%" + Nombre + "%");
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    prioridades.Add(LoadTipoIncidencia(ref accesoADatos));
                }

                return prioridades;
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

        public void Create(Prioridad prioridad)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO Prioridad VALUES (@Nombre,@nivelPrioridad, 1)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", prioridad.Nombre);
                accesoADatos.setearParametro("@nivelPrioridad", prioridad.nivelPrioridad);
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

        public void Update(Prioridad prioridad, int id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Prioridad SET nombre = @Nombre, nivelPrioridad = @nivelPrioridad WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre",prioridad.Nombre);
                accesoADatos.setearParametro("@nivelPrioridad", prioridad.nivelPrioridad);
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

        public void Delete(int Id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consultar = "DELETE FROM Prioridad WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Id", Id);
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

        public int getPrioridadId(string Nombre)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT id FROM Prioridad WHERE Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                if (accesoADatos.Lector.Read())
                {
                    return Convert.ToInt32(accesoADatos.Lector["id"]);
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
            return -1;
        }
    }
}

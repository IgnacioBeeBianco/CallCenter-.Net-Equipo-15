using Dominio;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EstadoDAO
    {
        private List<Estado> estado;
        private AccesoADatos accesoADatos;

        private Estado LoadEstado(ref AccesoADatos accesoADatos)
        {
            Estado estado = new Estado();
            estado.Id = (int)accesoADatos.Lector["id"];
            estado.Nombre = accesoADatos.Lector["nombre"].ToString();
            estado.nivelEstado = (int)accesoADatos.Lector["nivelEstado"];
            estado.estado = (bool)accesoADatos.Lector["estado"];

            return estado;
        }

        public Estado getEstado(int Id)
        {
            accesoADatos = new AccesoADatos();
            Estado estado = new Estado();

            try
            {
                string consulta = "SELECT id, nombre, nivelEstado, estado FROM Estado WHERE Id = @Id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Id", Id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    estado = LoadEstado(ref accesoADatos);
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

        public Estado getEstado(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            Estado estado = new Estado();

            try
            {
                string consulta = "SELECT id, nombre, nivelEstado, estado FROM Estado WHERE Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    estado = LoadEstado(ref accesoADatos);
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

        public List<Estado> List()
        {
            accesoADatos = new AccesoADatos();
            estado = new List<Estado>();

            try
            {
                string consulta = "SELECT id, nombre, nivelEstado, estado FROM Estado WHERE estado = 1 ORDER BY nivelEstado desc ";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
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

        public List<Estado> List(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            estado = new List<Estado>();

            try
            {
                string consulta = "SELECT id, nombre, nivelEstado, estado FROM Estado WHERE Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", "%" + Nombre + "%");
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

        public void Create(Estado estado)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO Estado VALUES (@Nombre, @nivelEstado, 1)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", estado.Nombre);
                accesoADatos.setearParametro("@nivelEstado", estado.nivelEstado);
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

        public void Update(string nombre, int nivelEstado, int id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Estado SET nombre = @Nombre, nivelEstado=@nivelEstado WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", nombre);
                accesoADatos.setearParametro("@nivelEstado", nivelEstado);
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

        public bool Delete(int Id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("SP_VerificarUsoEstado");
                accesoADatos.setearParametro("@EstadoId", Id);
                accesoADatos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public int getEstadoId(string Nombre)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT id FROM Estado WHERE Nombre LIKE @Nombre";
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

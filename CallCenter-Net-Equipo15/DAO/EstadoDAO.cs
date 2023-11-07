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

            return estado;
        }

        public Estado getEstado(int Id)
        {
            accesoADatos = new AccesoADatos();
            Estado estado = new Estado();

            try
            {
                string consulta = "SELECT id, nombre FROM Estado WHERE Id = @Id";
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
                string consulta = "SELECT id, nombre FROM Estado WHERE Nombre LIKE @Nombre";
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
                string consulta = "SELECT id, nombre FROM Estado";
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
                string consulta = "SELECT id, nombre FROM Estado WHERE Nombre LIKE @Nombre";
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
                string consulta = "INSERT INTO Estado VALUES (@Nombre)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", estado.Nombre);
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

        public void Update(string nombre, int id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Estado SET nombre = @Nombre WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", nombre);
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
                string consultar = "DELETE FROM Estado WHERE Id = @Id";

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
    }
}

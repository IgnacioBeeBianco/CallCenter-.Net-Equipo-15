using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioDAO
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private AccesoADatos accesoADatos = new AccesoADatos();

        public List<Usuario> GetUsuarios()
        {
            try
            {
                string consulta = "SELECT id, nombre, apellido, dni, domicilio, telefono FROM Usuario";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)accesoADatos.Lector["id"];
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.DNI = accesoADatos.Lector["dni"].ToString();
                    usuario.Domicilio = accesoADatos.Lector["domicilio"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();

                    usuarios.Add(usuario);
                }
                return usuarios;
            }catch (Exception ex)
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
            try
            {
                if (id == 0)
                {
                    string consulta = "DELETE FROM Usuarios WHERE id = @id";
                    accesoADatos.setearParametro("@id", id);
                    accesoADatos.AbrirConexion();
                    accesoADatos.consultar(consulta);
                    accesoADatos.ejecutarAccionScalar();

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
            
        }

        public Usuario GetUsuario(int id)
        {
            try
            {
                string consulta = "SELECT id, nombre, apellido, dni, domicilio, telefono FROM Usuarios WHERE id = @id";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@id", id);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();
                Usuario usuario = new Usuario();


                while (accesoADatos.Lector.Read())
                {
                    usuario.Id = (int)accesoADatos.Lector["id"];
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.DNI = accesoADatos.Lector["dni"].ToString();
                    usuario.Domicilio = accesoADatos.Lector["domicilio"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();

                }
                return usuario;
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

        public void Create(Cuenta cuenta, Usuario usuario)
        {
            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("SP_CrearUsuario");
                accesoADatos.setearParametro("@nombre", usuario.Nombre);
                accesoADatos.setearParametro("@apellido", usuario.Apellido);
                accesoADatos.setearParametro("@dni", usuario.DNI);
                accesoADatos.setearParametro("@domicilio", usuario.Domicilio);
                accesoADatos.setearParametro("@telefono", usuario.Telefono);
                accesoADatos.setearParametro("@genero", usuario.Genero);
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password_", cuenta.Password);
                accesoADatos.setearParametro("@id_rol", cuenta.Rol.Id);
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

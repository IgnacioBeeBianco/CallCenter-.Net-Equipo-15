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
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string consulta = "SELECT id, nombre, apellido, dni, domicilio, telefono, estado FROM Usuario WHERE estado = 1";
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
                    usuario.Estado = (bool)accesoADatos.Lector["estado"];

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

        public bool Delete(int id)
        {
            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("SP_VerificarUsoUsuario");
                accesoADatos.setearParametro("@UsuarioId", id);
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

        public Usuario GetUsuario(int id)
        {
            try
            {
                string consulta = "SELECT U.id, U.nombre, U.apellido, U.dni, U.domicilio, U.telefono, U.genero, C.email, C.password_, id_rol FROM Usuario U INNER JOIN Cuenta C ON C.id = U.cuenta_id  WHERE U.id = @id";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@id", id);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();
                Usuario usuario = new Usuario
                {
                    CuentaId = new Cuenta(), 
                };
                usuario.CuentaId.Rol = new Rol();


                while (accesoADatos.Lector.Read())
                {
                    usuario.Id = (int)accesoADatos.Lector["id"];
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.DNI = accesoADatos.Lector["dni"].ToString();
                    usuario.Domicilio = accesoADatos.Lector["domicilio"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();
                    usuario.Genero = Convert.ToChar(accesoADatos.Lector["genero"]);
                    usuario.CuentaId.Email = accesoADatos.Lector["email"].ToString();
                    usuario.CuentaId.Password = accesoADatos.Lector["password_"].ToString();
                    usuario.CuentaId.Rol.Id = (int)accesoADatos.Lector["id_rol"];

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

        public void Update(Usuario usuario)
        {
            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("SP_ModificarUsuario");
                accesoADatos.setearParametro("@id", usuario.Id);
                accesoADatos.setearParametro("@nombre", usuario.Nombre);
                accesoADatos.setearParametro("@apellido", usuario.Apellido);
                accesoADatos.setearParametro("@dni", usuario.DNI);
                accesoADatos.setearParametro("@domicilio", usuario.Domicilio);
                accesoADatos.setearParametro("@telefono", usuario.Telefono);
                accesoADatos.setearParametro("@genero", usuario.Genero);
                accesoADatos.setearParametro("@email", usuario.CuentaId.Email);
                accesoADatos.setearParametro("@password_", usuario.CuentaId.Password);
                accesoADatos.setearParametro("@id_rol", usuario.CuentaId.Rol.Id);
                accesoADatos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public List<Usuario> GetUsuariosClientes()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string consulta = "SELECT U.id, U.nombre, U.apellido, U.dni, U.telefono, C.id_rol, R.nombre FROM Usuario U INNER JOIN Cuenta C ON C.id = U.cuenta_id INNER JOIN Rol R ON R.id = C.id_rol WHERE R.nombre = 'Cliente' AND u.estado = 1";
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
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();

                    usuario.CuentaId = new Cuenta();
                    usuario.CuentaId.Rol = new Rol();
                    usuario.CuentaId.Rol.Nombre = accesoADatos.Lector["nombre"].ToString();
                    //usuario.Estado = (bool)accesoADatos.Lector["estado"];

                    usuarios.Add(usuario);
                }
                return usuarios;
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

        public List<Usuario> GetUsuariosClientesConIncidencias(int idAsignado)
        {
            try
            {
                string consulta = "SELECT U.id, U.nombre, U.apellido, U.dni, U.telefono, C.id_rol, R.nombre " +
                    "FROM Usuario U INNER JOIN Cuenta C ON C.id = U.cuenta_id " +
                    "INNER JOIN Rol R ON R.id = C.id_rol " +
                    "WHERE R.nombre = 'Cliente' AND (" +
                    "SELECT Count(*) FROM Incidencia as I " +
                    "WHERE I.creador_id = U.cuenta_id AND I.asignado_id = @idAsignado) > 0";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@idAsignado", idAsignado);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)accesoADatos.Lector["id"];
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.DNI = accesoADatos.Lector["dni"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();

                    usuario.CuentaId = new Cuenta();
                    usuario.CuentaId.Rol = new Rol();
                    usuario.CuentaId.Rol.Nombre = accesoADatos.Lector["nombre"].ToString();
                    //usuario.Estado = (bool)accesoADatos.Lector["estado"];

                    usuarios.Add(usuario);
                }
                return usuarios;
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

        public List<Usuario> GetUsuariosDistintosClientes()
        {
            try
            {
                string consulta = "SELECT U.id, U.nombre, U.apellido, U.dni, U.telefono, U.estado, C.id_rol, R.nombre FROM Usuario U INNER JOIN Cuenta C ON C.id = U.cuenta_id INNER JOIN Rol R ON R.id = C.id_rol WHERE R.nombre != 'Cliente' and u.estado=1";
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
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();
                    usuario.Estado = (bool)accesoADatos.Lector["estado"];

                    usuario.CuentaId = new Cuenta();
                    usuario.CuentaId.Rol = new Rol();
                    usuario.CuentaId.Rol.Nombre = accesoADatos.Lector["nombre"].ToString();

                    usuarios.Add(usuario);
                }
                return usuarios;
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

        public int getUsuarioId(string Nombre)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "SELECT id FROM Usuario WHERE Nombre LIKE @Nombre";
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

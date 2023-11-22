using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CuentaDAO
    {
        private AccesoADatos accesoADatos = new AccesoADatos();
        public Usuario Login(Cuenta cuenta)
        {
            try
            {
                Usuario usuario = new Usuario();

                string consulta = "SELECT U.id, U.nombre, U.apellido, U.dni, U.domicilio, U.telefono, U.genero, C.id, C.email, C.password_, C.id_rol, R.nombre as nombre_rol " +
                                        "FROM Cuenta C " +
                                        "INNER JOIN Usuario U ON U.cuenta_id = C.id " +
                                        "INNER JOIN Rol R ON R.id = C.id_rol " +
                                        "WHERE email = @email AND password_ = @password";
                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password", cuenta.Password);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    usuario.Id = (int)accesoADatos.Lector["id"];
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.DNI = accesoADatos.Lector["dni"].ToString();
                    usuario.Domicilio = accesoADatos.Lector["domicilio"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();
                    string genero = accesoADatos.Lector["genero"].ToString();
                    usuario.Genero = !string.IsNullOrEmpty(genero) ? genero[0] : '\0';
                    cuenta.Id = (int)accesoADatos.Lector["id"];
                    cuenta.Rol.Id = (int)accesoADatos.Lector["id_rol"];
                    cuenta.Rol.Nombre = accesoADatos.Lector["nombre_rol"].ToString();
                }

                if(usuario.Nombre != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                };
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

        public void crearNuevaCuentaCliente(Cuenta nuevo, Usuario cliente)
        {
            AccesoADatos accesoADatos = new AccesoADatos();
            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("InsertarClienteYAsociarCuenta");
                accesoADatos.setearParametro("@nombre", cliente.Nombre);
                accesoADatos.setearParametro("@apellido", cliente.Apellido);
                accesoADatos.setearParametro("@dni", cliente.DNI);
                accesoADatos.setearParametro("@domicilio", cliente.Domicilio);
                accesoADatos.setearParametro("@telefono", cliente.Telefono);
                accesoADatos.setearParametro("@genero", cliente.Genero);
                accesoADatos.setearParametro("@email", nuevo.Email);
                accesoADatos.setearParametro("@password_", nuevo.Password);
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

        public Cuenta GetCuenta(int id)
        {
            try {
                accesoADatos.AbrirConexion();
                string consulta = "SELECT C.id, C.email, C.password_, C.id_rol FROM Cuenta C INNER JOIN Rol R ON R.id = C.id_rol WHERE id = @id";
                accesoADatos.setearParametro("@id", id);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                Cuenta cuenta = new Cuenta
                {
                    Rol = new Rol()
                };

                while (accesoADatos.Lector.Read())
                {
                    cuenta.Id = (int)accesoADatos.Lector["id"];
                    cuenta.Email = accesoADatos.Lector["email"].ToString();
                    cuenta.Password = accesoADatos.Lector["password_"].ToString();
                    cuenta.Rol.Id = (int)accesoADatos.Lector["id_rol"];
                    cuenta.Rol.Nombre = accesoADatos.Lector["nombre_rol"].ToString();
                }

                return cuenta;
            
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void Update(Cuenta cuenta)
        {
            try
            {
                accesoADatos.AbrirConexion();
                string consulta = "UPDATE Cuenta SET email = @email, password_ = @password WHERE id = @id";
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password", cuenta.Password);
                accesoADatos.setearParametro("@id", cuenta.Id);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public void UpdatePassword(Cuenta cuenta)
        {
            try
            {
                accesoADatos.AbrirConexion();
                string consulta = "UPDATE Cuenta SET password_ = @password_ WHERE email = @email";
                accesoADatos.setearParametro("@email", cuenta.Email);
                accesoADatos.setearParametro("@password_", cuenta.Password);
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarAccion();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

        public bool getCuentaMail(Cuenta cuenta)
        {
            try
            {
                accesoADatos.AbrirConexion();
                string consulta = "SELECT COUNT(*) FROM Cuenta WHERE email = @mail";
                accesoADatos.setearParametro("@mail", cuenta.Email);
                accesoADatos.consultar(consulta);

                int count = accesoADatos.ejecutarAccionScalar();
                return count > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

    }
}

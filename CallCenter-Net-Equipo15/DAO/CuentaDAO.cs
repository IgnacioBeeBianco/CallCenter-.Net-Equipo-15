﻿using Dominio;
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

                string consulta = "SELECT U.nombre, U.apellido, U.domicilio, U.telefono, C.email, C.password_, C.id_rol, R.nombre as nombre_rol " +
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
                    usuario.Nombre = accesoADatos.Lector["nombre"].ToString();
                    usuario.Apellido = accesoADatos.Lector["apellido"].ToString();
                    usuario.Domicilio = accesoADatos.Lector["domicilio"].ToString();
                    usuario.Telefono = accesoADatos.Lector["telefono"].ToString();
                    cuenta.Rol.Id = (int)accesoADatos.Lector["id_rol"];
                    cuenta.Rol.Nombre = accesoADatos.Lector["nombre_rol"].ToString();
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
    }
}
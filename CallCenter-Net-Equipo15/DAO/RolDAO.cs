﻿using Dominio;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RolDAO
    {
        private List<Rol> rol;
        private AccesoADatos accesoADatos;

        private Rol LoadRol(ref AccesoADatos accesoADatos)
        {
            Rol rol = new Rol();
            rol.Id = (int)accesoADatos.Lector["id"];
            rol.Nombre = accesoADatos.Lector["nombre"].ToString();
            rol.Estado = bool.Parse(accesoADatos.Lector["estado"].ToString());

            return rol;
        }

        public Rol getRol(int Id)
        {
            accesoADatos = new AccesoADatos();
            Rol rol = new Rol();

            try
            {
                string consulta = "SELECT id, nombre, estado FROM Rol WHERE id = @Id";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Id", Id);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    rol = LoadRol(ref accesoADatos);
                }

                return rol;
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

        public Rol getRol(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            Rol rol = new Rol();

            try
            {
                string consulta = "SELECT id, nombre, estado FROM Rol WHERE Nombre LIKE @Nombre AND estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", Nombre);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    rol = LoadRol(ref accesoADatos);
                }

                return rol;
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

        public List<Rol> List()
        {
            accesoADatos = new AccesoADatos();
            rol = new List<Rol>();

            try
            {
                string consulta = "SELECT id, nombre, estado FROM Rol WHERE estado = 1";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    rol.Add(LoadRol(ref accesoADatos));
                }

                return rol;
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

        public List<Rol> List(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            rol = new List<Rol>();

            try
            {
                string consulta = "SELECT id, nombre, estado FROM Rol WHERE Nombre LIKE @Nombre";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", "%" + Nombre + "%");
                accesoADatos.ejecutarLectura();

                while (accesoADatos.Lector.Read())
                {
                    rol.Add(LoadRol(ref accesoADatos));
                }

                return rol;
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

        public void Create(Rol rol)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO Rol VALUES (@Nombre, 1)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", rol.Nombre);
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
                string consulta = "UPDATE Rol SET nombre = @Nombre WHERE Id = @Id";

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

        public bool Delete(int Id)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                accesoADatos.AbrirConexion();
                accesoADatos.setearProcedimiento("SP_VerificarUsoRol");
                accesoADatos.setearParametro("@RolId", Id);
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
    }
}
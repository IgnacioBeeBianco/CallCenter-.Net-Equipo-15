﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PrioridadDAO : DAO
    {

        private List<Prioridad> prioridades;

        public override DAO LoadTipoIncidencia(ref AccesoADatos accesoADatos)
        {
            Prioridad prioridad = new Prioridad();
            prioridad.Id = (long)accesoADatos.Lector["id"];
            prioridad.Nombre = accesoADatos.Lector["nombre"].ToString();

            return prioridad;
        }

        public override DAO getPrioridad(long Id)
        {
            accesoADatos = new AccesoADatos();
            Prioridad prioridad = new Prioridad();

            try
            {
                string consulta = "SELECT id, nombre FROM Prioridad WHERE Id = @Id";
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

        public override DAO getPrioridad(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            Prioridad prioridad = new Prioridad();

            try
            {
                string consulta = "SELECT id, nombre FROM Prioridad WHERE Nombre LIKE @Nombre";
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

        public override List<DAO> List()
        {
            accesoADatos = new AccesoADatos();
            prioridades = new List<Prioridad>();

            try
            {
                string consulta = "SELECT id, nombre FROM Prioridad";
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

        public override List<DAO> List(string Nombre)
        {
            accesoADatos = new AccesoADatos();
            prioridades = new List<Prioridad>();

            try
            {
                string consulta = "SELECT id, nombre FROM Prioridad WHERE Nombre LIKE @Nombre";
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

        public override void Create(Prioridad prioridad)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "INSERT INTO Prioridad(nombre) VALUES (@Nombre)";
                accesoADatos.AbrirConexion();
                accesoADatos.consultar(consulta);
                accesoADatos.setearParametro("@Nombre", prioridad.Nombre);
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

        public override void Update(Prioridad prioridad)
        {
            accesoADatos = new AccesoADatos();

            try
            {
                string consulta = "UPDATE Prioridad SET nombre = @Nombre WHERE Id = @Id";

                accesoADatos.AbrirConexion();
                accesoADatos.setearParametro("@Nombre", prioridad.Nombre);
                accesoADatos.setearParametro("@Id", prioridad.Id);
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

        public override void Delete(long Id)
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
    }
}

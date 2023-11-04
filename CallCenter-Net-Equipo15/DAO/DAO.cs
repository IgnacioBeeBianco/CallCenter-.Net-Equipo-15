using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public abstract class DAO
    {
        protected AccesoADatos accesoADatos;
        public abstract DAO LoadTipoIncidencia(ref AccesoADatos accesoADatos);

        public abstract DAO getPrioridad(long Id);

        public abstract DAO getPrioridad(string Nombre);

        public abstract List<DAO> List();

        public abstract List<DAO> List(string Nombre);

        public abstract void Create(Prioridad prioridad);

        public abstract void Update(Prioridad prioridad);

        public abstract void Delete(long Id);
    }
}

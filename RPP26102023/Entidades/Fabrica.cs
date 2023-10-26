using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabrica
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        /// <summary>
        /// Propiedad de lectura para la lista de vehiculos
        /// </summary>
        public List<Vehiculo> Vehiculos 
        { 
            get { return this.vehiculos; } 
        }

        private Fabrica()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        public Fabrica(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }

        public static Fabrica operator +(Fabrica f, Vehiculo v)
        {
            if (f.vehiculos.Count < f.capacidad)
            {
                f.vehiculos.Add(v);
            }

            return f;
        }

        public static Fabrica operator -(Fabrica f, Vehiculo v)
        {
            foreach (Vehiculo item in f.vehiculos)
            {
                if (item == v)
                {
                    f.vehiculos.Remove(v);
                }
            }
            return f;
        }
    }
}

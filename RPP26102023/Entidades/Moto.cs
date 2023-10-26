using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor de la clase Moto
        /// </summary>
        /// <param name="propulsion">Recibe el tipo de propulsion</param>
        public Moto(EPropulsion propulsion) 
            : base(propulsion)
        {
        }

        /// <summary>
        /// Propiedad de solo lectura 
        /// </summary>
        protected override string Tipo
        {
            get
            {
                return "Moto";
            }
        }
    }
}

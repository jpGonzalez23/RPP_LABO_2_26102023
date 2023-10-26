using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Constructor de la clase Automovil
        /// </summary>
        public Automovil() 
            : base(EPropulsion.Hibrida)
        {
        }

        /// <summary>
        /// Propiedad de solo lectura 
        /// </summary>
        protected override string Tipo
        {
            get
            {
                return "Automovil";
            }
        }
    }
}

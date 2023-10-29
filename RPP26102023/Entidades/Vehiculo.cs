using System.Text;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected bool esAWD;
        protected Guid numeroChasis;
        protected EPropulsion propulsion;

        /// <summary>
        /// Constructor de la clase base
        /// </summary>
        /// <param name="propulsion">Recibe el tipo de propulsion</param>
        protected Vehiculo(EPropulsion propulsion) 
            : this(propulsion, false)
        {
            
        }

        /// <summary>
        /// Sobrecarga del constructor
        /// </summary>
        /// <param name="propulsion">Recibe el tipo de propulsion</param>
        /// <param name="esAWD">Recibe si es AWD</param>
        protected Vehiculo(EPropulsion propulsion, bool esAWD)
        {
            this.esAWD = esAWD;
            this.propulsion = propulsion;
            this.numeroChasis = Guid.NewGuid();
        }

        /// <summary>
        /// Propiedad de solo lectura
        /// </summary>
        public EPropulsion Propulsion { get { return this.propulsion; } }

        /// <summary>
        /// Propiedad de solo lectura, debe ser implementada en las clase derivadas
        /// </summary>
        protected abstract string Tipo { get; }

        /// <summary>
        /// Metodo para mostrar la informacion del vehiculo
        /// </summary>
        /// <returns>Retorna una cadena de string</returns>
        protected virtual string GetInfor()
        {
            //StringBuilder sb = new StringBuilder();

            return string.Format($"{this.Tipo}, con propulsion a {this.Propulsion}, {(this.esAWD ? "es 4x4" : "no es 4x4")}, numero de chasis {this.numeroChasis}");

            //sb.appendline($"{this.tipo}");
            //sb.appendline($"con propulsión a {this.propulsion}");

            //if (this.esawd)
            //{
            //    sb.appendline("es awd,");
            //}
            //else
            //{
            //    sb.appendline("no es awd,");
            //}

            //sb.appendline($"numero de chasis {this.numerochasis}");

            //return sb.tostring();
        }

        /// <summary>
        /// Permite mostrar el metodo GetInfo 
        /// </summary>
        /// <returns>Retorna una cadena de string</returns>
        public override string ToString()
        {
            return this.GetInfor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1 is not null && v2 is not null)
            {
                return v1.GetType() == v2.GetType() && v1.numeroChasis == v2.numeroChasis;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del metodo ==
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
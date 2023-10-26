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
            this.propulsion = propulsion;
        }

        /// <summary>
        /// Sobrecarga del constructor
        /// </summary>
        /// <param name="propulsion">Recibe el tipo de propulsion</param>
        /// <param name="esAWD">Recibe si es AWD</param>
        protected Vehiculo(EPropulsion propulsion, bool esAWD)
        {
            this.esAWD = esAWD;
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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Tipo}");
            sb.AppendLine($"con propulsión a {this.Propulsion}");

            if (this.esAWD)
            {
                sb.AppendLine("Es AWD,");
            }
            else
            {
                sb.AppendLine("No es AWD,");
            }

            sb.AppendLine($"numero de chasis {this.numeroChasis}");

            return sb.ToString();
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
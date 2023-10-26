using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        private bool cabinaSimple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propulsion"></param>
        /// <param name="cabinaSimple"></param>
        public Camioneta(EPropulsion propulsion, bool cabinaSimple) 
            : base(propulsion, true)
        {
            this.cabinaSimple = cabinaSimple;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string Tipo
        {
            get
            {
                return "Camioneta";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetInfor()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.GetInfor()}");
            sb.AppendLine($"con cabina ");

            if (this.cabinaSimple)
            {
                sb.Append(" simple");
            }
            else
            {
                sb.Append(" doble");
            }

            return sb.ToString();
        }
    }
}

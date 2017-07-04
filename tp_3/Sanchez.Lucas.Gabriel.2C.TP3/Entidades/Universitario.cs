using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        protected int _legajo;

        #region Métodos

        /// <summary>
        /// Un objeto es igual a Universitario si el objeto es del mismo tipo que Universitario y llama al operador == de Universitario.
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool aux = false;

            if (obj.GetType() == this.GetType())
            {
                aux = (this == ((Universitario)obj));
            }

            return aux;
        }

        /// <summary>
        /// Devuelve un string con todos los datos de un Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this._legajo);

            return sb.ToString();
        }


        /// <summary>
        /// Método abstracto que retorna un string.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores

        /// <summary>
        /// Un universitario es distinto a otro si no comparten DNI ni legajo.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Un Universitario es igual a otro si comparten el mismo DNI ó el mismo legajo.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool aux = false;

            if ((pg1.DNI == pg2.DNI) || (pg1._legajo == pg2._legajo))
                aux = true;

            return aux;
        } 
        #endregion

        #region Constructores
        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        } 
        #endregion
    }
}

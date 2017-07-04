using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        } 
        #endregion

        #region Métodos
        /// <summary>
        /// Devuelve un string con los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            if (this._estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            else
                sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string informando la clase que el alumno toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma;
        }

        /// <summary>
        /// Hace visible los datos del alumno devolviendo el método MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        
        /// <summary>
        /// Un alumno es distinto a una clase si no la toma.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            //si el alumno no toma la clase, ya es distinto a la clase.
            return !(a == clase);
        }

        /// <summary>
        /// Devuelve true si el alumno toma la clase y si su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                aux = true;
            }

            return aux;
        } 
        #endregion

        public enum EEstadoCuenta { AlDia, Becado, Deudor }
    }
}

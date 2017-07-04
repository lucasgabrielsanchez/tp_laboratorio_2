using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Métodos
        /// <summary>
        /// Selecciona aleatoriamente 2 elementos del enumerado Universidad.Eclases.
        /// El enumerado EClases consta de 4 elementos. Los cuales por default y de forma implícita tienen un índice entero de 0, 1, 2 y 3. Por ende para que las clases se elijan
        /// de forma aleatoria, al random le doy un valor entre 0 y 4, ya que el valor minimo de este método es INCLUSIVO PERO el valor máximo es EXCLUSIVO.
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 4)));
            this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 4)));
        }

        /// <summary>
        /// Devuelve un string todos los datos del Profesor.
        /// </summary>
        /// <returns></returns>      
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con las clases del día que dá el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DíA:");
            //el método ElementAtOrDefault es parecido al método ElementAt, con la diferencia de que si le pasamos un índice que no existe en la cola,
            //elige el predeterminado, de esta manera evitamos que el programa pinche por buscar un valor fuera de rango. A diferencia del método Dequeue, el
            //método mencionado, trae un elemento de la cola sin quitarlo de la misma.
            sb.AppendLine(this._clasesDelDia.ElementAtOrDefault(0).ToString());
            sb.AppendLine(this._clasesDelDia.ElementAtOrDefault(1).ToString());

            return sb.ToString();

        }

        /// <summary>
        /// Hace visibles los datos del Profesor devolviendo un string compuestos por el retorno de MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool aux = false;

            if (i._clasesDelDia.Contains(clase)) //El método Contains determina si existe en la cola el elemento que le pasamos por parámetro.
                aux = true;

            return aux;
        } 
        #endregion

        #region Constructores
        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this()
        {
            //codeado nuevamente debido a la necesidad de invocar al constructor por default de esta misma clase.
            this._legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDni = dni;
            this.Nacionalidad = nacionalidad;
        } 
        #endregion

    }
}

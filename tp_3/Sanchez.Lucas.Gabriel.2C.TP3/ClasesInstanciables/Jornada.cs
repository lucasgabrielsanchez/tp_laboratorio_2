using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        } 
        #endregion

        #region Métodos

        /// <summary>
        /// Guarda en un archivo de texto, los datos de una jornada en formato string. Devuelve true si pudo guardarlo, caso contrario, lanza excepción.
        /// </summary>
        /// <param name="jornada">jornada a guardar en el archivo.</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            //no es necesario un try/cath ya que se valida dentro de la clase Texto.
            Texto txt = new Texto();
            //Pasándole sólo el nombre del archivo, por default se guarda en el path que devuelve: AppDomain.CurrentDomain.BaseDirectory.
            txt.guardar("Jornada.txt", jornada.ToString());

            return true;
        }

        /// <summary>
        /// Lee de un archivo de texto de una jornada y devuelve un string con los datos leídos.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            //no es necesario un try/cath ya que se valida dentro de la clase Texto.
            string aux;

            Texto txt = new Texto();
            //Pasándole sólo el nombre del archivo, por default se lee en el path que devuelve: AppDomain.CurrentDomain.BaseDirectory.
            txt.leer("Jornada.txt", out aux);

            return aux;
        }

        /// <summary>
        /// devuelve un string con todos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase, this._instructor);

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno al in this._alumnos)
            {
                sb.AppendFormat(al.ToString());
            }
            sb.AppendLine("<--------------------------------------------------->");
            return sb.ToString();
        }
        
        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        } 
        #endregion

        #region Operadores

        /// <summary>
        /// Un Alumno y una Jornada son distintos si éste no pertenece a la misma.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Un Alumno podrá agregarse a la Jornada si éste no pertenece a la misma.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Un Alumno y una Jornada son iguales si éste pertenece a la misma.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool aux = false;

            foreach (Alumno al in j._alumnos)
            {
                if (al.Equals(a))
                    aux = true;
                break;
            }

            return aux;
        } 
        #endregion

    }
}
